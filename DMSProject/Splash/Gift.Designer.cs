namespace Splash
{
    partial class Gift
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
            this.panelIcons = new System.Windows.Forms.Panel();
            this.label21 = new System.Windows.Forms.Label();
            this.picBoxVolunteer = new System.Windows.Forms.PictureBox();
            this.label20 = new System.Windows.Forms.Label();
            this.picBoxGift = new System.Windows.Forms.PictureBox();
            this.label19 = new System.Windows.Forms.Label();
            this.picBoxDonor = new System.Windows.Forms.PictureBox();
            this.label18 = new System.Windows.Forms.Label();
            this.picReports = new System.Windows.Forms.PictureBox();
            this.label17 = new System.Windows.Forms.Label();
            this.picBoxHome = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelLogout = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.picBoxLogo = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSaveDelete = new System.Windows.Forms.Button();
            this.panelGift = new System.Windows.Forms.Panel();
            this.cboDonorName = new System.Windows.Forms.ComboBox();
            this.txtGiftNote = new System.Windows.Forms.TextBox();
            this.btnLast = new System.Windows.Forms.Button();
            this.btnFirst = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.txtFund = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtCampaign = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtApproach = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtGiftType = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtReceivedAmount = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDate = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtGiftId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.errProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.panelIcons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxVolunteer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxGift)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxDonor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picReports)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxHome)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxLogo)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panelGift.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // panelIcons
            // 
            this.panelIcons.Controls.Add(this.label21);
            this.panelIcons.Controls.Add(this.picBoxVolunteer);
            this.panelIcons.Controls.Add(this.label20);
            this.panelIcons.Controls.Add(this.picBoxGift);
            this.panelIcons.Controls.Add(this.label19);
            this.panelIcons.Controls.Add(this.picBoxDonor);
            this.panelIcons.Controls.Add(this.label18);
            this.panelIcons.Controls.Add(this.picReports);
            this.panelIcons.Controls.Add(this.label17);
            this.panelIcons.Controls.Add(this.picBoxHome);
            this.panelIcons.Location = new System.Drawing.Point(387, 38);
            this.panelIcons.Name = "panelIcons";
            this.panelIcons.Size = new System.Drawing.Size(368, 57);
            this.panelIcons.TabIndex = 10;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Roboto Condensed", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(58)))), ((int)(((byte)(58)))));
            this.label21.Location = new System.Drawing.Point(277, 43);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(53, 13);
            this.label21.TabIndex = 23;
            this.label21.Text = "Volunteers";
            // 
            // picBoxVolunteer
            // 
            this.picBoxVolunteer.BackgroundImage = global::Splash.Properties.Resources.volunteericongray;
            this.picBoxVolunteer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.picBoxVolunteer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picBoxVolunteer.Location = new System.Drawing.Point(286, 2);
            this.picBoxVolunteer.Name = "picBoxVolunteer";
            this.picBoxVolunteer.Size = new System.Drawing.Size(37, 38);
            this.picBoxVolunteer.TabIndex = 22;
            this.picBoxVolunteer.TabStop = false;
            this.picBoxVolunteer.Tag = "volunteers";
            this.picBoxVolunteer.Click += new System.EventHandler(this.ShowNewForm);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Roboto Condensed", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(58)))), ((int)(((byte)(58)))));
            this.label20.Location = new System.Drawing.Point(230, 42);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(28, 13);
            this.label20.TabIndex = 21;
            this.label20.Text = "Gifts";
            // 
            // picBoxGift
            // 
            this.picBoxGift.BackgroundImage = global::Splash.Properties.Resources.gifticongray;
            this.picBoxGift.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.picBoxGift.Cursor = System.Windows.Forms.Cursors.No;
            this.picBoxGift.Location = new System.Drawing.Point(227, 1);
            this.picBoxGift.Name = "picBoxGift";
            this.picBoxGift.Size = new System.Drawing.Size(37, 38);
            this.picBoxGift.TabIndex = 20;
            this.picBoxGift.TabStop = false;
            this.picBoxGift.Tag = "gifts";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Roboto Condensed", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(58)))), ((int)(((byte)(58)))));
            this.label19.Location = new System.Drawing.Point(169, 42);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(38, 13);
            this.label19.TabIndex = 19;
            this.label19.Text = "Donors";
            // 
            // picBoxDonor
            // 
            this.picBoxDonor.BackgroundImage = global::Splash.Properties.Resources.donoricon;
            this.picBoxDonor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.picBoxDonor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picBoxDonor.Location = new System.Drawing.Point(166, 1);
            this.picBoxDonor.Name = "picBoxDonor";
            this.picBoxDonor.Size = new System.Drawing.Size(37, 38);
            this.picBoxDonor.TabIndex = 18;
            this.picBoxDonor.TabStop = false;
            this.picBoxDonor.Tag = "donors";
            this.picBoxDonor.Click += new System.EventHandler(this.ShowNewForm);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label18.Font = new System.Drawing.Font("Roboto Condensed", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(58)))), ((int)(((byte)(58)))));
            this.label18.Location = new System.Drawing.Point(103, 41);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(40, 13);
            this.label18.TabIndex = 17;
            this.label18.Tag = "reportshome";
            this.label18.Text = "Reports";
            // 
            // picReports
            // 
            this.picReports.BackgroundImage = global::Splash.Properties.Resources.plusicon;
            this.picReports.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.picReports.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picReports.Image = global::Splash.Properties.Resources.reporticon;
            this.picReports.Location = new System.Drawing.Point(105, 0);
            this.picReports.Name = "picReports";
            this.picReports.Size = new System.Drawing.Size(37, 38);
            this.picReports.TabIndex = 16;
            this.picReports.TabStop = false;
            this.picReports.Tag = "reportshome";
            this.picReports.Click += new System.EventHandler(this.ShowNewForm);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Roboto Condensed", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(58)))), ((int)(((byte)(58)))));
            this.label17.Location = new System.Drawing.Point(42, 41);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(33, 13);
            this.label17.TabIndex = 15;
            this.label17.Text = "Home";
            // 
            // picBoxHome
            // 
            this.picBoxHome.BackgroundImage = global::Splash.Properties.Resources.homeicon37;
            this.picBoxHome.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.picBoxHome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picBoxHome.Location = new System.Drawing.Point(39, 0);
            this.picBoxHome.Name = "picBoxHome";
            this.picBoxHome.Size = new System.Drawing.Size(37, 38);
            this.picBoxHome.TabIndex = 14;
            this.picBoxHome.TabStop = false;
            this.picBoxHome.Tag = "home";
            this.picBoxHome.Click += new System.EventHandler(this.ShowNewForm);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(194)))), ((int)(((byte)(115)))));
            this.panel1.Controls.Add(this.labelLogout);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.picBoxLogo);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-2, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1129, 37);
            this.panel1.TabIndex = 9;
            // 
            // labelLogout
            // 
            this.labelLogout.AutoSize = true;
            this.labelLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelLogout.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLogout.ForeColor = System.Drawing.Color.Gainsboro;
            this.labelLogout.Location = new System.Drawing.Point(1018, 12);
            this.labelLogout.Name = "labelLogout";
            this.labelLogout.Size = new System.Drawing.Size(47, 14);
            this.labelLogout.TabIndex = 4;
            this.labelLogout.Text = "LogOut";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Splash.Properties.Resources.accounticon;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Location = new System.Drawing.Point(958, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 37);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // picBoxLogo
            // 
            this.picBoxLogo.BackgroundImage = global::Splash.Properties.Resources.petonly;
            this.picBoxLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.picBoxLogo.Location = new System.Drawing.Point(24, 0);
            this.picBoxLogo.Name = "picBoxLogo";
            this.picBoxLogo.Size = new System.Drawing.Size(45, 37);
            this.picBoxLogo.TabIndex = 1;
            this.picBoxLogo.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Roboto", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(75, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "XYZ Charity";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(241)))), ((int)(((byte)(231)))));
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.panelGift);
            this.panel2.Location = new System.Drawing.Point(-2, 94);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1129, 592);
            this.panel2.TabIndex = 8;
            this.panel2.TabStop = true;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightGray;
            this.panel3.Controls.Add(this.btnAdd);
            this.panel3.Controls.Add(this.btnEdit);
            this.panel3.Controls.Add(this.btnCancel);
            this.panel3.Controls.Add(this.btnSaveDelete);
            this.panel3.Location = new System.Drawing.Point(3, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1123, 33);
            this.panel3.TabIndex = 4;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.SeaGreen;
            this.btnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.DialogResult = System.Windows.Forms.DialogResult.No;
            this.btnAdd.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(40, 3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 27);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.SteelBlue;
            this.btnEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEdit.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Location = new System.Drawing.Point(129, 3);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 27);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Gray;
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.No;
            this.btnCancel.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(1004, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 27);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSaveDelete
            // 
            this.btnSaveDelete.BackColor = System.Drawing.Color.IndianRed;
            this.btnSaveDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSaveDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSaveDelete.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveDelete.ForeColor = System.Drawing.Color.White;
            this.btnSaveDelete.Location = new System.Drawing.Point(914, 3);
            this.btnSaveDelete.Name = "btnSaveDelete";
            this.btnSaveDelete.Size = new System.Drawing.Size(75, 27);
            this.btnSaveDelete.TabIndex = 3;
            this.btnSaveDelete.Text = "Delete";
            this.btnSaveDelete.UseVisualStyleBackColor = false;
            this.btnSaveDelete.Click += new System.EventHandler(this.btnSaveDelete_Click);
            // 
            // panelGift
            // 
            this.panelGift.BackColor = System.Drawing.Color.White;
            this.panelGift.Controls.Add(this.cboDonorName);
            this.panelGift.Controls.Add(this.txtGiftNote);
            this.panelGift.Controls.Add(this.btnLast);
            this.panelGift.Controls.Add(this.btnFirst);
            this.panelGift.Controls.Add(this.btnNext);
            this.panelGift.Controls.Add(this.btnPrevious);
            this.panelGift.Controls.Add(this.label11);
            this.panelGift.Controls.Add(this.txtFund);
            this.panelGift.Controls.Add(this.label10);
            this.panelGift.Controls.Add(this.label9);
            this.panelGift.Controls.Add(this.txtCampaign);
            this.panelGift.Controls.Add(this.label8);
            this.panelGift.Controls.Add(this.txtApproach);
            this.panelGift.Controls.Add(this.label7);
            this.panelGift.Controls.Add(this.txtGiftType);
            this.panelGift.Controls.Add(this.label6);
            this.panelGift.Controls.Add(this.txtReceivedAmount);
            this.panelGift.Controls.Add(this.label5);
            this.panelGift.Controls.Add(this.label4);
            this.panelGift.Controls.Add(this.txtDate);
            this.panelGift.Controls.Add(this.label3);
            this.panelGift.Controls.Add(this.txtGiftId);
            this.panelGift.Controls.Add(this.label2);
            this.panelGift.Location = new System.Drawing.Point(11, 43);
            this.panelGift.Name = "panelGift";
            this.panelGift.Size = new System.Drawing.Size(1089, 471);
            this.panelGift.TabIndex = 3;
            // 
            // cboDonorName
            // 
            this.cboDonorName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboDonorName.FormattingEnabled = true;
            this.cboDonorName.Location = new System.Drawing.Point(221, 133);
            this.cboDonorName.Name = "cboDonorName";
            this.cboDonorName.Size = new System.Drawing.Size(204, 21);
            this.cboDonorName.TabIndex = 44;
            this.cboDonorName.SelectedIndexChanged += new System.EventHandler(this.cboDonorName_SelectedIndexChanged);
            // 
            // txtGiftNote
            // 
            this.txtGiftNote.BackColor = System.Drawing.Color.White;
            this.txtGiftNote.Font = new System.Drawing.Font("Roboto Condensed", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGiftNote.Location = new System.Drawing.Point(594, 172);
            this.txtGiftNote.MinimumSize = new System.Drawing.Size(204, 45);
            this.txtGiftNote.Multiline = true;
            this.txtGiftNote.Name = "txtGiftNote";
            this.txtGiftNote.Size = new System.Drawing.Size(204, 80);
            this.txtGiftNote.TabIndex = 43;
            // 
            // btnLast
            // 
            this.btnLast.BackColor = System.Drawing.Color.Gray;
            this.btnLast.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLast.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLast.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLast.ForeColor = System.Drawing.Color.White;
            this.btnLast.Location = new System.Drawing.Point(560, 353);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(75, 27);
            this.btnLast.TabIndex = 42;
            this.btnLast.Text = "Last >>";
            this.btnLast.UseVisualStyleBackColor = false;
            this.btnLast.Click += new System.EventHandler(this.Navigation_Handler);
            // 
            // btnFirst
            // 
            this.btnFirst.BackColor = System.Drawing.Color.Gray;
            this.btnFirst.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnFirst.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFirst.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFirst.ForeColor = System.Drawing.Color.White;
            this.btnFirst.Location = new System.Drawing.Point(325, 353);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(75, 27);
            this.btnFirst.TabIndex = 41;
            this.btnFirst.Text = "<< First";
            this.btnFirst.UseVisualStyleBackColor = false;
            this.btnFirst.Click += new System.EventHandler(this.Navigation_Handler);
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.SteelBlue;
            this.btnNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnNext.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNext.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.ForeColor = System.Drawing.Color.White;
            this.btnNext.Location = new System.Drawing.Point(481, 353);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 27);
            this.btnNext.TabIndex = 40;
            this.btnNext.Text = "Next >";
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.Navigation_Handler);
            // 
            // btnPrevious
            // 
            this.btnPrevious.BackColor = System.Drawing.Color.SteelBlue;
            this.btnPrevious.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPrevious.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrevious.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrevious.ForeColor = System.Drawing.Color.White;
            this.btnPrevious.Location = new System.Drawing.Point(402, 353);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(75, 27);
            this.btnPrevious.TabIndex = 39;
            this.btnPrevious.Text = "< Back";
            this.btnPrevious.UseVisualStyleBackColor = false;
            this.btnPrevious.Click += new System.EventHandler(this.Navigation_Handler);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this.label11.Location = new System.Drawing.Point(183, 273);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(31, 13);
            this.label11.TabIndex = 18;
            this.label11.Text = "Fund";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtFund
            // 
            this.txtFund.BackColor = System.Drawing.Color.White;
            this.txtFund.Font = new System.Drawing.Font("Roboto Condensed", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFund.Location = new System.Drawing.Point(221, 269);
            this.txtFund.Name = "txtFund";
            this.txtFund.Size = new System.Drawing.Size(204, 22);
            this.txtFund.TabIndex = 17;
            this.txtFund.Tag = "Fund";
            this.txtFund.Validating += new System.ComponentModel.CancelEventHandler(this.txt_Validating);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this.label10.Location = new System.Drawing.Point(532, 172);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 13);
            this.label10.TabIndex = 16;
            this.label10.Text = "Gift Note";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this.label9.Location = new System.Drawing.Point(157, 245);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "Campaign";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCampaign
            // 
            this.txtCampaign.BackColor = System.Drawing.Color.White;
            this.txtCampaign.Font = new System.Drawing.Font("Roboto Condensed", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCampaign.Location = new System.Drawing.Point(221, 241);
            this.txtCampaign.Name = "txtCampaign";
            this.txtCampaign.Size = new System.Drawing.Size(204, 22);
            this.txtCampaign.TabIndex = 13;
            this.txtCampaign.Tag = "Campaign";
            this.txtCampaign.Validating += new System.ComponentModel.CancelEventHandler(this.txt_Validating);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this.label8.Location = new System.Drawing.Point(160, 219);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Approach";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtApproach
            // 
            this.txtApproach.BackColor = System.Drawing.Color.White;
            this.txtApproach.Font = new System.Drawing.Font("Roboto Condensed", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApproach.Location = new System.Drawing.Point(221, 215);
            this.txtApproach.Name = "txtApproach";
            this.txtApproach.Size = new System.Drawing.Size(204, 22);
            this.txtApproach.TabIndex = 11;
            this.txtApproach.Tag = "Approach";
            this.txtApproach.Validating += new System.ComponentModel.CancelEventHandler(this.txt_Validating);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this.label7.Location = new System.Drawing.Point(160, 192);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Gift Type";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtGiftType
            // 
            this.txtGiftType.BackColor = System.Drawing.Color.White;
            this.txtGiftType.Font = new System.Drawing.Font("Roboto Condensed", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGiftType.Location = new System.Drawing.Point(221, 187);
            this.txtGiftType.Name = "txtGiftType";
            this.txtGiftType.Size = new System.Drawing.Size(204, 22);
            this.txtGiftType.TabIndex = 9;
            this.txtGiftType.Tag = "Gift Type";
            this.txtGiftType.Validating += new System.ComponentModel.CancelEventHandler(this.txt_Validating);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this.label6.Location = new System.Drawing.Point(123, 163);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "ReceivedAmount";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtReceivedAmount
            // 
            this.txtReceivedAmount.BackColor = System.Drawing.Color.White;
            this.txtReceivedAmount.Font = new System.Drawing.Font("Roboto Condensed", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReceivedAmount.Location = new System.Drawing.Point(221, 159);
            this.txtReceivedAmount.Name = "txtReceivedAmount";
            this.txtReceivedAmount.Size = new System.Drawing.Size(204, 22);
            this.txtReceivedAmount.TabIndex = 7;
            this.txtReceivedAmount.Tag = "Received Amount";
            this.txtReceivedAmount.Validating += new System.ComponentModel.CancelEventHandler(this.txt_Validating);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this.label5.Location = new System.Drawing.Point(145, 134);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Donor Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this.label4.Location = new System.Drawing.Point(535, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Gift Date";
            // 
            // txtDate
            // 
            this.txtDate.BackColor = System.Drawing.Color.White;
            this.txtDate.Font = new System.Drawing.Font("Roboto Condensed", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDate.Location = new System.Drawing.Point(594, 130);
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(204, 22);
            this.txtDate.TabIndex = 3;
            this.txtDate.Tag = "Gift date";
            this.txtDate.Validating += new System.ComponentModel.CancelEventHandler(this.txt_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this.label3.Location = new System.Drawing.Point(175, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Gift ID";
            // 
            // txtGiftId
            // 
            this.txtGiftId.BackColor = System.Drawing.Color.LightGray;
            this.txtGiftId.Location = new System.Drawing.Point(221, 103);
            this.txtGiftId.Name = "txtGiftId";
            this.txtGiftId.Size = new System.Drawing.Size(100, 20);
            this.txtGiftId.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Roboto", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(97, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "Gift Details";
            // 
            // errProvider
            // 
            this.errProvider.ContainerControl = this;
            // 
            // Gift
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1112, 617);
            this.Controls.Add(this.panelIcons);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "Gift";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "gift";
            this.Text = "Gift";
            this.Load += new System.EventHandler(this.Gift_Load);
            this.panelIcons.ResumeLayout(false);
            this.panelIcons.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxVolunteer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxGift)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxDonor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picReports)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxHome)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxLogo)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panelGift.ResumeLayout(false);
            this.panelGift.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelIcons;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.PictureBox picBoxVolunteer;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.PictureBox picBoxGift;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.PictureBox picBoxDonor;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.PictureBox picReports;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.PictureBox picBoxHome;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelLogout;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox picBoxLogo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panelGift;
        private System.Windows.Forms.TextBox txtGiftNote;
        private System.Windows.Forms.Button btnLast;
        private System.Windows.Forms.Button btnFirst;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtFund;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtCampaign;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtApproach;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtGiftType;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtReceivedAmount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtGiftId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSaveDelete;
        private System.Windows.Forms.ComboBox cboDonorName;
        private System.Windows.Forms.ErrorProvider errProvider;
    }
}