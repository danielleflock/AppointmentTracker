using C969.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static C969.Customers;
using static C969.Data.DatabaseHelper;

namespace C969
{
    public partial class Reports : Form
    {
        public Reports()
        {
            InitializeComponent();
        }

        private void GenerateAppointmentTypesByMonthReport()
        {
            var reportData = DatabaseHelper.GetAppointmentTypesByMonthData();

            var bindingList = new BindingList<AppointmentReportItem>(reportData);
            var source = new BindingSource(bindingList, null);
            dataGridViewReports.DataSource = source;

            dataGridViewReports.Columns["Month"].HeaderText = "Month";
            dataGridViewReports.Columns["Type"].HeaderText = "Appointment Type";
            dataGridViewReports.Columns["Count"].HeaderText = "Count";
            dataGridViewReports.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

       

        public class AppointmentReportItem
        {
            public string Month { get; set; }
            public string Type { get; set; }
            public int Count { get; set; }
        }

        private void GenerateConsultantScheduleReport()
        {
            var allAppointments = DatabaseHelper.GetAllAppointmentsWithUserDetails();

            var bindingList = new BindingList<AppointmentWithUserDetails>(allAppointments);
            var source = new BindingSource(bindingList, null);
            dataGridViewReports.DataSource = source;

            dataGridViewReports.Columns["UserName"].HeaderText = "Consultant";
            dataGridViewReports.Columns["CustomerName"].HeaderText = "Customer";
            dataGridViewReports.Columns["Type"].HeaderText = "Type";
            dataGridViewReports.Columns["StartTime"].HeaderText = "Start";
            dataGridViewReports.Columns["EndTime"].HeaderText = "End";

            dataGridViewReports.Columns["StartTime"].DefaultCellStyle.Format = "g";
            dataGridViewReports.Columns["EndTime"].DefaultCellStyle.Format = "g";

            dataGridViewReports.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }




        private void GenerateAppointmentsByCustomerReport()
        {
            var appointmentsData = DatabaseHelper.GetAllAppointments();

            var bindingList = new BindingList<Appointment>(appointmentsData);
            var source = new BindingSource(bindingList, null);
            dataGridViewReports.DataSource = source;

            dataGridViewReports.Columns["CustomerName"].HeaderText = "Customer Name";
            dataGridViewReports.Columns["Type"].HeaderText = "Appointment Type";
            dataGridViewReports.Columns["StartTime"].HeaderText = "Start Time";
            dataGridViewReports.Columns["EndTime"].HeaderText = "End Time";

            dataGridViewReports.Columns["StartTime"].DefaultCellStyle.Format = "g";
            dataGridViewReports.Columns["EndTime"].DefaultCellStyle.Format = "g";

            dataGridViewReports.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }



        private void btnAppointmentTypesByMonth_Click(object sender, EventArgs e)
        {
            GenerateAppointmentTypesByMonthReport();
        }

        private void btnConsultantSchedule_Click(object sender, EventArgs e)
        {
            GenerateConsultantScheduleReport();
        }

        private void btnAppointmentsByCustomer_Click(object sender, EventArgs e)
        {
            GenerateAppointmentsByCustomerReport();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
