namespace CoursemoApp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lstCourses = new System.Windows.Forms.ListBox();
            this.lstStudents1 = new System.Windows.Forms.ListBox();
            this.lstStudents2 = new System.Windows.Forms.ListBox();
            this.lstStuCourses1 = new System.Windows.Forms.ListBox();
            this.lstStuCourses2 = new System.Windows.Forms.ListBox();
            this.lstWaitlist = new System.Windows.Forms.ListBox();
            this.lstEnrolled = new System.Windows.Forms.ListBox();
            this.cmdLoadCourses = new System.Windows.Forms.Button();
            this.cmdLoadStudents = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmdEnroll1 = new System.Windows.Forms.Button();
            this.cmdDrop1 = new System.Windows.Forms.Button();
            this.cmdSwap = new System.Windows.Forms.Button();
            this.cmdDrop2 = new System.Windows.Forms.Button();
            this.cmdEnroll2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNumEnrolled = new System.Windows.Forms.TextBox();
            this.txtNumWaitlisted = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSemYear = new System.Windows.Forms.TextBox();
            this.txtDayTime = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtClassSize = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtDelay = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1181, 24);
            this.menuStrip1.TabIndex = 24;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.resetDatabaseToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // resetDatabaseToolStripMenuItem
            // 
            this.resetDatabaseToolStripMenuItem.Name = "resetDatabaseToolStripMenuItem";
            this.resetDatabaseToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.resetDatabaseToolStripMenuItem.Text = "Reset database";
            this.resetDatabaseToolStripMenuItem.Click += new System.EventHandler(this.resetDatabaseToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(149, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // lstCourses
            // 
            this.lstCourses.FormattingEnabled = true;
            this.lstCourses.ItemHeight = 20;
            this.lstCourses.Location = new System.Drawing.Point(12, 71);
            this.lstCourses.Name = "lstCourses";
            this.lstCourses.Size = new System.Drawing.Size(324, 304);
            this.lstCourses.Sorted = true;
            this.lstCourses.TabIndex = 25;
            this.lstCourses.SelectedIndexChanged += new System.EventHandler(this.lstCourses_SelectedIndexChanged);
            // 
            // lstStudents1
            // 
            this.lstStudents1.FormattingEnabled = true;
            this.lstStudents1.ItemHeight = 20;
            this.lstStudents1.Location = new System.Drawing.Point(639, 71);
            this.lstStudents1.Name = "lstStudents1";
            this.lstStudents1.Size = new System.Drawing.Size(262, 304);
            this.lstStudents1.Sorted = true;
            this.lstStudents1.TabIndex = 26;
            this.lstStudents1.SelectedIndexChanged += new System.EventHandler(this.lstStudents1_SelectedIndexChanged);
            // 
            // lstStudents2
            // 
            this.lstStudents2.FormattingEnabled = true;
            this.lstStudents2.ItemHeight = 20;
            this.lstStudents2.Location = new System.Drawing.Point(907, 71);
            this.lstStudents2.Name = "lstStudents2";
            this.lstStudents2.Size = new System.Drawing.Size(262, 304);
            this.lstStudents2.Sorted = true;
            this.lstStudents2.TabIndex = 27;
            this.lstStudents2.SelectedIndexChanged += new System.EventHandler(this.lstStudents2_SelectedIndexChanged);
            // 
            // lstStuCourses1
            // 
            this.lstStuCourses1.FormattingEnabled = true;
            this.lstStuCourses1.ItemHeight = 20;
            this.lstStuCourses1.Location = new System.Drawing.Point(639, 405);
            this.lstStuCourses1.Name = "lstStuCourses1";
            this.lstStuCourses1.Size = new System.Drawing.Size(262, 184);
            this.lstStuCourses1.TabIndex = 28;
            this.lstStuCourses1.SelectedIndexChanged += new System.EventHandler(this.lstStuCourses1_SelectedIndexChanged);
            // 
            // lstStuCourses2
            // 
            this.lstStuCourses2.FormattingEnabled = true;
            this.lstStuCourses2.ItemHeight = 20;
            this.lstStuCourses2.Location = new System.Drawing.Point(907, 405);
            this.lstStuCourses2.Name = "lstStuCourses2";
            this.lstStuCourses2.Size = new System.Drawing.Size(262, 184);
            this.lstStuCourses2.TabIndex = 29;
            this.lstStuCourses2.SelectedIndexChanged += new System.EventHandler(this.lstStuCourses2_SelectedIndexChanged);
            // 
            // lstWaitlist
            // 
            this.lstWaitlist.FormattingEnabled = true;
            this.lstWaitlist.ItemHeight = 20;
            this.lstWaitlist.Location = new System.Drawing.Point(309, 405);
            this.lstWaitlist.Name = "lstWaitlist";
            this.lstWaitlist.Size = new System.Drawing.Size(291, 244);
            this.lstWaitlist.TabIndex = 30;
            // 
            // lstEnrolled
            // 
            this.lstEnrolled.FormattingEnabled = true;
            this.lstEnrolled.ItemHeight = 20;
            this.lstEnrolled.Location = new System.Drawing.Point(12, 405);
            this.lstEnrolled.Name = "lstEnrolled";
            this.lstEnrolled.Size = new System.Drawing.Size(291, 244);
            this.lstEnrolled.TabIndex = 31;
            // 
            // cmdLoadCourses
            // 
            this.cmdLoadCourses.Location = new System.Drawing.Point(108, 27);
            this.cmdLoadCourses.Name = "cmdLoadCourses";
            this.cmdLoadCourses.Size = new System.Drawing.Size(132, 38);
            this.cmdLoadCourses.TabIndex = 32;
            this.cmdLoadCourses.Text = "Load Courses";
            this.cmdLoadCourses.UseVisualStyleBackColor = true;
            this.cmdLoadCourses.Click += new System.EventHandler(this.cmdLoadCourses_Click);
            // 
            // cmdLoadStudents
            // 
            this.cmdLoadStudents.Location = new System.Drawing.Point(836, 27);
            this.cmdLoadStudents.Name = "cmdLoadStudents";
            this.cmdLoadStudents.Size = new System.Drawing.Size(132, 38);
            this.cmdLoadStudents.TabIndex = 33;
            this.cmdLoadStudents.Text = "Load Students";
            this.cmdLoadStudents.UseVisualStyleBackColor = true;
            this.cmdLoadStudents.Click += new System.EventHandler(this.cmdLoadStudents_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(635, 382);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 20);
            this.label1.TabIndex = 34;
            this.label1.Text = "Current Enrollment:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(903, 382);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 20);
            this.label2.TabIndex = 35;
            this.label2.Text = "Current Enrollment:";
            // 
            // cmdEnroll1
            // 
            this.cmdEnroll1.Location = new System.Drawing.Point(639, 598);
            this.cmdEnroll1.Name = "cmdEnroll1";
            this.cmdEnroll1.Size = new System.Drawing.Size(132, 38);
            this.cmdEnroll1.TabIndex = 36;
            this.cmdEnroll1.Text = "Enroll";
            this.cmdEnroll1.UseVisualStyleBackColor = true;
            this.cmdEnroll1.Click += new System.EventHandler(this.cmdEnroll1_Click);
            // 
            // cmdDrop1
            // 
            this.cmdDrop1.Location = new System.Drawing.Point(639, 642);
            this.cmdDrop1.Name = "cmdDrop1";
            this.cmdDrop1.Size = new System.Drawing.Size(132, 38);
            this.cmdDrop1.TabIndex = 37;
            this.cmdDrop1.Text = "Drop";
            this.cmdDrop1.UseVisualStyleBackColor = true;
            this.cmdDrop1.Click += new System.EventHandler(this.cmdDrop1_Click);
            // 
            // cmdSwap
            // 
            this.cmdSwap.Location = new System.Drawing.Point(777, 598);
            this.cmdSwap.Name = "cmdSwap";
            this.cmdSwap.Size = new System.Drawing.Size(254, 82);
            this.cmdSwap.TabIndex = 38;
            this.cmdSwap.Text = "Swap";
            this.cmdSwap.UseVisualStyleBackColor = true;
            this.cmdSwap.Click += new System.EventHandler(this.cmdSwap_Click);
            // 
            // cmdDrop2
            // 
            this.cmdDrop2.Location = new System.Drawing.Point(1037, 642);
            this.cmdDrop2.Name = "cmdDrop2";
            this.cmdDrop2.Size = new System.Drawing.Size(132, 38);
            this.cmdDrop2.TabIndex = 40;
            this.cmdDrop2.Text = "Drop";
            this.cmdDrop2.UseVisualStyleBackColor = true;
            this.cmdDrop2.Click += new System.EventHandler(this.cmdDrop2_Click);
            // 
            // cmdEnroll2
            // 
            this.cmdEnroll2.Location = new System.Drawing.Point(1037, 598);
            this.cmdEnroll2.Name = "cmdEnroll2";
            this.cmdEnroll2.Size = new System.Drawing.Size(132, 38);
            this.cmdEnroll2.TabIndex = 39;
            this.cmdEnroll2.Text = "Enroll";
            this.cmdEnroll2.UseVisualStyleBackColor = true;
            this.cmdEnroll2.Click += new System.EventHandler(this.cmdEnroll2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 382);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 20);
            this.label3.TabIndex = 41;
            this.label3.Text = "Enrolled:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(305, 382);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 20);
            this.label4.TabIndex = 42;
            this.label4.Text = "Waitlist:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 660);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 20);
            this.label5.TabIndex = 43;
            this.label5.Text = "Total:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(305, 658);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 20);
            this.label6.TabIndex = 44;
            this.label6.Text = "Total:";
            // 
            // txtNumEnrolled
            // 
            this.txtNumEnrolled.Location = new System.Drawing.Point(54, 655);
            this.txtNumEnrolled.Name = "txtNumEnrolled";
            this.txtNumEnrolled.Size = new System.Drawing.Size(112, 26);
            this.txtNumEnrolled.TabIndex = 45;
            this.txtNumEnrolled.Text = "0";
            this.txtNumEnrolled.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtNumWaitlisted
            // 
            this.txtNumWaitlisted.Location = new System.Drawing.Point(353, 655);
            this.txtNumWaitlisted.Name = "txtNumWaitlisted";
            this.txtNumWaitlisted.Size = new System.Drawing.Size(120, 26);
            this.txtNumWaitlisted.TabIndex = 46;
            this.txtNumWaitlisted.Text = "0";
            this.txtNumWaitlisted.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(416, 109);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(135, 26);
            this.label7.TabIndex = 47;
            this.label7.Text = "Course Info";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtSemYear
            // 
            this.txtSemYear.Location = new System.Drawing.Point(372, 154);
            this.txtSemYear.Name = "txtSemYear";
            this.txtSemYear.Size = new System.Drawing.Size(228, 26);
            this.txtSemYear.TabIndex = 48;
            this.txtSemYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtDayTime
            // 
            this.txtDayTime.Location = new System.Drawing.Point(372, 225);
            this.txtDayTime.Name = "txtDayTime";
            this.txtDayTime.Size = new System.Drawing.Size(228, 26);
            this.txtDayTime.TabIndex = 49;
            this.txtDayTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(368, 202);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 20);
            this.label8.TabIndex = 50;
            this.label8.Text = "Day/Time:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(368, 280);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(87, 20);
            this.label9.TabIndex = 52;
            this.label9.Text = "Class Size:";
            // 
            // txtClassSize
            // 
            this.txtClassSize.Location = new System.Drawing.Point(372, 303);
            this.txtClassSize.Name = "txtClassSize";
            this.txtClassSize.Size = new System.Drawing.Size(228, 26);
            this.txtClassSize.TabIndex = 51;
            this.txtClassSize.Text = "0";
            this.txtClassSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(359, 42);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(84, 20);
            this.label10.TabIndex = 53;
            this.label10.Text = "Delay(ms):";
            // 
            // txtDelay
            // 
            this.txtDelay.Location = new System.Drawing.Point(448, 39);
            this.txtDelay.Name = "txtDelay";
            this.txtDelay.Size = new System.Drawing.Size(140, 26);
            this.txtDelay.TabIndex = 54;
            this.txtDelay.Text = "0";
            this.txtDelay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDelay.TextChanged += new System.EventHandler(this.txtDelay_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1181, 692);
            this.Controls.Add(this.txtDelay);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtClassSize);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtDayTime);
            this.Controls.Add(this.txtSemYear);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtNumWaitlisted);
            this.Controls.Add(this.txtNumEnrolled);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmdDrop2);
            this.Controls.Add(this.cmdEnroll2);
            this.Controls.Add(this.cmdSwap);
            this.Controls.Add(this.cmdDrop1);
            this.Controls.Add(this.cmdEnroll1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdLoadStudents);
            this.Controls.Add(this.cmdLoadCourses);
            this.Controls.Add(this.lstEnrolled);
            this.Controls.Add(this.lstWaitlist);
            this.Controls.Add(this.lstStuCourses2);
            this.Controls.Add(this.lstStuCourses1);
            this.Controls.Add(this.lstStudents2);
            this.Controls.Add(this.lstStudents1);
            this.Controls.Add(this.lstCourses);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "Form1";
            this.Text = "Coursemo";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetDatabaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ListBox lstCourses;
        private System.Windows.Forms.ListBox lstStudents1;
        private System.Windows.Forms.ListBox lstStudents2;
        private System.Windows.Forms.ListBox lstStuCourses1;
        private System.Windows.Forms.ListBox lstStuCourses2;
        private System.Windows.Forms.ListBox lstWaitlist;
        private System.Windows.Forms.ListBox lstEnrolled;
        private System.Windows.Forms.Button cmdLoadCourses;
        private System.Windows.Forms.Button cmdLoadStudents;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cmdEnroll1;
        private System.Windows.Forms.Button cmdDrop1;
        private System.Windows.Forms.Button cmdSwap;
        private System.Windows.Forms.Button cmdDrop2;
        private System.Windows.Forms.Button cmdEnroll2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNumEnrolled;
        private System.Windows.Forms.TextBox txtNumWaitlisted;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtSemYear;
        private System.Windows.Forms.TextBox txtDayTime;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtClassSize;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtDelay;
    }
}

