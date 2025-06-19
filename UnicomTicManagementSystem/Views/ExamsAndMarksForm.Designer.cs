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
            // --- Main Container Controls ---
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageExams = new System.Windows.Forms.TabPage();
            this.tabPageMarks = new System.Windows.Forms.TabPage();

            // --- Controls for Exam Tab ---
            this.dgvExams = new System.Windows.Forms.DataGridView();
            this.groupBoxExams = new System.Windows.Forms.GroupBox();
            this.txtExamId = new System.Windows.Forms.TextBox();
            this.labelExamId = new System.Windows.Forms.Label();
            this.txtExamName = new System.Windows.Forms.TextBox();
            this.labelExamName = new System.Windows.Forms.Label();
            this.cmbSubjects = new System.Windows.Forms.ComboBox();
            this.labelSubject = new System.Windows.Forms.Label();
            this.btnClearExam = new System.Windows.Forms.Button();
            this.btnDeleteExam = new System.Windows.Forms.Button();
            this.btnUpdateExam = new System.Windows.Forms.Button();
            this.btnAddExam = new System.Windows.Forms.Button();

            // --- Controls for Marks Tab ---
            this.labelSelectExam = new System.Windows.Forms.Label();
            this.cmbExamsForMarks = new System.Windows.Forms.ComboBox();
            this.dgvMarks = new System.Windows.Forms.DataGridView();
            this.btnSaveChanges = new System.Windows.Forms.Button();

            // Suspend Layout
            this.tabControlMain.SuspendLayout();
            this.tabPageExams.SuspendLayout();
            this.tabPageMarks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExams)).BeginInit();
            this.groupBoxExams.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMarks)).BeginInit();
            this.SuspendLayout();

            // --- Configure TabControl ---
            this.tabControlMain.Controls.Add(this.tabPageExams);
            this.tabControlMain.Controls.Add(this.tabPageMarks);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tabControlMain.Location = new System.Drawing.Point(0, 0);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(978, 594);

            // --- Configure "Manage Exams" TabPage ---
            this.tabPageExams.Controls.Add(this.groupBoxExams);
            this.tabPageExams.Controls.Add(this.dgvExams);
            this.tabPageExams.Location = new System.Drawing.Point(4, 34);
            this.tabPageExams.Name = "tabPageExams";
            this.tabPageExams.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageExams.Size = new System.Drawing.Size(970, 556);
            this.tabPageExams.Text = "Manage Exams";
            this.tabPageExams.UseVisualStyleBackColor = true;
            this.tabPageExams.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));

            // --- Configure Controls within "Manage Exams" Tab ---
            this.dgvExams.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvExams.Size = new System.Drawing.Size(964, 250);
            this.dgvExams.AllowUserToAddRows = false;
            this.dgvExams.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvExams.ReadOnly = true;
            this.dgvExams.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvExams.SelectionChanged += new System.EventHandler(this.dgvExams_SelectionChanged);

            this.groupBoxExams.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxExams.Text = "Exam Details";
            this.groupBoxExams.Controls.Add(this.labelExamId); this.groupBoxExams.Controls.Add(this.txtExamId);
            this.groupBoxExams.Controls.Add(this.labelExamName); this.groupBoxExams.Controls.Add(this.txtExamName);
            this.groupBoxExams.Controls.Add(this.labelSubject); this.groupBoxExams.Controls.Add(this.cmbSubjects);
            this.groupBoxExams.Controls.Add(this.btnAddExam); this.groupBoxExams.Controls.Add(this.btnUpdateExam);
            this.groupBoxExams.Controls.Add(this.btnDeleteExam); this.groupBoxExams.Controls.Add(this.btnClearExam);

            this.labelExamId.Location = new System.Drawing.Point(20, 40); this.labelExamId.Text = "Exam ID:";
            this.txtExamId.Location = new System.Drawing.Point(130, 37); this.txtExamId.ReadOnly = true;
            this.labelExamName.Location = new System.Drawing.Point(20, 80); this.labelExamName.Text = "Exam Name:";
            this.txtExamName.Location = new System.Drawing.Point(130, 77); this.txtExamName.Size = new System.Drawing.Size(300, 31);
            this.labelSubject.Location = new System.Drawing.Point(20, 120); this.labelSubject.Text = "Subject:";
            this.cmbSubjects.Location = new System.Drawing.Point(130, 117); this.cmbSubjects.Size = new System.Drawing.Size(300, 33); this.cmbSubjects.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            this.btnAddExam.Location = new System.Drawing.Point(24, 180); this.btnAddExam.Size = new System.Drawing.Size(150, 40); this.btnAddExam.Text = "Add Exam"; this.btnAddExam.Click += new System.EventHandler(this.btnAddExam_Click);
            this.btnUpdateExam.Location = new System.Drawing.Point(190, 180); this.btnUpdateExam.Size = new System.Drawing.Size(150, 40); this.btnUpdateExam.Text = "Update Exam"; this.btnUpdateExam.Click += new System.EventHandler(this.btnUpdateExam_Click);
            this.btnDeleteExam.Location = new System.Drawing.Point(356, 180); this.btnDeleteExam.Size = new System.Drawing.Size(150, 40); this.btnDeleteExam.Text = "Delete Exam"; this.btnDeleteExam.Click += new System.EventHandler(this.btnDeleteExam_Click);
            this.btnClearExam.Location = new System.Drawing.Point(522, 180); this.btnClearExam.Size = new System.Drawing.Size(150, 40); this.btnClearExam.Text = "Clear"; this.btnClearExam.Click += new System.EventHandler(this.btnClearExam_Click);

            // --- Configure "Enter & View Marks" TabPage ---
            this.tabPageMarks.Controls.Add(this.btnSaveChanges);
            this.tabPageMarks.Controls.Add(this.dgvMarks);
            this.tabPageMarks.Controls.Add(this.cmbExamsForMarks);
            this.tabPageMarks.Controls.Add(this.labelSelectExam);
            this.tabPageMarks.Location = new System.Drawing.Point(4, 34);
            this.tabPageMarks.Name = "tabPageMarks";
            this.tabPageMarks.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMarks.Size = new System.Drawing.Size(970, 556);
            this.tabPageMarks.Text = "Enter & View Marks";
            this.tabPageMarks.UseVisualStyleBackColor = true;
            this.tabPageMarks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));

            // --- Configure Controls within "Enter & View Marks" Tab ---
            this.labelSelectExam.Location = new System.Drawing.Point(12, 15); this.labelSelectExam.Text = "Select Exam to Manage Marks For:"; this.labelSelectExam.AutoSize = true;
            this.cmbExamsForMarks.Location = new System.Drawing.Point(300, 12); this.cmbExamsForMarks.Size = new System.Drawing.Size(400, 33); this.cmbExamsForMarks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbExamsForMarks.SelectedIndexChanged += new System.EventHandler(this.cmbExamsForMarks_SelectedIndexChanged);

            this.dgvMarks.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right;
            this.dgvMarks.Location = new System.Drawing.Point(8, 60);
            this.dgvMarks.Size = new System.Drawing.Size(954, 420);
            this.dgvMarks.AllowUserToAddRows = false;
            this.dgvMarks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            this.btnSaveChanges.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            this.btnSaveChanges.Location = new System.Drawing.Point(762, 498); this.btnSaveChanges.Size = new System.Drawing.Size(200, 50);
            this.btnSaveChanges.Text = "Save All Changes";
            this.btnSaveChanges.Click += new System.EventHandler(this.btnSaveChanges_Click);

            // --- Configure Main Form ---
            this.ClientSize = new System.Drawing.Size(978, 594);
            this.Controls.Add(this.tabControlMain);
            this.Name = "ExamsAndMarksForm";
            this.Text = "Exams and Marks Management";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.ExamsAndMarksForm_Load);

            // Resume Layout
            this.tabControlMain.ResumeLayout(false);
            this.tabPageExams.ResumeLayout(false);
            this.tabPageMarks.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvExams)).EndInit();
            this.groupBoxExams.ResumeLayout(false);
            this.groupBoxExams.PerformLayout();
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