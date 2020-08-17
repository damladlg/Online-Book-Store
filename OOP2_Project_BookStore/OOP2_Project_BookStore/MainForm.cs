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
    public partial class MainForm : Form
    {
        public static Label lblproduct = new Label();
        public MainForm()
        {
            InitializeComponent();

            lblproduct.AutoSize = true;
            lblproduct.Location = new System.Drawing.Point(10, 10);
            lblproduct.Name = "lblProduct";
            lblproduct.Size = new System.Drawing.Size(0, 13);
            lblproduct.TabIndex = 0;
            lblproduct.Text = "Sepetinizde ürün yoktur.";
            lblproduct.TextChanged += new System.EventHandler(this.lblproduct_TextChanged);

            lblproduct.MouseEnter += new System.EventHandler(this.tspbtnShopCart_MouseEnter);
            lblproduct.MouseLeave += new System.EventHandler(this.tspbtnShopCart_MouseLeave);
            pnlShopCard.Controls.Add(lblproduct);
        }

        private void lblproduct_TextChanged(object sender, EventArgs e)
        {
            tspbtnShopCart.Text = "Sepetim(" + LC.ShopCard.Products.Count + ")";
            if (pnlShopCard.Size.Height + 100 < 400)
                pnlShopCard.Size = new Size(pnlShopCard.Size.Width, lblproduct.Size.Height + 100);
        }

        DatabaseOperations db = new DatabaseOperations("db_BookStore");
        public static bool exit = false;
        LoginedCustomer LC;

        static public Admin admin;
        static public Account_Info account_Info;
        static public Basket newBasket;
        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Hide();
            Login l = new Login();
            l.ShowDialog();
            if (exit)
            {
                Application.Exit();
                return;
            }
            this.Show();
            LC = LoginedCustomer.Singleton();
            AdminCheck();
            RefreshMain();
            cmbx_filter.DataSource = new string[] { "Normal", "Fiyata Göre Artan", "Fiyata Göre Azalan", "Çok Satan" };
            chbx_all.Checked = true;
        }

        void AdminCheck()
        {
            if (LC.User.Type == "Admin")
            {
                tspbtn_admin.Enabled = true;
                tspbtn_admin.Visible = true;
            }
            else
            {
                tspbtn_admin.Enabled = false;
                tspbtn_admin.Visible = false;
            }
        }

        private void tspbtn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tspbtn_hide_Click(object sender, EventArgs e)
        {
            this.Visible = !this.Visible;
            if (this.Visible)
                cmsbtn_visible.Text = "Gizle";
            else
                cmsbtn_visible.Text = "Göster";
        }

        private void tspbtn_logOut_Click(object sender, EventArgs e)
        {
            LoginedCustomer.LoggedOut = true;
            LC.ShopCard.Clear();
            lblproduct.Text = "Sepetinizde ürün yoktur.";
            if (admin != null)
            {
                admin.Close();
                admin = null;
            }
            
            if (account_Info != null)
            {
                account_Info.Close();
                account_Info = null;
            }
            if (newBasket != null)
            {
                newBasket.Close();
                newBasket = null;
            }

            MainForm_Load(null, null);
        }

        private void tspbtn_admin_Click(object sender, EventArgs e)
        {

            Logger.logger(this.Name + "-" + "Admin", EventLogEntryType.Information);
            if (admin != null)
                return;
            admin = new Admin();
            admin.Show();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ntfi_bookstoreicon.Dispose();
        }

        private void tspbtn_account_Click(object sender, EventArgs e)
        {
            Logger.logger(this.Name + "-" + "Account_Info", EventLogEntryType.Information);
            if (account_Info != null)
                return;
            account_Info = new Account_Info();
            account_Info.Show();
        }

        private void tspbtnShopCart_Click(object sender, EventArgs e)
        {

            Logger.logger(this.Name + "-" + "Shop Cart", EventLogEntryType.Information);
            if (newBasket != null)
                return;
            newBasket = new Basket();
            newBasket.Show();
        }

        private void tspbtnShopCart_MouseEnter(object sender, EventArgs e)
        {
            pnlShopCard.Visible = true;
            tmr_hideCard.Stop();
        }

        private void tspbtnShopCart_MouseLeave(object sender, EventArgs e)
        {
            tmr_hideCard.Start();
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            pnlShopCard.Location = new Point(this.Size.Width - 220, pnlShopCard.Location.Y);
            pnl_shopping.Location = new Point(((this.Width / 5) ) , pnl_shopping.Location.Y);
            pnl_shopping.Size = new Size(((this.Width/5)*4), this.Height );
            pnlMain.Size = new Size(pnl_shopping.Width-96, pnl_shopping.Height - 96);
        }

        private void tmr_hideCard_Tick(object sender, EventArgs e)
        {
            pnlShopCard.Visible = false;
            tmr_hideCard.Stop();
        }

        /*Start Shopping panel*/
        List<Product> Products = new List<Product>();
        private void btnAddToCard_Click(object sender, EventArgs e)
        {
            Logger.logger(this.Name + "-" + "Add to Card", EventLogEntryType.Information);
            string[] temp = ((Button)sender).Name.Split('-');
            foreach (var item in pnlMain.Controls)
            {
                if (item is Panel)
                {
                    bool check = false;
                    foreach (var item2 in ((Panel)item).Controls)
                    {
                        if (item2 is NumericUpDown)
                        {
                            if (((NumericUpDown)item2).Name == "numeric_Count-" + temp[2])
                            {
                                int productIndex = Convert.ToInt32(temp[2]);
                                int numericUpdownCount = int.Parse(((NumericUpDown)item2).Value.ToString());

                                if (numericUpdownCount <= 0)
                                    return;
                                if (numericUpdownCount > Products[productIndex].Stock)
                                {
                                    MessageBox.Show("Stok miktarını geçmeyiniz.");
                                    return;
                                }
                                ItemToPurchase itemPurc = new ItemToPurchase(Products[productIndex], numericUpdownCount);
                                LC.ShopCard.AddProduct(itemPurc);
                                LC.RefreshCard();
                                check = true;
                                if (MainForm.newBasket != null)
                                    MainForm.newBasket.GenerateProduct();
                                break;
                            }
                        }
                    }
                    if (check)
                        break;
                }
            }
        }

        private void GetProduct()
        {
            Products.Clear();
            string sql = @"select p.id, p.Name, p.Price, p.Properties, p.Photo, p.SoldCount,
                                    p.Stock, pt.Type_Name from tbl_products p 
                                    join tbl_productType pt on p.Product_Type_ID = pt.id where Stock>0";
            if (cmbx_filter.SelectedIndex == 1)
                sql += " order by Price ASC";
            else if (cmbx_filter.SelectedIndex == 2)
                sql += " order by Price DESC";
            else if (cmbx_filter.SelectedIndex == 3)
                sql += " order by SoldCount DESC";
            DataTable dt = db.Select(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int id = int.Parse(dt.Rows[i][0].ToString());
                string type = dt.Rows[i][7].ToString();
                string name = dt.Rows[i][1].ToString();
                decimal price = Convert.ToDecimal(dt.Rows[i][2].ToString());
                string properties = dt.Rows[i][3].ToString();
                Image photo = Base64.GetImage(dt.Rows[i][4].ToString());
                int soldCount = int.Parse(dt.Rows[i][5].ToString());
                int stock = int.Parse(dt.Rows[i][6].ToString());
                Products.Add(Factory.PoductFactory(type, id, name, price, photo, stock, soldCount, properties));
            }
        }

        private void GenerateDisplayProduct(string t)
        {
            int count = 0;
            int colCount = 0;
            int itemcount = 0;
            pnlMain.Controls.Clear();
            foreach (var item in Products)
            {
                if (item is Book && !(t.Contains("Book")))
                    continue;
                else if (item is Magazine && !(t.Contains("Magazine")))
                    continue;
                else if (item is MusicCD && !(t.Contains("MusicCD")))
                    continue;

                Panel product = new Panel();
                product.Location = new System.Drawing.Point(((count * 170) + count * 5), ((colCount * 200) + colCount * 5));
                product.Name = "pnlProduct";
                product.Size = new System.Drawing.Size(170, 200);
                product.BorderStyle = BorderStyle.FixedSingle;
                product.TabIndex = ((colCount * 3) + count);

                Label lblName = new Label();

                lblName.AutoSize = true;
                lblName.Location = new System.Drawing.Point(95, 16);
                lblName.Name = "lblName";
                lblName.Size = new System.Drawing.Size(38, 13);
                lblName.TabIndex = 2;
                lblName.Text = "İsmi: " + item.Name;
                product.Controls.Add(lblName);

                Label lblPrice = new Label();

                lblPrice.AutoSize = true;
                lblPrice.Location = new System.Drawing.Point(96, 39);
                lblPrice.Name = "lblPrice";
                lblPrice.Size = new System.Drawing.Size(37, 13);
                lblPrice.TabIndex = 3;
                lblPrice.Text = "Fiyatı: " + item.Price;
                product.Controls.Add(lblPrice);

                PictureBox photo = new PictureBox();

                photo.Location = new System.Drawing.Point(3, 3);
                photo.Name = "picBoxProduct";
                photo.Size = new System.Drawing.Size(80, 100);
                photo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                photo.TabIndex = 1;
                photo.TabStop = false;
                photo.Image = item.Photo;
                product.Controls.Add(photo);

                Button addToCart = new Button();

                addToCart.Location = new System.Drawing.Point(105, 165);
                addToCart.Name = "btnAddToCard-" + (item.ID).ToString() + "-" + (itemcount).ToString();
                addToCart.Size = new System.Drawing.Size(56, 32);
                addToCart.TabIndex = 5;
                addToCart.Text = "Ekle";
                addToCart.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
                addToCart.UseVisualStyleBackColor = true;
                addToCart.Click += new System.EventHandler(this.btnAddToCard_Click);
                product.Controls.Add(addToCart);

                Label lblprop = new Label();

                lblprop.AutoSize = true;
                lblprop.Location = new System.Drawing.Point(10, 115);
                lblprop.Name = "lblProp";
                lblprop.Size = new System.Drawing.Size(37, 13);
                lblprop.TabIndex = 3;
                lblprop.Text = item.printProperties();
                product.Controls.Add(lblprop);

                NumericUpDown numericCount = new NumericUpDown();

                numericCount.Location = new System.Drawing.Point(70, 170);
                numericCount.Name = "numeric_Count-" + itemcount++;
                numericCount.Size = new System.Drawing.Size(35, 20);
                numericCount.TabIndex = 1;
                numericCount.MouseWheel += NumericUpDown_MouseWheel;
                numericCount.Value = 1;
                product.Controls.Add(numericCount);

                pnlMain.Controls.Add(product);
                if (count != (pnlMain.Size.Width/170)-1)
                    count++;
                else
                {
                    count = 0;
                    colCount++;
                }
            }
        }

        string FilterMagazine = "";
        string FilterMusic = "";
        string FilterBook = "";
        private void chbx_all_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (((CheckBox)sender).Name == "chbx_all")
                {
                    if (((CheckBox)sender).Checked)
                    {
                        chbx_book.Checked = false;
                        chbx_magazine.Checked = false;
                        chbx_music.Checked = false;
                        FilterMagazine = "Magazine";
                        FilterMusic = "MusicCD";
                        FilterBook = "Book";
                    }
                    else
                    {
                        FilterMagazine = "";
                        FilterMusic = "";
                        FilterBook = "";
                    }
                }
                else if (((CheckBox)sender).Name == "chbx_book")
                {
                    if (((CheckBox)sender).Checked)
                    {
                        if (chbx_all.Checked)
                            chbx_all.Checked = false;
                        FilterBook = "Book";
                    }
                    else
                        FilterBook = "";
                }
                else if (((CheckBox)sender).Name == "chbx_magazine")
                {
                    if (((CheckBox)sender).Checked)
                    {
                        if (chbx_all.Checked)
                            chbx_all.Checked = false;
                        FilterMagazine = "Magazine";
                    }
                    else
                        FilterMagazine = "";
                }
                else if (((CheckBox)sender).Name == "chbx_music")
                {
                    if (((CheckBox)sender).Checked)
                    {
                        if (chbx_all.Checked)
                            chbx_all.Checked = false;
                        FilterMusic = "MusicCD";
                    }
                    else
                        FilterMusic = "";
                }
                GenerateDisplayProduct(FilterBook + "-" + FilterMagazine + "-" + FilterMusic);
            }
            catch(Exception)
            {
                MessageBox.Show("Lütfen seçenek seçiniz.");
            }
        }


        private void NumericUpDown_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }
        
        public void RefreshMain()
        {
            GetProduct();
            GenerateDisplayProduct(FilterBook + "-" + FilterMagazine + "-" + FilterMusic);
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            chbx_all.Checked = true;
            RefreshMain();
        }

        private void cmbx_filter_SelectedValueChanged(object sender, EventArgs e)
        {
            RefreshMain();
        }

        /*End Shopping panel*/
    }
}