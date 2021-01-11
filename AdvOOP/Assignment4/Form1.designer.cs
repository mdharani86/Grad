namespace Ass4_vs
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
            this.txtNum1 = new System.Windows.Forms.TextBox();
            this.lab1 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNum2 = new System.Windows.Forms.TextBox();
            this.btnEnter = new System.Windows.Forms.Button();
            this.labRandom1 = new System.Windows.Forms.Label();
            this.labRandom2 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnAvg = new System.Windows.Forms.Button();
            this.btnMod = new System.Windows.Forms.Button();
            this.btnDiv = new System.Windows.Forms.Button();
            this.btnMul = new System.Windows.Forms.Button();
            this.btnSub = new System.Windows.Forms.Button();
            this.labResult = new System.Windows.Forms.Label();
            this.labAbove = new System.Windows.Forms.Label();
            this.labBelow = new System.Windows.Forms.Label();
            this.labBetween = new System.Windows.Forms.Label();
            this.labInErr = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtNum1
            // 
            this.txtNum1.BackColor = System.Drawing.Color.Aqua;
            this.txtNum1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNum1.Location = new System.Drawing.Point(265, 39);
            this.txtNum1.Margin = new System.Windows.Forms.Padding(4);
            this.txtNum1.Name = "txtNum1";
            this.txtNum1.Size = new System.Drawing.Size(147, 45);
            this.txtNum1.TabIndex = 0;
            // 
            // lab1
            // 
            this.lab1.AutoSize = true;
            this.lab1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab1.Location = new System.Drawing.Point(35, 50);
            this.lab1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lab1.Name = "lab1";
            this.lab1.Size = new System.Drawing.Size(194, 29);
            this.lab1.TabIndex = 2;
            this.lab1.Text = "Enter 1st integer:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(35, 124);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(203, 29);
            this.label1.TabIndex = 4;
            this.label1.Text = "Enter 2nd integer:";
            // 
            // txtNum2
            // 
            this.txtNum2.BackColor = System.Drawing.Color.Aqua;
            this.txtNum2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNum2.Location = new System.Drawing.Point(265, 113);
            this.txtNum2.Margin = new System.Windows.Forms.Padding(4);
            this.txtNum2.Name = "txtNum2";
            this.txtNum2.Size = new System.Drawing.Size(147, 45);
            this.txtNum2.TabIndex = 3;
            // 
            // btnEnter
            // 
            this.btnEnter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnEnter.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnter.ForeColor = System.Drawing.Color.Red;
            this.btnEnter.Location = new System.Drawing.Point(464, 113);
            this.btnEnter.Margin = new System.Windows.Forms.Padding(4);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(116, 46);
            this.btnEnter.TabIndex = 5;
            this.btnEnter.Text = "Enter";
            this.btnEnter.UseVisualStyleBackColor = false;
            this.btnEnter.Click += new System.EventHandler(this.btnEnter_Click);
            // 
            // labRandom1
            // 
            this.labRandom1.AutoSize = true;
            this.labRandom1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.labRandom1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.labRandom1.ForeColor = System.Drawing.Color.Magenta;
            this.labRandom1.Location = new System.Drawing.Point(264, 171);
            this.labRandom1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labRandom1.Name = "labRandom1";
            this.labRandom1.Size = new System.Drawing.Size(36, 39);
            this.labRandom1.TabIndex = 6;
            this.labRandom1.Text = "?";
            // 
            // labRandom2
            // 
            this.labRandom2.AutoSize = true;
            this.labRandom2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.labRandom2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.labRandom2.ForeColor = System.Drawing.Color.Magenta;
            this.labRandom2.Location = new System.Drawing.Point(264, 235);
            this.labRandom2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labRandom2.Name = "labRandom2";
            this.labRandom2.Size = new System.Drawing.Size(36, 39);
            this.labRandom2.TabIndex = 7;
            this.labRandom2.Text = "?";
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.Black;
            this.btnAdd.Location = new System.Drawing.Point(265, 294);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(48, 46);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "+";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnAvg
            // 
            this.btnAvg.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnAvg.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAvg.ForeColor = System.Drawing.Color.Black;
            this.btnAvg.Location = new System.Drawing.Point(545, 294);
            this.btnAvg.Margin = new System.Windows.Forms.Padding(4);
            this.btnAvg.Name = "btnAvg";
            this.btnAvg.Size = new System.Drawing.Size(71, 46);
            this.btnAvg.TabIndex = 9;
            this.btnAvg.Text = "Avg";
            this.btnAvg.UseVisualStyleBackColor = false;
            this.btnAvg.Click += new System.EventHandler(this.btnAvg_Click);
            // 
            // btnMod
            // 
            this.btnMod.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnMod.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMod.ForeColor = System.Drawing.Color.Black;
            this.btnMod.Location = new System.Drawing.Point(489, 294);
            this.btnMod.Margin = new System.Windows.Forms.Padding(4);
            this.btnMod.Name = "btnMod";
            this.btnMod.Size = new System.Drawing.Size(48, 46);
            this.btnMod.TabIndex = 10;
            this.btnMod.Text = "%";
            this.btnMod.UseVisualStyleBackColor = false;
            this.btnMod.Click += new System.EventHandler(this.btnMod_Click);
            // 
            // btnDiv
            // 
            this.btnDiv.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnDiv.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDiv.ForeColor = System.Drawing.Color.Black;
            this.btnDiv.Location = new System.Drawing.Point(433, 294);
            this.btnDiv.Margin = new System.Windows.Forms.Padding(4);
            this.btnDiv.Name = "btnDiv";
            this.btnDiv.Size = new System.Drawing.Size(48, 46);
            this.btnDiv.TabIndex = 11;
            this.btnDiv.Text = "/";
            this.btnDiv.UseVisualStyleBackColor = false;
            this.btnDiv.Click += new System.EventHandler(this.btnDiv_Click);
            // 
            // btnMul
            // 
            this.btnMul.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnMul.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMul.ForeColor = System.Drawing.Color.Black;
            this.btnMul.Location = new System.Drawing.Point(377, 294);
            this.btnMul.Margin = new System.Windows.Forms.Padding(4);
            this.btnMul.Name = "btnMul";
            this.btnMul.Size = new System.Drawing.Size(48, 46);
            this.btnMul.TabIndex = 12;
            this.btnMul.Text = "*";
            this.btnMul.UseVisualStyleBackColor = false;
            this.btnMul.Click += new System.EventHandler(this.btnMul_Click);
            // 
            // btnSub
            // 
            this.btnSub.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnSub.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSub.ForeColor = System.Drawing.Color.Black;
            this.btnSub.Location = new System.Drawing.Point(321, 294);
            this.btnSub.Margin = new System.Windows.Forms.Padding(4);
            this.btnSub.Name = "btnSub";
            this.btnSub.Size = new System.Drawing.Size(48, 46);
            this.btnSub.TabIndex = 13;
            this.btnSub.Text = "-";
            this.btnSub.UseVisualStyleBackColor = false;
            this.btnSub.Click += new System.EventHandler(this.btnSub_Click);
            // 
            // labResult
            // 
            this.labResult.AutoSize = true;
            this.labResult.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.labResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.labResult.ForeColor = System.Drawing.Color.Yellow;
            this.labResult.Location = new System.Drawing.Point(264, 362);
            this.labResult.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labResult.Name = "labResult";
            this.labResult.Size = new System.Drawing.Size(36, 39);
            this.labResult.TabIndex = 14;
            this.labResult.Text = "?";
            // 
            // labAbove
            // 
            this.labAbove.AutoSize = true;
            this.labAbove.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labAbove.Location = new System.Drawing.Point(53, 413);
            this.labAbove.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labAbove.Name = "labAbove";
            this.labAbove.Size = new System.Drawing.Size(81, 29);
            this.labAbove.TabIndex = 15;
            this.labAbove.Text = "Above";
            // 
            // labBelow
            // 
            this.labBelow.AutoSize = true;
            this.labBelow.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labBelow.Location = new System.Drawing.Point(53, 467);
            this.labBelow.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labBelow.Name = "labBelow";
            this.labBelow.Size = new System.Drawing.Size(81, 29);
            this.labBelow.TabIndex = 16;
            this.labBelow.Text = "Below";
            // 
            // labBetween
            // 
            this.labBetween.AutoSize = true;
            this.labBetween.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labBetween.Location = new System.Drawing.Point(53, 517);
            this.labBetween.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labBetween.Name = "labBetween";
            this.labBetween.Size = new System.Drawing.Size(108, 29);
            this.labBetween.TabIndex = 17;
            this.labBetween.Text = "Between";
            // 
            // labInErr
            // 
            this.labInErr.AutoSize = true;
            this.labInErr.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labInErr.ForeColor = System.Drawing.Color.Red;
            this.labInErr.Location = new System.Drawing.Point(429, 50);
            this.labInErr.Name = "labInErr";
            this.labInErr.Size = new System.Drawing.Size(0, 20);
            this.labInErr.TabIndex = 18;
            this.labInErr.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(908, 555);
            this.Controls.Add(this.labInErr);
            this.Controls.Add(this.labBetween);
            this.Controls.Add(this.labBelow);
            this.Controls.Add(this.labAbove);
            this.Controls.Add(this.labResult);
            this.Controls.Add(this.btnSub);
            this.Controls.Add(this.btnMul);
            this.Controls.Add(this.btnDiv);
            this.Controls.Add(this.btnMod);
            this.Controls.Add(this.btnAvg);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.labRandom2);
            this.Controls.Add(this.labRandom1);
            this.Controls.Add(this.btnEnter);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNum2);
            this.Controls.Add(this.lab1);
            this.Controls.Add(this.txtNum1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";            
            this.DoubleClick += new System.EventHandler(this.Form1_DoubleClick);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNum1;
        private System.Windows.Forms.Label lab1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNum2;
        private System.Windows.Forms.Button btnEnter;
        private System.Windows.Forms.Label labRandom1;
        private System.Windows.Forms.Label labRandom2;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnAvg;
        private System.Windows.Forms.Button btnMod;
        private System.Windows.Forms.Button btnDiv;
        private System.Windows.Forms.Button btnMul;
        private System.Windows.Forms.Button btnSub;
        private System.Windows.Forms.Label labResult;
        private System.Windows.Forms.Label labAbove;
        private System.Windows.Forms.Label labBelow;
        private System.Windows.Forms.Label labBetween;
        private System.Windows.Forms.Label labInErr;
    }
}

