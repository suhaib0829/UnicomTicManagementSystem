using System;

namespace UnicomTicManagementSystem.Views
{
    partial class CourseForm
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
            this.dgvCourses = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnClearCourse = new System.Windows.Forms.Button();
            this.btnDeleteCourse = new System.Windows.Forms.Button();
            this.btnUpdateCourse = new System.Windows.Forms.Button();
            this.btnAddCourse = new System.Windows.Forms.Button();
            this.txtCourseName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCourseId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCourses)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvCourses
            // 
            this.dgvCourses.AllowUserToAddRows = false;
            this.dgvCourses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCourses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCourses.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvCourses.Location = new System.Drawing.Point(0, 0);
            this.dgvCourses.Name = "dgvCourses";
            this.dgvCourses.ReadOnly = true;
            this.dgvCourses.RowHeadersWidth = 62;
            this.dgvCourses.RowTemplate.Height = 28;
            this.dgvCourses.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCourses.Size = new System.Drawing.Size(800, 239);
            this.dgvCourses.TabIndex = 0;
            this.dgvCourses.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvCourses_CellContentClick);
            this.dgvCourses.SelectionChanged += new System.EventHandler(this.DgvCourses_SelectionChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnClearCourse);
            this.groupBox1.Controls.Add(this.btnDeleteCourse);
            this.groupBox1.Controls.Add(this.btnUpdateCourse);
            this.groupBox1.Controls.Add(this.btnAddCourse);
            this.groupBox1.Controls.Add(this.txtCourseName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtCourseId);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(0, 245);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(800, 208);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Course Details";
            this.groupBox1.Enter += new System.EventHandler(this.GroupBox1_Enter);
            // 
            // btnClearCourse
            // 
            this.btnClearCourse.Location = new System.Drawing.Point(206, 161);
            this.btnClearCourse.Name = "btnClearCourse";
            this.btnClearCourse.Size = new System.Drawing.Size(106, 34);
            this.btnClearCourse.TabIndex = 7;
            this.btnClearCourse.Text = "Clear";
            this.btnClearCourse.UseVisualStyleBackColor = true;
            this.btnClearCourse.Click += new System.EventHandler(this.BtnClearCourse_Click);
            // 
            // btnDeleteCourse
            // 
            this.btnDeleteCourse.Location = new System.Drawing.Point(378, 161);
            this.btnDeleteCourse.Name = "btnDeleteCourse";
            this.btnDeleteCourse.Size = new System.Drawing.Size(106, 34);
            this.btnDeleteCourse.TabIndex = 6;
            this.btnDeleteCourse.Text = "Delete";
            this.btnDeleteCourse.UseVisualStyleBackColor = true;
            this.btnDeleteCourse.Click += new System.EventHandler(this.BtnDeleteCourse_Click);
            // 
            // btnUpdateCourse
            // 
            this.btnUpdateCourse.Location = new System.Drawing.Point(528, 99);
            this.btnUpdateCourse.Name = "btnUpdateCourse";
            this.btnUpdateCourse.Size = new System.Drawing.Size(106, 34);
            this.btnUpdateCourse.TabIndex = 5;
            this.btnUpdateCourse.Text = "Update";
            this.btnUpdateCourse.UseVisualStyleBackColor = true;
            this.btnUpdateCourse.Click += new System.EventHandler(this.BtnUpdateCourse_Click);
            // 
            // btnAddCourse
            // 
            this.btnAddCourse.Location = new System.Drawing.Point(528, 44);
            this.btnAddCourse.Name = "btnAddCourse";
            this.btnAddCourse.Size = new System.Drawing.Size(106, 34);
            this.btnAddCourse.TabIndex = 4;
            this.btnAddCourse.Text = "Add";
            this.btnAddCourse.UseVisualStyleBackColor = true;
            this.btnAddCourse.Click += new System.EventHandler(this.BtnAddCourse_Click);
            // 
            // txtCourseName
            // 
            this.txtCourseName.Location = new System.Drawing.Point(319, 75);
            this.txtCourseName.Name = "txtCourseName";
            this.txtCourseName.Size = new System.Drawing.Size(165, 26);
            this.txtCourseName.TabIndex = 3;
            this.txtCourseName.TextChanged += new System.EventHandler(this.TxtCourseName_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(202, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Course Name:";
            this.label2.Click += new System.EventHandler(this.Label2_Click);
            // 
            // txtCourseId
            // 
            this.txtCourseId.Enabled = false;
            this.txtCourseId.Location = new System.Drawing.Point(319, 26);
            this.txtCourseId.Name = "txtCourseId";
            this.txtCourseId.ReadOnly = true;
            this.txtCourseId.Size = new System.Drawing.Size(165, 26);
            this.txtCourseId.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(227, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Course ID:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // CourseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvCourses);
            this.Name = "CourseForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Manage Courses";
            this.Load += new System.EventHandler(this.CourseForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCourses)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        private void btnAddCourse_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCourses;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnUpdateCourse;
        private System.Windows.Forms.Button btnAddCourse;
        private System.Windows.Forms.TextBox txtCourseName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCourseId;
        private System.Windows.Forms.Button btnClearCourse;
        private System.Windows.Forms.Button btnDeleteCourse;
    }
}