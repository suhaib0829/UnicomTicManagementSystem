// In Views/MainForm.Designer.cs

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
            this.panelTitleBar = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.btnManageCourses = new System.Windows.Forms.Button();
            this.btnManageStudents = new System.Windows.Forms.Button();
            this.btnManageExams = new System.Windows.Forms.Button();
            this.btnManageTimetable = new System.Windows.Forms.Button();
            this.panelTitleBar.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTitleBar
            // 
            this.panelTitleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.panelTitleBar.Controls.Add(this.lblTitle);
            this.panelTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitleBar.Location = new System.Drawing.Point(0, 0);
            this.panelTitleBar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelTitleBar.Name = "panelTitleBar";
            this.panelTitleBar.Size = new System.Drawing.Size(800, 52);
            this.panelTitleBar.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.lblTitle.Size = new System.Drawing.Size(800, 52);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "UMS Dashboard";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelButtons
            // 
            this.panelButtons.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.panelButtons.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelButtons.Controls.Add(this.btnManageCourses);
            this.panelButtons.Controls.Add(this.btnManageStudents);
            this.panelButtons.Controls.Add(this.btnManageExams);
            this.panelButtons.Controls.Add(this.btnManageTimetable);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelButtons.Location = new System.Drawing.Point(0, 52);
            this.panelButtons.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Padding = new System.Windows.Forms.Padding(33, 32, 33, 32);
            this.panelButtons.Size = new System.Drawing.Size(800, 416);
            this.panelButtons.TabIndex = 1;
            // 
            // btnManageCourses
            // 
            this.btnManageCourses.BackColor = System.Drawing.Color.White;
            this.btnManageCourses.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnManageCourses.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManageCourses.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManageCourses.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnManageCourses.Location = new System.Drawing.Point(33, 32);
            this.btnManageCourses.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnManageCourses.Name = "btnManageCourses";
            this.btnManageCourses.Size = new System.Drawing.Size(187, 78);
            this.btnManageCourses.TabIndex = 0;
            this.btnManageCourses.Text = "Manage Courses\r\n&& Subjects";
            this.btnManageCourses.UseVisualStyleBackColor = false;
            this.btnManageCourses.Click += new System.EventHandler(this.btnManageCourses_Click);
            // 
            // btnManageStudents
            // 
            this.btnManageStudents.BackColor = System.Drawing.Color.White;
            this.btnManageStudents.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnManageStudents.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManageStudents.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManageStudents.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnManageStudents.Location = new System.Drawing.Point(233, 32);
            this.btnManageStudents.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnManageStudents.Name = "btnManageStudents";
            this.btnManageStudents.Size = new System.Drawing.Size(187, 78);
            this.btnManageStudents.TabIndex = 1;
            this.btnManageStudents.Text = "Manage Students";
            this.btnManageStudents.UseVisualStyleBackColor = false;
            this.btnManageStudents.Click += new System.EventHandler(this.btnManageStudents_Click);
            // 
            // btnManageExams
            // 
            this.btnManageExams.BackColor = System.Drawing.Color.White;
            this.btnManageExams.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnManageExams.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManageExams.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManageExams.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnManageExams.Location = new System.Drawing.Point(33, 123);
            this.btnManageExams.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnManageExams.Name = "btnManageExams";
            this.btnManageExams.Size = new System.Drawing.Size(187, 78);
            this.btnManageExams.TabIndex = 2;
            this.btnManageExams.Text = "Manage Exams\r\n&& Marks";
            this.btnManageExams.UseVisualStyleBackColor = false;
            this.btnManageExams.Click += new System.EventHandler(this.btnManageExams_Click);
            // 
            // btnManageTimetable
            // 
            this.btnManageTimetable.BackColor = System.Drawing.Color.White;
            this.btnManageTimetable.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnManageTimetable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManageTimetable.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManageTimetable.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnManageTimetable.Location = new System.Drawing.Point(233, 123);
            this.btnManageTimetable.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnManageTimetable.Name = "btnManageTimetable";
            this.btnManageTimetable.Size = new System.Drawing.Size(187, 78);
            this.btnManageTimetable.TabIndex = 3;
            this.btnManageTimetable.Text = "Manage Timetable";
            this.btnManageTimetable.UseVisualStyleBackColor = false;
            this.btnManageTimetable.Click += new System.EventHandler(this.btnManageTimetable_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 468);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.panelTitleBar);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Unicom TIC Management System";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panelTitleBar.ResumeLayout(false);
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        // --- 7. Declare Control Variables ---
        private System.Windows.Forms.Panel panelTitleBar;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button btnManageCourses;
        private System.Windows.Forms.Button btnManageStudents;
        private System.Windows.Forms.Button btnManageExams;
        private System.Windows.Forms.Button btnManageTimetable;
    }
}