using C969.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C969
{
    public partial class Customers : Form
    {
        private TimeZoneInfo currentTimeZone = TimeZoneInfo.Local;


        public class Appointment
        {
            public int AppointmentId { get; set; }
            public string CustomerName { get; set; }
            public DateTime StartTime { get; set; }
            public DateTime EndTime { get; set; }
            public string Type { get; set; }
        }
        public Customers()
        {
            InitializeComponent();
            this.currentTimeZone = TimeZoneInfo.Local;
            this.customerDataGridView.SelectionChanged += new System.EventHandler(this.dataGridViewCustomers_SelectionChanged);
            this.apptDataGridView.SelectionChanged += new System.EventHandler(this.apptDataGridView_SelectionChanged);
            CheckForUpcomingAppointments();
            DataGridView_Load();
            PopulateAppointmentTypeComboBox();
        }

        private void LoadAndConvertAppointmentTimes(int customerId)
        {
            DataTable appointment = DatabaseHelper.GetAppointmentsByCustomerId(customerId);

            foreach (DataRow row in appointment.Rows)
            {
                DateTime startUtc = Convert.ToDateTime(row["Start Date/Time"]);
                DateTime endUtc = Convert.ToDateTime(row["End Date/Time"]);

                row["Start Date/Time"] = TimeZoneInfo.ConvertTimeFromUtc(startUtc, TimeZoneInfo.Local);
                row["End Date/Time"] = TimeZoneInfo.ConvertTimeFromUtc(endUtc, TimeZoneInfo.Local);
            }

            apptDataGridView.DataSource = appointment;

            apptDataGridView.Refresh();
        }

        private void CheckForUpcomingAppointments()
        {
            var allAppointments = DatabaseHelper.GetAllAppointments();

            // Convert UTC start times to local timezone and filter for appointments within the next 15 minutes
            // Using lambda expressions for concise, readable data transformation and filtering
            var upcomingAppointments = allAppointments
                .Select(appointment => new Appointment
                {
                    AppointmentId = appointment.AppointmentId,
                    CustomerName = appointment.CustomerName,
                    StartTime = TimeZoneInfo.ConvertTimeFromUtc(appointment.StartTime, currentTimeZone), 
                })
                .Where(appointment => (appointment.StartTime - DateTime.Now).TotalMinutes <= 15 && (appointment.StartTime > DateTime.Now)) 
                .ToList();

            // lambda expression in ForEach to iterate over upcoming appointments and display alert
            upcomingAppointments.ForEach(appointment =>
                MessageBox.Show($"You have a meeting with {appointment.CustomerName} at {appointment.StartTime}", "Upcoming Appointment", MessageBoxButtons.OK, MessageBoxIcon.Information)
            );
        }


        private DateTime ConvertToLocalTime(DateTime utcTime, TimeZoneInfo timeZone)
        {
            return TimeZoneInfo.ConvertTimeFromUtc(utcTime, timeZone);
        }
        private void DataGridView_Load()
        {
            customerDataGridView.DataSource = DatabaseHelper.GetAllCustomers();
            customerDataGridView.AutoGenerateColumns = true;
            customerDataGridView.Columns["ID"].Visible = false;
            SetColumnVisibility("Customer Name", true);
            SetColumnVisibility("Address", true);
            SetColumnVisibility("Phone Number", true);
        }

        private void SetColumnVisibility(string columnName, bool visible)
        {
            if (customerDataGridView.Columns.Contains(columnName))
            {
                customerDataGridView.Columns[columnName].Visible = visible;
            }
            else
            {
                Console.WriteLine($"Column not found: {columnName}");
            }
        }

        private void dataGridViewCustomers_SelectionChanged(object sender, EventArgs e)
        {
            if (customerDataGridView.SelectedRows.Count > 0)
            {
                int customerId = Convert.ToInt32(customerDataGridView.SelectedRows[0].Cells["ID"].Value);
                var customerDetails = DatabaseHelper.GetCustomerDetailsById(customerId);

                if (customerDetails.Rows.Count > 0)
                {
                    var selectedRow = customerDetails.Rows[0];
                    customerName.Text = selectedRow["customerName"].ToString();
                    customerStreet.Text = selectedRow["address"].ToString();
                    customerCity.Text = selectedRow["city"].ToString();
                    customerCountry.Text = selectedRow["country"].ToString();
                    customerPostalCode.Text = selectedRow["postalCode"].ToString();
                    customerPhone.Text = selectedRow["phone"].ToString();

                    LoadAndConvertAppointmentTimes(customerId);
                }
            }
        }

        private void PopulateAppointmentTypeComboBox()
        {
            var appointmentTypes = new List<string> { "Presentation", "Scrum", "Consultation", "Follow-up", "Review" };
            typeComboBox.DataSource = appointmentTypes;
        }


        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            string name = customerName.Text.Trim();
            string streetAddress = customerStreet.Text.Trim();
            string city = customerCity.Text.Trim();
            string country = customerCountry.Text.Trim();
            string postalCode = customerPostalCode.Text.Trim();
            string phone = customerPhone.Text.Trim();

            if (!ValidateCustomerInput(name, streetAddress, city, country, postalCode, phone))
            {
                return;
            }

            try
            {
                int countryId = DatabaseHelper.InsertOrGetCountryId(country);
                int cityId = DatabaseHelper.InsertOrGetCityId(city, countryId);
                int addressId = DatabaseHelper.InsertAddress(streetAddress, postalCode, phone, cityId);
                DatabaseHelper.InsertCustomer(name, addressId);

                MessageBox.Show("Customer added successfully.");

                DataGridView_Load();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to add customer. Error: {ex.Message}");
            }
        }

        private void btnUpdateCustomer_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(customerName.Text))
            {
                MessageBox.Show("Customer name is required.");
                return;
            }

            int customerId = GetCurrentCustomerId();
            if (customerId == 0)
            {
                MessageBox.Show("No customer selected.");
                return;
            }

            int addressId = DatabaseHelper.GetAddressIdForCustomer(customerId);

            string name = customerName.Text.Trim();
            string streetAddress = customerStreet.Text.Trim();
            string city = customerCity.Text.Trim();
            string country = customerCountry.Text.Trim();
            string postalCode = customerPostalCode.Text.Trim();
            string phone = customerPhone.Text.Trim();

            if (!ValidateCustomerInput(name, streetAddress, city, country, postalCode, phone))
            {
                return; 
            }

            try
            {
                DatabaseHelper.UpdateAddress(addressId, streetAddress, "", city, country, postalCode, phone);

                DatabaseHelper.UpdateCustomer(customerId, name, addressId);

                MessageBox.Show("Customer updated successfully.");

                DataGridView_Load();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to update customer. Error: {ex.Message}");
            }
        }

        private int GetCurrentCustomerId()
        {
            if (customerDataGridView.SelectedRows.Count > 0)
            {
                return Convert.ToInt32(customerDataGridView.SelectedRows[0].Cells["ID"].Value);
            }
            return 0;
        }

        private bool ValidateCustomerInput(string name, string streetAddress, string city, string country, string postalCode, string phone)
        {
            bool isValid = true;
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(streetAddress) || string.IsNullOrWhiteSpace(city) || string.IsNullOrWhiteSpace(country))
            {
                MessageBox.Show("Name, street address, city, and country cannot be empty.");
                isValid = false;
            }

            Regex postalCodeRegex = new Regex(@"^\d{5}(-\d{4})?$");
            if (!postalCodeRegex.IsMatch(postalCode))
            {
                MessageBox.Show("Postal code is in an invalid format.");
                isValid = false;
            }

            return isValid;
        }




        private void btnDeleteCustomer_Click(object sender, EventArgs e)
        {
            int customerId = GetCurrentCustomerId();
            if (customerId > 0)
            {
                var confirmResult = MessageBox.Show("Are you sure you want to delete this customer and all related data?",
                                                     "Confirm Delete",
                                                     MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    try
                    {
                        DatabaseHelper.DeleteCustomer(customerId);
                        MessageBox.Show("Customer deleted successfully.");
                        DataGridView_Load();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Failed to delete customer. Error: {ex.Message}");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a customer to delete.");
            }
        }



        private void btnAddAppt_Click(object sender, EventArgs e)
        {
            int customerId = GetCurrentCustomerId();
            if (customerId <= 0)
            {
                MessageBox.Show("Please select a customer for the appointment.");
                return;
            }

            string appointmentType = typeComboBox.SelectedItem.ToString();

            DateTime startTimeLocal = dateTimePickerStart.Value;
            DateTime endTimeLocal = dateTimePickerEnd.Value;

            // Validate business hours and overlapping appointments
            if (!IsWithinBusinessHours(startTimeLocal, endTimeLocal))
            {
                MessageBox.Show("Appointment must be within business hours (9 AM to 5 PM local time).");
                return;
            }

            if (DatabaseHelper.IsOverlappingAppointment(customerId, startTimeLocal, endTimeLocal))
            {
                MessageBox.Show("This appointment overlaps with another appointment.");
                return;
            }

            // Convert local time to UTC
            DateTime startTimeUtc = TimeZoneInfo.ConvertTimeToUtc(dateTimePickerStart.Value, TimeZoneInfo.Local);
            DateTime endTimeUtc = TimeZoneInfo.ConvertTimeToUtc(dateTimePickerEnd.Value, TimeZoneInfo.Local);

            if (startTimeUtc >= endTimeUtc)
            {
                MessageBox.Show("Start time must be before end time.");
                return;
            }

            int userId = 1; 

            try
            {
                // Save the appointment in UTC
                DatabaseHelper.InsertAppointment(customerId, userId, appointmentType, startTimeUtc, endTimeUtc);
                MessageBox.Show("Appointment added successfully.");
                LoadAndConvertAppointmentTimes(customerId);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to add appointment. Error: {ex.Message}");
            }
        }

        private bool IsWithinBusinessHours(DateTime start, DateTime end)
        {
            TimeSpan businessStart = new TimeSpan(9, 0, 0); // 9 AM
            TimeSpan businessEnd = new TimeSpan(17, 0, 0); // 5 PM
            return start.TimeOfDay >= businessStart && end.TimeOfDay <= businessEnd && start.Date == end.Date;
        }


        private void btnUpdateAppt_Click(object sender, EventArgs e)
        {
            if (apptDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an appointment to update.");
                return;
            }

            int appointmentId = GetCurrentAppointmentId();
            int customerId = GetCurrentCustomerId();
            string type = typeComboBox.SelectedItem.ToString();

            DateTime startLocal = dateTimePickerStart.Value;
            DateTime endLocal = dateTimePickerEnd.Value;

            // Validate business hours and overlapping appointments
            if (!IsWithinBusinessHours(startLocal, endLocal))
            {
                MessageBox.Show("Appointment must be within business hours (9 AM to 5 PM local time).");
                return;
            }

            if (DatabaseHelper.IsOverlappingAppointment(customerId, startLocal, endLocal, appointmentId))
            {
                MessageBox.Show("This appointment overlaps with another appointment.");
                return;
            }

            // Convert local time to UTC for saving
            DateTime startUtc = TimeZoneInfo.ConvertTimeToUtc(dateTimePickerStart.Value, TimeZoneInfo.Local);
            DateTime endUtc = TimeZoneInfo.ConvertTimeToUtc(dateTimePickerEnd.Value, TimeZoneInfo.Local);

            if (startUtc >= endUtc)
            {
                MessageBox.Show("Start time must be before end time.");
                return;
            }

            try
            {
                DatabaseHelper.UpdateAppointment(appointmentId, type, startUtc, endUtc);
                MessageBox.Show("Appointment updated successfully.");

                LoadAndConvertAppointmentTimes(customerId); // Refresh and convert times
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to update appointment. Error: {ex.Message}");
            }
        }


        private void apptDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (apptDataGridView.SelectedRows.Count > 0)
            {
                string selectedType = Convert.ToString(apptDataGridView.SelectedRows[0].Cells["Appointment Type"].Value);
                DateTime startTime = Convert.ToDateTime(apptDataGridView.SelectedRows[0].Cells["Start Date/Time"].Value);
                DateTime endTime = Convert.ToDateTime(apptDataGridView.SelectedRows[0].Cells["End Date/Time"].Value);

                typeComboBox.SelectedItem = selectedType;

                dateTimePickerStart.Value = startTime;
                dateTimePickerEnd.Value = endTime;
            }
        }



        private void btnDeleteAppt_Click(object sender, EventArgs e)
        {
            if (apptDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an appointment to delete.");
                return;
            }

            var confirmResult = MessageBox.Show("Are you sure you want to delete this appointment?", "Confirm Deletion", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                int appointmentId = GetCurrentAppointmentId(); 
                try
                {
                    DatabaseHelper.DeleteAppointment(appointmentId);
                    MessageBox.Show("Appointment deleted successfully.");

                    int customerId = GetCurrentCustomerId();
                    apptDataGridView.DataSource = DatabaseHelper.GetAppointmentsByCustomerId(customerId);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to delete appointment. Error: {ex.Message}");
                }
            }
        }

        private int GetCurrentAppointmentId()
        {
            if (apptDataGridView.SelectedRows.Count > 0)
            {
                return Convert.ToInt32(apptDataGridView.SelectedRows[0].Cells["ID"].Value);
            }
            return 0;
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
