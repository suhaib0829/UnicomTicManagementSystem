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
            // 
            // dgvCourses
            // 
            this.dgvCourses.AllowUserToAddRows = false;
            this.dgvCourses.AllowUserToDeleteRows = false;
            this.dgvCourses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCourses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCourses.Location = new System.Drawing.Point(8, 8);
            this.dgvCourses.Margin = new System.Windows.Forms.Padding(2);
            this.dgvCourses.Name = "dgvCourses";
            this.dgvCourses.ReadOnly = true;
            this.dgvCourses.RowHeadersVisible = false;
            this.dgvCourses.RowTemplate.Height = 28;
            this.dgvCourses.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCourses.Size = new System.Drawing.Size(300, 338);
            this.dgvCourses.TabIndex = 0;
            this.dgvCourses.SelectionChanged += new System.EventHandler(this.dgvCourses_SelectionChanged);
            // 
            // groupBoxCourses
            // 
            this.groupBoxCourses.Controls.Add(this.btnClearCourse);
            this.groupBoxCourses.Controls.Add(this.btnDeleteCourse);
            this.groupBoxCourses.Controls.Add(this.btnUpdateCourse);
            this.groupBoxCourses.Controls.Add(this.btnAddCourse);
            this.groupBoxCourses.Controls.Add(this.txtCourseName);
            this.groupBoxCourses.Controls.Add(this.labelCourseName);
            this.groupBoxCourses.Controls.Add(this.txtCourseId);
            this.groupBoxCourses.Controls.Add(this.labelCourseId);
            this.groupBoxCourses.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.groupBoxCourses.Location = new System.Drawing.Point(320, 8);
            this.groupBoxCourses.Margin = new System.Windows.Forms.Padding(2);
            this.groupBoxCourses.Name = "groupBoxCourses";
            this.groupBoxCourses.Padding = new System.Windows.Forms.Padding(2);
            this.groupBoxCourses.Size = new System.Drawing.Size(327, 130);
            this.groupBoxCourses.TabIndex = 1;
            this.groupBoxCourses.TabStop = false;
            this.groupBoxCourses.Text = "Manage Courses";
            // 
            // btnClearCourse
            // 
            this.btnClearCourse.Location = new System.Drawing.Point(252, 84);
            this.btnClearCourse.Margin = new System.Windows.Forms.Padding(2);
            this.btnClearCourse.Name = "btnClearCourse";
            this.btnClearCourse.Size = new System.Drawing.Size(67, 26);
            this.btnClearCourse.TabIndex = 0;
            this.btnClearCourse.Text = "Clear";
            this.btnClearCourse.Click += new System.EventHandler(this.btnClearCourse_Click);
            // 
            // btnDeleteCourse
            // 
            this.btnDeleteCourse.Location = new System.Drawing.Point(173, 84);
            this.btnDeleteCourse.Margin = new System.Windows.Forms.Padding(2);
            this.btnDeleteCourse.Name = "btnDeleteCourse";
            this.btnDeleteCourse.Size = new System.Drawing.Size(67, 26);
            this.btnDeleteCourse.TabIndex = 1;
            this.btnDeleteCourse.Text = "Delete";
            this.btnDeleteCourse.Click += new System.EventHandler(this.btnDeleteCourse_Click);
            // 
            // btnUpdateCourse
            // 
            this.btnUpdateCourse.Location = new System.Drawing.Point(95, 84);
            this.btnUpdateCourse.Margin = new System.Windows.Forms.Padding(2);
            this.btnUpdateCourse.Name = "btnUpdateCourse";
            this.btnUpdateCourse.Size = new System.Drawing.Size(67, 26);
            this.btnUpdateCourse.TabIndex = 2;
            this.btnUpdateCourse.Text = "Update";
            this.btnUpdateCourse.Click += new System.EventHandler(this.btnUpdateCourse_Click);
            // 
            // btnAddCourse
            // 
            this.btnAddCourse.Location = new System.Drawing.Point(16, 84);
            this.btnAddCourse.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddCourse.Name = "btnAddCourse";
            this.btnAddCourse.Size = new System.Drawing.Size(67, 26);
            this.btnAddCourse.TabIndex = 3;
            this.btnAddCourse.Text = "Add";
            this.btnAddCourse.Click += new System.EventHandler(this.btnAddCourse_Click);
            // 
            // txtCourseName
            // 
            this.txtCourseName.Location = new System.Drawing.Point(95, 50);
            this.txtCourseName.Margin = new System.Windows.Forms.Padding(2);
            this.txtCourseName.Name = "txtCourseName";
            this.txtCourseName.Size = new System.Drawing.Size(220, 23);
            this.txtCourseName.TabIndex = 4;
            // 
            // labelCourseName
            // 
            this.labelCourseName.AutoSize = true;
            this.labelCourseName.Location = new System.Drawing.Point(13, 52);
            this.labelCourseName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelCourseName.Name = "labelCourseName";
            this.labelCourseName.Size = new System.Drawing.Size(82, 15);
            this.labelCourseName.TabIndex = 5;
            this.labelCourseName.Text = "Course Name:";
            // 
            // txtCourseId
            // 
            this.txtCourseId.Location = new System.Drawing.Point(87, 24);
            this.txtCourseId.Margin = new System.Windows.Forms.Padding(2);
            this.txtCourseId.Name = "txtCourseId";
            this.txtCourseId.ReadOnly = true;
            this.txtCourseId.Size = new System.Drawing.Size(68, 23);
            this.txtCourseId.TabIndex = 6;
            // 
            // labelCourseId
            // 
            this.labelCourseId.AutoSize = true;
            this.labelCourseId.Location = new System.Drawing.Point(13, 26);
            this.labelCourseId.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelCourseId.Name = "labelCourseId";
            this.labelCourseId.Size = new System.Drawing.Size(61, 15);
            this.labelCourseId.TabIndex = 7;
            this.labelCourseId.Text = "Course ID:";
            // 
            // groupBoxSubjects
            // 
            this.groupBoxSubjects.Controls.Add(this.dgvSubjects);
            this.groupBoxSubjects.Controls.Add(this.btnAddSubject);
            this.groupBoxSubjects.Controls.Add(this.txtSubjectName);
            this.groupBoxSubjects.Controls.Add(this.labelSubjectName);
            this.groupBoxSubjects.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.groupBoxSubjects.Location = new System.Drawing.Point(320, 143);
            this.groupBoxSubjects.Margin = new System.Windows.Forms.Padding(2);
            this.groupBoxSubjects.Name = "groupBoxSubjects";
            this.groupBoxSubjects.Padding = new System.Windows.Forms.Padding(2);
            this.groupBoxSubjects.Size = new System.Drawing.Size(327, 203);
            this.groupBoxSubjects.TabIndex = 2;
            this.groupBoxSubjects.TabStop = false;
            this.groupBoxSubjects.Text = "Manage Subjects for Selected Course";
            // 
            // dgvSubjects
            // 
            this.dgvSubjects.AllowUserToAddRows = false;
            this.dgvSubjects.AllowUserToDeleteRows = false;
            this.dgvSubjects.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSubjects.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSubjects.Location = new System.Drawing.Point(16, 78);
            this.dgvSubjects.Margin = new System.Windows.Forms.Padding(2);
            this.dgvSubjects.Name = "dgvSubjects";
            this.dgvSubjects.ReadOnly = true;
            this.dgvSubjects.RowHeadersVisible = false;
            this.dgvSubjects.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSubjects.Size = new System.Drawing.Size(297, 110);
            this.dgvSubjects.TabIndex = 0;
            // 
            // btnAddSubject
            // 
            this.btnAddSubject.Location = new System.Drawing.Point(220, 42);
            this.btnAddSubject.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddSubject.Name = "btnAddSubject";
            this.btnAddSubject.Size = new System.Drawing.Size(93, 26);
            this.btnAddSubject.TabIndex = 1;
            this.btnAddSubject.Text = "Add Subject";
            this.btnAddSubject.Click += new System.EventHandler(this.btnAddSubject_Click);
            // 
            // txtSubjectName
            // 
            this.txtSubjectName.Location = new System.Drawing.Point(16, 46);
            this.txtSubjectName.Margin = new System.Windows.Forms.Padding(2);
            this.txtSubjectName.Name = "txtSubjectName";
            this.txtSubjectName.Size = new System.Drawing.Size(201, 23);
            this.txtSubjectName.TabIndex = 2;
            // 
            // labelSubjectName
            // 
            this.labelSubjectName.AutoSize = true;
            this.labelSubjectName.Location = new System.Drawing.Point(13, 26);
            this.labelSubjectName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelSubjectName.Name = "labelSubjectName";
            this.labelSubjectName.Size = new System.Drawing.Size(111, 15);
            this.labelSubjectName.TabIndex = 3;
            this.labelSubjectName.Text = "New Subject Name:";
            // 
            // CourseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.BackgroundImage = global::UnicomTicManagementSystem.Properties.Resources.borderpng_parspng_com_14;
            this.ClientSize = new System.Drawing.Size(656, 354);
            this.Controls.Add(this.groupBoxSubjects);
            this.Controls.Add(this.groupBoxCourses);
            this.Controls.Add(this.dgvCourses);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
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

        // Declare all control variables
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