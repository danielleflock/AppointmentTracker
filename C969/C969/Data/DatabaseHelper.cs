using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static C969.Customers;
using static C969.Reports;

namespace C969.Data
{
    public class DatabaseHelper
    {
        private static string connectionString = "server=127.0.0.1; port=3306; database=client_schedule; user=sqlUser; password=Passw0rd!;";

        public static void TestDatabaseConnection()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MessageBox.Show("Connection Successful!", "Database Connection Test", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"Connection Failed: {ex.Message}", "Database Connection Test", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public static bool ValidateUser(string username, string password)
        {
            bool isValid = false;
            string query = "SELECT COUNT(*) FROM user WHERE userName = @username AND password = @password"; 

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password); 

                    try
                    {
                        conn.Open();
                        int result = Convert.ToInt32(cmd.ExecuteScalar());
                        if (result > 0)
                        {
                            isValid = true;
                        }
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show($"Database error: {ex.Message}");
                    }
                }
            }

            return isValid;
        }       

        public static DataTable GetAllCustomers()
        {
            DataTable customerDetails = new DataTable();
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                var query = @"SELECT 
                  c.customerId AS 'ID', 
                  c.customerName AS 'Name', 
                  CONCAT(a.address, ', ', city.city, ', ', country.country) AS 'Address', 
                  a.phone AS 'Phone Number'
              FROM 
                  customer c
                  JOIN address a ON c.addressId = a.addressId
                  JOIN city ON a.cityId = city.cityId
                  JOIN country ON city.countryId = country.countryId;";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    using (var adapter = new MySqlDataAdapter(cmd))
                    {
                        adapter.Fill(customerDetails);
                    }
                }
            }
            return customerDetails;
        }


        public static DataTable GetCustomerDetailsById(int customerId)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                var query = @"
                    SELECT c.customerId, c.customerName, a.address, a.postalCode, a.phone, city.city, country.country
                    FROM customer c
                    JOIN address a ON c.addressId = a.addressId
                    JOIN city ON a.cityId = city.cityId
                    JOIN country ON city.countryId = country.countryId
                    WHERE c.customerId = @customerId;";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@customerId", customerId);
                    using (var adapter = new MySqlDataAdapter(cmd))
                    {
                        DataTable customerDetails = new DataTable();
                        adapter.Fill(customerDetails);
                        return customerDetails;
                    }
                }
            }
        }

        public static DataTable GetAppointmentsByCustomerId(int customerId)
        {
            using (var conn = new MySqlConnection("server=127.0.0.1; port=3306; database=client_schedule; user=sqlUser; password=Passw0rd!;"))
            {
                conn.Open();
                using (var cmd = new MySqlCommand("SELECT appointmentId AS 'ID', type AS 'Appointment Type', start AS 'Start Date/Time', end AS 'End Date/Time' FROM Appointment WHERE CustomerId = @CustomerId ORDER BY start", conn))
                {
                    cmd.Parameters.AddWithValue("@CustomerId", customerId);
                    using (var adapter = new MySqlDataAdapter(cmd))
                    {
                        DataTable appointment = new DataTable();
                        adapter.Fill(appointment);
                        return appointment;
                    }
                }
            }
        }
        


        private static int GetIdIfExists(string tableName, string idColumnName, string searchColumn, string searchValue)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                var query = $"SELECT {idColumnName} FROM {tableName} WHERE {searchColumn} = @searchValue LIMIT 1;";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@searchValue", searchValue);
                    var result = cmd.ExecuteScalar();
                    return result != null ? Convert.ToInt32(result) : 0;
                }
            }
        }

        public static int InsertOrGetCountryId(string countryName)
        {
            int countryId = GetIdIfExists("country", "countryId", "country", countryName);
            if (countryId != 0) return countryId;

            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                var query = "INSERT INTO country (country, createDate, createdBy, lastUpdate, lastUpdateBy) VALUES (@country, NOW(), 'admin', NOW(), 'admin'); SELECT LAST_INSERT_ID();";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@country", countryName);
                    countryId = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            return countryId;
        }

        public static int InsertOrGetCityId(string cityName, int countryId)
        {
            int cityId = GetIdIfExists("city", "cityId", "city", cityName);
            if (cityId != 0) return cityId;

            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                var query = "INSERT INTO city (city, countryId, createDate, createdBy, lastUpdate, lastUpdateBy) VALUES (@city, @countryId, NOW(), 'admin', NOW(), 'admin'); SELECT LAST_INSERT_ID();";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@city", cityName);
                    cmd.Parameters.AddWithValue("@countryId", countryId);
                    cityId = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            return cityId;
        }

        public static int InsertAddress(string address, string postalCode, string phone, int cityId)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                var query = "INSERT INTO address (address, address2, postalCode, phone, cityId, createDate, createdBy, lastUpdate, lastUpdateBy) VALUES (@address, '', @postalCode, @phone, @cityId, NOW(), 'admin', NOW(), 'admin'); SELECT LAST_INSERT_ID();";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@address", address);
                    cmd.Parameters.AddWithValue("@postalCode", postalCode);
                    cmd.Parameters.AddWithValue("@phone", phone);
                    cmd.Parameters.AddWithValue("@cityId", cityId);
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        public static void InsertCustomer(string customerName, int addressId)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                var query = "INSERT INTO customer (customerName, addressId, active, createDate, createdBy, lastUpdate, lastUpdateBy) VALUES (@customerName, @addressId, 1, NOW(), 'admin', NOW(), 'admin');";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@customerName", customerName);
                    cmd.Parameters.AddWithValue("@addressId", addressId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void UpdateCustomer(int customerId, string customerName, int addressId)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                var query = "UPDATE customer SET customerName = @customerName, addressId = @addressId, lastUpdate = NOW(), lastUpdateBy = 'admin' WHERE customerId = @customerId;";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@customerName", customerName);
                    cmd.Parameters.AddWithValue("@addressId", addressId);
                    cmd.Parameters.AddWithValue("@customerId", customerId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void UpdateAddress(int addressId, string address, string address2, string city, string country, string postalCode, string phone)
        {
            int countryId = InsertOrGetCountryId(country);

            int cityId = InsertOrGetCityId(city, countryId);

            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                var query = @"UPDATE address 
                      SET address = @address, address2 = @address2, postalCode = @postalCode, 
                          phone = @phone, cityId = @cityId, lastUpdate = NOW(), lastUpdateBy = 'admin' 
                      WHERE addressId = @addressId;";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@address", address);
                    cmd.Parameters.AddWithValue("@address2", address2);
                    cmd.Parameters.AddWithValue("@postalCode", postalCode);
                    cmd.Parameters.AddWithValue("@phone", phone);
                    cmd.Parameters.AddWithValue("@cityId", cityId);
                    cmd.Parameters.AddWithValue("@addressId", addressId);
                    cmd.ExecuteNonQuery();
                }
            }
        }



        public static List<Appointment> GetAllAppointments()
        {
            List<Appointment> appointments = new List<Appointment>();
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                var query = @"
                    SELECT 
                        a.appointmentId AS 'appointmentId', 
                        c.customerName AS 'customerName', 
                        a.type AS 'type',
                        a.start AS 'start',
                        a.end AS 'end' 
                    FROM 
                        appointment a
                    JOIN 
                        customer c ON a.customerId = c.customerId
                    ORDER BY 
                        a.start;";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            appointments.Add(new Appointment
                            {
                                AppointmentId = reader.GetInt32("appointmentId"),
                                CustomerName = reader.GetString("customerName"),
                                Type = reader.GetString("type"), 
                                StartTime = reader.GetDateTime("start"),
                                EndTime = reader.GetDateTime("end") 
                            });
                        }
                    }
                }
            }
            return appointments;
        }


        public static List<AppointmentReportItem> GetAppointmentTypesByMonthData()
        {
            List<AppointmentReportItem> reportItems = new List<AppointmentReportItem>();
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                var query = @"
                    SELECT 
                        DATE_FORMAT(start, '%Y-%m') AS Month, 
                        type, 
                        COUNT(*) AS Count 
                    FROM 
                        appointment 
                    GROUP BY 
                        DATE_FORMAT(start, '%Y-%m'), type
                    ORDER BY 
                        Month, type;";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var month = reader.GetString("Month");
                            var type = reader.GetString("type");
                            var count = reader.GetInt32("Count");
                            reportItems.Add(new AppointmentReportItem { Month = month, Type = type, Count = count });
                        }
                    }
                }
            }
            return reportItems;
        }


        public static int GetAddressIdForCustomer(int customerId)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                var query = "SELECT addressId FROM customer WHERE customerId = @customerId;";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@customerId", customerId);
                    var result = cmd.ExecuteScalar();
                    return result != null ? Convert.ToInt32(result) : 0;
                }
            }
        }

        public static bool IsOverlappingAppointment(int customerId, DateTime startLocal, DateTime endLocal, int? excludingAppointmentId = null)
        {
            // Convert local start and end times to UTC to compare against database values
            DateTime startUtc = TimeZoneInfo.ConvertTimeToUtc(startLocal, TimeZoneInfo.Local);
            DateTime endUtc = TimeZoneInfo.ConvertTimeToUtc(endLocal, TimeZoneInfo.Local);

            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = @"
                    SELECT COUNT(*) FROM appointment
                    WHERE customerId = @customerId
                    AND ((start < @endUtc AND end > @startUtc)
                    OR (start = @startUtc AND end = @endUtc))";

                if (excludingAppointmentId.HasValue)
                {
                    query += " AND appointmentId != @excludingAppointmentId";
                }

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@customerId", customerId);
                    cmd.Parameters.AddWithValue("@startUtc", startUtc);
                    cmd.Parameters.AddWithValue("@endUtc", endUtc);
                    if (excludingAppointmentId.HasValue)
                    {
                        cmd.Parameters.AddWithValue("@excludingAppointmentId", excludingAppointmentId.Value);
                    }
                    int overlappingCount = Convert.ToInt32(cmd.ExecuteScalar());
                    return overlappingCount > 0;
                }
            }
        }

        public static List<AppointmentWithUserDetails> GetAllAppointmentsWithUserDetails()
        {
            List<AppointmentWithUserDetails> appointments = new List<AppointmentWithUserDetails>();

            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                var query = @"
                    SELECT a.appointmentId, a.type, a.start, a.end, c.customerName, u.userName 
                    FROM appointment a
                    JOIN customer c ON a.customerId = c.customerId
                    JOIN user u ON a.userId = u.userId
                    ORDER BY a.start";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var appointment = new AppointmentWithUserDetails
                            {
                                AppointmentId = reader.GetInt32("appointmentId"),
                                Type = reader.GetString("type"),
                                StartTime = reader.GetDateTime("start"),
                                EndTime = reader.GetDateTime("end"),
                                CustomerName = reader.GetString("customerName"),
                                UserName = reader.GetString("userName")
                            };
                            appointments.Add(appointment);
                        }
                    }
                }
            }

            return appointments;
        }

        public class AppointmentWithUserDetails
        {
            public int AppointmentId { get; set; }
            public string Type { get; set; }
            public DateTime StartTime { get; set; }
            public DateTime EndTime { get; set; }
            public string CustomerName { get; set; }
            public string UserName { get; set; } // Consultant name
        }


        public static void DeleteCustomer(int customerId)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                var trans = conn.BeginTransaction();

                try
                {
                    // Delete related appointments first
                    var deleteAppointmentsQuery = "DELETE FROM appointment WHERE customerId = @customerId;";
                    using (var cmd = new MySqlCommand(deleteAppointmentsQuery, conn, trans))
                    {
                        cmd.Parameters.AddWithValue("@customerId", customerId);
                        cmd.ExecuteNonQuery();
                    }

                    // Delete the customer
                    var deleteCustomerQuery = "DELETE FROM customer WHERE customerId = @customerId;";
                    using (var cmd = new MySqlCommand(deleteCustomerQuery, conn, trans))
                    {
                        cmd.Parameters.AddWithValue("@customerId", customerId);
                        cmd.ExecuteNonQuery();
                    }

                    trans.Commit();
                }
                catch
                {
                    trans.Rollback();
                    throw;
                }
            }
        }

        public static void InsertAppointment(int customerId, int userId, string type, DateTime start, DateTime end)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                var query = @"
            INSERT INTO appointment (customerId, userId, title, description, location, contact, type, url, start, end, createDate, createdBy, lastUpdate, lastUpdateBy)
            VALUES (@customerId, @userId, '', '', '', '', @type, '', @start, @end, NOW(), 'system', NOW(), 'system');";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@customerId", customerId);
                    cmd.Parameters.AddWithValue("@userId", userId);
                    cmd.Parameters.AddWithValue("@type", type);
                    cmd.Parameters.AddWithValue("@start", start);
                    cmd.Parameters.AddWithValue("@end", end);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void DeleteAppointment(int appointmentId)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                var query = "DELETE FROM appointment WHERE appointmentId = @appointmentId;";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@appointmentId", appointmentId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void UpdateAppointment(int appointmentId, string type, DateTime start, DateTime end)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                var query = @"
            UPDATE appointment 
            SET 
                type = @type, 
                start = @start, 
                end = @end, 
                lastUpdate = NOW(), 
                lastUpdateBy = 'system' 
            WHERE appointmentId = @appointmentId;";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@type", type);
                    cmd.Parameters.AddWithValue("@start", start);
                    cmd.Parameters.AddWithValue("@end", end);
                    cmd.Parameters.AddWithValue("@appointmentId", appointmentId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static DataTable GetAppointmentsByDateRange(DateTime start, DateTime end)
        {
            DataTable appointment = new DataTable();
            string connectionString = "server=127.0.0.1; port=3306; database=client_schedule; user=sqlUser; password=Passw0rd!;";

            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = @"SELECT 
                                    a.start AS 'Start Date/Time',
                                    a.end AS 'End Date/Time',
                                    a.customerId AS 'Customer ID',
                                    c.customerName AS 'Customer Name',
                                    a.type AS 'Appointment Type'
                                FROM 
                                    appointment a
                                JOIN 
                                    customer c ON a.customerId = c.customerId
                                WHERE 
                                    a.start >= @StartDate AND a.end <= @EndDate
                                ORDER BY 
                                    a.start";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@StartDate", start);
                    cmd.Parameters.AddWithValue("@EndDate", end);
                    using (var adapter = new MySqlDataAdapter(cmd))
                    {
                        adapter.Fill(appointment);
                    }
                }
            }
            return appointment;
        }



    }
}
