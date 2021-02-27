namespace Ass6
{
    partial class Form2
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
            this.btn = new System.Windows.Forms.Button();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.radClock = new System.Windows.Forms.RadioButton();
            this.radCounterClock = new System.Windows.Forms.RadioButton();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.clockwiseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.counterClockwiseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn
            // 
            this.btn.BackColor = System.Drawing.Color.Blue;
            this.btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn.Location = new System.Drawing.Point(0, 0);
            this.btn.Name = "btn";
            this.btn.Size = new System.Drawing.Size(40, 40);
            this.btn.TabIndex = 0;
            this.btn.UseVisualStyleBackColor = false;
            this.btn.Click += new System.EventHandler(this.btn_Click);
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // radClock
            // 
            this.radClock.AutoSize = true;
            this.radClock.Location = new System.Drawing.Point(178, 92);
            this.radClock.Name = "radClock";
            this.radClock.Size = new System.Drawing.Size(90, 21);
            this.radClock.TabIndex = 1;
            this.radClock.Text = "Clockwise";
            this.radClock.UseVisualStyleBackColor = true;
            // 
            // radCounterClock
            // 
            this.radCounterClock.AutoSize = true;
            this.radCounterClock.Checked = true;
            this.radCounterClock.Location = new System.Drawing.Point(178, 119);
            this.radCounterClock.Name = "radCounterClock";
            this.radCounterClock.Size = new System.Drawing.Size(144, 21);
            this.radCounterClock.TabIndex = 2;
            this.radCounterClock.TabStop = true;
            this.radCounterClock.Text = "Counter Clockwise";
            this.radCounterClock.UseVisualStyleBackColor = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clockwiseToolStripMenuItem,
            this.counterClockwiseToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(200, 52);
            // 
            // clockwiseToolStripMenuItem
            // 
            this.clockwiseToolStripMenuItem.Name = "clockwiseToolStripMenuItem";
            this.clockwiseToolStripMenuItem.Size = new System.Drawing.Size(199, 24);
            this.clockwiseToolStripMenuItem.Text = "Clockwise";
            this.clockwiseToolStripMenuItem.Click += new System.EventHandler(this.clockwiseToolStripMenuItem_Click);
            // 
            // counterClockwiseToolStripMenuItem
            // 
            this.counterClockwiseToolStripMenuItem.Name = "counterClockwiseToolStripMenuItem";
            this.counterClockwiseToolStripMenuItem.Size = new System.Drawing.Size(199, 24);
            this.counterClockwiseToolStripMenuItem.Text = "Counter Clockwise";
            this.counterClockwiseToolStripMenuItem.Click += new System.EventHandler(this.counterClockwiseToolStripMenuItem_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 242);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.radClock);
            this.Controls.Add(this.radCounterClock);
            this.Controls.Add(this.btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.DoubleClick += new System.EventHandler(this.Form2_DoubleClick);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.RadioButton radClock;
        private System.Windows.Forms.RadioButton radCounterClock;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem clockwiseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem counterClockwiseToolStripMenuItem;
    }
}