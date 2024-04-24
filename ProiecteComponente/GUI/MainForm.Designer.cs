namespace GUI
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
            this.labelLocuitori = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fIleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.afisorLocuitori = new System.Windows.Forms.DataGridView();
            this.buttonAdaugaLocuitor = new System.Windows.Forms.Button();
            this.buttonRefreshLocuitori = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.afisorLocuitori)).BeginInit();
            this.SuspendLayout();
            // 
            // labelLocuitori
            // 
            this.labelLocuitori.AutoSize = true;
            this.labelLocuitori.Font = new System.Drawing.Font("Yu Gothic UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelLocuitori.Location = new System.Drawing.Point(912, 88);
            this.labelLocuitori.Name = "labelLocuitori";
            this.labelLocuitori.Size = new System.Drawing.Size(168, 51);
            this.labelLocuitori.TabIndex = 0;
            this.labelLocuitori.Text = "Locuitori";
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fIleToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1797, 40);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fIleToolStripMenuItem
            // 
            this.fIleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fIleToolStripMenuItem.Name = "fIleToolStripMenuItem";
            this.fIleToolStripMenuItem.Size = new System.Drawing.Size(71, 36);
            this.fIleToolStripMenuItem.Text = "&File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(184, 44);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // afisorLocuitori
            // 
            this.afisorLocuitori.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.afisorLocuitori.Location = new System.Drawing.Point(80, 224);
            this.afisorLocuitori.Name = "afisorLocuitori";
            this.afisorLocuitori.RowHeadersWidth = 82;
            this.afisorLocuitori.RowTemplate.Height = 33;
            this.afisorLocuitori.Size = new System.Drawing.Size(1504, 254);
            this.afisorLocuitori.TabIndex = 3;
            // 
            // buttonAdaugaLocuitor
            // 
            this.buttonAdaugaLocuitor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAdaugaLocuitor.Location = new System.Drawing.Point(664, 584);
            this.buttonAdaugaLocuitor.Name = "buttonAdaugaLocuitor";
            this.buttonAdaugaLocuitor.Size = new System.Drawing.Size(208, 64);
            this.buttonAdaugaLocuitor.TabIndex = 4;
            this.buttonAdaugaLocuitor.Text = "Adauga Locuitor";
            this.buttonAdaugaLocuitor.UseVisualStyleBackColor = true;
            this.buttonAdaugaLocuitor.Click += new System.EventHandler(this.buttonAdaugaLocuitor_Click);
            // 
            // buttonRefreshLocuitori
            // 
            this.buttonRefreshLocuitori.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonRefreshLocuitori.Location = new System.Drawing.Point(1152, 584);
            this.buttonRefreshLocuitori.Name = "buttonRefreshLocuitori";
            this.buttonRefreshLocuitori.Size = new System.Drawing.Size(147, 64);
            this.buttonRefreshLocuitori.TabIndex = 5;
            this.buttonRefreshLocuitori.Text = "Refresh";
            this.buttonRefreshLocuitori.UseVisualStyleBackColor = true;
            this.buttonRefreshLocuitori.Click += new System.EventHandler(this.buttonRefreshLocuitori_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1797, 726);
            this.Controls.Add(this.buttonRefreshLocuitori);
            this.Controls.Add(this.buttonAdaugaLocuitor);
            this.Controls.Add(this.afisorLocuitori);
            this.Controls.Add(this.labelLocuitori);
            this.Controls.Add(this.menuStrip1);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.afisorLocuitori)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelLocuitori;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fIleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.DataGridView afisorLocuitori;
        private System.Windows.Forms.Button buttonAdaugaLocuitor;
        private System.Windows.Forms.Button buttonRefreshLocuitori;
    }
}

