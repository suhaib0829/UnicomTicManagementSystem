// In Views/StudentForm.Designer.cs

namespace UnicomTicManagementSystem.Views
{
    partial class StudentForm
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
            // --- Instantiate All Controls ---
            this.dgvStudents = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblPasswordInfo = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbCourses = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtStudentName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtStudentId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();

            // --- Configure DataGridView ---
            this.dgvStudents.AllowUserToAddRows = false;
            this.dgvStudents.AllowUserToDeleteRows = false;
            this.dgvStudents.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStudents.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvStudents.Location = new System.Drawing.Point(0, 0);
            this.dgvStudents.Name = "dgvStudents";
            this.dgvStudents.ReadOnly = true;
            this.dgvStudents.RowHeadersVisible = false;
            this.dgvStudents.RowTemplate.Height = 28;
            this.dgvStudents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStudents.Size = new System.Drawing.Size(978, 300);
            this.dgvStudents.TabIndex = 0;
            this.dgvStudents.SelectionChanged += new System.EventHandler(this.dgvStudents_SelectionChanged);

            // --- Configure GroupBox ---
            this.groupBox1.Controls.Add(this.lblPasswordInfo);
            this.groupBox1.Controls.Add(this.txtPassword);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cmbCourses);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtUsername);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtStudentName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtStudentId);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.btnUpdate);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.groupBox1.Location = new System.Drawing.Point(0, 300);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(978, 294);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Student Details";

            // --- Configure Labels and TextBoxes inside GroupBox ---
            this.label1.Location = new System.Drawing.Point(30, 40); this.label1.Text = "Student ID:"; this.label1.AutoSize = true;
            this.txtStudentId.Location = new System.Drawing.Point(140, 37); this.txtStudentId.ReadOnly = true; this.txtStudentId.Size = new System.Drawing.Size(100, 31);

            this.label2.Location = new System.Drawing.Point(30, 80); this.label2.Text = "Full Name:"; this.label2.AutoSize = true;
            this.txtStudentName.Location = new System.Drawing.Point(140, 77); this.txtStudentName.Size = new System.Drawing.Size(300, 31);

            this.label3.Location = new System.Drawing.Point(460, 40); this.label3.Text = "Username:"; this.label3.AutoSize = true;
            this.txtUsername.Location = new System.Drawing.Point(560, 37); this.txtUsername.Size = new System.Drawing.Size(300, 31);

            this.label4.Location = new System.Drawing.Point(460, 80); this.label4.Text = "Course:"; this.label4.AutoSize = true;
            this.cmbCourses.Location = new System.Drawing.Point(560, 77); this.cmbCourses.Size = new System.Drawing.Size(300, 33); this.cmbCourses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            this.label5.Location = new System.Drawing.Point(30, 120); this.label5.Text = "Password:"; this.label5.AutoSize = true;
            this.txtPassword.Location = new System.Drawing.Point(140, 117); this.txtPassword.Size = new System.Drawing.Size(300, 31); this.txtPassword.PasswordChar = '*';

            this.lblPasswordInfo.Location = new System.Drawing.Point(136, 151); this.lblPasswordInfo.Text = "(For new students only. Cannot be changed here.)"; this.lblPasswordInfo.AutoSize = true; this.lblPasswordInfo.ForeColor = System.Drawing.Color.DimGray;

            // --- Configure Buttons ---
            this.btnAdd.Location = new System.Drawing.Point(34, 220); this.btnAdd.Size = new System.Drawing.Size(180, 50); this.btnAdd.Text = "Add New"; this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            this.btnUpdate.Location = new System.Drawing.Point(232, 220); this.btnUpdate.Size = new System.Drawing.Size(180, 50); this.btnUpdate.Text = "Update Selected"; this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            this.btnDelete.Location = new System.Drawing.Point(430, 220); this.btnDelete.Size = new System.Drawing.Size(180, 50); this.btnDelete.Text = "Delete Selected"; this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            this.btnClear.Location = new System.Drawing.Point(628, 220); this.btnClear.Size = new System.Drawing.Size(180, 50); this.btnClear.Text = "Clear / Cancel"; this.btnClear.Click += new System.EventHandler(this.btnClear_Click);

            // --- Configure Form ---
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(978, 594);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvStudents);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "StudentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Manage Students";
            this.Load += new System.EventHandler(this.StudentForm_Load);

            ((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView dgvStudents;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtStudentId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtStudentName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbCourses;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblPasswordInfo;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
    }
}