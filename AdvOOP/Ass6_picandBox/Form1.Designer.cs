namespace Ass6
{
    partial class Form1
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
            this.pic1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.chkFreeze = new System.Windows.Forms.CheckBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openNextFormToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.freezePictureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unfreezePictureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pic1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pic1
            // 
            this.pic1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pic1.Image = global::Ass6.Properties.Resources.Jacksonville;
            this.pic1.Location = new System.Drawing.Point(0, 28);
            this.pic1.Name = "pic1";
            this.pic1.Size = new System.Drawing.Size(769, 395);
            this.pic1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic1.TabIndex = 0;
            this.pic1.TabStop = false;
            this.pic1.Click += new System.EventHandler(this.pic1_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // chkFreeze
            // 
            this.chkFreeze.AutoSize = true;
            this.chkFreeze.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.chkFreeze.Location = new System.Drawing.Point(525, 353);
            this.chkFreeze.Name = "chkFreeze";
            this.chkFreeze.Size = new System.Drawing.Size(213, 35);
            this.chkFreeze.TabIndex = 1;
            this.chkFreeze.Text = "Freeze Picture";
            this.chkFreeze.UseVisualStyleBackColor = true;
            this.chkFreeze.CheckedChanged += new System.EventHandler(this.chkFreeze_CheckedChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(769, 28);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openNextFormToolStripMenuItem,
            this.toolStripMenuItem1,
            this.freezePictureToolStripMenuItem,
            this.unfreezePictureToolStripMenuItem,
            this.toolStripMenuItem2,
            this.quitToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(58, 24);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // openNextFormToolStripMenuItem
            // 
            this.openNextFormToolStripMenuItem.Name = "openNextFormToolStripMenuItem";
            this.openNextFormToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.openNextFormToolStripMenuItem.Text = "Open Next Form";
            this.openNextFormToolStripMenuItem.Click += new System.EventHandler(this.pic1_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(213, 6);
            // 
            // freezePictureToolStripMenuItem
            // 
            this.freezePictureToolStripMenuItem.Name = "freezePictureToolStripMenuItem";
            this.freezePictureToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.freezePictureToolStripMenuItem.Text = "Freeze Picture";
            this.freezePictureToolStripMenuItem.Click += new System.EventHandler(this.freezePictureToolStripMenuItem_Click);
            // 
            // unfreezePictureToolStripMenuItem
            // 
            this.unfreezePictureToolStripMenuItem.Name = "unfreezePictureToolStripMenuItem";
            this.unfreezePictureToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.unfreezePictureToolStripMenuItem.Text = "Unfreeze Picture";
            this.unfreezePictureToolStripMenuItem.Click += new System.EventHandler(this.unfreezePictureToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(213, 6);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 423);
            this.ControlBox = false;
            this.Controls.Add(this.chkFreeze);
            this.Controls.Add(this.pic1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tampa";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pic1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pic1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckBox chkFreeze;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openNextFormToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem freezePictureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unfreezePictureToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
    }
}

