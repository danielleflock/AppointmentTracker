namespace C969
{
    partial class Calendar
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
            dataGridViewCalendar = new DataGridView();
            label1 = new Label();
            calendarDisplay = new ComboBox();
            btnCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewCalendar).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewCalendar
            // 
            dataGridViewCalendar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCalendar.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCalendar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCalendar.Location = new Point(44, 72);
            dataGridViewCalendar.Name = "dataGridViewCalendar";
            dataGridViewCalendar.RowTemplate.Height = 25;
            dataGridViewCalendar.Size = new Size(710, 292);
            dataGridViewCalendar.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(45, 33);
            label1.Name = "label1";
            label1.Size = new Size(130, 15);
            label1.TabIndex = 1;
            label1.Text = "View Appointments by:";
            // 
            // calendarDisplay
            // 
            calendarDisplay.FormattingEnabled = true;
            calendarDisplay.Location = new Point(181, 30);
            calendarDisplay.Name = "calendarDisplay";
            calendarDisplay.Size = new Size(121, 23);
            calendarDisplay.TabIndex = 2;
            calendarDisplay.SelectedIndexChanged += calendarDisplay_SelectedIndexChanged;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(679, 402);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // Calendar
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnCancel);
            Controls.Add(calendarDisplay);
            Controls.Add(label1);
            Controls.Add(dataGridViewCalendar);
            Name = "Calendar";
            Text = "Calendar";
            ((System.ComponentModel.ISupportInitialize)dataGridViewCalendar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewCalendar;
        private Label label1;
        private ComboBox calendarDisplay;
        private Button btnCancel;
    }
}