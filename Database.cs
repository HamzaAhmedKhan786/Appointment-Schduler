using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Appointment_Scheduler
{
    class Database
    {
        private Data_Object d_obj = new Data_Object();
        private string insert_sql = string.Empty;
        private SqlConnection connection;
        private string connectionString = "Data Source=DESKTOP-C5OOOF5; Initial Catalog = Calender; Integrated Security = True";

        public void Set_Data(Data_Object d_obj)
        {
            this.d_obj = d_obj;
        }

        private void CreateConnection()
        {

        }

        public void Insert_Data()
        {
            CreateConnection();
            SqlConnection connection = new SqlConnection(connectionString);

            insert_sql = "Insert into ScheduleAppointment (ID, Date, Time, Appointment_Subject, Description, Attendees) VALUES(@id, @date,@time ,@subject ,@desc ,@attendees)";

            SqlCommand cmd = new SqlCommand(insert_sql, connection);

            cmd.Parameters.AddWithValue("@id", d_obj.id);
            cmd.Parameters.AddWithValue("@date", d_obj.dt);
            cmd.Parameters.AddWithValue("@time", d_obj.time);
            cmd.Parameters.AddWithValue("@subject", d_obj.appointment_subject);
            cmd.Parameters.AddWithValue("@desc", d_obj.desc);
            cmd.Parameters.AddWithValue("@attendees", d_obj.attnd);

            try
            {
                connection.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Records Inserted Successfully");

            }
            catch (SqlException e)
            {
                MessageBox.Show("Error Generated. Details: " + e.ToString());
            }
            finally
            {
                connection.Close();
            }
        }

        public DataTable Get_Data(string month_str)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            int month_int = d_obj.Create_Month(month_str);
            string SqlString = "Select * from ScheduleAppointment WHERE Month(Date) =" + month_int + ";";
            SqlDataAdapter sda = new SqlDataAdapter(SqlString, connection);
            DataTable dt = new DataTable();
            try
            {
                connection.Open();
                sda.Fill(dt);


            }
            catch (SqlException se)
            {

            }
            finally
            {
                connection.Close();
            }
            return dt;

        }

      
    }

    public class Data_Object
    {
        public Guid id;
        public DateTime dt = new DateTime();
        public DateTime time = new DateTime();
        public string appointment_subject = string.Empty;
        public string desc = string.Empty;
        public string attnd = string.Empty;

        internal int Create_Month(string text)
        {
            int month = 0;
            if (!text.Equals(string.Empty))
            {
                if (text.Equals("Jan"))
                {
                    month = 1;
                }
                else if (text.Equals("Feb"))
                {
                    month = 2;
                }
                else if (text.Equals("Mar"))
                {
                    month = 3;
                }
                else if (text.Equals("Apr"))
                {
                    month = 4;
                }
                else if (text.Equals("May"))
                {
                    month = 5;
                }
                else if (text.Equals("Jun"))
                {
                    month = 6;
                }
                else if (text.Equals("Jul"))
                {
                    month = 7;
                }
                else if (text.Equals("Aug"))
                {
                    month = 8;
                }
                else if (text.Equals("Sep"))
                {
                    month = 9;
                }
                else if (text.Equals("Oct"))
                {
                    month = 10;
                }
                else if (text.Equals("Nov"))
                {
                    month = 11;
                }
                else if (text.Equals("Dec"))
                {
                    month = 12;
                }
            }
            return month;
        }
    }
}
