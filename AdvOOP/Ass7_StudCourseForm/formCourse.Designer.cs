namespace Ass7
{
    partial class formCourse
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
            this.btnExit = new System.Windows.Forms.Button();
            this.lbltest = new System.Windows.Forms.Label();
            this.btnStudForm = new System.Windows.Forms.Button();
            this.txtCourseName = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.lblCourseWorkName = new System.Windows.Forms.Label();
            this.comboCourse = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCourseNum = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnExit.Location = new System.Drawing.Point(627, 18);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(155, 38);
            this.btnExit.TabIndex = 30;
            this.btnExit.Text = "Exit Application";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lbltest
            // 
            this.lbltest.AutoSize = true;
            this.lbltest.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lbltest.Location = new System.Drawing.Point(549, 115);
            this.lbltest.Name = "lbltest";
            this.lbltest.Size = new System.Drawing.Size(0, 20);
            this.lbltest.TabIndex = 26;
            // 
            // btnStudForm
            // 
            this.btnStudForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnStudForm.Location = new System.Drawing.Point(553, 375);
            this.btnStudForm.Name = "btnStudForm";
            this.btnStudForm.Size = new System.Drawing.Size(209, 46);
            this.btnStudForm.TabIndex = 25;
            this.btnStudForm.Text = "Student Form";
            this.btnStudForm.UseVisualStyleBackColor = true;
            this.btnStudForm.Click += new System.EventHandler(this.btnStudForm_Click);
            // 
            // txtCourseName
            // 
            this.txtCourseName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtCourseName.Location = new System.Drawing.Point(228, 213);
            this.txtCourseName.Name = "txtCourseName";
            this.txtCourseName.Size = new System.Drawing.Size(239, 30);
            this.txtCourseName.TabIndex = 22;
            // 
            // btnClear
            // 
            this.btnClear.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnClear.Location = new System.Drawing.Point(84, 375);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(114, 46);
            this.btnClear.TabIndex = 24;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnSubmit.Location = new System.Drawing.Point(242, 375);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(114, 46);
            this.btnSubmit.TabIndex = 23;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // lblCourseWorkName
            // 
            this.lblCourseWorkName.AutoSize = true;
            this.lblCourseWorkName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblCourseWorkName.Location = new System.Drawing.Point(19, 218);
            this.lblCourseWorkName.Name = "lblCourseWorkName";
            this.lblCourseWorkName.Size = new System.Drawing.Size(191, 25);
            this.lblCourseWorkName.TabIndex = 27;
            this.lblCourseWorkName.Text = "Course Work Name:";
            // 
            // comboCourse
            // 
            this.comboCourse.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.comboCourse.FormattingEnabled = true;
            this.comboCourse.Items.AddRange(new object[] {
            "Assignment",
            "Discussion",
            "Project",
            "Quiz",
            "Exam"});
            this.comboCourse.Location = new System.Drawing.Point(228, 133);
            this.comboCourse.Name = "comboCourse";
            this.comboCourse.Size = new System.Drawing.Size(239, 33);
            this.comboCourse.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(64, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 25);
            this.label2.TabIndex = 28;
            this.label2.Text = "Course Work:";
            // 
            // txtCourseNum
            // 
            this.txtCourseNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtCourseNum.Location = new System.Drawing.Point(228, 62);
            this.txtCourseNum.Name = "txtCourseNum";
            this.txtCourseNum.Size = new System.Drawing.Size(239, 30);
            this.txtCourseNum.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(42, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 25);
            this.label1.TabIndex = 29;
            this.label1.Text = "Course Number:";
            // 
            // formCourse
            // 
            this.AcceptButton = this.btnSubmit;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClear;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.lbltest);
            this.Controls.Add(this.btnStudForm);
            this.Controls.Add(this.txtCourseName);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.lblCourseWorkName);
            this.Controls.Add(this.comboCourse);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCourseNum);
            this.Controls.Add(this.label1);
            this.Name = "formCourse";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lbltest;
        private System.Windows.Forms.Button btnStudForm;
        private System.Windows.Forms.TextBox txtCourseName;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label lblCourseWorkName;
        private System.Windows.Forms.ComboBox comboCourse;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCourseNum;
        private System.Windows.Forms.Label label1;
    }
}

