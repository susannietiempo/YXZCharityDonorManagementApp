namespace Splash
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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.manageMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolBarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusBarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.giftsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.volunteerProgramsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.volunteerAssignmentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.volunteersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.constituentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addGiftToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addVolunteerHoursToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addVolunteerProgramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addVolunteerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSplitButton2 = new System.Windows.Forms.ToolStripSplitButton();
            this.viewDonorGiftToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewVolunteerAssignmentReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.prgBar = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manageMenu,
            this.reportsMenu,
            this.helpMenu});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1133, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // manageMenu
            // 
            this.manageMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolBarToolStripMenuItem,
            this.statusBarToolStripMenuItem,
            this.giftsToolStripMenuItem,
            this.volunteerProgramsToolStripMenuItem,
            this.volunteerAssignmentsToolStripMenuItem});
            this.manageMenu.Name = "manageMenu";
            this.manageMenu.Size = new System.Drawing.Size(62, 20);
            this.manageMenu.Text = "&Manage";
            // 
            // toolBarToolStripMenuItem
            // 
            this.toolBarToolStripMenuItem.CheckOnClick = true;
            this.toolBarToolStripMenuItem.Name = "toolBarToolStripMenuItem";
            this.toolBarToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.toolBarToolStripMenuItem.Text = "&Users";
            this.toolBarToolStripMenuItem.ToolTipText = "login";
            // 
            // statusBarToolStripMenuItem
            // 
            this.statusBarToolStripMenuItem.CheckOnClick = true;
            this.statusBarToolStripMenuItem.Name = "statusBarToolStripMenuItem";
            this.statusBarToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.statusBarToolStripMenuItem.Tag = "donors";
            this.statusBarToolStripMenuItem.Text = "&Constituents";
            this.statusBarToolStripMenuItem.Click += new System.EventHandler(this.ShowNewForm);
            // 
            // giftsToolStripMenuItem
            // 
            this.giftsToolStripMenuItem.CheckOnClick = true;
            this.giftsToolStripMenuItem.Name = "giftsToolStripMenuItem";
            this.giftsToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.giftsToolStripMenuItem.Tag = "gifts";
            this.giftsToolStripMenuItem.Text = "Gifts";
            this.giftsToolStripMenuItem.Click += new System.EventHandler(this.ShowNewForm);
            // 
            // volunteerProgramsToolStripMenuItem
            // 
            this.volunteerProgramsToolStripMenuItem.CheckOnClick = true;
            this.volunteerProgramsToolStripMenuItem.Name = "volunteerProgramsToolStripMenuItem";
            this.volunteerProgramsToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.volunteerProgramsToolStripMenuItem.Tag = "volunteerprog";
            this.volunteerProgramsToolStripMenuItem.Text = "Volunteer Programs";
            this.volunteerProgramsToolStripMenuItem.Click += new System.EventHandler(this.ShowNewForm);
            // 
            // volunteerAssignmentsToolStripMenuItem
            // 
            this.volunteerAssignmentsToolStripMenuItem.Name = "volunteerAssignmentsToolStripMenuItem";
            this.volunteerAssignmentsToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.volunteerAssignmentsToolStripMenuItem.Tag = "volunteerassn";
            this.volunteerAssignmentsToolStripMenuItem.Text = "Volunteer Assignments";
            this.volunteerAssignmentsToolStripMenuItem.Click += new System.EventHandler(this.ShowNewForm);
            // 
            // reportsMenu
            // 
            this.reportsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem,
            this.volunteersToolStripMenuItem});
            this.reportsMenu.Name = "reportsMenu";
            this.reportsMenu.Size = new System.Drawing.Size(59, 20);
            this.reportsMenu.Text = "&Reports";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.optionsToolStripMenuItem.Tag = "reportgift";
            this.optionsToolStripMenuItem.Text = "&Gifts - Donor";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.ShowNewForm);
            // 
            // volunteersToolStripMenuItem
            // 
            this.volunteersToolStripMenuItem.Name = "volunteersToolStripMenuItem";
            this.volunteersToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.volunteersToolStripMenuItem.Tag = "reportassn";
            this.volunteersToolStripMenuItem.Text = "Volunteer Assignment";
            this.volunteersToolStripMenuItem.Click += new System.EventHandler(this.ShowNewForm);
            // 
            // helpMenu
            // 
            this.helpMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator8});
            this.helpMenu.Name = "helpMenu";
            this.helpMenu.Size = new System.Drawing.Size(52, 20);
            this.helpMenu.Text = "&About";
            this.helpMenu.Click += new System.EventHandler(this.ShowNewForm);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(104, 6);
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSplitButton1,
            this.toolStripSplitButton2,
            this.toolStripButton1});
            this.toolStrip.Location = new System.Drawing.Point(0, 24);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(1133, 25);
            this.toolStrip.TabIndex = 1;
            this.toolStrip.Text = "ToolStrip";
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSplitButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.constituentToolStripMenuItem,
            this.addGiftToolStripMenuItem,
            this.addVolunteerHoursToolStripMenuItem,
            this.addVolunteerProgramToolStripMenuItem,
            this.addVolunteerToolStripMenuItem});
            this.toolStripSplitButton1.Image = global::Splash.Properties.Resources.plusicon20blue;
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(32, 22);
            this.toolStripSplitButton1.Text = "toolStripSplitButton1";
            // 
            // constituentToolStripMenuItem
            // 
            this.constituentToolStripMenuItem.Name = "constituentToolStripMenuItem";
            this.constituentToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.constituentToolStripMenuItem.Tag = "donors";
            this.constituentToolStripMenuItem.Text = "Add Constituent";
            this.constituentToolStripMenuItem.Click += new System.EventHandler(this.ShowNewForm);
            // 
            // addGiftToolStripMenuItem
            // 
            this.addGiftToolStripMenuItem.Name = "addGiftToolStripMenuItem";
            this.addGiftToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.addGiftToolStripMenuItem.Tag = "gifts";
            this.addGiftToolStripMenuItem.Text = "Add Gift";
            this.addGiftToolStripMenuItem.Click += new System.EventHandler(this.ShowNewForm);
            // 
            // addVolunteerHoursToolStripMenuItem
            // 
            this.addVolunteerHoursToolStripMenuItem.Name = "addVolunteerHoursToolStripMenuItem";
            this.addVolunteerHoursToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.addVolunteerHoursToolStripMenuItem.Tag = "volunteerassn";
            this.addVolunteerHoursToolStripMenuItem.Text = "Add Volunteer Hours";
            this.addVolunteerHoursToolStripMenuItem.Click += new System.EventHandler(this.ShowNewForm);
            // 
            // addVolunteerProgramToolStripMenuItem
            // 
            this.addVolunteerProgramToolStripMenuItem.Name = "addVolunteerProgramToolStripMenuItem";
            this.addVolunteerProgramToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.addVolunteerProgramToolStripMenuItem.Tag = "volunteerprog";
            this.addVolunteerProgramToolStripMenuItem.Text = "Add Volunteer Program";
            this.addVolunteerProgramToolStripMenuItem.Click += new System.EventHandler(this.ShowNewForm);
            // 
            // addVolunteerToolStripMenuItem
            // 
            this.addVolunteerToolStripMenuItem.Name = "addVolunteerToolStripMenuItem";
            this.addVolunteerToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.addVolunteerToolStripMenuItem.Tag = "volunteerassn";
            this.addVolunteerToolStripMenuItem.Text = "Add Volunteer";
            this.addVolunteerToolStripMenuItem.Click += new System.EventHandler(this.ShowNewForm);
            // 
            // toolStripSplitButton2
            // 
            this.toolStripSplitButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSplitButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewDonorGiftToolStripMenuItem,
            this.viewVolunteerAssignmentReportToolStripMenuItem});
            this.toolStripSplitButton2.Image = global::Splash.Properties.Resources.report20;
            this.toolStripSplitButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton2.Name = "toolStripSplitButton2";
            this.toolStripSplitButton2.Size = new System.Drawing.Size(32, 22);
            this.toolStripSplitButton2.Text = "toolStripSplitButton2";
            // 
            // viewDonorGiftToolStripMenuItem
            // 
            this.viewDonorGiftToolStripMenuItem.Name = "viewDonorGiftToolStripMenuItem";
            this.viewDonorGiftToolStripMenuItem.Size = new System.Drawing.Size(256, 22);
            this.viewDonorGiftToolStripMenuItem.Text = "View Donor - Gift Report";
            this.viewDonorGiftToolStripMenuItem.Click += new System.EventHandler(this.ShowNewForm);
            // 
            // viewVolunteerAssignmentReportToolStripMenuItem
            // 
            this.viewVolunteerAssignmentReportToolStripMenuItem.Name = "viewVolunteerAssignmentReportToolStripMenuItem";
            this.viewVolunteerAssignmentReportToolStripMenuItem.Size = new System.Drawing.Size(256, 22);
            this.viewVolunteerAssignmentReportToolStripMenuItem.Text = "View Volunteer Assignment Report";
            this.viewVolunteerAssignmentReportToolStripMenuItem.Click += new System.EventHandler(this.ShowNewForm);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::Splash.Properties.Resources.question20xblue;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Tag = "about";
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.Click += new System.EventHandler(this.ShowNewForm);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.prgBar,
            this.toolStripStatusLabel1});
            this.statusStrip.Location = new System.Drawing.Point(0, 709);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1133, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            // 
            // prgBar
            // 
            this.prgBar.Name = "prgBar";
            this.prgBar.Size = new System.Drawing.Size(100, 16);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(39, 17);
            this.toolStripStatusLabel1.Text = "Status";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1133, 731);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.menuStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Donor Management System";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripMenuItem manageMenu;
        private System.Windows.Forms.ToolStripMenuItem toolBarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem statusBarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportsMenu;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpMenu;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        internal System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        internal System.Windows.Forms.StatusStrip statusStrip;
        internal System.Windows.Forms.ToolStripProgressBar prgBar;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton1;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton2;
        private System.Windows.Forms.ToolStripMenuItem giftsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem volunteerProgramsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem volunteerAssignmentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem volunteersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem constituentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addGiftToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addVolunteerHoursToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addVolunteerProgramToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addVolunteerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewDonorGiftToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewVolunteerAssignmentReportToolStripMenuItem;
    }
}



