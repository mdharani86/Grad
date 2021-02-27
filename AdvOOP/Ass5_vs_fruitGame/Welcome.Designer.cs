namespace Ass5_vs
{
    partial class Welcome
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
            this.labWelcome = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labWelcome
            // 
            this.labWelcome.AutoSize = true;
            this.labWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labWelcome.ForeColor = System.Drawing.Color.Green;
            this.labWelcome.Location = new System.Drawing.Point(35, 30);
            this.labWelcome.Name = "labWelcome";
            this.labWelcome.Size = new System.Drawing.Size(64, 25);
            this.labWelcome.TabIndex = 0;
            this.labWelcome.Text = "label1";
            this.labWelcome.DoubleClick += new System.EventHandler(this.labWelcome_DoubleClick);
            // 
            // Welcome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1080, 372);
            this.Controls.Add(this.labWelcome);
            this.Name = "Welcome";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Welcome";
            this.Load += new System.EventHandler(this.Welcome_Load);
            this.DoubleClick += new System.EventHandler(this.Welcome_DoubleClick);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labWelcome;
    }
}