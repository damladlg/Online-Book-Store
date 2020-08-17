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
using System.Diagnostics;
namespace OOP2_Project_BookStore
{
    public partial class Sing_In : Form
    {
        public Sing_In()
        {
            InitializeComponent();
        }

        DatabaseOperations db = new DatabaseOperations("db_BookStore");
        private void Sing_In_Load(object sender, EventArgs e)
        {
            cmbx_gender.DisplayMember = "Type_Name";
            cmbx_gender.ValueMember = "id";
            cmbx_gender.DataSource = db.Select("select id,Type_Name from tbl_gender");
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                Logger.logger(this.Name + "-" + "Save", EventLogEntryType.Information);
                if (txt_pass.Text == "" || txt_name.Text == "" || txt_mail.Text == "" || txt_lastname.Text == "" || txt_username.Text == "")
                {
                    MessageBox.Show("Tüm alanları doldurunuz...", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!Network_.EmailKontrol(txt_mail.Text))
                {
                    MessageBox.Show("Geçerli bir mail adresi giriniz...", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DataTable dt = db.Select("select * from tbl_user where username='" + txt_username.Text + "'");
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Bu kullanıcı adı daha önceden eklenmiş...", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                dt = db.Select("select * from tbl_user");
                if (dt.Rows.Count == 0)
                    dt = db.Select("select id from tbl_userType where Type_Name='Admin'");
                else
                    dt = db.Select("select id from tbl_userType where Type_Name='Customer'");

                string photo;
                if (cmbx_gender.SelectedValue.ToString() == "Erkek")
                {
                    photo = Base64.Tobase64Image("../../Resources/Male.png");
                }
                else
                {
                    photo = Base64.Tobase64Image("../../Resources/Female.png");
                }
                object a = db.I(@"insert into tbl_user (Name,LastName,Email,Username,Password,Type_ID,Gender_ID,Photo) values('" + txt_name.Text + "','" + txt_lastname.Text + "','" +
                                                            txt_mail.Text + "','" + txt_username.Text + "','" + Hash.ComputeSha256Hash(txt_pass.Text) + "'," + dt.Rows[0][0].ToString() + "," + cmbx_gender.SelectedValue + ",'" + photo + "')");
                if (Convert.ToInt32(a) > 0)
                {
                    MessageBox.Show("Kayıt başarılı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                Logger.logger(this.Name + "-" + "Save", EventLogEntryType.Error);
                MessageBox.Show("Girdiğiniz kullanıcı adı mevcuttur. Yeni bir tane seçiniz.");
            }
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            Logger.logger(this.Name + "-" + "Exit", EventLogEntryType.Information);
            this.Close();
        }
    }
}
