using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccessLayer
{
    public class clsLicensesDAL
    {
       


        public static bool GetLicenseByID(int LicenseID,ref int ApplicationID,ref int DriverID,ref int LicenseClass,ref DateTime IssueDate,ref DateTime ExpirationDate,
          ref string Notes,ref float PaidFees,ref bool IsActive,ref short IssueReason,ref int CreatedByUserID)
        {
            bool Found = true;
            SqlConnection connection = new SqlConnection(DataBaseSettings.connectionString);
            string query = "SELECT * FROM Licenses WHERE LicenseID = @LicenseID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseID", LicenseID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    Found = true;
                    ApplicationID = (int)reader["ApplicationID"];
                    DriverID = (int)reader["DriverID"];
                    LicenseClass = (int)reader["LicenseClass"];
                    IssueDate = (DateTime)reader["IssueDate"];
                    ExpirationDate = (DateTime)reader["ExpirationDate"];
                    Notes = reader["Notes"] != DBNull.Value ? (string)reader["Notes"] : string.Empty;
                    PaidFees = Convert.ToSingle(reader["PaidFees"]);
                    IsActive = (bool)reader["IsActive"];
                    IssueReason = Convert.ToInt16(reader["IssueReason"]);
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                }
                else
                {
                    Found = false;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Found = false;
                Console.WriteLine("Error in GetLicenseByID: {0}", ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return Found;
        }

        public static bool GetLicenseByLocalDrivingLicenseAppID(int LocalDrivingLicenseApplicationID,ref int LicenseID, ref int ApplicationID, ref int DriverID, ref int LicenseClass, ref DateTime IssueDate, ref DateTime ExpirationDate,
         ref string Notes, ref float PaidFees, ref bool IsActive, ref short IssueReason, ref int CreatedByUserID)
        {
            bool Found = true;
            SqlConnection connection = new SqlConnection(DataBaseSettings.connectionString);
            string query = @"select Licenses.* from Licenses inner join Applications on Licenses.ApplicationID=Applications.ApplicationID inner join LocalDrivingLicenseApplications" +
                " on LocalDrivingLicenseApplications.ApplicationID=Applications.ApplicationID where LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    Found = true;
                    ApplicationID = (int)reader["ApplicationID"];
                    DriverID = (int)reader["DriverID"];
                    LicenseClass = (int)reader["LicenseClass"];
                    IssueDate = (DateTime)reader["IssueDate"];
                    ExpirationDate = (DateTime)reader["ExpirationDate"];
                    Notes = reader["Notes"] != DBNull.Value ? (string)reader["Notes"] : string.Empty;
                    PaidFees = Convert.ToSingle(reader["PaidFees"]);
                    IsActive = (bool)reader["IsActive"];
                    IssueReason = Convert.ToInt16(reader["IssueReason"]);
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    LicenseID = (int)reader["LicenseID"];
                }
                else
                {
                    Found = false;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Found = false;
                Console.WriteLine("Error in GetLicenseByLDLAppID: {0}", ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return Found;
        }



        public static DataTable GetLicensesTable()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(DataBaseSettings.connectionString);
            string query = "select * from Licenses ";
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

        public static DataTable GetRecordByNationalNo(string NationalNo)
        {
          
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(DataBaseSettings.connectionString);
            string query = "select Licenses.*,LicenseClasses.ClassName from Licenses inner join Applications on Licenses.ApplicationID=Applications.ApplicationID" +
                " inner join People on Applications.ApplicantPersonID=People.PersonID inner join  " +
                "LicenseClasses \r\non LicenseClasses.LicenseClassID=Licenses.LicenseClass where People.NationalNo=@NationalNo;\r\n ";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@NationalNo", NationalNo);

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

        public static int AddNewLicense(int ApplicationID,int DriverID,int LicenseClass,DateTime IssueDate,DateTime ExpirationDate,
            string Notes,float PaidFees,bool IsActive,short IssueReason,int CreatedByUserID)
        {
            int ID = -1;
            SqlConnection connection = new SqlConnection(DataBaseSettings.connectionString);
            string query = @"
        INSERT INTO Licenses
        (ApplicationID, DriverID, LicenseClass, IssueDate, ExpirationDate, Notes, PaidFees, IsActive, IssueReason, CreatedByUserID)
        VALUES
        (@ApplicationID, @DriverID, @LicenseClass, @IssueDate, @ExpirationDate, @Notes, @PaidFees, @IsActive, @IssueReason, @CreatedByUserID);
        SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@DriverID", DriverID);
            command.Parameters.AddWithValue("@LicenseClass", LicenseClass);
            command.Parameters.AddWithValue("@IssueDate", IssueDate);
            command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
            command.Parameters.AddWithValue("@Notes", string.IsNullOrEmpty(Notes) ? (object)DBNull.Value : Notes);
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            command.Parameters.AddWithValue("@IssueReason", IssueReason);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

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
                Console.WriteLine("Error adding license: {0}", ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return ID;
        }

        public static bool UpdateLicense(int LicenseID,int ApplicationID,int DriverID,int LicenseClass,DateTime IssueDate,DateTime ExpirationDate,
    string Notes,float PaidFees,bool IsActive,short IssueReason,int CreatedByUserID)
        {
            SqlConnection connection = new SqlConnection(DataBaseSettings.connectionString);
            int rows_affected = 0;

            string query = @"
        UPDATE Licenses SET
            ApplicationID = @ApplicationID,
            DriverID = @DriverID,
            LicenseClass = @LicenseClass,
            IssueDate = @IssueDate,
            ExpirationDate = @ExpirationDate,
            Notes = @Notes,
            PaidFees = @PaidFees,
            IsActive = @IsActive,
            IssueReason = @IssueReason,
            CreatedByUserID = @CreatedByUserID
          WHERE LicenseID = @LicenseID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseID", LicenseID);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@DriverID", DriverID);
            command.Parameters.AddWithValue("@LicenseClass", LicenseClass);
            command.Parameters.AddWithValue("@IssueDate", IssueDate);
            command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
            command.Parameters.AddWithValue("@Notes", string.IsNullOrEmpty(Notes) ? (object)DBNull.Value : Notes);
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            command.Parameters.AddWithValue("@IssueReason", IssueReason);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            try
            {
                connection.Open();
                rows_affected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error updating license: {0}", ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return (rows_affected > 0);
        }


        public static bool DeleteLicense(int LicenseID)
        {
            SqlConnection connection = new SqlConnection(DataBaseSettings.connectionString);
            int rows_affected = 0;

            string query = @"DELETE FROM Licenses WHERE LicenseID = @LicenseID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseID", LicenseID);

            try
            {
                connection.Open();
                rows_affected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error deleting license: {0}", ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return (rows_affected > 0);
        }


        public static bool IsLicenseExists(int LicenseID)
        {
            bool Found = false;
            SqlConnection connection = new SqlConnection(DataBaseSettings.connectionString);
            string query = "SELECT 1 FROM Licenses WHERE LicenseID = @LicenseID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseID", LicenseID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                Found = reader.HasRows;
                reader.Close();
            }
            catch (Exception ex)
            {
                Found = false;
                Console.WriteLine($"Error checking existence: {ex.Message}");
            }
            finally
            {
                connection.Close();
            }

            return Found;
        }


        public static bool IsLicenseExistsByLocalDrivingAppID(int LocalDrivingLicenseApplicationID)
        {
            bool Found = false;
            SqlConnection connection = new SqlConnection(DataBaseSettings.connectionString);
            string query = "select top 1 search=1 from Licenses inner join Applications on Licenses.ApplicationID=Applications.ApplicationID" +
                " inner join\r\nLocalDrivingLicenseApplications on LocalDrivingLicenseApplications.ApplicationID=Applications.ApplicationID\r\n" +
                "where LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID;\r\n";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                Found = reader.HasRows;
                reader.Close();
            }
            catch (Exception ex)
            {
                Found = false;
                Console.WriteLine($"Error checking existence: {ex.Message}");
            }
            finally
            {
                connection.Close();
            }

            return Found;
        }


        public static bool IsLicenseExpired(int LicenseID)
        {
            bool Found = false;
            DateTime CurrentDate = DateTime.Now;
            SqlConnection connection = new SqlConnection(DataBaseSettings.connectionString);
            string query = " select search=1 from Licenses where ExpirationDate<=@Date and LicenseID=@LicenseID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseID", LicenseID);
            command.Parameters.AddWithValue("@Date",CurrentDate);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                Found = reader.HasRows;
                reader.Close();
            }
            catch (Exception ex)
            {
                Found = false;
                Console.WriteLine($"Error expired license: {ex.Message}");
            }
            finally
            {
                connection.Close();
            }

            return Found;
        }

        public static bool IsLicenseActive(int LicenseID)
        {
            bool Found = false;
          //  DateTime CurrentDate = DateTime.Now;
            SqlConnection connection = new SqlConnection(DataBaseSettings.connectionString);
            string query = "select search=1 from Licenses where LicenseID=@LicenseID and IsActive=1;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseID", LicenseID);
       
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                Found = reader.HasRows;
                reader.Close();
            }
            catch (Exception ex)
            {
                Found = false;
                Console.WriteLine($"Error  Is Active license: {ex.Message}");
            }
            finally
            {
                connection.Close();
            }

            return Found;
        }

        public static bool IsSelectedClass_ExistsForLicense(int LicenseID,int LicenseClass)
        {
            bool Found = false;
            SqlConnection connection = new SqlConnection(DataBaseSettings.connectionString);
            string query = "select search=1 from Licenses where LicenseClass=@LicenseClass and LicenseID=@LicenseID ";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseID", LicenseID);
            command.Parameters.AddWithValue("@LicenseClass", LicenseClass);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                Found = reader.HasRows;
                reader.Close();
            }
            catch (Exception ex)
            {
                Found = false;
                Console.WriteLine($"Error  Is class exists for license: {ex.Message}");
            }
            finally
            {
                connection.Close();
            }

            return Found;
        }

        public static bool DeactivateLicense(int LicenseID)
        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(DataBaseSettings.connectionString);

            string query = @"UPDATE Licenses
                           SET 
                              IsActive = 0
                             
                         WHERE LicenseID=@LicenseID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseID", LicenseID);


            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error deactive: " + ex.Message);
                return false;
            }

            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }

    }
}
