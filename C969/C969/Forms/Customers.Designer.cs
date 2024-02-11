namespace C969
{
    partial class Customers
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
            customerDataGridView = new DataGridView();
            apptDataGridView = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            customerName = new TextBox();
            customerStreet = new TextBox();
            customerPhone = new TextBox();
            btnAddCustomer = new Button();
            btnUpdateCustomer = new Button();
            btnDeleteCustomer = new Button();
            btnDeleteAppt = new Button();
            btnUpdateAppt = new Button();
            btnAddAppt = new Button();
            label7 = new Label();
            label8 = new Label();
            typeComboBox = new ComboBox();
            dateTimePickerStart = new DateTimePicker();
            dateTimePickerEnd = new DateTimePicker();
            label6 = new Label();
            customerCity = new TextBox();
            label10 = new Label();
            customerCountry = new TextBox();
            label11 = new Label();
            customerPostalCode = new TextBox();
            label12 = new Label();
            btnCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)customerDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)apptDataGridView).BeginInit();
            SuspendLayout();
            // 
            // customerDataGridView
            // 
            customerDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            customerDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            customerDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            customerDataGridView.Location = new Point(18, 24);
            customerDataGridView.Name = "customerDataGridView";
            customerDataGridView.RowTemplate.Height = 25;
            customerDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            customerDataGridView.Size = new Size(363, 229);
            customerDataGridView.TabIndex = 0;
            // 
            // apptDataGridView
            // 
            apptDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            apptDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            apptDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            apptDataGridView.Location = new Point(403, 24);
            apptDataGridView.Name = "apptDataGridView";
            apptDataGridView.RowTemplate.Height = 25;
            apptDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            apptDataGridView.Size = new Size(363, 229);
            apptDataGridView.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(18, 6);
            label1.Name = "label1";
            label1.Size = new Size(64, 15);
            label1.TabIndex = 2;
            label1.Text = "Customers";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(403, 6);
            label2.Name = "label2";
            label2.Size = new Size(138, 15);
            label2.TabIndex = 3;
            label2.Text = "Customer Appointments";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(61, 274);
            label3.Name = "label3";
            label3.Size = new Size(39, 15);
            label3.TabIndex = 4;
            label3.Text = "Name";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(19, 312);
            label4.Name = "label4";
            label4.Size = new Size(82, 15);
            label4.TabIndex = 5;
            label4.Text = "Street Address";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(190, 349);
            label5.Name = "label5";
            label5.Size = new Size(88, 15);
            label5.TabIndex = 6;
            label5.Text = "Phone Number";
            // 
            // customerName
            // 
            customerName.Location = new Point(106, 271);
            customerName.Name = "customerName";
            customerName.Size = new Size(75, 23);
            customerName.TabIndex = 7;
            // 
            // customerStreet
            // 
            customerStreet.Location = new Point(106, 308);
            customerStreet.Name = "customerStreet";
            customerStreet.Size = new Size(75, 23);
            customerStreet.TabIndex = 8;
            // 
            // customerPhone
            // 
            customerPhone.Location = new Point(284, 346);
            customerPhone.Name = "customerPhone";
            customerPhone.Size = new Size(75, 23);
            customerPhone.TabIndex = 9;
            // 
            // btnAddCustomer
            // 
            btnAddCustomer.Location = new Point(121, 384);
            btnAddCustomer.Name = "btnAddCustomer";
            btnAddCustomer.Size = new Size(75, 23);
            btnAddCustomer.TabIndex = 10;
            btnAddCustomer.Text = "Add";
            btnAddCustomer.UseVisualStyleBackColor = true;
            btnAddCustomer.Click += btnAddCustomer_Click;
            // 
            // btnUpdateCustomer
            // 
            btnUpdateCustomer.Location = new Point(203, 384);
            btnUpdateCustomer.Name = "btnUpdateCustomer";
            btnUpdateCustomer.Size = new Size(75, 23);
            btnUpdateCustomer.TabIndex = 11;
            btnUpdateCustomer.Text = "Update";
            btnUpdateCustomer.UseVisualStyleBackColor = true;
            btnUpdateCustomer.Click += btnUpdateCustomer_Click;
            // 
            // btnDeleteCustomer
            // 
            btnDeleteCustomer.Location = new Point(284, 384);
            btnDeleteCustomer.Name = "btnDeleteCustomer";
            btnDeleteCustomer.Size = new Size(75, 23);
            btnDeleteCustomer.TabIndex = 12;
            btnDeleteCustomer.Text = "Delete";
            btnDeleteCustomer.UseVisualStyleBackColor = true;
            btnDeleteCustomer.Click += btnDeleteCustomer_Click;
            // 
            // btnDeleteAppt
            // 
            btnDeleteAppt.Location = new Point(663, 384);
            btnDeleteAppt.Name = "btnDeleteAppt";
            btnDeleteAppt.Size = new Size(75, 23);
            btnDeleteAppt.TabIndex = 15;
            btnDeleteAppt.Text = "Delete";
            btnDeleteAppt.UseVisualStyleBackColor = true;
            btnDeleteAppt.Click += btnDeleteAppt_Click;
            // 
            // btnUpdateAppt
            // 
            btnUpdateAppt.Location = new Point(582, 384);
            btnUpdateAppt.Name = "btnUpdateAppt";
            btnUpdateAppt.Size = new Size(75, 23);
            btnUpdateAppt.TabIndex = 14;
            btnUpdateAppt.Text = "Update";
            btnUpdateAppt.UseVisualStyleBackColor = true;
            btnUpdateAppt.Click += btnUpdateAppt_Click;
            // 
            // btnAddAppt
            // 
            btnAddAppt.Location = new Point(500, 384);
            btnAddAppt.Name = "btnAddAppt";
            btnAddAppt.Size = new Size(75, 23);
            btnAddAppt.TabIndex = 13;
            btnAddAppt.Text = "Add";
            btnAddAppt.UseVisualStyleBackColor = true;
            btnAddAppt.Click += btnAddAppt_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(452, 314);
            label7.Name = "label7";
            label7.Size = new Size(60, 15);
            label7.TabIndex = 17;
            label7.Text = "Start Time";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(481, 277);
            label8.Name = "label8";
            label8.Size = new Size(31, 15);
            label8.TabIndex = 16;
            label8.Text = "Type";
            // 
            // typeComboBox
            // 
            typeComboBox.FormattingEnabled = true;
            typeComboBox.Location = new Point(535, 274);
            typeComboBox.Name = "typeComboBox";
            typeComboBox.Size = new Size(200, 23);
            typeComboBox.TabIndex = 19;
            // 
            // dateTimePickerStart
            // 
            dateTimePickerStart.CustomFormat = "MM/dd/yyyy hh:mm tt";
            dateTimePickerStart.Format = DateTimePickerFormat.Custom;
            dateTimePickerStart.Location = new Point(535, 309);
            dateTimePickerStart.Name = "dateTimePickerStart";
            dateTimePickerStart.ShowUpDown = true;
            dateTimePickerStart.Size = new Size(200, 23);
            dateTimePickerStart.TabIndex = 20;
            // 
            // dateTimePickerEnd
            // 
            dateTimePickerEnd.CustomFormat = "MM/dd/yyyy hh:mm tt";
            dateTimePickerEnd.Format = DateTimePickerFormat.Custom;
            dateTimePickerEnd.Location = new Point(535, 344);
            dateTimePickerEnd.Name = "dateTimePickerEnd";
            dateTimePickerEnd.ShowUpDown = true;
            dateTimePickerEnd.Size = new Size(200, 23);
            dateTimePickerEnd.TabIndex = 27;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(456, 350);
            label6.Name = "label6";
            label6.Size = new Size(56, 15);
            label6.TabIndex = 26;
            label6.Text = "End Time";
            // 
            // customerCity
            // 
            customerCity.Location = new Point(106, 345);
            customerCity.Name = "customerCity";
            customerCity.Size = new Size(75, 23);
            customerCity.TabIndex = 29;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(72, 349);
            label10.Name = "label10";
            label10.Size = new Size(28, 15);
            label10.TabIndex = 28;
            label10.Text = "City";
            // 
            // customerCountry
            // 
            customerCountry.Location = new Point(284, 271);
            customerCountry.Name = "customerCountry";
            customerCountry.Size = new Size(75, 23);
            customerCountry.TabIndex = 31;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(228, 274);
            label11.Name = "label11";
            label11.Size = new Size(50, 15);
            label11.TabIndex = 30;
            label11.Text = "Country";
            // 
            // customerPostalCode
            // 
            customerPostalCode.Location = new Point(284, 308);
            customerPostalCode.Name = "customerPostalCode";
            customerPostalCode.Size = new Size(75, 23);
            customerPostalCode.TabIndex = 33;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(208, 312);
            label12.Name = "label12";
            label12.Size = new Size(70, 15);
            label12.TabIndex = 32;
            label12.Text = "Postal Code";
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(713, 415);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 34;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // Customers
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnCancel);
            Controls.Add(customerPostalCode);
            Controls.Add(label12);
            Controls.Add(customerCountry);
            Controls.Add(label11);
            Controls.Add(customerCity);
            Controls.Add(label10);
            Controls.Add(dateTimePickerEnd);
            Controls.Add(label6);
            Controls.Add(dateTimePickerStart);
            Controls.Add(typeComboBox);
            Controls.Add(label7);
            Controls.Add(label8);
            Controls.Add(btnDeleteAppt);
            Controls.Add(btnUpdateAppt);
            Controls.Add(btnAddAppt);
            Controls.Add(btnDeleteCustomer);
            Controls.Add(btnUpdateCustomer);
            Controls.Add(btnAddCustomer);
            Controls.Add(customerPhone);
            Controls.Add(customerStreet);
            Controls.Add(customerName);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(apptDataGridView);
            Controls.Add(customerDataGridView);
            Name = "Customers";
            Text = "Customers";
            ((System.ComponentModel.ISupportInitialize)customerDataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)apptDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView customerDataGridView;
        private DataGridView apptDataGridView;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox customerName;
        private TextBox customerStreet;
        private TextBox customerPhone;
        private Button btnAddCustomer;
        private Button btnUpdateCustomer;
        private Button btnDeleteCustomer;
        private Button btnDeleteAppt;
        private Button btnUpdateAppt;
        private Button btnAddAppt;
        private Label label6;
        private Label label7;
        private Label label8;
        private ComboBox typeComboBox;
        private DateTimePicker dateTimePickerStart;
        private DateTimePicker dateTimePickerEnd;
        private Label label9;
        private TextBox customerCity;
        private Label label10;
        private TextBox customerCountry;
        private Label label11;
        private TextBox customerPostalCode;
        private Label label12;
        private Button btnCancel;
    }
}