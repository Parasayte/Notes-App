namespace menustrip
{
    partial class menu
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Selectall = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newNameToolStripMenuItem = new System.Windows.Forms.ToolStripTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.Selectall);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(8, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(804, 94);
            this.panel1.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.Image = global::menustrip.Properties.Resources.Hopstarter_Sleek_Xp_Basic_Folder_Open_24;
            this.label4.Location = new System.Drawing.Point(182, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 20);
            this.label4.TabIndex = 3;
            this.label4.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.DarkGray;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label3.Location = new System.Drawing.Point(220, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(2, 20);
            this.label3.TabIndex = 2;
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // Selectall
            // 
            this.Selectall.Image = global::menustrip.Properties.Resources.Hopstarter_Sleek_Xp_Basic_Copy_48;
            this.Selectall.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Selectall.Location = new System.Drawing.Point(89, 9);
            this.Selectall.Name = "Selectall";
            this.Selectall.Size = new System.Drawing.Size(81, 71);
            this.Selectall.TabIndex = 1;
            this.Selectall.Text = "Select All";
            this.Selectall.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Selectall.Click += new System.EventHandler(this.Selectall_Click);
            // 
            // label2
            // 
            this.label2.Enabled = false;
            this.label2.Image = global::menustrip.Properties.Resources.Hopstarter_Sleek_Xp_Basic_Close_48;
            this.label2.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label2.Location = new System.Drawing.Point(2, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 71);
            this.label2.TabIndex = 0;
            this.label2.Text = "Delete";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.fileNameToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(824, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Image = global::menustrip.Properties.Resources.Hopstarter_Sleek_Xp_Basic_Applications_Cascade_16;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.fileToolStripMenuItem.Text = "File";
            this.fileToolStripMenuItem.Click += new System.EventHandler(this.fileToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = global::menustrip.Properties.Resources.Hopstarter_Sleek_Xp_Basic_Cancel_16;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(93, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // fileNameToolStripMenuItem
            // 
            this.fileNameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.renameToolStripMenuItem});
            this.fileNameToolStripMenuItem.Image = global::menustrip.Properties.Resources.Hopstarter_Soft_Scraps_Button_Blank_Green_16;
            this.fileNameToolStripMenuItem.Name = "fileNameToolStripMenuItem";
            this.fileNameToolStripMenuItem.Size = new System.Drawing.Size(88, 20);
            this.fileNameToolStripMenuItem.Text = "File Name";
            // 
            // renameToolStripMenuItem
            // 
            this.renameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newNameToolStripMenuItem});
            this.renameToolStripMenuItem.Image = global::menustrip.Properties.Resources.Hopstarter_Sleek_Xp_Basic_Pen_16;
            this.renameToolStripMenuItem.Name = "renameToolStripMenuItem";
            this.renameToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.renameToolStripMenuItem.Text = "Rename";
            this.renameToolStripMenuItem.Click += new System.EventHandler(this.renameToolStripMenuItem_Click);
            // 
            // newNameToolStripMenuItem
            // 
            this.newNameToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.newNameToolStripMenuItem.Name = "newNameToolStripMenuItem";
            this.newNameToolStripMenuItem.Size = new System.Drawing.Size(180, 23);
            this.newNameToolStripMenuItem.Text = "New Name";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Image = global::menustrip.Properties.Resources.P;
            this.label1.Location = new System.Drawing.Point(743, 378);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 72);
            this.label1.TabIndex = 4;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(824, 450);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Name = "menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Files Menu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.menu_FormClosing);
            this.Load += new System.EventHandler(this.menu_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label Selectall;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolStripMenuItem fileNameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem renameToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox newNameToolStripMenuItem;
    }
}