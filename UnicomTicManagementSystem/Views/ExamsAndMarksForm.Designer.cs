// In Views/ExamsAndMarksForm.Designer.cs
namespace UnicomTicManagementSystem.Views
{
    partial class ExamsAndMarksForm
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
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageExams = new System.Windows.Forms.TabPage();
            this.groupBoxExams = new System.Windows.Forms.GroupBox();
            this.labelExamId = new System.Windows.Forms.Label();
            this.txtExamId = new System.Windows.Forms.TextBox();
            this.labelExamName = new System.Windows.Forms.Label();
            this.txtExamName = new System.Windows.Forms.TextBox();
            this.labelSubject = new System.Windows.Forms.Label();
            this.cmbSubjects = new System.Windows.Forms.ComboBox();
            this.btnAddExam = new System.Windows.Forms.Button();
            this.btnUpdateExam = new System.Windows.Forms.Button();
            this.btnDeleteExam = new System.Windows.Forms.Button();
            this.btnClearExam = new System.Windows.Forms.Button();
            this.dgvExams = new System.Windows.Forms.DataGridView();
            this.tabPageMarks = new System.Windows.Forms.TabPage();
            this.btnSaveChanges = new System.Windows.Forms.Button();
            this.dgvMarks = new System.Windows.Forms.DataGridView();
            this.cmbExamsForMarks = new System.Windows.Forms.ComboBox();
            this.labelSelectExam = new System.Windows.Forms.Label();
            this.tabControlMain.SuspendLayout();
            this.tabPageExams.SuspendLayout();
            this.groupBoxExams.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExams)).BeginInit();
            this.tabPageMarks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMarks)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabPageExams);
            this.tabControlMain.Controls.Add(this.tabPageMarks);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tabControlMain.Location = new System.Drawing.Point(0, 0);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(978, 594);
            this.tabControlMain.TabIndex = 0;
            // 
            // tabPageExams
            // 
            this.tabPageExams.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.tabPageExams.Controls.Add(this.groupBoxExams);
            this.tabPageExams.Controls.Add(this.dgvExams);
            this.tabPageExams.Location = new System.Drawing.Point(4, 24);
            this.tabPageExams.Name = "tabPageExams";
            this.tabPageExams.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageExams.Size = new System.Drawing.Size(970, 566);
            this.tabPageExams.TabIndex = 0;
            this.tabPageExams.Text = "Manage Exams";
            // 
            // groupBoxExams
            // 
            this.groupBoxExams.Controls.Add(this.labelExamId);
            this.groupBoxExams.Controls.Add(this.txtExamId);
            this.groupBoxExams.Controls.Add(this.labelExamName);
            this.groupBoxExams.Controls.Add(this.txtExamName);
            this.groupBoxExams.Controls.Add(this.labelSubject);
            this.groupBoxExams.Controls.Add(this.cmbSubjects);
            this.groupBoxExams.Controls.Add(this.btnAddExam);
            this.groupBoxExams.Controls.Add(this.btnUpdateExam);
            this.groupBoxExams.Controls.Add(this.btnDeleteExam);
            this.groupBoxExams.Controls.Add(this.btnClearExam);
            this.groupBoxExams.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxExams.Location = new System.Drawing.Point(3, 253);
            this.groupBoxExams.Name = "groupBoxExams";
            this.groupBoxExams.Size = new System.Drawing.Size(964, 310);
            this.groupBoxExams.TabIndex = 0;
            this.groupBoxExams.TabStop = false;
            this.groupBoxExams.Text = "Exam Details";
            // 
            // labelExamId
            // 
            this.labelExamId.Location = new System.Drawing.Point(20, 40);
            this.labelExamId.Name = "labelExamId";
            this.labelExamId.Size = new System.Drawing.Size(100, 23);
            this.labelExamId.TabIndex = 0;
            this.labelExamId.Text = "Exam ID:";
            // 
            // txtExamId
            // 
            this.txtExamId.Location = new System.Drawing.Point(130, 37);
            this.txtExamId.Name = "txtExamId";
            this.txtExamId.ReadOnly = true;
            this.txtExamId.Size = new System.Drawing.Size(100, 23);
            this.txtExamId.TabIndex = 1;
            // 
            // labelExamName
            // 
            this.labelExamName.Location = new System.Drawing.Point(20, 80);
            this.labelExamName.Name = "labelExamName";
            this.labelExamName.Size = new System.Drawing.Size(100, 23);
            this.labelExamName.TabIndex = 2;
            this.labelExamName.Text = "Exam Name:";
            // 
            // txtExamName
            // 
            this.txtExamName.Location = new System.Drawing.Point(130, 77);
            this.txtExamName.Name = "txtExamName";
            this.txtExamName.Size = new System.Drawing.Size(300, 23);
            this.txtExamName.TabIndex = 3;
            this.txtExamName.TextChanged += new System.EventHandler(this.txtExamName_TextChanged);
            // 
            // labelSubject
            // 
            this.labelSubject.Location = new System.Drawing.Point(20, 120);
            this.labelSubject.Name = "labelSubject";
            this.labelSubject.Size = new System.Drawing.Size(100, 23);
            this.labelSubject.TabIndex = 4;
            this.labelSubject.Text = "Subject:";
            // 
            // cmbSubjects
            // 
            this.cmbSubjects.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSubjects.Location = new System.Drawing.Point(130, 117);
            this.cmbSubjects.Name = "cmbSubjects";
            this.cmbSubjects.Size = new System.Drawing.Size(300, 23);
            this.cmbSubjects.TabIndex = 5;
            // 
            // btnAddExam
            // 
            this.btnAddExam.Location = new System.Drawing.Point(24, 180);
            this.btnAddExam.Name = "btnAddExam";
            this.btnAddExam.Size = new System.Drawing.Size(150, 40);
            this.btnAddExam.TabIndex = 6;
            this.btnAddExam.Text = "Add Exam";
            this.btnAddExam.Click += new System.EventHandler(this.btnAddExam_Click);
            // 
            // btnUpdateExam
            // 
            this.btnUpdateExam.Location = new System.Drawing.Point(190, 180);
            this.btnUpdateExam.Name = "btnUpdateExam";
            this.btnUpdateExam.Size = new System.Drawing.Size(150, 40);
            this.btnUpdateExam.TabIndex = 7;
            this.btnUpdateExam.Text = "Update Exam";
            this.btnUpdateExam.Click += new System.EventHandler(this.btnUpdateExam_Click);
            // 
            // btnDeleteExam
            // 
            this.btnDeleteExam.Location = new System.Drawing.Point(356, 180);
            this.btnDeleteExam.Name = "btnDeleteExam";
            this.btnDeleteExam.Size = new System.Drawing.Size(150, 40);
            this.btnDeleteExam.TabIndex = 8;
            this.btnDeleteExam.Text = "Delete Exam";
            this.btnDeleteExam.Click += new System.EventHandler(this.btnDeleteExam_Click);
            // 
            // btnClearExam
            // 
            this.btnClearExam.Location = new System.Drawing.Point(522, 180);
            this.btnClearExam.Name = "btnClearExam";
            this.btnClearExam.Size = new System.Drawing.Size(150, 40);
            this.btnClearExam.TabIndex = 9;
            this.btnClearExam.Text = "Clear";
            this.btnClearExam.Click += new System.EventHandler(this.btnClearExam_Click);
            // 
            // dgvExams
            // 
            this.dgvExams.AllowUserToAddRows = false;
            this.dgvExams.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvExams.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvExams.Location = new System.Drawing.Point(3, 3);
            this.dgvExams.Name = "dgvExams";
            this.dgvExams.ReadOnly = true;
            this.dgvExams.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvExams.Size = new System.Drawing.Size(964, 250);
            this.dgvExams.TabIndex = 1;
            this.dgvExams.SelectionChanged += new System.EventHandler(this.dgvExams_SelectionChanged);
            // 
            // tabPageMarks
            // 
            this.tabPageMarks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.tabPageMarks.Controls.Add(this.btnSaveChanges);
            this.tabPageMarks.Controls.Add(this.dgvMarks);
            this.tabPageMarks.Controls.Add(this.cmbExamsForMarks);
            this.tabPageMarks.Controls.Add(this.labelSelectExam);
            this.tabPageMarks.Location = new System.Drawing.Point(4, 24);
            this.tabPageMarks.Name = "tabPageMarks";
            this.tabPageMarks.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMarks.Size = new System.Drawing.Size(970, 566);
            this.tabPageMarks.TabIndex = 1;
            this.tabPageMarks.Text = "Enter & View Marks";
            // 
            // btnSaveChanges
            // 
            this.btnSaveChanges.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveChanges.Location = new System.Drawing.Point(762, 508);
            this.btnSaveChanges.Name = "btnSaveChanges";
            this.btnSaveChanges.Size = new System.Drawing.Size(200, 50);
            this.btnSaveChanges.TabIndex = 0;
            this.btnSaveChanges.Text = "Save All Changes";
            this.btnSaveChanges.Click += new System.EventHandler(this.btnSaveChanges_Click);
            // 
            // dgvMarks
            // 
            this.dgvMarks.AllowUserToAddRows = false;
            this.dgvMarks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMarks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMarks.Location = new System.Drawing.Point(8, 60);
            this.dgvMarks.Name = "dgvMarks";
            this.dgvMarks.Size = new System.Drawing.Size(954, 430);
            this.dgvMarks.TabIndex = 1;
            // 
            // cmbExamsForMarks
            // 
            this.cmbExamsForMarks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbExamsForMarks.Location = new System.Drawing.Point(300, 12);
            this.cmbExamsForMarks.Name = "cmbExamsForMarks";
            this.cmbExamsForMarks.Size = new System.Drawing.Size(400, 23);
            this.cmbExamsForMarks.TabIndex = 2;
            this.cmbExamsForMarks.SelectedIndexChanged += new System.EventHandler(this.cmbExamsForMarks_SelectedIndexChanged);
            // 
            // labelSelectExam
            // 
            this.labelSelectExam.AutoSize = true;
            this.labelSelectExam.Location = new System.Drawing.Point(12, 15);
            this.labelSelectExam.Name = "labelSelectExam";
            this.labelSelectExam.Size = new System.Drawing.Size(187, 15);
            this.labelSelectExam.TabIndex = 3;
            this.labelSelectExam.Text = "Select Exam to Manage Marks For:";
            // 
            // ExamsAndMarksForm
            // 
            this.ClientSize = new System.Drawing.Size(978, 594);
            this.Controls.Add(this.tabControlMain);
            this.Name = "ExamsAndMarksForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Exams and Marks Management";
            this.Load += new System.EventHandler(this.ExamsAndMarksForm_Load);
            this.tabControlMain.ResumeLayout(false);
            this.tabPageExams.ResumeLayout(false);
            this.groupBoxExams.ResumeLayout(false);
            this.groupBoxExams.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExams)).EndInit();
            this.tabPageMarks.ResumeLayout(false);
            this.tabPageMarks.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMarks)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        // Declare all control variables
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageExams;
        private System.Windows.Forms.TabPage tabPageMarks;
        private System.Windows.Forms.DataGridView dgvExams;
        private System.Windows.Forms.GroupBox groupBoxExams;
        private System.Windows.Forms.TextBox txtExamId;
        private System.Windows.Forms.Label labelExamId;
        private System.Windows.Forms.TextBox txtExamName;
        private System.Windows.Forms.Label labelExamName;
        private System.Windows.Forms.ComboBox cmbSubjects;
        private System.Windows.Forms.Label labelSubject;
        private System.Windows.Forms.Button btnClearExam;
        private System.Windows.Forms.Button btnDeleteExam;
        private System.Windows.Forms.Button btnUpdateExam;
        private System.Windows.Forms.Button btnAddExam;
        private System.Windows.Forms.Label labelSelectExam;
        private System.Windows.Forms.ComboBox cmbExamsForMarks;
        private System.Windows.Forms.DataGridView dgvMarks;
        private System.Windows.Forms.Button btnSaveChanges;
    }
}