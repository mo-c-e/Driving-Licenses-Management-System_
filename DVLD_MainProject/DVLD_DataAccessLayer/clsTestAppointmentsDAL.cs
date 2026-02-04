using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccessLayer
{
    public class clsTestAppointmentsDAL
    {
       

        public static bool FindTestAppointmentByID(int TestAppointmentID, ref int TestTypeID, ref int LocalDrivingLicenseApplicationID,ref DateTime AppointmentDate,ref float PaidFees,ref int CreatedByUserID,
            ref byte IsLocked,ref Nullable<int> RetakeTestApplicationID)
        {
            bool Find = true;
            SqlConnection connection = new SqlConnection(DataBaseSettings.connectionString);
            string query = "select * from TestAppointments where TestAppointmentID=@TestAppointmentID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    Find = true;
                    TestTypeID = (int)reader["TestTypeID"];
                    LocalDrivingLicenseApplicationID = (int)reader["LocalDrivingLicenseApplicationID"];
                    AppointmentDate = (DateTime)reader["AppointmentDate"];
                    PaidFees = Convert.ToSingle(reader["PaidFees"]);
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    IsLocked = Convert.ToByte(reader["IsLocked"]);
                    // RetakeTestApplicationID = (Nullable<int>)reader["RetakeTestApplicationID"];
                    RetakeTestApplicationID = reader["RetakeTestApplicationID"] != DBNull.Value? Convert.ToInt32(reader["RetakeTestApplicationID"]): (int?)null;


                }
                else
                {
                    Find = false;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Find = false;
                Console.WriteLine("Error Find : {0}", ex.Message);

            }
            finally
            {
                connection.Close();
            }
            return Find;

        }

       
        public static DataTable GetTestAppointmentTable()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(DataBaseSettings.connectionString);
            string query = "select * from TestAppointments;";
            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : {0}", ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return dt;
        }

        public static DataTable GetTestAppointmentTableByLocalDrivingLicense(int LocalDrivingLicenseApplicationID,int TestTypeID)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(DataBaseSettings.connectionString);
            string query = " select TestAppointmentID,AppointmentDate,PaidFees,IsLocked from TestAppointments where LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID  and TestTypeID=@TestTypeID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : {0}", ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return dt;
        }

        public static int CountTiral(int TestTypeID,int LocalDrivingLicenseApplicationID)
        {
            int ID = -1;
            SqlConnection connection = new SqlConnection(DataBaseSettings.connectionString);
            string query = @"select Count(R.RetakeTestApplicationID) as Trial
                             from 
                             (select TestAppointments.TestAppointmentID,TestTypes.TestTypeTitle,LocalDrivingLicenseApplicationID,RetakeTestApplicationID 
                            from TestAppointments inner join TestTypes on TestAppointments.TestTypeID= TestTypes.TestTypeID where 
                   TestAppointments.TestTypeID=@TestTypeID  and TestAppointments.LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID)R group by R.LocalDrivingLicenseApplicationID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int Trial))
                {
                    ID = Trial;
                }

            }
            catch (Exception ex)
            {

                Console.WriteLine("Error add: {0}", ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return ID;
        }

        public static int AddNewTestAppointment(int TestAppointmentID, int TestTypeID, int LocalDrivingLicenseApplicationID,  DateTime AppointmentDate, float PaidFees, int CreatedByUserID,
             byte IsLocked, Nullable<int>  RetakeTestApplicationID)
        {
            int ID = -1;
            SqlConnection connection = new SqlConnection(DataBaseSettings.connectionString);
            string query = @"insert into TestAppointments(TestTypeID, LocalDrivingLicenseApplicationID,AppointmentDate,PaidFees,CreatedByUserID,
             IsLocked,RetakeTestApplicationID)
                values (@TestTypeID,@LocalDrivingLicenseApplicationID,@AppointmentDate,@PaidFees,@CreatedByUserID,@IsLocked,@RetakeTestApplicationID);
                         select SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@IsLocked", IsLocked);
            //command.Parameters.AddWithValue("@RetakeTestApplicationID", RetakeTestApplicationID);
            command.Parameters.AddWithValue("@RetakeTestApplicationID",(object)RetakeTestApplicationID ?? DBNull.Value);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    ID = insertedID;
                }

            }
            catch (Exception ex)
            {

                Console.WriteLine("Error add: {0}", ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return ID;
        }

        public static bool UpdateTestAppointment(int TestAppointmentID, int TestTypeID, int LocalDrivingLicenseApplicationID, DateTime AppointmentDate, float PaidFees, int CreatedByUserID,
             byte IsLocked, Nullable<int> RetakeTestApplicationID)
        {
            SqlConnection connection = new SqlConnection(DataBaseSettings.connectionString);
            int rows_affected = 0;
            string query = @"update TestAppointments 
             set TestTypeID=@TestTypeID,LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID,AppointmentDate=@AppointmentDate,PaidFees=@PaidFees,
			 CreatedByUserID=@CreatedByUserID,IsLocked=@IsLocked,RetakeTestApplicationID=@RetakeTestApplicationID where TestAppointmentID=@TestAppointmentID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@IsLocked", IsLocked);
            //  command.Parameters.AddWithValue("@RetakeTestApplicationID", RetakeTestApplicationID);
            command.Parameters.AddWithValue("@RetakeTestApplicationID",RetakeTestApplicationID ?? (object)DBNull.Value); 
            try
            {
                connection.Open();
                rows_affected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                Console.WriteLine("Error update : {0}", ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return (rows_affected > 0);
        }

        public static bool DeleteTestAppointment(int TestAppointmentID)
        {
            SqlConnection connection = new SqlConnection(DataBaseSettings.connectionString);
            int rows_affected = 0;
            string query = @"delete TestAppointments where TestAppointmentID=@TestAppointmentID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            try
            {
                connection.Open();
                rows_affected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                Console.WriteLine("Error delete : {0}", ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return (rows_affected > 0);
        }

        public static bool IsTestAppointmentExists(int TestAppointmentID)
        {
            bool Find = false;
            SqlConnection connection = new SqlConnection(DataBaseSettings.connectionString);
            string query = "select Search=1 from TestAppointments where TestAppointmentID=@TestAppointmentID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                Find = reader.HasRows;
                reader.Close();
            }
            catch (Exception ex)
            {
                Find = false;
                Console.WriteLine($"Error exists {ex.Message}");
            }
            finally
            {
                connection.Close();
            }
            return Find;
        }

        public static int  GetTestAppointmentID_When_RetakExists(int LocalDrivingLicenseApplicationID,int TestTypeID)
        {
            int ID = -1;
            SqlConnection connection = new SqlConnection(DataBaseSettings.connectionString);
            string query = "select top 1 TestAppointmentID from TestAppointments where" +
                " LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID and RetakeTestApplicationID is not null and TestTypeID=@TestTypeID  order by TestAppointmentID desc;";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int Trial))
                {
                    ID = Trial;
                }

            }
            catch (Exception ex)
            {

                Console.WriteLine("Error add: {0}", ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return ID;
        }

        public static bool IsTestAppointmentExistsByLocalDrivingLicenseID(int LocalDrivingLicenseApplicationID)
        {
            bool Find = false;
            SqlConnection connection = new SqlConnection(DataBaseSettings.connectionString);
            string query = "select search = 1 from TestAppointments where LocalDrivingLicenseApplicationID =@LocalDrivingLicenseApplicationID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                Find = reader.HasRows;
                reader.Close();
            }
            catch (Exception ex)
            {
                Find = false;
                Console.WriteLine($"Error exists {ex.Message}");
            }
            finally
            {
                connection.Close();
            }
            return Find;
        }

        public static bool IsLocked(int LocalDrivingLicenseApplicationID,int TestTypeID)
        {
            bool Find = false;
            SqlConnection connection = new SqlConnection(DataBaseSettings.connectionString);
            string query = " select * from TestAppointments where LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID and IsLocked=0 and TestTypeID=@TestTypeID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                Find = reader.HasRows;
                reader.Close();
            }
            catch (Exception ex)
            {
                Find = false;
                Console.WriteLine($"Error exists {ex.Message}");
            }
            finally
            {
                connection.Close();
            }
            return Find;
        }

        public static bool IsLocked_AppointmentID(int TestAppointmentID, int TestTypeID)
        {
            bool Find = false;
            SqlConnection connection = new SqlConnection(DataBaseSettings.connectionString);
            string query = "select search=1 from TestAppointments where IsLocked=1 and TestAppointmentID=@TestAppointmentID and TestTypeID=@TestTypeID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                Find = reader.HasRows;
                reader.Close();
            }
            catch (Exception ex)
            {
                Find = false;
                Console.WriteLine($"Error exists {ex.Message}");
            }
            finally
            {
                connection.Close();
            }
            return Find;
        }


        public static DateTime GetLeastDateAppointment(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
           
            DateTime appointmentDate = DateTime.MinValue;
            SqlConnection connection = new SqlConnection(DataBaseSettings.connectionString);
            string query = "select top 1 AppointmentDate from TestAppointments where LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID and  TestTypeID=@TestTypeID order by AppointmentDate asc;";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && DateTime.TryParse(result.ToString(), out DateTime parsedDate))
                {
                    appointmentDate = parsedDate;
                }

            }
            catch (Exception ex)
            {

                Console.WriteLine("Error add: {0}", ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return appointmentDate;
        }
    }
}
