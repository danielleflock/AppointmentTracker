namespace C969
{
    partial class Reports
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
            btnAppointmentTypesByMonth = new Button();
            btnConsultantSchedule = new Button();
            btnAppointmentsByCustomer = new Button();
            btnClose = new Button();
            dataGridViewReports = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridViewReports).BeginInit();
            SuspendLayout();
            // 
            // btnAppointmentTypesByMonth
            // 
            btnAppointmentTypesByMonth.Location = new Point(12, 32);
            btnAppointmentTypesByMonth.Name = "btnAppointmentTypesByMonth";
            btnAppointmentTypesByMonth.Size = new Size(244, 63);
            btnAppointmentTypesByMonth.TabIndex = 0;
            btnAppointmentTypesByMonth.Text = "Appointment Types by Month";
            btnAppointmentTypesByMonth.UseVisualStyleBackColor = true;
            btnAppointmentTypesByMonth.Click += btnAppointmentTypesByMonth_Click;
            // 
            // btnConsultantSchedule
            // 
            btnConsultantSchedule.Location = new Point(276, 32);
            btnConsultantSchedule.Name = "btnConsultantSchedule";
            btnConsultantSchedule.Size = new Size(244, 63);
            btnConsultantSchedule.TabIndex = 1;
            btnConsultantSchedule.Text = "Consultant Schedule";
            btnConsultantSchedule.UseVisualStyleBackColor = true;
            btnConsultantSchedule.Click += btnConsultantSchedule_Click;
            // 
            // btnAppointmentsByCustomer
            // 
            btnAppointmentsByCustomer.Location = new Point(544, 32);
            btnAppointmentsByCustomer.Name = "btnAppointmentsByCustomer";
            btnAppointmentsByCustomer.Size = new Size(244, 63);
            btnAppointmentsByCustomer.TabIndex = 2;
            btnAppointmentsByCustomer.Text = "Appointments by Customer";
            btnAppointmentsByCustomer.UseVisualStyleBackColor = true;
            btnAppointmentsByCustomer.Click += btnAppointmentsByCustomer_Click;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(697, 404);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(75, 23);
            btnClose.TabIndex = 3;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // dataGridViewReports
            // 
            dataGridViewReports.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewReports.Location = new Point(12, 117);
            dataGridViewReports.Name = "dataGridViewReports";
            dataGridViewReports.RowTemplate.Height = 25;
            dataGridViewReports.Size = new Size(776, 252);
            dataGridViewReports.TabIndex = 4;
            // 
            // Reports
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridViewReports);
            Controls.Add(btnClose);
            Controls.Add(btnAppointmentsByCustomer);
            Controls.Add(btnConsultantSchedule);
            Controls.Add(btnAppointmentTypesByMonth);
            Name = "Reports";
            Text = "Reports";
            ((System.ComponentModel.ISupportInitialize)dataGridViewReports).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnAppointmentTypesByMonth;
        private Button btnConsultantSchedule;
        private Button btnAppointmentsByCustomer;
        private Button btnClose;
        private ListView listViewReports;
        private DataGridView dataGridViewReports;
    }
}