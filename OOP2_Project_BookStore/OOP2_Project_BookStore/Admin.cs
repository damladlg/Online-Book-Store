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
using System.IO;
using System.Diagnostics;
namespace OOP2_Project_BookStore
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        DatabaseOperations db = new DatabaseOperations("db_BookStore");
        private string pass = "";

        private void Admin_Load(object sender, EventArgs e)
        {
            btn_save.Visible = false;
            cmbx_userGender.DisplayMember = "Type_Name";
            cmbx_userGender.ValueMember = "id";
            cmbx_userGender.DataSource = db.Select("select id, Type_Name from tbl_gender");

            cmbx_userType.DisplayMember = "Type_Name";
            cmbx_userType.ValueMember = "id";
            cmbx_userType.DataSource = db.Select("select id, Type_Name from tbl_userType");
            if (tbc_info.SelectedIndex == 0)
                GetUserData();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            Logger.logger(this.Name + "-" + "Add", EventLogEntryType.Information);
            if (tbc_info.SelectedIndex == 0)
            {
                if (txt_userName.Text == "" || txt_userLastname.Text == "" || txt_UserEmail.Text == "" ||
                    txt_userUsermane.Text == "" || (!txt_userPass.ReadOnly && txt_userPass.Text == ""))
                {
                    MessageBox.Show("Adres dışında boş bırakamazsınız...", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!Network_.EmailKontrol(txt_UserEmail.Text))
                {
                    MessageBox.Show("Lütfen geçerli bir mail adresi giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!txt_userPass.ReadOnly)
                    pass = Hash.ComputeSha256Hash(txt_userPass.Text);

                InsertData("User");
            }
            else if (tbc_info.SelectedIndex == 1)
            {
                if (txt_bookName.Text == "" || txt_bookPrice.Text == "" || txt_bookISBN.Text == "" || txt_bookAuthor.Text == "" || txt_bookPublisher.Text == "" || txt_bookPage.Text == "")
                {
                    MessageBox.Show("Lütfen boş bırakmayınız...", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                InsertData("Book");
            }
            else if (tbc_info.SelectedIndex == 2)
            {
                if (txt_musicCdName.Text == "" || txt_musicCdPrice.Text == "" || txt_musicCdSinger.Text == "" || cmbx_musicCdType.Text == "")
                {
                    MessageBox.Show("Lütfen boş bırakmayınız...", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                InsertData("MusicCD");
            }
            else if (tbc_info.SelectedIndex == 3)
            {
                if (txt_magazineName.Text == "" || txt_magazinePrice.Text == "" || cmbx_magazineType.Text == "" || txt_magazineIssue.Text == "")
                {
                    MessageBox.Show("Lütfen boş bırakmayınız...", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                InsertData("Magazine");
            }
        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            Logger.logger(this.Name + "-" + "Delete", EventLogEntryType.Information);
            if (tbc_info.SelectedIndex == 0)
            {
                if (lstvw_users.SelectedItems.Count == 0)
                {
                    MessageBox.Show("Lütfen listeden seçim yapınız");
                    return;
                }
                DeleteData("User");
            }
            else if (tbc_info.SelectedIndex == 1)
            {
                if (lstvw_book.SelectedItems.Count == 0)
                {
                    MessageBox.Show("Lütfen listeden seçim yapınız");
                    return;
                }
                DeleteData("Book");
            }
            else if (tbc_info.SelectedIndex == 2)
            {
                if (lstvw_Music.SelectedItems.Count == 0)
                {
                    MessageBox.Show("Lütfen listeden seçim yapınız");
                    return;
                }
                DeleteData("MusicCD");
            }
            else if (tbc_info.SelectedIndex == 3)
            {
                if (lstvw_magazine.SelectedItems.Count == 0)
                {
                    MessageBox.Show("Lütfen listeden seçim yapınız");
                    return;
                }
                DeleteData("Magazine");
            }
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            Logger.logger(this.Name + "-" + "Update", EventLogEntryType.Information);
            if (tbc_info.SelectedIndex == 0)
            {
                if (lstvw_users.SelectedItems.Count == 0)
                {
                    MessageBox.Show("Lütfen listeden seçim yapınız");
                }
                if (txt_userName.Text == "" || txt_userLastname.Text == "" || txt_UserEmail.Text == "" ||
                    txt_userUsermane.Text == "" || (!txt_userPass.ReadOnly && txt_userPass.Text == ""))
                {
                    MessageBox.Show("Adres dışında boş bırakamazsınız...", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!Network_.EmailKontrol(txt_UserEmail.Text))
                {
                    MessageBox.Show("Lütfen geçerli bir mail adresi giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!txt_userPass.ReadOnly)
                    pass = Hash.ComputeSha256Hash(txt_userPass.Text);

                UpdateData("User");
            }
            else if (tbc_info.SelectedIndex == 1)
            {
                if (lstvw_book.SelectedItems.Count == 0)
                {
                    MessageBox.Show("Lütfen listeden seçim yapınız");
                }
                if (txt_bookName.Text == "" || txt_bookPrice.Text == "" || txt_bookISBN.Text == "" || txt_bookAuthor.Text == "" || txt_bookPublisher.Text == "" || txt_bookPage.Text == "")
                {
                    MessageBox.Show("Lütfen boş bırakmayınız...", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                UpdateData("Book");
            }
            else if (tbc_info.SelectedIndex == 2)
            {
                if (lstvw_Music.SelectedItems.Count == 0)
                {
                    MessageBox.Show("Lütfen listeden seçim yapınız");
                }
                if (txt_musicCdName.Text == "" || txt_musicCdPrice.Text == "" || txt_musicCdSinger.Text == "" || cmbx_musicCdType.Text == "")
                {
                    MessageBox.Show("Lütfen boş bırakmayınız...", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                UpdateData("MusicCD");
            }
            else if (tbc_info.SelectedIndex == 3)
            {
                if (lstvw_magazine.SelectedItems.Count == 0)
                {
                    MessageBox.Show("Lütfen listeden seçim yapınız");
                }
                if (txt_magazineName.Text == "" || txt_magazinePrice.Text == "" || cmbx_magazineType.Text == "" || txt_magazineIssue.Text == "")
                {
                    MessageBox.Show("Lütfen boş bırakmayınız...", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                UpdateData("Magazine");
            }
        }

        private void tbc_info_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tbc_info.SelectedIndex == 0)
            {
                btn_add.Visible = true;
                btn_del.Visible = true;
                btn_update.Visible = true;
                btn_save.Visible = false;
                GetUserData();
            }
            else if (tbc_info.SelectedIndex == 1)
            {
                btn_add.Visible = true;
                btn_del.Visible = true;
                btn_update.Visible = true;
                btn_save.Visible = false;
                GetProductData("Book", lstvw_book);
                picbx_bookPhoto.Image = imglst_Photos.Images[2];
            }
            else if (tbc_info.SelectedIndex == 2)
            {
                btn_add.Visible = true;
                btn_del.Visible = true;
                btn_update.Visible = true;
                btn_save.Visible = false;
                cmbx_musicCdType.DataSource = new string[] { "Romance", "HardRock", "Country", "Pop" };

                GetProductData("MusicCD", lstvw_Music);
                picbx_musicPhoto.Image = imglst_Photos.Images[3];
            }
            else if (tbc_info.SelectedIndex == 3)
            {
                btn_add.Visible = true;
                btn_del.Visible = true;
                btn_update.Visible = true;
                btn_save.Visible = false;
                cmbx_magazineType.DataSource = new string[] { " Actual", "News", "Sport", "Computer", "Technology" };
                GetProductData("Magazine", lstvw_magazine);
                picbx_MagasinePhoto.Image = imglst_Photos.Images[4];
            }
            else if (tbc_info.SelectedIndex == 4)
            {
                GetLogData();
                btn_add.Visible = false;
                btn_del.Visible = false;
                btn_update.Visible = false;
                btn_save.Visible = true;
            }
        }

        private void InsertData(string v)
        {
            string sorgu = "";
            switch (v)
            {
                case "User":
                    sorgu = @"insert into tbl_user (Name,LastName,Address,Email,Username,Password,Type_ID,Gender_ID,Photo) values('" + txt_userName.Text + "','" +
                            txt_userLastname.Text + "','" + txt_userAddress.Text + "','" + txt_UserEmail.Text + "','" + txt_userUsermane.Text + "','" + pass + "'," + cmbx_userType.SelectedValue + "," + cmbx_userGender.SelectedValue + ",'";
                    if (pcbx_photo.Image != null)
                        sorgu += Base64.Tobase64Image(pcbx_photo.Image) + "')";
                    else
                        sorgu += "')";
                    break;
                case "Book":
                    sorgu = @"insert into tbl_products (Name,Price,Product_Type_ID,Properties,Photo,Stock,SoldCount) values('" +
                        txt_bookName.Text + "','" + txt_bookPrice.Text + "',(select id from tbl_productType where Type_Name='Book'),'" +
                        txt_bookISBN.Text + "-" + txt_bookAuthor.Text + "-" + txt_bookPublisher.Text + "-" + txt_bookPage.Text + "','" + Base64.Tobase64Image(picbx_bookPhoto.Image) + "'," + txt_bookStock.Text + ",0)";
                    break;
                case "MusicCD":
                    sorgu = @"insert into tbl_products (Name,Price,Product_Type_ID,Properties,Photo,Stock,SoldCount) values('" +
                        txt_musicCdName.Text + "','" + txt_musicCdPrice.Text + "',(select id from tbl_productType where Type_Name='MusicCD'),'" +
                        txt_musicCdSinger.Text + "-" + cmbx_musicCdType.SelectedText + "','" + Base64.Tobase64Image(picbx_musicPhoto.Image) + "'," + txt_musicStock.Text + ",0)";
                    break;
                case "Magazine":
                    sorgu = @"insert into tbl_products (Name,Price,Product_Type_ID,Properties,Photo,Stock,SoldCount) values('" +
                        txt_magazineName.Text + "','" + txt_magazinePrice.Text + "',(select id from tbl_productType where Type_Name='Magazine'),'" +
                        cmbx_magazineType.SelectedText + "-" + txt_magazineIssue.Text + "','" + Base64.Tobase64Image(picbx_MagasinePhoto.Image) + "'," + txt_magazineStock.Text + ",0)";
                    break;
                default:
                    break;
            }
            object t = db.I(sorgu);
            if (Convert.ToInt32(t) >= 1)
            {
                MessageBox.Show("Kayıt eklendi.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (tbc_info.SelectedIndex == 0)
                    GetUserData();
                else if (tbc_info.SelectedIndex == 1)
                    GetProductData("Book", lstvw_book);
                else if (tbc_info.SelectedIndex == 2)
                    GetProductData("MusicCD", lstvw_Music);
                else if (tbc_info.SelectedIndex == 3)
                    GetProductData("Magazine", lstvw_magazine);
            }
        }

        private void DeleteData(string v)
        {
            string sorgu = "";
            switch (v)
            {
                case "User":
                    sorgu = @"delete from tbl_user where id=" + lstvw_users.SelectedItems[0].SubItems[0].Text;
                    break;
                case "Book":
                    sorgu = @"delete from tbl_products where id=" + lstvw_book.SelectedItems[0].SubItems[0].Text;
                    break;
                case "MusicCD":
                    sorgu = @"delete from tbl_products where id=" + lstvw_Music.SelectedItems[0].SubItems[0].Text;
                    break;
                case "Magazine":
                    sorgu = @"delete from tbl_products where id=" + lstvw_magazine.SelectedItems[0].SubItems[0].Text;
                    break;
                default:
                    break;
            }
            int t = db.UD(sorgu);
            if (t >= 1)
            {
                MessageBox.Show("Kayıt silindi.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (tbc_info.SelectedIndex == 0)
                    GetUserData();
                else if (tbc_info.SelectedIndex == 1)
                    GetProductData("Book", lstvw_book);
                else if (tbc_info.SelectedIndex == 2)
                    GetProductData("MusicCD", lstvw_Music);
                else if (tbc_info.SelectedIndex == 3)
                    GetProductData("Magazine", lstvw_magazine);
            }
        }

        private void UpdateData(string v)
        {
            string sorgu = "";
            switch (v)
            {
                case "User":
                    sorgu = @"update tbl_user set Name='" + txt_userName.Text + "',LastName='" + txt_userLastname.Text + "',Address='" + txt_userAddress.Text + "',Email='" +
                            txt_UserEmail.Text + "',Username='" + txt_userUsermane.Text + "',Password='" + pass + "',Type_ID=" + cmbx_userType.SelectedValue + ",Gender_ID=" + cmbx_userGender.SelectedValue + ",Photo='";
                    if (pcbx_photo.Image != null)
                        sorgu += Base64.Tobase64Image(pcbx_photo.Image);
                    sorgu += "' where id=" + lstvw_users.SelectedItems[0].SubItems[0].Text;
                    break;
                case "Book":
                    sorgu = @"update tbl_products set Name='" + txt_bookName.Text + "', Price='" +
                        txt_bookPrice.Text + "',Photo='" + Base64.Tobase64Image(picbx_bookPhoto.Image) + "',Stock=" + txt_bookStock.Text + " , Properties='" + txt_bookISBN.Text + "-" + txt_bookAuthor.Text + "-"
                        + txt_bookPublisher.Text + "-" + txt_bookPage.Text + "' where id=" + lstvw_book.SelectedItems[0].SubItems[0].Text;
                    break;
                case "MusicCD":
                    sorgu = @"update tbl_products set Name='" + txt_musicCdName.Text + "', Price='" + txt_musicCdPrice.Text +
                         "',Photo='" + Base64.Tobase64Image(picbx_musicPhoto.Image) + "',Stock=" + txt_musicStock.Text + " ,Properties='" + txt_musicCdSinger.Text + "-" + cmbx_musicCdType.SelectedText + "'  where id=" + lstvw_Music.SelectedItems[0].SubItems[0].Text;
                    break;
                case "Magazine":
                    sorgu = @"update tbl_products set Name='" + txt_magazineName.Text + "', Price='" + txt_magazinePrice.Text +
                         "',Photo='" + Base64.Tobase64Image(picbx_MagasinePhoto.Image) + "',Stock=" + txt_magazineStock.Text + " ,Properties='" + cmbx_magazineType.SelectedText + "-" + txt_magazineIssue.Text + "'where id=" + lstvw_magazine.SelectedItems[0].SubItems[0].Text;
                    break;
                default:
                    break;
            }
            int t = db.UD(sorgu);
            if (t >= 1)
            {
                MessageBox.Show("Kayıt güncellendi.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (tbc_info.SelectedIndex == 0)
                    GetUserData();
                else if (tbc_info.SelectedIndex == 1)
                    GetProductData("Book", lstvw_book);
                else if (tbc_info.SelectedIndex == 2)
                    GetProductData("MusicCD", lstvw_Music);
                else if (tbc_info.SelectedIndex == 3)
                    GetProductData("Magazine", lstvw_magazine);
            }
        }

        /*Start Tab User*/
        void GetUserData()
        {
            lstvw_users.Items.Clear();
            DataTable dt = db.Select(@"select u.id,u.name,u.LastName,u.Address,u.Email,u.Username,u.Password,u.Type_ID,ut.Type_Name as type,
                                            u.Gender_ID,g.Type_Name as gender,u.Photo from tbl_user u
                                            join tbl_gender g on g.id=u.Gender_ID
                                            join tbl_userType ut on ut.id=u.Type_ID");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                lstvw_users.Items.Add(new ListViewItem(new string[] { dt.Rows[i][0].ToString(), dt.Rows[i][1].ToString(), dt.Rows[i][2].ToString(), dt.Rows[i][3].ToString(), dt.Rows[i][4].ToString(), dt.Rows[i][5].ToString(), dt.Rows[i][6].ToString(),
                                                                    dt.Rows[i][7].ToString(),dt.Rows[i][8].ToString(),dt.Rows[i][9].ToString(),dt.Rows[i][10].ToString(),dt.Rows[i][11].ToString()}));
            }
        }

        private void lstvw_users_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (lstvw_users.SelectedItems.Count == 0)
                return;
            txt_userName.Text = lstvw_users.SelectedItems[0].SubItems[1].Text.ToString();
            txt_userLastname.Text = lstvw_users.SelectedItems[0].SubItems[2].Text.ToString();
            txt_userAddress.Text = lstvw_users.SelectedItems[0].SubItems[3].Text.ToString();
            txt_UserEmail.Text = lstvw_users.SelectedItems[0].SubItems[4].Text.ToString();
            txt_userUsermane.Text = lstvw_users.SelectedItems[0].SubItems[5].Text.ToString();
            pass = lstvw_users.SelectedItems[0].SubItems[6].Text.ToString();
            cmbx_userType.SelectedValue = lstvw_users.SelectedItems[0].SubItems[7].Text.ToString();
            cmbx_userGender.SelectedValue = lstvw_users.SelectedItems[0].SubItems[9].Text.ToString();
            if (lstvw_users.SelectedItems[0].SubItems[11].Text.ToString() != "")
            {
                pcbx_photo.Image = Base64.GetImage(lstvw_users.SelectedItems[0].SubItems[11].Text.ToString());
            }
            else
            {
                if (cmbx_userGender.Text.Equals("Erkek"))
                    pcbx_photo.Image = imglst_Photos.Images[1];
                else
                    pcbx_photo.Image = imglst_Photos.Images[0];
            }
        }

        private void ttp_userPass_Draw(object sender, DrawToolTipEventArgs e)
        {
            e.DrawBackground();
            e.DrawBorder();
            e.DrawText();
        }

        private void txt_userPass_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Parolayı değiştirmek istediğinize emin misiniz?.", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {
                txt_userPass.ReadOnly = false;
            }
        }

        private void txt_userPass_MouseHover(object sender, EventArgs e)
        {
            ttp_userPass.Show("Parolayı değiştirmek için tıklayın.", txt_userPass);
            ttp_userPass.OwnerDraw = true;
        }

        private void cmbx_userGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pcbx_photo.Image != null)
                return;
            if (cmbx_userGender.Text == "Kadın")
                pcbx_photo.Image = imglst_Photos.Images[0];
            else
                pcbx_photo.Image = imglst_Photos.Images[1];
        }
        /*End Tab User*/

        /*  Product Data get*/
        void GetProductData(string type, ListView display)
        {
            display.Items.Clear();
            DataTable dt = db.Select(@"select p.id,p.Name,p.Price,p.Product_Type_ID,pt.Type_Name,p.Properties,p.Photo,p.SoldCount,p.Stock from tbl_products p
                                            join tbl_productType pt on pt.id=p.Product_Type_ID
                                            where Product_Type_ID=(select id from tbl_productType where Type_Name='" + type + "' )");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                display.Items.Add(new ListViewItem(new string[] { dt.Rows[i][0].ToString(), dt.Rows[i][1].ToString(), dt.Rows[i][2].ToString().Replace(',','.'),
                    dt.Rows[i][3].ToString(), dt.Rows[i][4].ToString(), dt.Rows[i][5].ToString(),dt.Rows[i][6].ToString(),dt.Rows[i][7].ToString(),dt.Rows[i][8].ToString()}));
            }
        }
        /*End Product Data get*/

        /*Start Tab Book */
        private void lstvw_book_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (lstvw_book.SelectedItems.Count == 0)
                return;
            txt_bookName.Text = lstvw_book.SelectedItems[0].SubItems[1].Text.ToString();
            txt_bookPrice.Text = lstvw_book.SelectedItems[0].SubItems[2].Text.ToString();

            string[] temp = lstvw_book.SelectedItems[0].SubItems[5].Text.ToString().Split('-');
            txt_bookISBN.Text = temp[0];
            txt_bookAuthor.Text = temp[1];
            txt_bookPublisher.Text = temp[2];
            txt_bookPage.Text = temp[3];
            picbx_bookPhoto.Image = Base64.GetImage(lstvw_book.SelectedItems[0].SubItems[6].Text.ToString());
            txt_bookStock.Text = lstvw_book.SelectedItems[0].SubItems[8].Text.ToString();
        }

        private void txt_bookPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
                MessageBox.Show("Lütfen sadece sayı giriniz.");
            }
        }
        /*End Tab Book */

        /*Start Tab MusicCD */
        private void lstvw_Music_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (lstvw_Music.SelectedItems.Count == 0)
                return;
            txt_musicCdName.Text = lstvw_Music.SelectedItems[0].SubItems[1].Text;
            txt_musicCdPrice.Text = lstvw_Music.SelectedItems[0].SubItems[2].Text;
            string[] temp = lstvw_Music.SelectedItems[0].SubItems[5].Text.Split('-');
            txt_musicCdSinger.Text = temp[0];
            cmbx_musicCdType.Text = temp[1];
            picbx_musicPhoto.Image = Base64.GetImage(lstvw_Music.SelectedItems[0].SubItems[6].Text.ToString());
            txt_musicStock.Text = lstvw_Music.SelectedItems[0].SubItems[8].Text;
        }

        private void txt_musicCdPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
                MessageBox.Show("Lütfen sadece sayı giriniz.");
            }
        }
        /*End Tab MusicCD */

        /*Start Tab Magazine */
        private void lstvw_magazine_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstvw_magazine.SelectedItems.Count == 0)
                return;
            txt_magazineName.Text = lstvw_magazine.SelectedItems[0].SubItems[1].Text;
            txt_magazinePrice.Text = lstvw_magazine.SelectedItems[0].SubItems[2].Text;
            string[] temp = lstvw_magazine.SelectedItems[0].SubItems[5].Text.Split('-');
            cmbx_magazineType.Text = temp[0];
            txt_magazineIssue.Text = temp[1];
            picbx_MagasinePhoto.Image = Base64.GetImage(lstvw_magazine.SelectedItems[0].SubItems[6].Text.ToString());
            txt_magazineStock.Text = lstvw_magazine.SelectedItems[0].SubItems[8].Text;
        }

        private void txt_magazinePrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
                MessageBox.Show("Lütfen sadece sayı giriniz.");
            }
        }

        private void Admin_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainForm.admin = null;
        }

        private void btn_magazineAddPhoto_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "PNG files (*.png)|*.png";
                ofd.FilterIndex = 1;
                ofd.RestoreDirectory = true;
                string filepath;
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    filepath = ofd.FileName;
                    if (((Button)sender).Name.Contains("magazine"))
                        picbx_MagasinePhoto.Image = Image.FromFile(filepath);
                    else if (((Button)sender).Name.Contains("book"))
                        picbx_bookPhoto.Image = Image.FromFile(filepath);
                    else if (((Button)sender).Name.Contains("music"))
                        picbx_musicPhoto.Image = Image.FromFile(filepath);
                }
            }
            catch(Exception)
            {

            }
        }
        /*End Tab Magazine */

        /*Start Tab Event Viewer */
        void GetLogData()
        {
            lstvw_users.Items.Clear();
            DataTable dt = db.Select(@"select e.id,e.Entry_Type,e.Time,e.User_Name,e.Button from tbl_log e");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                lstvw_log.Items.Add(new ListViewItem(new string[] { dt.Rows[i][0].ToString(), dt.Rows[i][1].ToString(), dt.Rows[i][2].ToString(), dt.Rows[i][3].ToString(), dt.Rows[i][4].ToString() }));
            }
        }
        private void btn_save_Click(object sender, EventArgs e)
        {
            Logger.logger(this.Name + "-" + "Save", EventLogEntryType.Information);
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            sfd.FilterIndex = 2;
            sfd.RestoreDirectory = true;
            if (sfd.ShowDialog() == DialogResult.OK)
            {

                string path = sfd.FileName;
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine("Düzey" + "\t\t" + "Tarih ve Saat" + "\t " + "Kullanıcı Adı" + "\t " + "Olay Kimliği");
                    foreach (ListViewItem item in lstvw_log.Items)
                    {
                        sw.WriteLine(item.SubItems[1].Text + "\t" + item.SubItems[2].Text + "\t" + item.SubItems[3].Text + "\t" + item.SubItems[4].Text);
                    }
                    sw.Close();
                }
            }
        }
     
    }
}
