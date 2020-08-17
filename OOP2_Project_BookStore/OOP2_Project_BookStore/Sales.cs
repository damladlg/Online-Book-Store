using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Db;
using System.Text.RegularExpressions;
using System.Diagnostics;
namespace OOP2_Project_BookStore
{
    public partial class Sales : Form
    {
        public Sales()
        {
            InitializeComponent();
        }
        bool CCCheck = false;
        LoginedCustomer LC = LoginedCustomer.Singleton();
        DatabaseOperations Db = new DatabaseOperations("db_BookStore");
        private void Sales_Load(object sender, EventArgs e)
        {
            cmbx_PTCCMounth.DataSource = new string[] {"01","02","03","04","05","06","07","08","09","10","11","12" };
            cmbx_PTCCYear.DataSource = new string[] { "2020", "2021", "2022", "2023", "2024", "2025", "2026", "2027", "2028", "2029", "2030" };

            cmbx_paymentType.DataSource = Db.Select("select id,Type_Name from tbl_paymentType");
            cmbx_paymentType.DisplayMember = "Type_Name";
            cmbx_paymentType.ValueMember = "id";

            pnl_paymentTypeCash.Visible = true;
            pnl_paymentTypeCC.Visible = false;

            chbx_ChoiceDef.Checked = true;
            txt_defAddress.Text = LC.User.Address;
            lbl_PTotal.Text = "Ürün toplamı\n" + LC.ShopCard.GetPaymentAmount();
            lbl_totalPeyment.Text = "Toplam Ödenecek Tutar\n" +( LC.ShopCard.GetPaymentAmount() + 6).ToString();
            chbx_mail.Checked = true;
        }

