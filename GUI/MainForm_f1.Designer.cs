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
            this.components = new System.ComponentModel.Container();
            this.afisorLocuitori = new System.Windows.Forms.DataGridView();
            this.labelAfisare = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.contextMenuAfisorLocuitori = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.labelNrLocuitori = new System.Windows.Forms.Label();
            this.labelNrInt = new System.Windows.Forms.Label();
            this.contextMenuAfisorLocuitoriRecord = new System.Windows.Forms.ContextMenuStrip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.afisorLocuitori)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // afisorLocuitori
            // 
            this.afisorLocuitori.AllowUserToAddRows = false;
            this.afisorLocuitori.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.afisorLocuitori.Location = new System.Drawing.Point(88, 168);
            this.afisorLocuitori.Name = "afisorLocuitori";
            this.afisorLocuitori.ReadOnly = true;
            this.afisorLocuitori.RowHeadersWidth = 82;
            this.afisorLocuitori.RowTemplate.Height = 33;
            this.afisorLocuitori.Size = new System.Drawing.Size(1406, 550);
            this.afisorLocuitori.TabIndex = 14;
            // 
            // labelAfisare
            // 
            this.labelAfisare.AutoSize = true;
            this.labelAfisare.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelAfisare.Location = new System.Drawing.Point(672, 72);
            this.labelAfisare.Name = "labelAfisare";
            this.labelAfisare.Size = new System.Drawing.Size(248, 37);
            this.labelAfisare.TabIndex = 19;
            this.labelAfisare.Text = "Afisare Locuitori";
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1624, 40);
            this.menuStrip1.TabIndex = 20;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(71, 40);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(184, 44);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.Exit_StripMenu_Click);
            // 
            // contextMenuAfisorLocuitori
            // 
            this.contextMenuAfisorLocuitori.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.contextMenuAfisorLocuitori.Name = "contextMenuAfisorLocuitori";
            this.contextMenuAfisorLocuitori.Size = new System.Drawing.Size(61, 4);
            // 
            // labelNrLocuitori
            // 
            this.labelNrLocuitori.AutoSize = true;
            this.labelNrLocuitori.Location = new System.Drawing.Point(88, 128);
            this.labelNrLocuitori.Name = "labelNrLocuitori";
            this.labelNrLocuitori.Size = new System.Drawing.Size(157, 25);
            this.labelNrLocuitori.TabIndex = 28;
            this.labelNrLocuitori.Text = "Nr. de locuitori:";
            // 
            // labelNrInt
            // 
            this.labelNrInt.AutoSize = true;
            this.labelNrInt.Location = new System.Drawing.Point(240, 128);
            this.labelNrInt.Name = "labelNrInt";
            this.labelNrInt.Size = new System.Drawing.Size(24, 25);
            this.labelNrInt.TabIndex = 29;
            this.labelNrInt.Text = "0";
            // 
            // contextMenuAfisorLocuitoriRecord
            // 
            this.contextMenuAfisorLocuitoriRecord.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.contextMenuAfisorLocuitoriRecord.Name = "contextMenuAfisorLocuitoriRecord";
            this.contextMenuAfisorLocuitoriRecord.Size = new System.Drawing.Size(61, 4);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1624, 779);
            this.Controls.Add(this.labelNrInt);
            this.Controls.Add(this.labelNrLocuitori);
            this.Controls.Add(this.labelAfisare);
            this.Controls.Add(this.afisorLocuitori);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Main Form";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.afisorLocuitori)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView afisorLocuitori;
        private System.Windows.Forms.Label labelAfisare;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ContextMenuStrip contextMenuAfisorLocuitori;
        private System.Windows.Forms.Label labelNrLocuitori;
        private System.Windows.Forms.Label labelNrInt;
        private System.Windows.Forms.ContextMenuStrip contextMenuAfisorLocuitoriRecord;
    }
}

