using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnicomTicManagementSystem.Controllers;
using UnicomTicManagementSystem.Models;
using UnicomTicManagementSystem.Views;
using UnicomTICManagementSystem.Views;


namespace UnicomTicManagementSystem.Views
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
            this.manageCoursesButton = new System.Windows.Forms.Button();
            this.manageStudentsButton = new System.Windows.Forms.Button();
            this.manageExamsButton = new System.Windows.Forms.Button();
            this.manageTimetableButton = new System.Windows.Forms.Button();
            this.viewTimetableButton = new System.Windows.Forms.Button();
            this.viewMarksButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // manageCoursesButton
            // 
            this.manageCoursesButton.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.manageCoursesButton.Location = new System.Drawing.Point(25, 100);
            this.manageCoursesButton.Name = "manageCoursesButton";
            this.manageCoursesButton.Size = new System.Drawing.Size(216, 93);
            this.manageCoursesButton.TabIndex = 0;
            this.manageCoursesButton.Text = "Manage Courses & Subjects";
            this.manageCoursesButton.UseVisualStyleBackColor = false;
            this.manageCoursesButton.Click += new System.EventHandler(this.manageCoursesButton_Click);
            // 
            // manageStudentsButton
            // 
            this.manageStudentsButton.BackColor = System.Drawing.SystemColors.Highlight;
            this.manageStudentsButton.Location = new System.Drawing.Point(262, 100);
            this.manageStudentsButton.Name = "manageStudentsButton";
            this.manageStudentsButton.Size = new System.Drawing.Size(240, 93);
            this.manageStudentsButton.TabIndex = 1;
            this.manageStudentsButton.Text = "Manage Students";
            this.manageStudentsButton.UseVisualStyleBackColor = false;
            this.manageStudentsButton.Click += new System.EventHandler(this.manageStudentsButton_Click);
            // 
            // manageExamsButton
            // 
            this.manageExamsButton.BackColor = System.Drawing.SystemColors.HotTrack;
            this.manageExamsButton.Location = new System.Drawing.Point(522, 100);
            this.manageExamsButton.Name = "manageExamsButton";
            this.manageExamsButton.Size = new System.Drawing.Size(220, 93);
            this.manageExamsButton.TabIndex = 2;
            this.manageExamsButton.Text = "Manage Exams & Marks";
            this.manageExamsButton.UseVisualStyleBackColor = false;
            this.manageExamsButton.Click += new System.EventHandler(this.manageExamsButton_Click);
            // 
            // manageTimetableButton
            // 
            this.manageTimetableButton.BackColor = System.Drawing.Color.LightPink;
            this.manageTimetableButton.Location = new System.Drawing.Point(25, 262);
            this.manageTimetableButton.Name = "manageTimetableButton";
            this.manageTimetableButton.Size = new System.Drawing.Size(216, 92);
            this.manageTimetableButton.TabIndex = 3;
            this.manageTimetableButton.Text = "Manage Timetable";
            this.manageTimetableButton.UseVisualStyleBackColor = false;
            this.manageTimetableButton.Click += new System.EventHandler(this.manageTimetableButton_Click);
            // 
            // viewTimetableButton
            // 
            this.viewTimetableButton.BackColor = System.Drawing.Color.Pink;
            this.viewTimetableButton.Location = new System.Drawing.Point(262, 262);
            this.viewTimetableButton.Name = "viewTimetableButton";
            this.viewTimetableButton.Size = new System.Drawing.Size(240, 92);
            this.viewTimetableButton.TabIndex = 4;
            this.viewTimetableButton.Text = "View Timetable";
            this.viewTimetableButton.UseVisualStyleBackColor = false;
            this.viewTimetableButton.Click += new System.EventHandler(this.viewTimetableButton_Click);
            // 
            // viewMarksButton
            // 
            this.viewMarksButton.BackColor = System.Drawing.Color.PaleVioletRed;
            this.viewMarksButton.Location = new System.Drawing.Point(522, 262);
            this.viewMarksButton.Name = "viewMarksButton";
            this.viewMarksButton.Size = new System.Drawing.Size(220, 92);
            this.viewMarksButton.TabIndex = 5;
            this.viewMarksButton.Text = "View My Marks";
            this.viewMarksButton.UseVisualStyleBackColor = false;
            this.viewMarksButton.Click += new System.EventHandler(this.viewMarksButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.viewMarksButton);
            this.Controls.Add(this.viewTimetableButton);
            this.Controls.Add(this.manageTimetableButton);
            this.Controls.Add(this.manageExamsButton);
            this.Controls.Add(this.manageStudentsButton);
            this.Controls.Add(this.manageCoursesButton);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.ResumeLayout(false);

        }

        private void viewMarksButton_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void viewTimetableButton_Click(object sender, EventArgs e)
        {
            // We pass the user's role to the form's constructor.
            TimetableForm timetableForm = new TimetableForm(_loggedInUserRole);
            timetableForm.ShowDialog();
            throw new NotImplementedException();
        }

        private void manageTimetableButton_Click(object sender, EventArgs e)
        {
            // We pass the user's role to the form's constructor.
            TimetableForm timetableForm = new TimetableForm(_loggedInUserRole);
            timetableForm.ShowDialog();
            throw new NotImplementedException();
        }

        private void manageExamsButton_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void manageStudentsButton_Click(object sender, EventArgs e)
        {
            // Create an instance of our new form
            StudentForm studentForm = new StudentForm();
            // Show it as a modal dialog
            studentForm.ShowDialog();
            throw new NotImplementedException();
        }

        private void manageCoursesButton_Click(object sender, EventArgs e)
        {
            CourseForm courseForm = new CourseForm();

            // Show it as a dialog. This will pause the code here until the form is closed.
            
            {
                courseForm.ShowDialog();
            }
        }

        #endregion

        private System.Windows.Forms.Button manageCoursesButton;
        private System.Windows.Forms.Button manageStudentsButton;
        private System.Windows.Forms.Button manageExamsButton;
        private System.Windows.Forms.Button manageTimetableButton;
        private System.Windows.Forms.Button viewTimetableButton;
        private System.Windows.Forms.Button viewMarksButton;
    }
}