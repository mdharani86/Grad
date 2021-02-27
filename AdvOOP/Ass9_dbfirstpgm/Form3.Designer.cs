namespace Ass9
{
    partial class Form3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            this.btnExit = new System.Windows.Forms.Button();
            this.lblProductSelected = new System.Windows.Forms.Label();
            this.lstProductSelected = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTotalPrice = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnExit.Location = new System.Drawing.Point(189, 402);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(155, 46);
            this.btnExit.TabIndex = 26;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblProductSelected
            // 
            this.lblProductSelected.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.lblProductSelected.ForeColor = System.Drawing.Color.Black;
            this.lblProductSelected.Location = new System.Drawing.Point(43, 44);
            this.lblProductSelected.Name = "lblProductSelected";
            this.lblProductSelected.Size = new System.Drawing.Size(169, 23);
            this.lblProductSelected.TabIndex = 25;
            this.lblProductSelected.Text = "Products Selected:";
            // 
            // lstProductSelected
            // 
            this.lstProductSelected.AllowDrop = true;
            this.lstProductSelected.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lstProductSelected.ForeColor = System.Drawing.Color.Black;
            this.lstProductSelected.FormattingEnabled = true;
            this.lstProductSelected.ItemHeight = 20;
            this.lstProductSelected.Location = new System.Drawing.Point(46, 70);
            this.lstProductSelected.Name = "lstProductSelected";
            this.lstProductSelected.Size = new System.Drawing.Size(455, 244);
            this.lstProductSelected.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(55, 355);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 23);
            this.label1.TabIndex = 27;
            this.label1.Text = "Total Price = ";
            // 
            // lblTotalPrice
            // 
            this.lblTotalPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotalPrice.ForeColor = System.Drawing.Color.Red;
            this.lblTotalPrice.Location = new System.Drawing.Point(165, 355);
            this.lblTotalPrice.Name = "lblTotalPrice";
            this.lblTotalPrice.Size = new System.Drawing.Size(169, 23);
            this.lblTotalPrice.TabIndex = 28;
            this.lblTotalPrice.Text = "$";
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 512);
            this.Controls.Add(this.lblTotalPrice);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.lblProductSelected);
            this.Controls.Add(this.lstProductSelected);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form3";
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblProductSelected;
        private System.Windows.Forms.ListBox lstProductSelected;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTotalPrice;
    }
}