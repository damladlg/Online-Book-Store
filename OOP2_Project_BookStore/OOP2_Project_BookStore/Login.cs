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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        DatabaseOperations db = new DatabaseOperations("db_BookStore");
        private void btn_SingIn_Click(object sender, EventArgs e)
        {
            Logger.logger(this.Name + "-" + "SigIn", EventLogEntryType.Information);
            Sing_In SI = new Sing_In();
            this.Hide();
            SI.ShowDialog();
            this.Show();
        }
        LoginedCustomer LC;
        private void btn_login_Click(object sender, EventArgs e)
        {
            
            if (!Network_.checkStatus())
            {
                MessageBox.Show("İnternet bağlantısını kontrol ediniz.");
                return;
            }
            if (txt_pass.Text == "" || txt_username.Text == "")
            {
                MessageBox.Show("Tüm alanları doldurunuz...", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DataTable dt = db.Select(@"select u.id,u.Name,u.LastName,u.Email,u.Username,u.Password,ut.Type_Name,u.Gender_ID,u.Address,u.Photo from tbl_user u
                                    join tbl_userType ut on ut.id=u.Type_ID
                                     where u.Username='" + txt_username.Text + "' and u.Password='" + Hash.ComputeSha256Hash(txt_pass.Text) + "'");
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Kullanıcı adınız yada şifreniz yanlıştır...", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                lbl_result.Text = "Giriş başarısız...";
                lbl_result.BackColor = Color.Red;
                return;
            }
            string gender = "";
            if (dt.Rows[0][7] != null)
                gender = dt.Rows[0][7].ToString();

            Customer user = new Customer(int.Parse(dt.Rows[0][0].ToString()), dt.Rows[0][1].ToString(), dt.Rows[0][2].ToString(),
                        dt.Rows[0][3].ToString(), dt.Rows[0][4].ToString(), dt.Rows[0][5].ToString(), dt.Rows[0][6].ToString(),
                        gender, dt.Rows[0][8].ToString(), dt.Rows[0][9].ToString());

            LC = LoginedCustomer.Singleton(user);
            Logger.logger(this.Name + "-" + "Login", EventLogEntryType.Information);
            tmr_Join.Start();

            txt_pass.Enabled = false;
            txt_username.Enabled = false;
            btn_exit.Enabled = false;
            btn_login.Enabled = false;
            btn_SingIn.Enabled = false;
            lbl_result.Text = "Giriş yapılıyor...";
            lbl_result.BackColor = Color.Green;
        }

        int counter = 0;
        private void tmr_Join_Tick(object sender, EventArgs e)
        {
            if (counter++ == 3)
            {
                tmr_Join.Stop();
                this.Close();
            }
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            Logger.logger(this.Name + "-" + "Exit", EventLogEntryType.Information);
            this.Close();
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (LoginedCustomer.LoggedOut)
                MainForm.exit = true;
        }

        private void txt_username_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                btn_login_Click(null, null);
        }
    }
}