        private void cmbx_paymentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbx_paymentType.Text == "Nakit")
            {
                pnl_paymentTypeCash.Visible = true;
                pnl_paymentTypeCC.Visible = false;
            }
            else
            {
                pnl_paymentTypeCash.Visible = false;
                pnl_paymentTypeCC.Visible = true;
            }
        }

        private void checkCardNumber()
        {
            try
            {
                lbl_cardType.Text = "";
                picbx_creditcard.Image = null;
                Regex visaRegex = new Regex("^4[0-9]{12}(?:[0-9]{3})?$");
                Regex masterRegex = new Regex("^5[1-5][0-9]{14}$");
                Regex expressRegex = new Regex("^3[47][0-9]{13}$");
                CCCheck = true;
                if (visaRegex.IsMatch(txt_ccNumber.Text))
                    picbx_creditcard.Image = imglst_CreditCard.Images[0];
                else if (masterRegex.IsMatch(txt_ccNumber.Text))
                    picbx_creditcard.Image = imglst_CreditCard.Images[1];
                else if (expressRegex.IsMatch(txt_ccNumber.Text))
                    picbx_creditcard.Image = imglst_CreditCard.Images[2];
            }
            catch
            {
                lbl_cardType.Text = "Kart bilgileri yanlış\nyada\neksik";
                CCCheck = false;
            }
        }
        
        private void txt_ccNumber_TextChanged(object sender, EventArgs e)
        {
            if(txt_ccNumber.Text.Length>=15)
            {
                checkCardNumber();
            }
        }

        private void btn_addressAdd_Click(object sender, EventArgs e)
        {

            Logger.logger(this.Name + "-" + "Address Add", EventLogEntryType.Information);
            pnl_newAddress.Visible = true;
            chbx_choiceNew.Checked = true;
            btn_addressAdd.Enabled = false;
        }

        private void btn_addressDel_Click(object sender, EventArgs e)
        {
            Logger.logger(this.Name + "-" + "Address Delete", EventLogEntryType.Information);
            pnl_newAddress.Visible = false;
            txt_newAddress.Text = "";
            chbx_ChoiceDef.Checked = true;
            btn_addressAdd.Enabled = true;
        }

        bool placeOrder = false;
        private void btn_placeOrder_Click(object sender, EventArgs e)
        {
            Logger.logger(this.Name + "-" + "Place Order", EventLogEntryType.Information);
            string address="";
            if (chbx_ChoiceDef.Checked)
            {
                if (txt_defAddress.Text == "")
                {
                    MessageBox.Show("Profilden adresinizi ekleyiniz yada yeni adres ekleyerek devam ediniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                address = txt_defAddress.Text;
            }
            else
            {
                if (txt_newAddress.Text == "")
                {
                    MessageBox.Show("Yeni adresinizi boş bırakmayınız.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                address = txt_newAddress.Text;
            }
            if (pnl_paymentTypeCC.Visible)
            {
                if (!CCCheck)
                    return;
                if (txt_CCname.Text == "" || txt_ccNumber.Text == "" || txt_CCcvs.Text == "")
                {
                    MessageBox.Show("Kart bilgilerinizi boş bırakmayınız.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                DateTime date = DateTime.Now;
                if (date.Year == int.Parse(cmbx_PTCCYear.Text))
                {
                    if (date.Month > int.Parse(cmbx_PTCCMounth.Text))
                    {
                        MessageBox.Show("Son kullanma tarihi yanlış.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }
            LC.ShopCard.PaymentType = int.Parse(cmbx_paymentType.SelectedValue.ToString());
            
            string tempAmount = (LC.ShopCard.GetPaymentAmount()+6).ToString();
            tempAmount = tempAmount.Replace(",", ".");
            
            
            if (LC.ShopCard.SellingId <= 0)
            {
                LC.ShopCard.SellingId = Convert.ToInt32(Db.I(@"insert into tbl_selling (User_ID,Amount,Payment_Type_ID,Statu,Address) 
                        values(" + LC.User.Customer_Id + "," + tempAmount + "," + cmbx_paymentType.SelectedValue + ",1,'" + address + "')"));
            }
            else
            {
                DataTable dt = Db.Select("select User_ID,Amount,Payment_Type_ID,Statu,Address from tbl_selling where id="+LC.ShopCard.SellingId);
                string temp = "Update tbl_selling set ";
                bool check = false;
                if (dt.Rows[0][1].ToString() != LC.ShopCard.GetPaymentAmount().ToString())
                {
                    check = true;
                    temp += "Amount=" + tempAmount;
                }
                if (dt.Rows[0][2].ToString() != cmbx_paymentType.SelectedValue.ToString())
                {
                    if (check)
                    {
                        temp += ", ";
                    }
                    check = true;
                    temp += "Payment_Type_ID=" + cmbx_paymentType.SelectedValue;
                }
                if (dt.Rows[0][3].ToString() != "1")
                {
                    if (check)
                    {
                        temp += ", ";
                    }
                    check = true;
                    temp += "Statu=1";
                }
                if (dt.Rows[0][4].ToString() != address)
                {
                    if (check)
                    {
                        temp += ", ";
                    }
                    temp += "Address=" + address;
                }
                temp += " where id=" + LC.ShopCard.SellingId;
                Db.UD(temp);
            }

            if (LC.ShopCard.SellingId > 0)
            {
                if (DialogResult.No == MessageBox.Show("Emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {
                    btn_cancelOrder_Click(null,null);
                }
                LC.ShopCard.PlaceOrder(LC.User,chbx_mail.Checked,chbx_phone.Checked, txt_newAddress.Text, txt_phoneNumber.Text);
                placeOrder = true;
                MessageBox.Show("Alışverişte bizi tercih ettiğiniz için teşekkür ederiz.\nİyi günler");
                LC.ShopCard.Clear();
                LC.RefreshCard();
                this.Close();
            }
        }

        private void btn_cancelOrder_Click(object sender, EventArgs e)
        {
            Logger.logger(this.Name + "-" + "Cancel Order", EventLogEntryType.Information);
            if (DialogResult.No == MessageBox.Show("İptal etmek istediğinize emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                return;
            LC.ShopCard.CancelOrder();
            MainForm.newBasket.Show();
            this.Close();
        }

        private void chbx_ChoiceDef_CheckedChanged(object sender, EventArgs e)
        {
            if(chbx_ChoiceDef.Checked)
                chbx_choiceNew.Checked = false;
        }

        private void chbx_choiceNew_CheckedChanged(object sender, EventArgs e)
        {
            if (chbx_choiceNew.Checked)
                chbx_ChoiceDef.Checked = false;
        }

        private void Sales_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (placeOrder)
                MainForm.newBasket = null;
            else
                MainForm.newBasket.Show();
        }

        private void chbx_phone_CheckedChanged(object sender, EventArgs e)
        {
            if (chbx_phone.Checked)
                txt_phoneNumber.Visible = true;
            else
                txt_phoneNumber.Visible = false;
        }
    }
}
