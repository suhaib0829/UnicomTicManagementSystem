using System;

namespace UnicomTICManagementSystem.Views
{
    partial class TimetableForm
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
            this.dgvTimetable = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.cmbRooms = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTimeSlot = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbSubjects = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTimetableId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimetable)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvTimetable
            // 
            this.dgvTimetable.AllowUserToAddRows = false;
            this.dgvTimetable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTimetable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTimetable.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvTimetable.Location = new System.Drawing.Point(0, 0);
            this.dgvTimetable.Name = "dgvTimetable";
            this.dgvTimetable.ReadOnly = true;
            this.dgvTimetable.RowHeadersWidth = 62;
            this.dgvTimetable.RowTemplate.Height = 28;
            this.dgvTimetable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTimetable.Size = new System.Drawing.Size(800, 284);
            this.dgvTimetable.TabIndex = 0;
            this.dgvTimetable.SelectionChanged += new System.EventHandler(this.dgvTimetable_SelectionChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.cmbRooms);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtTimeSlot);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cmbSubjects);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtTimetableId);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 284);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(800, 260);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Timetable Entry Details";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(542, 219);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(161, 29);
            this.button4.TabIndex = 11;
            this.button4.Text = "Clear / Cancel";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(85, 219);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(180, 29);
            this.button3.TabIndex = 10;
            this.button3.Text = "Delete Selected";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(542, 178);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(161, 35);
            this.button2.TabIndex = 9;
            this.button2.Text = "Update Selected";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(85, 178);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(180, 35);
            this.button1.TabIndex = 8;
            this.button1.Text = "Add New";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // cmbRooms
            // 
            this.cmbRooms.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRooms.FormattingEnabled = true;
            this.cmbRooms.Location = new System.Drawing.Point(582, 116);
            this.cmbRooms.Name = "cmbRooms";
            this.cmbRooms.Size = new System.Drawing.Size(177, 28);
            this.cmbRooms.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(425, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Room (Lab/Hall):";
            // 
            // txtTimeSlot
            // 
            this.txtTimeSlot.Location = new System.Drawing.Point(186, 116);
            this.txtTimeSlot.Name = "txtTimeSlot";
            this.txtTimeSlot.Size = new System.Drawing.Size(201, 26);
            this.txtTimeSlot.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(81, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Time Slot:";
            // 
            // cmbSubjects
            // 
            this.cmbSubjects.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSubjects.FormattingEnabled = true;
            this.cmbSubjects.Location = new System.Drawing.Point(582, 52);
            this.cmbSubjects.Name = "cmbSubjects";
            this.cmbSubjects.Size = new System.Drawing.Size(177, 28);
            this.cmbSubjects.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(486, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Subject:";
            // 
            // txtTimetableId
            // 
            this.txtTimetableId.Location = new System.Drawing.Point(186, 52);
            this.txtTimetableId.Name = "txtTimetableId";
            this.txtTimetableId.ReadOnly = true;
            this.txtTimetableId.Size = new System.Drawing.Size(201, 26);
            this.txtTimetableId.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(81, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Entry ID:";
            // 
            // TimetableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 544);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvTimetable);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "TimetableForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Manage Timetable";
            this.Load += new System.EventHandler(this.TimetableForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimetable)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTimetable;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbRooms;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTimeSlot;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbSubjects;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTimetableId;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
    }
}