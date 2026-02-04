using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccessLayer
{
    public class clsTestsDAL
    {
        int TestID;
        int TestAppointmentID;
        byte TestResult;
        string Notes; // Allows Null
        int CreatedByUserID;

        public static bool GetTestsByID(int TestID, ref int TestAppointmentID,ref byte TestResult, ref string Notes, ref int CreatedByUserID)
        {
            bool Find = true;
            SqlConnection connection = new SqlConnection(DataBaseSettings.connectionString);
            string query = "select * from Tests where TestID=@TestID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestID", TestID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    Find = true;
                    TestAppointmentID = (int)reader["TestAppointmentID"];
                    TestResult = Convert.ToByte(reader["TestResult"]);
                    Notes = reader["Notes"] != DBNull.Value ? (string)reader["Notes"].ToString() : "";
                    CreatedByUserID = (int)reader["CreatedByUserID"];
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
                Console.WriteLine("Error : {0}", ex.Message);

            }
            finally
            {
                connection.Close();
            }
            return Find;

        }

   
        public static DataTable GetTestsTable()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(DataBaseSettings.connectionString);
            string query = "select * ,Result= case when TestResult=0 then 'Fail' else 'Pass' end from Tests;;";
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

        public static int AddNewTests(int TestID, int TestAppointmentID, byte TestResult, string Notes,  int CreatedByUserID)
        {
            int ID = -1;
            SqlConnection connection = new SqlConnection(DataBaseSettings.connectionString);
            string query = @"insert into Tests(TestAppointmentID, TestResult, Notes, CreatedByUserID)
                values (@TestAppointmentID, @TestResult, @Notes, @CreatedByUserID);
                         select SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            command.Parameters.AddWithValue("@TestResult", TestResult);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            if (Notes != "")
            {
                command.Parameters.AddWithValue("@Notes", Notes);
            }
            else
            {
                command.Parameters.AddWithValue("@Notes", System.DBNull.Value);
            }
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

                Console.WriteLine("Error AddNew : {0}", ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return ID;
        }

        public static bool UpdateTests(int TestID, int TestAppointmentID, byte TestResult, string Notes, int CreatedByUserID)
        {
            SqlConnection connection = new SqlConnection(DataBaseSettings.connectionString);
            int rows_affected = 0;
            string query = @"update Tests 
             set TestAppointmentID=@TestAppointmentID,TestResult=@TestResult,Notes=@Notes,CreatedByUserID=@CreatedByUserID
			 where TestID=@TestID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            command.Parameters.AddWithValue("@TestResult", TestResult);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@TestID", TestID);
            if (Notes != "")
            {
                command.Parameters.AddWithValue("@Notes", Notes);
            }
            else
            {
                command.Parameters.AddWithValue("@Notes", System.DBNull.Value);
            }
            try
            {
                connection.Open();
                rows_affected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                Console.WriteLine("Error Update : {0}", ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return (rows_affected > 0);
        }

        public static bool DeleteTests(int TestID)
        {
            SqlConnection connection = new SqlConnection(DataBaseSettings.connectionString);
            int rows_affected = 0;
            string query = @"delete Tests where TestID=@TestID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestID", TestID);
            try
            {
                connection.Open();
                rows_affected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                Console.WriteLine("Error Delete : {0}", ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return (rows_affected > 0);
        }

        public static bool IsTestsExists(int TestID)
        {
            bool Find = false;
            SqlConnection connection = new SqlConnection(DataBaseSettings.connectionString);
            string query = "select Search=1 from Tests where TestID=@TestID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestID", TestID);
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
                Console.WriteLine($"Error Is Exists {ex.Message}");
            }
            finally
            {
                connection.Close();
            }
            return Find;
        }


        public static bool IsTestTypeExists(int LocalDrivingLicenseApplicationID,string TestTypeTitle)
        {
            bool Find = false;
            SqlConnection connection = new SqlConnection(DataBaseSettings.connectionString);
            string query = "SELECT  Find=1\r\nFROM  Tests " +
                "INNER JOIN\r\n   TestAppointments ON Tests.TestAppointmentID = TestAppointments.TestAppointmentID INNER JOIN\r\n " +
                "LocalDrivingLicenseApplications ON TestAppointments.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID INNER JOIN\r\n" +
                "Applications ON LocalDrivingLicenseApplications.ApplicationID = Applications.ApplicationID INNER JOIN\r\n " +
                "People ON Applications.ApplicantPersonID = People.PersonID INNER JOIN\r\n" +
                "TestTypes ON TestAppointments.TestTypeID = TestTypes.TestTypeID\r\n\t\t\t\t\t\t inner join" +
                " LicenseClasses on LocalDrivingLicenseApplications.LicenseClassID=LicenseClasses.LicenseClassID\r\n\t\t\t\t\t\t" +
                "where LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID and TestTypes.TestTypeTitle=@TestTypeTitle and Tests.TestResult=1 ;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeTitle", TestTypeTitle);
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
                Console.WriteLine($"Error IsTestTypeExists{ex.Message}");
            }
            finally
            {
                connection.Close();
            }
            return Find;
        }

        public static bool IsPass(int TestTypeID, int LocalDrivingLicenseApplicationID)
        {
            bool Find = false;
            SqlConnection connection = new SqlConnection(DataBaseSettings.connectionString);
            string query = "select Search=1 from " +
                "Tests inner join TestAppointments on Tests.TestAppointmentID=TestAppointments.TestAppointmentID where " +
                "TestResult=1 and TestTypeID=@TestTypeID and " +
                "LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID";
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
                Console.WriteLine($"Error IsFail{ex.Message}");
            }
            finally
            {
                connection.Close();
            }
            return Find;
        }

        public static bool IsTestExists_ByLocalDrivingLicenseApp(int LocalDrivingLicenseApplicationID)
        {
            bool Find = false;
            SqlConnection connection = new SqlConnection(DataBaseSettings.connectionString);
            string query = "select  top 1 search=1 from TestAppointments where LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID\r\n";
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
                Console.WriteLine($"Error Is Exists {ex.Message}");
            }
            finally
            {
                connection.Close();
            }
            return Find;
        }

        public static int CountPassedTests(int LocalDrivingLicenseApplicationID)
        {
            int ID = -1;
            SqlConnection connection = new SqlConnection(DataBaseSettings.connectionString);
            string query = "select Count(*) from (select Tests.TestAppointmentID,TestResult,TestTypeID from Tests inner join" +
                " TestAppointments on TestAppointments.TestAppointmentID=Tests.TestAppointmentID where TestResult=1 and TestAppointments.LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID)R ;";
            SqlCommand command = new SqlCommand(query, connection);

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

                Console.WriteLine("Error CountPass: {0}", ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return ID;
        }
        }
}
