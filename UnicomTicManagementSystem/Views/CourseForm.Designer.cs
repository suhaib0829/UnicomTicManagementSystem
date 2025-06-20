// In Views/CourseForm.Designer.cs
namespace UnicomTicManagementSystem.Views
{
    partial class CourseForm
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
            this.dgvCourses = new System.Windows.Forms.DataGridView();
            this.groupBoxCourses = new System.Windows.Forms.GroupBox();
            this.btnClearCourse = new System.Windows.Forms.Button();
            this.btnDeleteCourse = new System.Windows.Forms.Button();
            this.btnUpdateCourse = new System.Windows.Forms.Button();
            this.btnAddCourse = new System.Windows.Forms.Button();
            this.txtCourseName = new System.Windows.Forms.TextBox();
            this.labelCourseName = new System.Windows.Forms.Label();
            this.txtCourseId = new System.Windows.Forms.TextBox();
            this.labelCourseId = new System.Windows.Forms.Label();
            this.groupBoxSubjects = new System.Windows.Forms.GroupBox();
            this.dgvSubjects = new System.Windows.Forms.DataGridView();
            this.btnAddSubject = new System.Windows.Forms.Button();
            this.txtSubjectName = new System.Windows.Forms.TextBox();
            this.labelSubjectName = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.dgvCourses)).BeginInit();
            this.groupBoxCourses.SuspendLayout();
            this.groupBoxSubjects.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubjects)).BeginInit();
            this.SuspendLayout();

            // dgvCourses
            this.dgvCourses.AllowUserToAddRows = false;
            this.dgvCourses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCourses.Location = new System.Drawing.Point(12, 12);
            this.dgvCourses.Name = "dgvCourses";
            this.dgvCourses.ReadOnly = true;
            this.dgvCourses.RowHeadersVisible = false;
            this.dgvCourses.RowTemplate.Height = 28;
            this.dgvCourses.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCourses.Size = new System.Drawing.Size(450, 520);
            this.dgvCourses.SelectionChanged += new System.EventHandler(this.dgvCourses_SelectionChanged);

            // groupBoxCourses
            this.groupBoxCourses.Controls.Add(this.btnClearCourse);
            this.groupBoxCourses.Controls.Add(this.btnDeleteCourse);
            this.groupBoxCourses.Controls.Add(this.btnUpdateCourse);
            this.groupBoxCourses.Controls.Add(this.btnAddCourse);
            this.groupBoxCourses.Controls.Add(this.txtCourseName);
            this.groupBoxCourses.Controls.Add(this.labelCourseName);
            this.groupBoxCourses.Controls.Add(this.txtCourseId);
            this.groupBoxCourses.Controls.Add(this.labelCourseId);
            this.groupBoxCourses.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.groupBoxCourses.Location = new System.Drawing.Point(480, 12);
            this.groupBoxCourses.Name = "groupBoxCourses";
            this.groupBoxCourses.Size = new System.Drawing.Size(490, 200);
            this.groupBoxCourses.TabStop = false;
            this.groupBoxCourses.Text = "Manage Courses";

            this.labelCourseId.Location = new System.Drawing.Point(20, 40); this.labelCourseId.Text = "Course ID:"; this.labelCourseId.AutoSize = true;
            this.txtCourseId.Location = new System.Drawing.Point(130, 37); this.txtCourseId.ReadOnly = true; this.txtCourseId.Size = new System.Drawing.Size(100, 31);
            this.labelCourseName.Location = new System.Drawing.Point(20, 80); this.labelCourseName.Text = "Course Name:"; this.labelCourseName.AutoSize = true;
            this.txtCourseName.Location = new System.Drawing.Point(130, 77); this.txtCourseName.Size = new System.Drawing.Size(340, 31);
            this.btnAddCourse.Location = new System.Drawing.Point(24, 130); this.btnAddCourse.Size = new System.Drawing.Size(100, 40); this.btnAddCourse.Text = "Add"; this.btnAddCourse.Click += new System.EventHandler(this.btnAddCourse_Click);
            this.btnUpdateCourse.Location = new System.Drawing.Point(142, 130); this.btnUpdateCourse.Size = new System.Drawing.Size(100, 40); this.btnUpdateCourse.Text = "Update"; this.btnUpdateCourse.Click += new System.EventHandler(this.btnUpdateCourse_Click);
            this.btnDeleteCourse.Location = new System.Drawing.Point(260, 130); this.btnDeleteCourse.Size = new System.Drawing.Size(100, 40); this.btnDeleteCourse.Text = "Delete"; this.btnDeleteCourse.Click += new System.EventHandler(this.btnDeleteCourse_Click);
            this.btnClearCourse.Location = new System.Drawing.Point(378, 130); this.btnClearCourse.Size = new System.Drawing.Size(100, 40); this.btnClearCourse.Text = "Clear"; this.btnClearCourse.Click += new System.EventHandler(this.btnClearCourse_Click);

            // groupBoxSubjects
            this.groupBoxSubjects.Controls.Add(this.dgvSubjects);
            this.groupBoxSubjects.Controls.Add(this.btnAddSubject);
            this.groupBoxSubjects.Controls.Add(this.txtSubjectName);
            this.groupBoxSubjects.Controls.Add(this.labelSubjectName);
            this.groupBoxSubjects.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.groupBoxSubjects.Location = new System.Drawing.Point(480, 220);
            this.groupBoxSubjects.Name = "groupBoxSubjects";
            this.groupBoxSubjects.Size = new System.Drawing.Size(490, 312);
            this.groupBoxSubjects.TabStop = false;
            this.groupBoxSubjects.Text = "Manage Subjects for Selected Course";

            this.labelSubjectName.Location = new System.Drawing.Point(20, 40); this.labelSubjectName.Text = "New Subject Name:"; this.labelSubjectName.AutoSize = true;
            this.txtSubjectName.Location = new System.Drawing.Point(24, 70); this.txtSubjectName.Size = new System.Drawing.Size(300, 31);
            this.btnAddSubject.Location = new System.Drawing.Point(330, 65); this.btnAddSubject.Size = new System.Drawing.Size(140, 40); this.btnAddSubject.Text = "Add Subject"; this.btnAddSubject.Click += new System.EventHandler(this.btnAddSubject_Click);
            this.dgvSubjects.AllowUserToAddRows = false;
            this.dgvSubjects.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSubjects.Location = new System.Drawing.Point(24, 120);
            this.dgvSubjects.Name = "dgvSubjects";
            this.dgvSubjects.ReadOnly = true;
            this.dgvSubjects.RowHeadersVisible = false;
            this.dgvSubjects.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSubjects.Size = new System.Drawing.Size(446, 170);

            // CourseForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(984, 544);
            this.Controls.Add(this.groupBoxSubjects);
            this.Controls.Add(this.groupBoxCourses);
            this.Controls.Add(this.dgvCourses);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "CourseForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Manage Courses and Subjects";
            this.Load += new System.EventHandler(this.CourseForm_Load);

            ((System.ComponentModel.ISupportInitialize)(this.dgvCourses)).EndInit();
            this.groupBoxCourses.ResumeLayout(false);
            this.groupBoxCourses.PerformLayout();
            this.groupBoxSubjects.ResumeLayout(false);
            this.groupBoxSubjects.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubjects)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCourses;
        private System.Windows.Forms.GroupBox groupBoxCourses;
        private System.Windows.Forms.Button btnClearCourse;
        private System.Windows.Forms.Button btnDeleteCourse;
        private System.Windows.Forms.Button btnUpdateCourse;
        private System.Windows.Forms.Button btnAddCourse;
        private System.Windows.Forms.TextBox txtCourseName;
        private System.Windows.Forms.Label labelCourseName;
        private System.Windows.Forms.TextBox txtCourseId;
        private System.Windows.Forms.Label labelCourseId;
        private System.Windows.Forms.GroupBox groupBoxSubjects;
        private System.Windows.Forms.DataGridView dgvSubjects;
        private System.Windows.Forms.TextBox txtSubjectName;
        private System.Windows.Forms.Button btnAddSubject;
        private System.Windows.Forms.Label labelSubjectName;
    }
}