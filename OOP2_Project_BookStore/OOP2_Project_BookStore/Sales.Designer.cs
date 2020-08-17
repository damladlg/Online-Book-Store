namespace OOP2_Project_BookStore
{
    partial class Sales
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Sales));
            this.pnl_mainAddress = new System.Windows.Forms.Panel();
            this.pnl_newAddress = new System.Windows.Forms.Panel();
            this.btn_addressDel = new System.Windows.Forms.Button();
            this.txt_newAddress = new System.Windows.Forms.TextBox();
            this.chbx_choiceNew = new System.Windows.Forms.CheckBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.pnl_defAddress = new System.Windows.Forms.Panel();
            this.txt_defAddress = new System.Windows.Forms.TextBox();
            this.chbx_ChoiceDef = new System.Windows.Forms.CheckBox();
            this.lbl_AddressTitle = new System.Windows.Forms.Label();
            this.lbl_AddressInfo = new System.Windows.Forms.Label();
            this.btn_addressAdd = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbx_paymentType = new System.Windows.Forms.ComboBox();
            this.pnl_mainPayment = new System.Windows.Forms.Panel();
            this.pnl_paymentTypeCash = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pnl_paymentTypeCC = new System.Windows.Forms.Panel();
            this.lbl_cardType = new System.Windows.Forms.Label();
            this.txt_ccNumber = new System.Windows.Forms.TextBox();
            this.picbx_creditcard = new System.Windows.Forms.PictureBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_CCname = new System.Windows.Forms.TextBox();
            this.txt_CCcvs = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbx_PTCCYear = new System.Windows.Forms.ComboBox();
            this.cmbx_PTCCMounth = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.imglst_CreditCard = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_totalPeyment = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lbl_PTotal = new System.Windows.Forms.Label();
            this.btn_placeOrder = new System.Windows.Forms.Button();
            this.btn_cancelOrder = new System.Windows.Forms.Button();
            this.txt_phoneNumber = new System.Windows.Forms.TextBox();
            this.chbx_mail = new System.Windows.Forms.CheckBox();
            this.chbx_phone = new System.Windows.Forms.CheckBox();
            this.pnl_mainAddress.SuspendLayout();
            this.pnl_newAddress.SuspendLayout();
            this.pnl_defAddress.SuspendLayout();
            this.pnl_mainPayment.SuspendLayout();
            this.pnl_paymentTypeCash.SuspendLayout();
            this.pnl_paymentTypeCC.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbx_creditcard)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_mainAddress
            // 
            this.pnl_mainAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_mainAddress.Controls.Add(this.pnl_newAddress);
            this.pnl_mainAddress.Controls.Add(this.pnl_defAddress);
            this.pnl_mainAddress.Controls.Add(this.btn_addressAdd);
            this.pnl_mainAddress.Controls.Add(this.label1);
            this.pnl_mainAddress.Location = new System.Drawing.Point(12, 12);
            this.pnl_mainAddress.Name = "pnl_mainAddress";
            this.pnl_mainAddress.Size = new System.Drawing.Size(534, 219);
            this.pnl_mainAddress.TabIndex = 0;
            this.pnl_mainAddress.Tag = "Address";
            // 
            // pnl_newAddress
            // 
            this.pnl_newAddress.AutoScroll = true;
            this.pnl_newAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_newAddress.Controls.Add(this.btn_addressDel);
            this.pnl_newAddress.Controls.Add(this.txt_newAddress);
            this.pnl_newAddress.Controls.Add(this.chbx_choiceNew);
            this.pnl_newAddress.Controls.Add(this.label14);
            this.pnl_newAddress.Controls.Add(this.label15);
            this.pnl_newAddress.Location = new System.Drawing.Point(264, 56);
            this.pnl_newAddress.Name = "pnl_newAddress";
            this.pnl_newAddress.Size = new System.Drawing.Size(255, 149);
            this.pnl_newAddress.TabIndex = 3;
            this.pnl_newAddress.Visible = false;
            // 
            // btn_addressDel
            // 
            this.btn_addressDel.Location = new System.Drawing.Point(189, 116);
            this.btn_addressDel.Name = "btn_addressDel";
            this.btn_addressDel.Size = new System.Drawing.Size(46, 23);
            this.btn_addressDel.TabIndex = 8;
            this.btn_addressDel.Text = "Sil";
            this.btn_addressDel.UseVisualStyleBackColor = true;
            this.btn_addressDel.Click += new System.EventHandler(this.btn_addressDel_Click);
            // 
            // txt_newAddress
            // 
            this.txt_newAddress.Location = new System.Drawing.Point(54, 34);
            this.txt_newAddress.Multiline = true;
            this.txt_newAddress.Name = "txt_newAddress";
            this.txt_newAddress.Size = new System.Drawing.Size(191, 76);
            this.txt_newAddress.TabIndex = 7;
            // 
            // chbx_choiceNew
            // 
            this.chbx_choiceNew.AutoSize = true;
            this.chbx_choiceNew.Location = new System.Drawing.Point(11, 122);
            this.chbx_choiceNew.Name = "chbx_choiceNew";
            this.chbx_choiceNew.Size = new System.Drawing.Size(45, 17);
            this.chbx_choiceNew.TabIndex = 6;
            this.chbx_choiceNew.Text = "Seç";
            this.chbx_choiceNew.UseVisualStyleBackColor = true;
            this.chbx_choiceNew.CheckedChanged += new System.EventHandler(this.chbx_choiceNew_CheckedChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label14.Location = new System.Drawing.Point(8, 10);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(74, 16);
            this.label14.TabIndex = 5;
            this.label14.Text = "Yeni Adres";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(8, 37);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(40, 13);
            this.label15.TabIndex = 4;
            this.label15.Text = "Adres: ";
            // 
            // pnl_defAddress
            // 
            this.pnl_defAddress.AutoScroll = true;
            this.pnl_defAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_defAddress.Controls.Add(this.txt_defAddress);
            this.pnl_defAddress.Controls.Add(this.chbx_ChoiceDef);
            this.pnl_defAddress.Controls.Add(this.lbl_AddressTitle);
            this.pnl_defAddress.Controls.Add(this.lbl_AddressInfo);
            this.pnl_defAddress.Location = new System.Drawing.Point(13, 56);
            this.pnl_defAddress.Name = "pnl_defAddress";
            this.pnl_defAddress.Size = new System.Drawing.Size(251, 149);
            this.pnl_defAddress.TabIndex = 2;
            // 
            // txt_defAddress
            // 
            this.txt_defAddress.Enabled = false;
            this.txt_defAddress.Location = new System.Drawing.Point(50, 34);
            this.txt_defAddress.Multiline = true;
            this.txt_defAddress.Name = "txt_defAddress";
            this.txt_defAddress.Size = new System.Drawing.Size(192, 76);
            this.txt_defAddress.TabIndex = 9;
            // 
            // chbx_ChoiceDef
            // 
            this.chbx_ChoiceDef.AutoSize = true;
            this.chbx_ChoiceDef.Location = new System.Drawing.Point(9, 122);
            this.chbx_ChoiceDef.Name = "chbx_ChoiceDef";
            this.chbx_ChoiceDef.Size = new System.Drawing.Size(45, 17);
            this.chbx_ChoiceDef.TabIndex = 3;
            this.chbx_ChoiceDef.Text = "Seç";
            this.chbx_ChoiceDef.UseVisualStyleBackColor = true;
            this.chbx_ChoiceDef.CheckedChanged += new System.EventHandler(this.chbx_ChoiceDef_CheckedChanged);
            // 
            // lbl_AddressTitle
            // 
            this.lbl_AddressTitle.AutoSize = true;
            this.lbl_AddressTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_AddressTitle.Location = new System.Drawing.Point(6, 10);
            this.lbl_AddressTitle.Name = "lbl_AddressTitle";
            this.lbl_AddressTitle.Size = new System.Drawing.Size(115, 16);
            this.lbl_AddressTitle.TabIndex = 2;
            this.lbl_AddressTitle.Text = "Kullanıcının adresi";
            // 
            // lbl_AddressInfo
            // 
            this.lbl_AddressInfo.AutoSize = true;
            this.lbl_AddressInfo.Location = new System.Drawing.Point(6, 37);
            this.lbl_AddressInfo.Name = "lbl_AddressInfo";
            this.lbl_AddressInfo.Size = new System.Drawing.Size(40, 13);
            this.lbl_AddressInfo.TabIndex = 0;
            this.lbl_AddressInfo.Text = "Adres: ";
            // 
            // btn_addressAdd
            // 
            this.btn_addressAdd.Location = new System.Drawing.Point(445, 7);
            this.btn_addressAdd.Name = "btn_addressAdd";
            this.btn_addressAdd.Size = new System.Drawing.Size(75, 23);
            this.btn_addressAdd.TabIndex = 1;
            this.btn_addressAdd.Text = "Adres ekle";
            this.btn_addressAdd.UseVisualStyleBackColor = true;
            this.btn_addressAdd.Click += new System.EventHandler(this.btn_addressAdd_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(15, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Adres";
            // 
            // cmbx_paymentType
            // 
            this.cmbx_paymentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbx_paymentType.FormattingEnabled = true;
            this.cmbx_paymentType.Location = new System.Drawing.Point(87, 16);
            this.cmbx_paymentType.Name = "cmbx_paymentType";
            this.cmbx_paymentType.Size = new System.Drawing.Size(184, 21);
            this.cmbx_paymentType.TabIndex = 1;
            this.cmbx_paymentType.SelectedIndexChanged += new System.EventHandler(this.cmbx_paymentType_SelectedIndexChanged);
            // 
            // pnl_mainPayment
            // 
            this.pnl_mainPayment.AutoScroll = true;
            this.pnl_mainPayment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_mainPayment.Controls.Add(this.pnl_paymentTypeCash);
            this.pnl_mainPayment.Controls.Add(this.pnl_paymentTypeCC);
            this.pnl_mainPayment.Controls.Add(this.label2);
            this.pnl_mainPayment.Controls.Add(this.cmbx_paymentType);
            this.pnl_mainPayment.Location = new System.Drawing.Point(12, 249);
            this.pnl_mainPayment.Name = "pnl_mainPayment";
            this.pnl_mainPayment.Size = new System.Drawing.Size(534, 280);
            this.pnl_mainPayment.TabIndex = 2;
            // 
            // pnl_paymentTypeCash
            // 
            this.pnl_paymentTypeCash.AutoScroll = true;
            this.pnl_paymentTypeCash.Controls.Add(this.label10);
            this.pnl_paymentTypeCash.Controls.Add(this.label4);
            this.pnl_paymentTypeCash.Location = new System.Drawing.Point(13, 43);
            this.pnl_paymentTypeCash.Name = "pnl_paymentTypeCash";
            this.pnl_paymentTypeCash.Size = new System.Drawing.Size(509, 227);
            this.pnl_paymentTypeCash.TabIndex = 3;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label10.Location = new System.Drawing.Point(11, 49);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(260, 16);
            this.label10.TabIndex = 4;
            this.label10.Text = "Ödeme işlemi kargo sirketiyle yapılacaktır.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(11, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(170, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "Nakit olarak seçim yaptınız.";
            // 
            // pnl_paymentTypeCC
            // 
            this.pnl_paymentTypeCC.AutoScroll = true;
            this.pnl_paymentTypeCC.Controls.Add(this.lbl_cardType);
            this.pnl_paymentTypeCC.Controls.Add(this.txt_ccNumber);
            this.pnl_paymentTypeCC.Controls.Add(this.picbx_creditcard);
            this.pnl_paymentTypeCC.Controls.Add(this.label9);
            this.pnl_paymentTypeCC.Controls.Add(this.txt_CCname);
            this.pnl_paymentTypeCC.Controls.Add(this.txt_CCcvs);
            this.pnl_paymentTypeCC.Controls.Add(this.label8);
            this.pnl_paymentTypeCC.Controls.Add(this.label7);
            this.pnl_paymentTypeCC.Controls.Add(this.cmbx_PTCCYear);
            this.pnl_paymentTypeCC.Controls.Add(this.cmbx_PTCCMounth);
            this.pnl_paymentTypeCC.Controls.Add(this.label6);
            this.pnl_paymentTypeCC.Controls.Add(this.label5);
            this.pnl_paymentTypeCC.Controls.Add(this.label3);
            this.pnl_paymentTypeCC.Location = new System.Drawing.Point(14, 43);
            this.pnl_paymentTypeCC.Name = "pnl_paymentTypeCC";
            this.pnl_paymentTypeCC.Size = new System.Drawing.Size(509, 227);
            this.pnl_paymentTypeCC.TabIndex = 3;
            // 
            // lbl_cardType
            // 
            this.lbl_cardType.AutoSize = true;
            this.lbl_cardType.Location = new System.Drawing.Point(358, 155);
            this.lbl_cardType.Name = "lbl_cardType";
            this.lbl_cardType.Size = new System.Drawing.Size(0, 13);
            this.lbl_cardType.TabIndex = 99;
            this.lbl_cardType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_ccNumber
            // 
            this.txt_ccNumber.Location = new System.Drawing.Point(169, 54);
            this.txt_ccNumber.Name = "txt_ccNumber";
            this.txt_ccNumber.Size = new System.Drawing.Size(119, 20);
            this.txt_ccNumber.TabIndex = 13;
            this.txt_ccNumber.TextChanged += new System.EventHandler(this.txt_ccNumber_TextChanged);
            // 
            // picbx_creditcard
            // 
            this.picbx_creditcard.Location = new System.Drawing.Point(315, 87);
            this.picbx_creditcard.Name = "picbx_creditcard";
            this.picbx_creditcard.Size = new System.Drawing.Size(128, 128);
            this.picbx_creditcard.TabIndex = 12;
            this.picbx_creditcard.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label9.Location = new System.Drawing.Point(14, 36);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 15);
            this.label9.TabIndex = 9;
            this.label9.Text = "Kart Sahibi";
            // 
            // txt_CCname
            // 
            this.txt_CCname.Location = new System.Drawing.Point(17, 54);
            this.txt_CCname.Name = "txt_CCname";
            this.txt_CCname.Size = new System.Drawing.Size(113, 20);
            this.txt_CCname.TabIndex = 8;
            // 
            // txt_CCcvs
            // 
            this.txt_CCcvs.Location = new System.Drawing.Point(169, 122);
            this.txt_CCcvs.Name = "txt_CCcvs";
            this.txt_CCcvs.Size = new System.Drawing.Size(52, 20);
            this.txt_CCcvs.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(166, 102);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(28, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "CVS";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.Location = new System.Drawing.Point(65, 125);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(12, 16);
            this.label7.TabIndex = 5;
            this.label7.Text = "/";
            // 
            // cmbx_PTCCYear
            // 
            this.cmbx_PTCCYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbx_PTCCYear.FormattingEnabled = true;
            this.cmbx_PTCCYear.Location = new System.Drawing.Point(83, 122);
            this.cmbx_PTCCYear.Name = "cmbx_PTCCYear";
            this.cmbx_PTCCYear.Size = new System.Drawing.Size(50, 21);
            this.cmbx_PTCCYear.TabIndex = 4;
            // 
            // cmbx_PTCCMounth
            // 
            this.cmbx_PTCCMounth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbx_PTCCMounth.FormattingEnabled = true;
            this.cmbx_PTCCMounth.Location = new System.Drawing.Point(20, 122);
            this.cmbx_PTCCMounth.Name = "cmbx_PTCCMounth";
            this.cmbx_PTCCMounth.Size = new System.Drawing.Size(39, 21);
            this.cmbx_PTCCMounth.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(17, 100);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 15);
            this.label6.TabIndex = 3;
            this.label6.Text = "Son kullanım tarihi";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(166, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 15);
            this.label5.TabIndex = 2;
            this.label5.Text = "Kart numarası";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Kredi Kartı/Banka Kartı";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ödeme türü:";
            // 
            // imglst_CreditCard
            // 
            this.imglst_CreditCard.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imglst_CreditCard.ImageStream")));
            this.imglst_CreditCard.TransparentColor = System.Drawing.Color.Transparent;
            this.imglst_CreditCard.Images.SetKeyName(0, "VISA.png");
            this.imglst_CreditCard.Images.SetKeyName(1, "MASTERCARD.png");
            this.imglst_CreditCard.Images.SetKeyName(2, "AEXPRESS.png");
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbl_totalPeyment);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.lbl_PTotal);
            this.panel1.Location = new System.Drawing.Point(552, 14);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(235, 217);
            this.panel1.TabIndex = 4;
            // 
            // lbl_totalPeyment
            // 
            this.lbl_totalPeyment.AutoSize = true;
            this.lbl_totalPeyment.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_totalPeyment.Location = new System.Drawing.Point(18, 131);
            this.lbl_totalPeyment.Name = "lbl_totalPeyment";
            this.lbl_totalPeyment.Size = new System.Drawing.Size(200, 20);
            this.lbl_totalPeyment.TabIndex = 6;
            this.lbl_totalPeyment.Text = "Toplam Ödenecek Tutar";
            this.lbl_totalPeyment.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label11.Location = new System.Drawing.Point(101, 97);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(34, 16);
            this.label11.TabIndex = 5;
            this.label11.Text = "6 TL";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label12.Location = new System.Drawing.Point(77, 72);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(82, 16);
            this.label12.TabIndex = 5;
            this.label12.Text = "Kargo ücreti ";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_PTotal
            // 
            this.lbl_PTotal.AutoSize = true;
            this.lbl_PTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_PTotal.Location = new System.Drawing.Point(71, 21);
            this.lbl_PTotal.Name = "lbl_PTotal";
            this.lbl_PTotal.Size = new System.Drawing.Size(92, 18);
            this.lbl_PTotal.TabIndex = 4;
            this.lbl_PTotal.Text = "Ürün toplamı";
            this.lbl_PTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_placeOrder
            // 
            this.btn_placeOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_placeOrder.Location = new System.Drawing.Point(554, 372);
            this.btn_placeOrder.Name = "btn_placeOrder";
            this.btn_placeOrder.Size = new System.Drawing.Size(235, 51);
            this.btn_placeOrder.TabIndex = 5;
            this.btn_placeOrder.Text = "Siparişi Tamamla";
            this.btn_placeOrder.UseVisualStyleBackColor = true;
            this.btn_placeOrder.Click += new System.EventHandler(this.btn_placeOrder_Click);
            // 
            // btn_cancelOrder
            // 
            this.btn_cancelOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_cancelOrder.Location = new System.Drawing.Point(554, 465);
            this.btn_cancelOrder.Name = "btn_cancelOrder";
            this.btn_cancelOrder.Size = new System.Drawing.Size(235, 51);
            this.btn_cancelOrder.TabIndex = 5;
            this.btn_cancelOrder.Text = "Siparişi İptal Et";
            this.btn_cancelOrder.UseVisualStyleBackColor = true;
            this.btn_cancelOrder.Click += new System.EventHandler(this.btn_cancelOrder_Click);
            // 
            // txt_phoneNumber
            // 
            this.txt_phoneNumber.Location = new System.Drawing.Point(554, 305);
            this.txt_phoneNumber.Name = "txt_phoneNumber";
            this.txt_phoneNumber.Size = new System.Drawing.Size(127, 20);
            this.txt_phoneNumber.TabIndex = 6;
            this.txt_phoneNumber.Visible = false;
            // 
            // chbx_mail
            // 
            this.chbx_mail.AutoSize = true;
            this.chbx_mail.Location = new System.Drawing.Point(554, 249);
            this.chbx_mail.Name = "chbx_mail";
            this.chbx_mail.Size = new System.Drawing.Size(127, 17);
            this.chbx_mail.TabIndex = 7;
            this.chbx_mail.Text = "Mail ile fatura gönder.";
            this.chbx_mail.UseVisualStyleBackColor = true;
            // 
            // chbx_phone
            // 
            this.chbx_phone.AutoSize = true;
            this.chbx_phone.Location = new System.Drawing.Point(554, 282);
            this.chbx_phone.Name = "chbx_phone";
            this.chbx_phone.Size = new System.Drawing.Size(131, 17);
            this.chbx_phone.TabIndex = 7;
            this.chbx_phone.Text = "SMS ile fatura gönder.";
            this.chbx_phone.UseVisualStyleBackColor = true;
            this.chbx_phone.CheckedChanged += new System.EventHandler(this.chbx_phone_CheckedChanged);
            // 
            // Sales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 543);
            this.Controls.Add(this.chbx_phone);
            this.Controls.Add(this.chbx_mail);
            this.Controls.Add(this.txt_phoneNumber);
            this.Controls.Add(this.btn_cancelOrder);
            this.Controls.Add(this.btn_placeOrder);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnl_mainPayment);
            this.Controls.Add(this.pnl_mainAddress);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(817, 582);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(817, 582);
            this.Name = "Sales";
            this.Text = "Satış";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Sales_FormClosing);
            this.Load += new System.EventHandler(this.Sales_Load);
            this.pnl_mainAddress.ResumeLayout(false);
            this.pnl_mainAddress.PerformLayout();
            this.pnl_newAddress.ResumeLayout(false);
            this.pnl_newAddress.PerformLayout();
            this.pnl_defAddress.ResumeLayout(false);
            this.pnl_defAddress.PerformLayout();
            this.pnl_mainPayment.ResumeLayout(false);
            this.pnl_mainPayment.PerformLayout();
            this.pnl_paymentTypeCash.ResumeLayout(false);
            this.pnl_paymentTypeCash.PerformLayout();
            this.pnl_paymentTypeCC.ResumeLayout(false);
            this.pnl_paymentTypeCC.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbx_creditcard)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnl_mainAddress;
        private System.Windows.Forms.Panel pnl_defAddress;
        private System.Windows.Forms.Label lbl_AddressInfo;
        private System.Windows.Forms.Button btn_addressAdd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chbx_ChoiceDef;
        private System.Windows.Forms.Label lbl_AddressTitle;
        private System.Windows.Forms.ComboBox cmbx_paymentType;
        private System.Windows.Forms.Panel pnl_mainPayment;
        private System.Windows.Forms.Panel pnl_newAddress;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnl_paymentTypeCash;
        private System.Windows.Forms.Panel pnl_paymentTypeCC;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbx_PTCCYear;
        private System.Windows.Forms.ComboBox cmbx_PTCCMounth;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_CCcvs;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbl_cardType;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_CCname;
        private System.Windows.Forms.ImageList imglst_CreditCard;
        private System.Windows.Forms.PictureBox picbx_creditcard;
        private System.Windows.Forms.TextBox txt_ccNumber;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_totalPeyment;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lbl_PTotal;
        private System.Windows.Forms.Button btn_placeOrder;
        private System.Windows.Forms.Button btn_cancelOrder;
        private System.Windows.Forms.CheckBox chbx_choiceNew;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btn_addressDel;
        private System.Windows.Forms.TextBox txt_newAddress;
        private System.Windows.Forms.TextBox txt_defAddress;
        private System.Windows.Forms.TextBox txt_phoneNumber;
        private System.Windows.Forms.CheckBox chbx_mail;
        private System.Windows.Forms.CheckBox chbx_phone;
    }
}