namespace OOP2_Project_BookStore
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tspbtn_exit = new System.Windows.Forms.ToolStripButton();
            this.tspbtn_hide = new System.Windows.Forms.ToolStripButton();
            this.tspbtn_account = new System.Windows.Forms.ToolStripButton();
            this.tspbtn_logOut = new System.Windows.Forms.ToolStripButton();
            this.tspbtn_admin = new System.Windows.Forms.ToolStripButton();
            this.tspbtnShopCart = new System.Windows.Forms.ToolStripButton();
            this.cms_notifi = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsbtn_visible = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsbtn_exit = new System.Windows.Forms.ToolStripMenuItem();
            this.ntfi_bookstoreicon = new System.Windows.Forms.NotifyIcon(this.components);
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.pnlShopCard = new System.Windows.Forms.Panel();
            this.tmr_hideCard = new System.Windows.Forms.Timer(this.components);
            this.pnl_shopping = new System.Windows.Forms.Panel();
            this.lbl_filter = new System.Windows.Forms.Label();
            this.cmbx_filter = new System.Windows.Forms.ComboBox();
            this.btn_refresh = new System.Windows.Forms.Button();
            this.grp_Type = new System.Windows.Forms.GroupBox();
            this.chbx_music = new System.Windows.Forms.CheckBox();
            this.chbx_all = new System.Windows.Forms.CheckBox();
            this.chbx_magazine = new System.Windows.Forms.CheckBox();
            this.chbx_book = new System.Windows.Forms.CheckBox();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.toolStrip1.SuspendLayout();
            this.cms_notifi.SuspendLayout();
            this.pnl_shopping.SuspendLayout();
            this.grp_Type.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tspbtn_exit,
            this.tspbtn_hide,
            this.tspbtn_account,
            this.tspbtn_logOut,
            this.tspbtn_admin,
            this.tspbtnShopCart});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.toolStrip1.Size = new System.Drawing.Size(1200, 56);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tspbtn_exit
            // 
            this.tspbtn_exit.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tspbtn_exit.Image = ((System.Drawing.Image)(resources.GetObject("tspbtn_exit.Image")));
            this.tspbtn_exit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tspbtn_exit.Name = "tspbtn_exit";
            this.tspbtn_exit.Size = new System.Drawing.Size(52, 53);
            this.tspbtn_exit.Text = "Çıkış";
            this.tspbtn_exit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tspbtn_exit.Click += new System.EventHandler(this.tspbtn_exit_Click);
            // 
            // tspbtn_hide
            // 
            this.tspbtn_hide.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tspbtn_hide.Image = ((System.Drawing.Image)(resources.GetObject("tspbtn_hide.Image")));
            this.tspbtn_hide.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tspbtn_hide.Name = "tspbtn_hide";
            this.tspbtn_hide.Size = new System.Drawing.Size(53, 53);
            this.tspbtn_hide.Text = "Gizle";
            this.tspbtn_hide.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tspbtn_hide.Click += new System.EventHandler(this.tspbtn_hide_Click);
            // 
            // tspbtn_account
            // 
            this.tspbtn_account.Image = ((System.Drawing.Image)(resources.GetObject("tspbtn_account.Image")));
            this.tspbtn_account.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tspbtn_account.Name = "tspbtn_account";
            this.tspbtn_account.Size = new System.Drawing.Size(86, 53);
            this.tspbtn_account.Text = "Hesabım";
            this.tspbtn_account.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tspbtn_account.Click += new System.EventHandler(this.tspbtn_account_Click);
            // 
            // tspbtn_logOut
            // 
            this.tspbtn_logOut.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tspbtn_logOut.Image = global::OOP2_Project_BookStore.Properties.Resources.loggout;
            this.tspbtn_logOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tspbtn_logOut.Name = "tspbtn_logOut";
            this.tspbtn_logOut.Size = new System.Drawing.Size(128, 53);
            this.tspbtn_logOut.Text = "Oturum Kapat";
            this.tspbtn_logOut.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tspbtn_logOut.Click += new System.EventHandler(this.tspbtn_logOut_Click);
            // 
            // tspbtn_admin
            // 
            this.tspbtn_admin.Image = ((System.Drawing.Image)(resources.GetObject("tspbtn_admin.Image")));
            this.tspbtn_admin.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tspbtn_admin.Name = "tspbtn_admin";
            this.tspbtn_admin.Size = new System.Drawing.Size(69, 53);
            this.tspbtn_admin.Text = "Admin";
            this.tspbtn_admin.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tspbtn_admin.Click += new System.EventHandler(this.tspbtn_admin_Click);
            // 
            // tspbtnShopCart
            // 
            this.tspbtnShopCart.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tspbtnShopCart.Image = ((System.Drawing.Image)(resources.GetObject("tspbtnShopCart.Image")));
            this.tspbtnShopCart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tspbtnShopCart.Name = "tspbtnShopCart";
            this.tspbtnShopCart.Size = new System.Drawing.Size(101, 53);
            this.tspbtnShopCart.Text = "Sepetim(0)";
            this.tspbtnShopCart.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tspbtnShopCart.Click += new System.EventHandler(this.tspbtnShopCart_Click);
            this.tspbtnShopCart.MouseEnter += new System.EventHandler(this.tspbtnShopCart_MouseEnter);
            this.tspbtnShopCart.MouseLeave += new System.EventHandler(this.tspbtnShopCart_MouseLeave);
            // 
            // cms_notifi
            // 
            this.cms_notifi.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.cms_notifi.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsbtn_visible,
            this.cmsbtn_exit});
            this.cms_notifi.Name = "cms_notifi";
            this.cms_notifi.Size = new System.Drawing.Size(122, 64);
            // 
            // cmsbtn_visible
            // 
            this.cmsbtn_visible.Name = "cmsbtn_visible";
            this.cmsbtn_visible.Size = new System.Drawing.Size(121, 30);
            this.cmsbtn_visible.Text = "Gizle";
            this.cmsbtn_visible.Click += new System.EventHandler(this.tspbtn_hide_Click);
            // 
            // cmsbtn_exit
            // 
            this.cmsbtn_exit.Name = "cmsbtn_exit";
            this.cmsbtn_exit.Size = new System.Drawing.Size(121, 30);
            this.cmsbtn_exit.Text = "Çıkış";
            this.cmsbtn_exit.Click += new System.EventHandler(this.tspbtn_exit_Click);
            // 
            // ntfi_bookstoreicon
            // 
            this.ntfi_bookstoreicon.ContextMenuStrip = this.cms_notifi;
            this.ntfi_bookstoreicon.Icon = ((System.Drawing.Icon)(resources.GetObject("ntfi_bookstoreicon.Icon")));
            this.ntfi_bookstoreicon.Text = "notifyIcon1";
            this.ntfi_bookstoreicon.Visible = true;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // pnlShopCard
            // 
            this.pnlShopCard.AutoScroll = true;
            this.pnlShopCard.Location = new System.Drawing.Point(882, 65);
            this.pnlShopCard.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlShopCard.Name = "pnlShopCard";
            this.pnlShopCard.Size = new System.Drawing.Size(300, 105);
            this.pnlShopCard.TabIndex = 4;
            this.pnlShopCard.Visible = false;
            this.pnlShopCard.MouseEnter += new System.EventHandler(this.tspbtnShopCart_MouseEnter);
            this.pnlShopCard.MouseLeave += new System.EventHandler(this.tspbtnShopCart_MouseLeave);
            // 
            // tmr_hideCard
            // 
            this.tmr_hideCard.Interval = 500;
            this.tmr_hideCard.Tick += new System.EventHandler(this.tmr_hideCard_Tick);
            // 
            // pnl_shopping
            // 
            this.pnl_shopping.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnl_shopping.Controls.Add(this.lbl_filter);
            this.pnl_shopping.Controls.Add(this.cmbx_filter);
            this.pnl_shopping.Controls.Add(this.btn_refresh);
            this.pnl_shopping.Controls.Add(this.grp_Type);
            this.pnl_shopping.Controls.Add(this.pnlMain);
            this.pnl_shopping.Location = new System.Drawing.Point(18, 63);
            this.pnl_shopping.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnl_shopping.Name = "pnl_shopping";
            this.pnl_shopping.Size = new System.Drawing.Size(991, 607);
            this.pnl_shopping.TabIndex = 6;
            // 
            // lbl_filter
            // 
            this.lbl_filter.AutoSize = true;
            this.lbl_filter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_filter.Location = new System.Drawing.Point(568, 38);
            this.lbl_filter.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_filter.Name = "lbl_filter";
            this.lbl_filter.Size = new System.Drawing.Size(60, 22);
            this.lbl_filter.TabIndex = 5;
            this.lbl_filter.Text = "Filtre: ";
            // 
            // cmbx_filter
            // 
            this.cmbx_filter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbx_filter.FormattingEnabled = true;
            this.cmbx_filter.Location = new System.Drawing.Point(638, 34);
            this.cmbx_filter.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbx_filter.Name = "cmbx_filter";
            this.cmbx_filter.Size = new System.Drawing.Size(235, 28);
            this.cmbx_filter.TabIndex = 4;
            this.cmbx_filter.SelectedValueChanged += new System.EventHandler(this.cmbx_filter_SelectedValueChanged);
            // 
            // btn_refresh
            // 
            this.btn_refresh.Location = new System.Drawing.Point(18, 26);
            this.btn_refresh.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_refresh.Name = "btn_refresh";
            this.btn_refresh.Size = new System.Drawing.Size(112, 35);
            this.btn_refresh.TabIndex = 3;
            this.btn_refresh.Text = "Güncelle";
            this.btn_refresh.UseVisualStyleBackColor = true;
            this.btn_refresh.Click += new System.EventHandler(this.btn_refresh_Click);
            // 
            // grp_Type
            // 
            this.grp_Type.Controls.Add(this.chbx_music);
            this.grp_Type.Controls.Add(this.chbx_all);
            this.grp_Type.Controls.Add(this.chbx_magazine);
            this.grp_Type.Controls.Add(this.chbx_book);
            this.grp_Type.Location = new System.Drawing.Point(162, 12);
            this.grp_Type.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grp_Type.Name = "grp_Type";
            this.grp_Type.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grp_Type.Size = new System.Drawing.Size(380, 58);
            this.grp_Type.TabIndex = 1;
            this.grp_Type.TabStop = false;
            this.grp_Type.Text = "Ürün Türleri";
            // 
            // chbx_music
            // 
            this.chbx_music.AutoSize = true;
            this.chbx_music.Location = new System.Drawing.Point(267, 29);
            this.chbx_music.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chbx_music.Name = "chbx_music";
            this.chbx_music.Size = new System.Drawing.Size(103, 24);
            this.chbx_music.TabIndex = 1;
            this.chbx_music.Text = "Müzik CD";
            this.chbx_music.UseVisualStyleBackColor = true;
            this.chbx_music.CheckedChanged += new System.EventHandler(this.chbx_all_CheckedChanged);
            // 
            // chbx_all
            // 
            this.chbx_all.AutoSize = true;
            this.chbx_all.Location = new System.Drawing.Point(9, 29);
            this.chbx_all.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chbx_all.Name = "chbx_all";
            this.chbx_all.Size = new System.Drawing.Size(76, 24);
            this.chbx_all.TabIndex = 1;
            this.chbx_all.Text = "Hepsi";
            this.chbx_all.UseVisualStyleBackColor = true;
            this.chbx_all.CheckedChanged += new System.EventHandler(this.chbx_all_CheckedChanged);
            // 
            // chbx_magazine
            // 
            this.chbx_magazine.AutoSize = true;
            this.chbx_magazine.Location = new System.Drawing.Point(182, 28);
            this.chbx_magazine.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chbx_magazine.Name = "chbx_magazine";
            this.chbx_magazine.Size = new System.Drawing.Size(73, 24);
            this.chbx_magazine.TabIndex = 1;
            this.chbx_magazine.Text = "Dergi";
            this.chbx_magazine.UseVisualStyleBackColor = true;
            this.chbx_magazine.CheckedChanged += new System.EventHandler(this.chbx_all_CheckedChanged);
            // 
            // chbx_book
            // 
            this.chbx_book.AutoSize = true;
            this.chbx_book.Location = new System.Drawing.Point(98, 29);
            this.chbx_book.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chbx_book.Name = "chbx_book";
            this.chbx_book.Size = new System.Drawing.Size(71, 24);
            this.chbx_book.TabIndex = 1;
            this.chbx_book.Text = "Kitap";
            this.chbx_book.UseVisualStyleBackColor = true;
            this.chbx_book.CheckedChanged += new System.EventHandler(this.chbx_all_CheckedChanged);
            // 
            // pnlMain
            // 
            this.pnlMain.AutoScroll = true;
            this.pnlMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMain.Location = new System.Drawing.Point(18, 80);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(950, 464);
            this.pnlMain.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 692);
            this.Controls.Add(this.pnlShopCard);
            this.Controls.Add(this.pnl_shopping);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.cms_notifi.ResumeLayout(false);
            this.pnl_shopping.ResumeLayout(false);
            this.pnl_shopping.PerformLayout();
            this.grp_Type.ResumeLayout(false);
            this.grp_Type.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tspbtn_exit;
        private System.Windows.Forms.ToolStripButton tspbtn_hide;
        private System.Windows.Forms.ContextMenuStrip cms_notifi;
        private System.Windows.Forms.ToolStripMenuItem cmsbtn_visible;
        private System.Windows.Forms.ToolStripMenuItem cmsbtn_exit;
        private System.Windows.Forms.NotifyIcon ntfi_bookstoreicon;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ToolStripButton tspbtn_logOut;
        private System.Windows.Forms.ToolStripButton tspbtn_admin;
        private System.Windows.Forms.ToolStripButton tspbtn_account;
        private System.Windows.Forms.Panel pnlShopCard;
        public System.Windows.Forms.ToolStripButton tspbtnShopCart;
        private System.Windows.Forms.Timer tmr_hideCard;
        private System.Windows.Forms.Panel pnl_shopping;
        private System.Windows.Forms.GroupBox grp_Type;
        private System.Windows.Forms.CheckBox chbx_music;
        private System.Windows.Forms.CheckBox chbx_all;
        private System.Windows.Forms.CheckBox chbx_magazine;
        private System.Windows.Forms.CheckBox chbx_book;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Button btn_refresh;
        private System.Windows.Forms.Label lbl_filter;
        private System.Windows.Forms.ComboBox cmbx_filter;
    }
}

