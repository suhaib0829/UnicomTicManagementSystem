// In Views/MainForm.Designer.cs
namespace UnicomTicManagementSystem.Views
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.panelTitleBar = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.btnManageStudents = new System.Windows.Forms.Button();
            this.btnManageExams = new System.Windows.Forms.Button();
            this.btnManageTimetable = new System.Windows.Forms.Button();
            this.btnManageCourses = new System.Windows.Forms.Button();
            this.panelTitleBar.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();

            // panelTitleBar
            this.panelTitleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.panelTitleBar.Controls.Add(this.btnLogout);
            this.panelTitleBar.Controls.Add(this.lblTitle);
            this.panelTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitleBar.Location = new System.Drawing.Point(0, 0);
            this.panelTitleBar.Name = "panelTitleBar";
            this.panelTitleBar.Size = new System.Drawing.Size(1200, 80); // Adjusted for a standard large screen

            // btnLogout
            this.btnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(83)))), ((int)(((byte)(79)))));
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(1050, 20);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(130, 40);
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);

            // lblTitle
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.lblTitle.Size = new System.Drawing.Size(1200, 80);
            this.lblTitle.Text = "UMS Dashboard";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // panelButtons (This is the main content area)
            this.panelButtons.BackColor = System.Drawing.Color.White; // Changed for clarity, you can set your image here
            this.panelButtons.BackgroundImage = global::UnicomTicManagementSystem.Properties.Resources.R;
            this.panelButtons.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            // THE FIX: Adding buttons DIRECTLY to this panel, not a sub-panel.
            this.panelButtons.Controls.Add(this.btnManageStudents);
            this.panelButtons.Controls.Add(this.btnManageExams);
            this.panelButtons.Controls.Add(this.btnManageTimetable);
            this.panelButtons.Controls.Add(this.btnManageCourses);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelButtons.Location = new System.Drawing.Point(0, 80);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(1200, 640);
            this.panelButtons.Paint += new System.Windows.Forms.PaintEventHandler(this.panelButtons_Paint);

            // btnManageCourses
            this.btnManageCourses.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(112)))), ((int)(((byte)(204)))));
            this.btnManageCourses.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.btnManageCourses.ForeColor = System.Drawing.Color.White;
            this.btnManageCourses.Location = new System.Drawing.Point(52, 52); // Positioned for vertical layout
            this.btnManageCourses.Name = "btnManageCourses";
            this.btnManageCourses.Size = new System.Drawing.Size(280, 120);
            this.btnManageCourses.Text = "Manage Courses\r\n& Subjects";
            this.btnManageCourses.UseVisualStyleBackColor = false;
            this.btnManageCourses.Click += new System.EventHandler(this.btnManageCourses_Click);

            // btnManageTimetable
            this.btnManageTimetable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(112)))), ((int)(((byte)(204)))));
            this.btnManageTimetable.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.btnManageTimetable.ForeColor = System.Drawing.Color.White;
            this.btnManageTimetable.Location = new System.Drawing.Point(52, 192); // Positioned below Courses
            this.btnManageTimetable.Name = "btnManageTimetable";
            this.btnManageTimetable.Size = new System.Drawing.Size(280, 120);
            this.btnManageTimetable.Text = "Manage Timetable";
            this.btnManageTimetable.UseVisualStyleBackColor = false;
            this.btnManageTimetable.Click += new System.EventHandler(this.btnManageTimetable_Click);

            // btnManageExams
            this.btnManageExams.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(112)))), ((int)(((byte)(204)))));
            this.btnManageExams.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.btnManageExams.ForeColor = System.Drawing.Color.White;
            this.btnManageExams.Location = new System.Drawing.Point(52, 332); // Positioned below Timetable
            this.btnManageExams.Name = "btnManageExams";
            this.btnManageExams.Size = new System.Drawing.Size(280, 120);
            this.btnManageExams.Text = "Manage Exams\r\n& Marks";
            this.btnManageExams.UseVisualStyleBackColor = false;
            this.btnManageExams.Click += new System.EventHandler(this.btnManageExams_Click);

            // btnManageStudents
            this.btnManageStudents.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(112)))), ((int)(((byte)(204)))));
            this.btnManageStudents.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.btnManageStudents.ForeColor = System.Drawing.Color.White;
            this.btnManageStudents.Location = new System.Drawing.Point(52, 472); // Positioned below Exams
            this.btnManageStudents.Name = "btnManageStudents";
            this.btnManageStudents.Size = new System.Drawing.Size(280, 120);
            this.btnManageStudents.Text = "Manage Students";
            this.btnManageStudents.UseVisualStyleBackColor = false;
            this.btnManageStudents.Click += new System.EventHandler(this.btnManageStudents_Click);

            // MainForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 720);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.panelTitleBar);
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

        private System.Windows.Forms.Panel panelTitleBar;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button btnManageCourses;
        private System.Windows.Forms.Button btnManageStudents;
        private System.Windows.Forms.Button btnManageExams;
        private System.Windows.Forms.Button btnManageTimetable;
    }
}