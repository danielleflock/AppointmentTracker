namespace C969
{
    partial class Dashboard
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
            btnManageCustomers = new Button();
            btnViewCalendar = new Button();
            btnGenerateReports = new Button();
            btnLogout = new Button();
            SuspendLayout();
            // 
            // btnManageCustomers
            // 
            btnManageCustomers.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            btnManageCustomers.Location = new Point(260, 34);
            btnManageCustomers.Margin = new Padding(5, 6, 5, 6);
            btnManageCustomers.Name = "btnManageCustomers";
            btnManageCustomers.Size = new Size(290, 57);
            btnManageCustomers.TabIndex = 0;
            btnManageCustomers.Text = "Customers/Appointments";
            btnManageCustomers.UseVisualStyleBackColor = true;
            btnManageCustomers.Click += btnManageCustomers_Click;
            // 
            // btnViewCalendar
            // 
            btnViewCalendar.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            btnViewCalendar.Location = new Point(260, 119);
            btnViewCalendar.Margin = new Padding(5, 6, 5, 6);
            btnViewCalendar.Name = "btnViewCalendar";
            btnViewCalendar.Size = new Size(290, 57);
            btnViewCalendar.TabIndex = 2;
            btnViewCalendar.Text = "Calendar";
            btnViewCalendar.UseVisualStyleBackColor = true;
            btnViewCalendar.Click += btnViewCalendar_Click;
            // 
            // btnGenerateReports
            // 
            btnGenerateReports.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            btnGenerateReports.Location = new Point(260, 200);
            btnGenerateReports.Margin = new Padding(5, 6, 5, 6);
            btnGenerateReports.Name = "btnGenerateReports";
            btnGenerateReports.Size = new Size(290, 57);
            btnGenerateReports.TabIndex = 3;
            btnGenerateReports.Text = "Reports";
            btnGenerateReports.UseVisualStyleBackColor = true;
            btnGenerateReports.Click += btnGenerateReports_Click;
            // 
            // btnLogout
            // 
            btnLogout.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            btnLogout.Location = new Point(328, 331);
            btnLogout.Margin = new Padding(5, 6, 5, 6);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(163, 42);
            btnLogout.TabIndex = 4;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // Dashboard
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(815, 409);
            Controls.Add(btnLogout);
            Controls.Add(btnGenerateReports);
            Controls.Add(btnViewCalendar);
            Controls.Add(btnManageCustomers);
            Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(5, 6, 5, 6);
            Name = "Dashboard";
            Text = "Dashboard";
            ResumeLayout(false);
        }

        #endregion

        private Button btnManageCustomers;
        private Button btnViewCalendar;
        private Button btnGenerateReports;
        private Button btnLogout;
    }
}