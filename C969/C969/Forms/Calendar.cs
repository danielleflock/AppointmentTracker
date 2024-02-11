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
using C969.Helpers;

namespace C969
{
    public partial class Calendar : Form
    {
        public Calendar()
        {
            InitializeComponent();
            PopulateViewOptions();
        }

        private void PopulateViewOptions()
        {
            calendarDisplay.Items.Add("Week");
            calendarDisplay.Items.Add("Month");
            calendarDisplay.SelectedIndex = 0;
        }
        private void calendarDisplay_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateCalendarDisplay();
        }

        private void UpdateCalendarDisplay()
        {
            string selectedView = calendarDisplay.SelectedItem.ToString();
            if (selectedView == "Week")
            {
                DisplayWeekView();
            }
            else if (selectedView == "Month")
            {
                DisplayMonthView();
            }
        }

        private void DisplayWeekView()
        {
            var startDate = DateTime.Now.StartOfWeek(DayOfWeek.Monday);
            var endDate = startDate.AddDays(7);

            var appointments = DatabaseHelper.GetAppointmentsByDateRange(startDate, endDate);
            ConvertAppointmentTimesToLocal(appointments);
            dataGridViewCalendar.DataSource = appointments;

            FormatDataGridViewColumns();
        }

        private void DisplayMonthView()
        {
            var startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            var endDate = startDate.AddMonths(1).AddDays(-1);

            var appointments = DatabaseHelper.GetAppointmentsByDateRange(startDate, endDate);
            ConvertAppointmentTimesToLocal(appointments);
            dataGridViewCalendar.DataSource = appointments;

            FormatDataGridViewColumns();
        }

        private void ConvertAppointmentTimesToLocal(DataTable appointments)
        {
            foreach (DataRow row in appointments.Rows)
            {
                row["Start Date/Time"] = TimeZoneInfo.ConvertTimeFromUtc((DateTime)row["Start Date/Time"], TimeZoneInfo.Local);
                row["End Date/Time"] = TimeZoneInfo.ConvertTimeFromUtc((DateTime)row["End Date/Time"], TimeZoneInfo.Local);
            }
        }

        private void FormatDataGridViewColumns()
        {
            if (dataGridViewCalendar.Columns["Start Date/Time"] != null)
            {
                dataGridViewCalendar.Columns["Start Date/Time"].DefaultCellStyle.Format = "g";
            }
            if (dataGridViewCalendar.Columns["End Date/Time"] != null)
            {
                dataGridViewCalendar.Columns["End Date/Time"].DefaultCellStyle.Format = "g";
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
