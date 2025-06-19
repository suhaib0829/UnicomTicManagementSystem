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
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.btnManageCourses = new System.Windows.Forms.Button();
            this.btnManageStudents = new System.Windows.Forms.Button();
            this.btnManageExams = new System.Windows.Forms.Button();
            this.btnManageTimetable = new System.Windows.Forms.Button();
            this.panelTitleBar.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();

            // panelTitleBar
            this.panelTitleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.panelTitleBar.Controls.Add(this.btnLogout);
            this.panelTitleBar.Controls.Add(this.lblTitle);
            this.panelTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitleBar.Location = new System.Drawing.Point(0, 0);
            this.panelTitleBar.Size = new System.Drawing.Size(1200, 80);

            // lblTitle
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.lblTitle.Text = "UMS Dashboard";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // btnLogout
            this.btnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(83)))), ((int)(((byte)(79)))));
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(1050, 20);
            this.btnLogout.Size = new System.Drawing.Size(130, 40);
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);

            // panelButtons
            this.panelButtons.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.panelButtons.Controls.Add(this.btnManageCourses);
            this.panelButtons.Controls.Add(this.btnManageStudents);
            this.panelButtons.Controls.Add(this.btnManageExams);
            this.panelButtons.Controls.Add(this.btnManageTimetable);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelButtons.Location = new System.Drawing.Point(0, 80);
            this.panelButtons.Padding = new System.Windows.Forms.Padding(50);
            this.panelButtons.Size = new System.Drawing.Size(1200, 640);

            // ... (Button configurations) ...
            this.btnManageCourses.Location = new System.Drawing.Point(50, 50); this.btnManageCourses.Size = new System.Drawing.Size(280, 120);
            this.btnManageCourses.Text = "Manage Courses\r\n&& Subjects"; this.btnManageCourses.Click += new System.EventHandler(this.btnManageCourses_Click);
            this.btnManageStudents.Location = new System.Drawing.Point(350, 50); this.btnManageStudents.Size = new System.Drawing.Size(280, 120);
            this.btnManageStudents.Text = "Manage Students"; this.btnManageStudents.Click += new System.EventHandler(this.btnManageStudents_Click);
            this.btnManageExams.Location = new System.Drawing.Point(50, 190); this.btnManageExams.Size = new System.Drawing.Size(280, 120);
            this.btnManageExams.Text = "Manage Exams\r\n&& Marks"; this.btnManageExams.Click += new System.EventHandler(this.btnManageExams_Click);
            this.btnManageTimetable.Location = new System.Drawing.Point(350, 190); this.btnManageTimetable.Size = new System.Drawing.Size(280, 120);
            this.btnManageTimetable.Text = "Manage Timetable"; this.btnManageTimetable.Click += new System.EventHandler(this.btnManageTimetable_Click);

            foreach (System.Windows.Forms.Button btn in this.panelButtons.Controls)
            {
                btn.BackColor = System.Drawing.Color.White;
                btn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
                btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                btn.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
                btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            }

            // MainForm
            this.ClientSize = new System.Drawing.Size(1200, 720);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.panelTitleBar);
            this.Name = "MainForm";
            this.Text = "Unicom TIC Management System";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
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