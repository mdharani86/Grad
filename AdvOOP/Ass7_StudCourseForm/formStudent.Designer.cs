namespace Ass7
{
    partial class formStudent
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
            this.lstTest = new System.Windows.Forms.ListBox();
            this.txtxCredits = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSummary = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.txtCourseGrade = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCourseWorkScore = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lstCourseWork = new System.Windows.Forms.ListBox();
            this.lstCourse = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboStud = new System.Windows.Forms.ComboBox();
            this.btnUpdateStud = new System.Windows.Forms.Button();
            this.btnRemStud = new System.Windows.Forms.Button();
            this.btnAddStud = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnEnroll = new System.Windows.Forms.Button();
            this.btnRemEnroll = new System.Windows.Forms.Button();
            this.btnupdatecredits = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lstTest
            // 
            this.lstTest.FormattingEnabled = true;
            this.lstTest.ItemHeight = 16;
            this.lstTest.Location = new System.Drawing.Point(12, 475);
            this.lstTest.Name = "lstTest";
            this.lstTest.Size = new System.Drawing.Size(1087, 52);
            this.lstTest.TabIndex = 44;
            this.lstTest.SelectedIndexChanged += new System.EventHandler(this.lstTest_SelectedIndexChanged);
            // 
            // txtxCredits
            // 
            this.txtxCredits.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtxCredits.Location = new System.Drawing.Point(625, 39);
            this.txtxCredits.Name = "txtxCredits";
            this.txtxCredits.Size = new System.Drawing.Size(118, 26);
            this.txtxCredits.TabIndex = 43;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label7.Location = new System.Drawing.Point(465, 42);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(148, 20);
            this.label7.TabIndex = 42;
            this.label7.Text = "Total Credit hours:";
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnExit.Location = new System.Drawing.Point(944, 17);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(155, 38);
            this.btnExit.TabIndex = 40;
            this.btnExit.Text = "Exit Application";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSummary
            // 
            this.btnSummary.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnSummary.Location = new System.Drawing.Point(672, 396);
            this.btnSummary.Name = "btnSummary";
            this.btnSummary.Size = new System.Drawing.Size(155, 38);
            this.btnSummary.TabIndex = 39;
            this.btnSummary.Text = "Summary Form";
            this.btnSummary.UseVisualStyleBackColor = true;
            this.btnSummary.Click += new System.EventHandler(this.btnSummary_Click);
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnClear.Location = new System.Drawing.Point(520, 396);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(110, 38);
            this.btnClear.TabIndex = 38;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // txtCourseGrade
            // 
            this.txtCourseGrade.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtCourseGrade.Location = new System.Drawing.Point(807, 175);
            this.txtCourseGrade.Name = "txtCourseGrade";
            this.txtCourseGrade.ReadOnly = true;
            this.txtCourseGrade.Size = new System.Drawing.Size(118, 26);
            this.txtCourseGrade.TabIndex = 37;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label6.Location = new System.Drawing.Point(803, 139);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(114, 20);
            this.label6.TabIndex = 36;
            this.label6.Text = "Course Grade";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label5.Location = new System.Drawing.Point(621, 139);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(156, 20);
            this.label5.TabIndex = 35;
            this.label5.Text = "Course Work Score";
            // 
            // txtCourseWorkScore
            // 
            this.txtCourseWorkScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtCourseWorkScore.Location = new System.Drawing.Point(625, 175);
            this.txtCourseWorkScore.Name = "txtCourseWorkScore";
            this.txtCourseWorkScore.Size = new System.Drawing.Size(118, 26);
            this.txtCourseWorkScore.TabIndex = 34;
            this.txtCourseWorkScore.TextChanged += new System.EventHandler(this.txtCourseWorkScore_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.Location = new System.Drawing.Point(343, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 20);
            this.label3.TabIndex = 31;
            this.label3.Text = "Course Work";
            // 
            // lstCourseWork
            // 
            this.lstCourseWork.FormattingEnabled = true;
            this.lstCourseWork.ItemHeight = 16;
            this.lstCourseWork.Location = new System.Drawing.Point(294, 126);
            this.lstCourseWork.Name = "lstCourseWork";
            this.lstCourseWork.Size = new System.Drawing.Size(224, 180);
            this.lstCourseWork.TabIndex = 30;
            this.lstCourseWork.SelectedIndexChanged += new System.EventHandler(this.lstCourseWork_SelectedIndexChanged);
            // 
            // lstCourse
            // 
            this.lstCourse.FormattingEnabled = true;
            this.lstCourse.ItemHeight = 16;
            this.lstCourse.Location = new System.Drawing.Point(56, 126);
            this.lstCourse.Name = "lstCourse";
            this.lstCourse.Size = new System.Drawing.Size(138, 180);
            this.lstCourse.TabIndex = 29;
            this.lstCourse.SelectedIndexChanged += new System.EventHandler(this.lstCourse_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(65, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 20);
            this.label2.TabIndex = 28;
            this.label2.Text = "Course List";
            // 
            // comboStud
            // 
            this.comboStud.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.comboStud.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.comboStud.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.comboStud.FormattingEnabled = true;
            this.comboStud.Location = new System.Drawing.Point(217, 35);
            this.comboStud.Name = "comboStud";
            this.comboStud.Size = new System.Drawing.Size(178, 33);
            this.comboStud.TabIndex = 27;
            // 
            // btnUpdateStud
            // 
            this.btnUpdateStud.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.btnUpdateStud.Location = new System.Drawing.Point(625, 226);
            this.btnUpdateStud.Name = "btnUpdateStud";
            this.btnUpdateStud.Size = new System.Drawing.Size(202, 38);
            this.btnUpdateStud.TabIndex = 26;
            this.btnUpdateStud.Text = "Add/Update Student Score";
            this.btnUpdateStud.UseVisualStyleBackColor = true;
            this.btnUpdateStud.Click += new System.EventHandler(this.btnUpdateStud_Click);
            // 
            // btnRemStud
            // 
            this.btnRemStud.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnRemStud.Location = new System.Drawing.Point(270, 396);
            this.btnRemStud.Name = "btnRemStud";
            this.btnRemStud.Size = new System.Drawing.Size(195, 38);
            this.btnRemStud.TabIndex = 25;
            this.btnRemStud.Text = "Remove Student";
            this.btnRemStud.UseVisualStyleBackColor = true;
            this.btnRemStud.Click += new System.EventHandler(this.btnRemStud_Click);
            // 
            // btnAddStud
            // 
            this.btnAddStud.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnAddStud.Location = new System.Drawing.Point(56, 396);
            this.btnAddStud.Name = "btnAddStud";
            this.btnAddStud.Size = new System.Drawing.Size(155, 38);
            this.btnAddStud.TabIndex = 24;
            this.btnAddStud.Text = "Add Student";
            this.btnAddStud.UseVisualStyleBackColor = true;
            this.btnAddStud.Click += new System.EventHandler(this.btnAddStud_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(73, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 20);
            this.label1.TabIndex = 23;
            this.label1.Text = "Student ID";
            // 
            // btnEnroll
            // 
            this.btnEnroll.Location = new System.Drawing.Point(12, 327);
            this.btnEnroll.Name = "btnEnroll";
            this.btnEnroll.Size = new System.Drawing.Size(209, 39);
            this.btnEnroll.TabIndex = 45;
            this.btnEnroll.Text = "Enroll studID into Course";
            this.btnEnroll.UseVisualStyleBackColor = true;
            this.btnEnroll.Click += new System.EventHandler(this.btnEnroll_Click);
            // 
            // btnRemEnroll
            // 
            this.btnRemEnroll.Location = new System.Drawing.Point(270, 327);
            this.btnRemEnroll.Name = "btnRemEnroll";
            this.btnRemEnroll.Size = new System.Drawing.Size(262, 39);
            this.btnRemEnroll.TabIndex = 46;
            this.btnRemEnroll.Text = "Remove Course from student list";
            this.btnRemEnroll.UseVisualStyleBackColor = true;
            this.btnRemEnroll.Click += new System.EventHandler(this.btnRemEnroll_Click);
            // 
            // btnupdatecredits
            // 
            this.btnupdatecredits.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.btnupdatecredits.Location = new System.Drawing.Point(625, 83);
            this.btnupdatecredits.Name = "btnupdatecredits";
            this.btnupdatecredits.Size = new System.Drawing.Size(182, 38);
            this.btnupdatecredits.TabIndex = 47;
            this.btnupdatecredits.Text = "Add/Update Credit Hours";
            this.btnupdatecredits.UseVisualStyleBackColor = true;
            this.btnupdatecredits.Click += new System.EventHandler(this.btnupdatecredits_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(868, 327);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(231, 119);
            this.label4.TabIndex = 48;
            this.label4.Text = "Instruction:\r\n1. Add Students\r\n2. Enroll Courses to Student\r\n3. Add/update scores" +
    " of student for\r\n     each course work\r\n4. Add/update Total credit hours\r\n     e" +
    "arned by student.\r\n";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // formStudent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1120, 564);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnupdatecredits);
            this.Controls.Add(this.btnRemEnroll);
            this.Controls.Add(this.btnEnroll);
            this.Controls.Add(this.lstTest);
            this.Controls.Add(this.txtxCredits);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSummary);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.txtCourseGrade);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtCourseWorkScore);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lstCourseWork);
            this.Controls.Add(this.lstCourse);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboStud);
            this.Controls.Add(this.btnUpdateStud);
            this.Controls.Add(this.btnRemStud);
            this.Controls.Add(this.btnAddStud);
            this.Controls.Add(this.label1);
            this.Name = "formStudent";
            this.Text = "formStudent";
            this.Load += new System.EventHandler(this.formStudent_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstTest;
        private System.Windows.Forms.TextBox txtxCredits;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSummary;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TextBox txtCourseGrade;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCourseWorkScore;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lstCourseWork;
        private System.Windows.Forms.ListBox lstCourse;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboStud;
        private System.Windows.Forms.Button btnUpdateStud;
        private System.Windows.Forms.Button btnRemStud;
        private System.Windows.Forms.Button btnAddStud;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnEnroll;
        private System.Windows.Forms.Button btnRemEnroll;
        private System.Windows.Forms.Button btnupdatecredits;
        private System.Windows.Forms.Label label4;
    }
}