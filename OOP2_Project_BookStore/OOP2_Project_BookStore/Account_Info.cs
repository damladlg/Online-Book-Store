using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Db;
using System.Diagnostics;
namespace OOP2_Project_BookStore
{
    public partial class Account_Info : Form
    {
        public Account_Info()
        {
            InitializeComponent();
        }

        DatabaseOperations db = new DatabaseOperations("db_BookStore");
        LoginedCustomer lu = LoginedCustomer.Singleton();
        public string pass;

        private void Account_Info_Load(object sender, EventArgs e)
        {
            pass = lu.User.Password;
            txtPassword.ReadOnly = true;
            txtName.Text = lu.User.Name;
            txtLastname.Text = lu.User.LastName;
            txtMail.Text = lu.User.Email;
            txtUsername.Text = lu.User.Username;
            txtAddress.Text = lu.User.Address;
            pictureBox.Image = Base64.GetImage(lu.User.Photo);
        }

        Bitmap image;
        private void btnChange_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialogPicture = new OpenFileDialog();
            openFileDialogPicture.Multiselect = false;
            openFileDialogPicture.Filter = "All Files |*.png; *.jpeg;*.jpg| PNG Files (*.png)|*.png|JPEG Files (*.jpeg)|*.jpeg|JPG Files (*.jpg)|*.jpg";
            openFileDialogPicture.Title = "Select File";

            try
            {
                Logger.logger(this.Name + "-" + "Change", EventLogEntryType.Information);
                if (openFileDialogPicture.ShowDialog() == DialogResult.OK)
                {
                    image = new Bitmap(openFileDialogPicture.FileName);
                    pictureBox.Image = (Image)image;

                    Base64.Tobase64Image(pictureBox.Image);
                }
            }
            catch
            {
                Logger.logger(this.Name + "-" + "Change", EventLogEntryType.Error);
                MessageBox.Show("Fotoğraf seçilemedi.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            try
            {
                Logger.logger(this.Name + "-" + "Update", EventLogEntryType.Information);
                if (txtName.Text == "" || txtMail.Text == "" || txtLastname.Text == "" || txtUsername.Text == "" /*|| txtAddress.Text == ""*/)
                {
                    MessageBox.Show("Tüm alanları doldurunuz...", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!Network_.EmailKontrol(txtMail.Text))
                {
                    MessageBox.Show("Geçerli bir mail adresi giriniz...", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DataTable dt = db.Select("select * from tbl_user where username='" + txtUsername.Text + "'" + "and id not in(" + lu.User.Customer_Id + ")");
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Bu kullanıcı adı mevcut farklı bir kullanıcı adı deneyiniz...", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if ((!txtPassword.ReadOnly) && (txtPassword.Text != ""))
                    pass = Hash.ComputeSha256Hash(txtPassword.Text);
                object a = db.UD("update tbl_user set Name='" + txtName.Text + "',LastName='" + txtLastname.Text + "',Address='" + txtAddress.Text + "',Email='" + txtMail.Text +
                    "',Username='" + txtUsername.Text + "',Password='" + pass + "',Photo='" + Base64.Tobase64Image(pictureBox.Image) + "'where id=" + lu.User.Customer_Id);

                if (Convert.ToInt32(a) > 0)
                {
                    MessageBox.Show("Güncelleme başarılı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch(Exception)
            {
                Logger.logger(this.Name + "-" + "Update", EventLogEntryType.Error);
            }

        }

        private void txtPassword_Click(object sender, EventArgs e)
        {
            Logger.logger(this.Name + "-" + "Password", EventLogEntryType.Information);
            if (DialogResult.Yes == MessageBox.Show("Parolayı değiştirmek istediğinize emin misiniz?.", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {
                if (DialogResult.OK == MessageBox.Show("Yeni Şifrenizi Giriniz.", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.None))
                {
                    txtPassword.ReadOnly = false;

                }
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (txtPassword.Text != "")
                {
                    MessageBox.Show("Yeni Şifreniz oluşturuldu.", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.None);
                    Logger.logger(this.Name + "-" + "Passwod Update", EventLogEntryType.Information);
                }
                else
                {
                    txtPassword.Clear();
                    MessageBox.Show("Şifreniz hatalı, lütfen tekrar giriniz.", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.None);
                    Logger.logger(this.Name + "-" + "Passwod Update", EventLogEntryType.Error);
                }
            }
        }

        private void Account_Info_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainForm.account_Info = null;
        }
    }
}
