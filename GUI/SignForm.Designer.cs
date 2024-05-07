namespace GUI
{
    partial class SignForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SignForm));
            this.labelSignIn = new System.Windows.Forms.Label();
            this.buttonSignIn = new System.Windows.Forms.Button();
            this.textLogin = new System.Windows.Forms.TextBox();
            this.textPassword = new System.Windows.Forms.TextBox();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.file_StripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.exit_StripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.labelGuestMode = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.pictureLogin = new System.Windows.Forms.PictureBox();
            this.picturePassword = new System.Windows.Forms.PictureBox();
            this.picturePassShow = new System.Windows.Forms.PictureBox();
            this.picturePassHide = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureLogin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picturePassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picturePassShow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picturePassHide)).BeginInit();
            this.SuspendLayout();
            // 
            // labelSignIn
            // 
            this.labelSignIn.AutoSize = true;
            this.labelSignIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelSignIn.Location = new System.Drawing.Point(110, 62);
            this.labelSignIn.Name = "labelSignIn";
            this.labelSignIn.Size = new System.Drawing.Size(263, 51);
            this.labelSignIn.TabIndex = 0;
            this.labelSignIn.Text = "Autentificare";
            // 
            // buttonSignIn
            // 
            this.buttonSignIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSignIn.Location = new System.Drawing.Point(160, 272);
            this.buttonSignIn.Name = "buttonSignIn";
            this.buttonSignIn.Size = new System.Drawing.Size(150, 50);
            this.buttonSignIn.TabIndex = 1;
            this.buttonSignIn.Text = "Sign in";
            this.buttonSignIn.UseVisualStyleBackColor = true;
            this.buttonSignIn.Click += new System.EventHandler(this.ButtonSignIn_Click);
            // 
            // textLogin
            // 
            this.textLogin.Location = new System.Drawing.Point(144, 144);
            this.textLogin.Name = "textLogin";
            this.textLogin.Size = new System.Drawing.Size(200, 31);
            this.textLogin.TabIndex = 2;
            // 
            // textPassword
            // 
            this.textPassword.Location = new System.Drawing.Point(144, 208);
            this.textPassword.Name = "textPassword";
            this.textPassword.Size = new System.Drawing.Size(200, 31);
            this.textPassword.TabIndex = 4;
            // 
            // menuStrip
            // 
            this.menuStrip.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.file_StripMenu});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(474, 40);
            this.menuStrip.TabIndex = 6;
            this.menuStrip.Text = "menuStrip1";
            // 
            // file_StripMenu
            // 
            this.file_StripMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exit_StripMenu});
            this.file_StripMenu.Name = "file_StripMenu";
            this.file_StripMenu.Size = new System.Drawing.Size(71, 36);
            this.file_StripMenu.Text = "&File";
            // 
            // exit_StripMenu
            // 
            this.exit_StripMenu.Name = "exit_StripMenu";
            this.exit_StripMenu.Size = new System.Drawing.Size(184, 44);
            this.exit_StripMenu.Text = "E&xit";
            this.exit_StripMenu.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // labelGuestMode
            // 
            this.labelGuestMode.AutoSize = true;
            this.labelGuestMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelGuestMode.ForeColor = System.Drawing.SystemColors.Highlight;
            this.labelGuestMode.Location = new System.Drawing.Point(144, 352);
            this.labelGuestMode.Name = "labelGuestMode";
            this.labelGuestMode.Size = new System.Drawing.Size(171, 31);
            this.labelGuestMode.TabIndex = 7;
            this.labelGuestMode.Text = "Guest Mode";
            this.labelGuestMode.Click += new System.EventHandler(this.LabelGuestMode_Click);
            // 
            // pictureLogin
            // 
            this.pictureLogin.Image = ((System.Drawing.Image)(resources.GetObject("pictureLogin.Image")));
            this.pictureLogin.Location = new System.Drawing.Point(72, 136);
            this.pictureLogin.Name = "pictureLogin";
            this.pictureLogin.Size = new System.Drawing.Size(56, 50);
            this.pictureLogin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureLogin.TabIndex = 8;
            this.pictureLogin.TabStop = false;
            // 
            // picturePassword
            // 
            this.picturePassword.Image = ((System.Drawing.Image)(resources.GetObject("picturePassword.Image")));
            this.picturePassword.Location = new System.Drawing.Point(72, 200);
            this.picturePassword.Name = "picturePassword";
            this.picturePassword.Size = new System.Drawing.Size(56, 50);
            this.picturePassword.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picturePassword.TabIndex = 9;
            this.picturePassword.TabStop = false;
            // 
            // picturePassShow
            // 
            this.picturePassShow.Image = ((System.Drawing.Image)(resources.GetObject("picturePassShow.Image")));
            this.picturePassShow.Location = new System.Drawing.Point(360, 200);
            this.picturePassShow.Name = "picturePassShow";
            this.picturePassShow.Size = new System.Drawing.Size(56, 50);
            this.picturePassShow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picturePassShow.TabIndex = 10;
            this.picturePassShow.TabStop = false;
            this.picturePassShow.Click += new System.EventHandler(this.PicturePassShow_Click);
            // 
            // picturePassHide
            // 
            this.picturePassHide.Image = ((System.Drawing.Image)(resources.GetObject("picturePassHide.Image")));
            this.picturePassHide.Location = new System.Drawing.Point(360, 200);
            this.picturePassHide.Name = "picturePassHide";
            this.picturePassHide.Size = new System.Drawing.Size(56, 50);
            this.picturePassHide.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picturePassHide.TabIndex = 11;
            this.picturePassHide.TabStop = false;
            this.picturePassHide.Click += new System.EventHandler(this.PicturePassHide_Click);
            // 
            // SignForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 429);
            this.Controls.Add(this.picturePassHide);
            this.Controls.Add(this.picturePassShow);
            this.Controls.Add(this.picturePassword);
            this.Controls.Add(this.pictureLogin);
            this.Controls.Add(this.labelGuestMode);
            this.Controls.Add(this.textPassword);
            this.Controls.Add(this.textLogin);
            this.Controls.Add(this.buttonSignIn);
            this.Controls.Add(this.labelSignIn);
            this.Controls.Add(this.menuStrip);
            this.MaximizeBox = false;
            this.Name = "SignForm";
            this.Text = "Sign Form";
            this.Load += new System.EventHandler(this.SignForm_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureLogin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picturePassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picturePassShow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picturePassHide)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelSignIn;
        private System.Windows.Forms.Button buttonSignIn;
        private System.Windows.Forms.TextBox textLogin;
        private System.Windows.Forms.TextBox textPassword;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem file_StripMenu;
        private System.Windows.Forms.ToolStripMenuItem exit_StripMenu;
        private System.Windows.Forms.Label labelGuestMode;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.PictureBox pictureLogin;
        private System.Windows.Forms.PictureBox picturePassword;
        private System.Windows.Forms.PictureBox picturePassShow;
        private System.Windows.Forms.PictureBox picturePassHide;
        private System.Windows.Forms.Timer timer1;
    }
}