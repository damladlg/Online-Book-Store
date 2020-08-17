using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
namespace OOP2_Project_BookStore
{
    public partial class Basket : Form
    {
        public Basket()
        {
            InitializeComponent();
        }

        private void FormBasket_Load(object sender, EventArgs e)
        {
            GenerateProduct();
        }

        LoginedCustomer LC = LoginedCustomer.Singleton();
        public void GenerateProduct()
        {
            pnlMain.Controls.Clear();
            int count = 0;
            foreach (var item in LC.ShopCard.Products)
            {
                Panel pnlProduct = new Panel();
                pnlProduct.Location = new System.Drawing.Point(10, ((count * 65) + 15));
                pnlProduct.Name = "pnlProduct";
                pnlProduct.Size = new System.Drawing.Size(470, 57);
                pnlProduct.TabIndex = 0;
                pnlProduct.BorderStyle = BorderStyle.FixedSingle;

                PictureBox picbxProduct = new PictureBox();
                picbxProduct.Location = new System.Drawing.Point(12, 3);
                picbxProduct.Name = "picbxProduct";
                picbxProduct.Size = new System.Drawing.Size(52, 51);
                picbxProduct.TabIndex = 0;
                picbxProduct.Image = ((ItemToPurchase)item).Product.Photo;
                picbxProduct.TabStop = false;
                picbxProduct.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                pnlProduct.Controls.Add(picbxProduct);

                Label lblName = new Label();
                lblName.AutoSize = true;
                lblName.Location = new System.Drawing.Point(85, 10);
                lblName.Name = "lblName";
                lblName.Size = new System.Drawing.Size(28, 13);
                lblName.TabIndex = 1;
                lblName.Text = "Adı: " + ((ItemToPurchase)item).Product.Name;
                pnlProduct.Controls.Add(lblName);

                Label lblPrice = new Label();
                lblPrice.AutoSize = true;
                lblPrice.Location = new System.Drawing.Point(85, 32);
                lblPrice.Name = "lblPrice";
                lblPrice.Size = new System.Drawing.Size(37, 13);
                lblPrice.TabIndex = 2;
                lblPrice.Text = "Fiyatı: " + ((ItemToPurchase)item).Product.Price;
                pnlProduct.Controls.Add(lblPrice);

                Label lblAdded = new Label();
                lblAdded.AutoSize = true;
                lblAdded.Location = new System.Drawing.Point(280, 23);
                lblAdded.Name = "lblAdded";
                lblAdded.Size = new System.Drawing.Size(52, 13);
                lblAdded.TabIndex = 1;
                lblAdded.Text = "Eklenen: ";
                pnlProduct.Controls.Add(lblAdded);

                NumericUpDown nmcUDcount = new NumericUpDown();
                nmcUDcount.Location = new System.Drawing.Point(336, 21);
                nmcUDcount.Name = "nmcUDcount-" + count;
                nmcUDcount.Size = new System.Drawing.Size(38, 20);
                nmcUDcount.TabIndex = 3;
                nmcUDcount.Value = ((ItemToPurchase)item).Quantity;
                nmcUDcount.ValueChanged += new System.EventHandler(this.nmcUDcount_ValueChanged);
                nmcUDcount.MouseWheel += NumericUpDown_MouseWheel;
                pnlProduct.Controls.Add(nmcUDcount);

                Button btnDelete = new Button();
                btnDelete.Location = new System.Drawing.Point(410, 18);
                btnDelete.Name = "btnDelete-" + count;
                btnDelete.Size = new System.Drawing.Size(46, 23);
                btnDelete.TabIndex = 4;
                btnDelete.Text = "Çıkar";
                btnDelete.UseVisualStyleBackColor = true;
                btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
                pnlProduct.Controls.Add(btnDelete);

                pnlMain.Controls.Add(pnlProduct);
                count++;
            }
            lblTotalAmount.Text = "Toplam Tutar\n" + LC.ShopCard.GetPaymentAmount();
        }

        private void nmcUDcount_ValueChanged(object sender, EventArgs e)
        {
            string[] arr = ((NumericUpDown)sender).Name.Split('-');
            int tmp = int.Parse(((NumericUpDown)sender).Value.ToString());
            if (tmp <= 0)
            {
                ItemToPurchase item = ((ItemToPurchase)LC.ShopCard.Products[int.Parse(arr[1])]);
                LC.ShopCard.RemoveProduct(item);
            }
            else
            {
                LC.ShopCard.DecreaseProductCount(int.Parse(arr[1]), tmp);
            }
            GenerateProduct();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Logger.logger(this.Name + "-" + "Delete", EventLogEntryType.Information);
            string[] arr = ((Button)sender).Name.Split('-');
            ItemToPurchase item = ((ItemToPurchase)LC.ShopCard.Products[int.Parse(arr[1])]);
            LC.ShopCard.RemoveProduct(item);
            LC.RefreshCard();
            GenerateProduct();
        }

        private void btn_sales_Click(object sender, EventArgs e)
        {
            Logger.logger(this.Name + "-" + "Sales", EventLogEntryType.Information);
            if (LC.ShopCard.Products.Count <= 0)
                return;

            Sales s = new Sales();
            this.Hide();
            s.Show();
        }

        private void NumericUpDown_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }

        private void Basket_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainForm.newBasket = null;
        }
    }
}