using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccessLayer
{
    public class clsDetainedLicensesDAL
    {
       


        public static bool GetDetainedLicenseInfoByID(int DetainID,ref int LicenseID,ref DateTime DetainDate,ref float FineFees,ref int CreatedByUserID,ref bool IsReleased,
            ref DateTime? ReleaseDate,ref int? ReleasedByUserID,ref int? ReleaseApplicationID)
        {
            bool Found = false;

            using (SqlConnection connection = new SqlConnection(DataBaseSettings.connectionString))
            {
                string query = "SELECT * FROM DetainedLicenses WHERE DetainID = @DetainID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@DetainID", DetainID);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        Found = true;

                        LicenseID = (int)reader["LicenseID"];
                        DetainDate = (DateTime)reader["DetainDate"];
                        FineFees = Convert.ToSingle(reader["FineFees"]);
                        CreatedByUserID = (int)reader["CreatedByUserID"];
                        IsReleased = (bool)reader["IsReleased"];

                        // Nullable fields
                        ReleaseDate = reader["ReleaseDate"] != DBNull.Value
                            ? (DateTime?)reader["ReleaseDate"]
                            : null;

                        ReleasedByUserID = reader["ReleasedByUserID"] != DBNull.Value
                            ? (int?)reader["ReleasedByUserID"]
                            : null;

                        ReleaseApplicationID = reader["ReleaseApplicationID"] != DBNull.Value
                            ? (int?)reader["ReleaseApplicationID"]
                            : null;
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error Get By ID: {0}", ex.Message);
                    Found = false;
                }
                finally
                {
                    connection.Close();
                }
            }

            return Found;
        }

        public static bool GetDetainedLicenseInfoByLicenseID(int LicenseID, ref int DetainID, ref DateTime DetainDate, ref float FineFees, ref int CreatedByUserID, ref bool IsReleased,
           ref DateTime? ReleaseDate, ref int? ReleasedByUserID, ref int? ReleaseApplicationID)
        {
            bool Found = false;

            using (SqlConnection connection = new SqlConnection(DataBaseSettings.connectionString))
            {
                string query = "SELECT * FROM DetainedLicenses WHERE LicenseID = @LicenseID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@LicenseID", LicenseID);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        Found = true;

                        DetainID = (int)reader["DetainID"];
                        DetainDate = (DateTime)reader["DetainDate"];
                        FineFees = Convert.ToSingle(reader["FineFees"]);
                        CreatedByUserID = (int)reader["CreatedByUserID"];
                        IsReleased = (bool)reader["IsReleased"];

                        // Nullable fields
                        ReleaseDate = reader["ReleaseDate"] != DBNull.Value
                            ? (DateTime?)reader["ReleaseDate"]
                            : null;

                        ReleasedByUserID = reader["ReleasedByUserID"] != DBNull.Value
                            ? (int?)reader["ReleasedByUserID"]
                            : null;

                        ReleaseApplicationID = reader["ReleaseApplicationID"] != DBNull.Value
                            ? (int?)reader["ReleaseApplicationID"]
                            : null;
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error Get By LicenseID: {0}", ex.Message);
                    Found = false;
                }
                finally
                {
                    connection.Close();
                }
            }

            return Found;
        }

        public static bool GetLastDetainedRecordByLicenseID(int LicenseID, ref int DetainID, ref DateTime DetainDate, ref float FineFees, ref int CreatedByUserID, ref bool IsReleased,
           ref DateTime? ReleaseDate, ref int? ReleasedByUserID, ref int? ReleaseApplicationID)
        {
            bool Found = false;

            using (SqlConnection connection = new SqlConnection(DataBaseSettings.connectionString))
            {
                string query = "select  top 1 * from DetainedLicenses where LicenseID=@LicenseID order by DetainID desc;";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@LicenseID", LicenseID);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        Found = true;

                        DetainID = (int)reader["DetainID"];
                        DetainDate = (DateTime)reader["DetainDate"];
                        FineFees = Convert.ToSingle(reader["FineFees"]);
                        CreatedByUserID = (int)reader["CreatedByUserID"];
                        IsReleased = (bool)reader["IsReleased"];

                        // Nullable fields
                        ReleaseDate = reader["ReleaseDate"] != DBNull.Value
                            ? (DateTime?)reader["ReleaseDate"]
                            : null;

                        ReleasedByUserID = reader["ReleasedByUserID"] != DBNull.Value
                            ? (int?)reader["ReleasedByUserID"]
                            : null;

                        ReleaseApplicationID = reader["ReleaseApplicationID"] != DBNull.Value
                            ? (int?)reader["ReleaseApplicationID"]
                            : null;
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error Get By LicenseID: {0}", ex.Message);
                    Found = false;
                }
                finally
                {
                    connection.Close();
                }
            }

            return Found;
        }

        public static DataTable GetDetainedLicensesView()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(DataBaseSettings.connectionString);
            string query = "select * from DetainedLicenses_View;";
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
                Console.WriteLine("Error Get View : {0}", ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return dt;
        }

        public static int AddNewDetainedLicense(int LicenseID,DateTime DetainDate,float FineFees,int CreatedByUserID,bool IsReleased,
              DateTime? ReleaseDate,int? ReleasedByUserID,int? ReleaseApplicationID)
        {
            int newDetainID = -1;

            using (SqlConnection connection = new SqlConnection(DataBaseSettings.connectionString))
            {
                string query = @"
            INSERT INTO DetainedLicenses 
            (LicenseID, DetainDate, FineFees, CreatedByUserID, IsReleased, ReleaseDate, ReleasedByUserID, ReleaseApplicationID)
            VALUES 
            (@LicenseID, @DetainDate, @FineFees, @CreatedByUserID, @IsReleased, @ReleaseDate, @ReleasedByUserID, @ReleaseApplicationID);
            SELECT SCOPE_IDENTITY();";

                SqlCommand command = new SqlCommand(query, connection);

                // Required (non-nullable) fields
                command.Parameters.AddWithValue("@LicenseID", LicenseID);
                command.Parameters.AddWithValue("@DetainDate", DetainDate);
                command.Parameters.AddWithValue("@FineFees", FineFees);
                command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                command.Parameters.AddWithValue("@IsReleased", IsReleased);

                // Nullable fields (handle null properly)
                command.Parameters.AddWithValue("@ReleaseDate", ReleaseDate.HasValue ? (object)ReleaseDate.Value : DBNull.Value);
                command.Parameters.AddWithValue("@ReleasedByUserID", ReleasedByUserID.HasValue ? (object)ReleasedByUserID.Value : DBNull.Value);
                command.Parameters.AddWithValue("@ReleaseApplicationID", ReleaseApplicationID.HasValue ? (object)ReleaseApplicationID.Value : DBNull.Value);


                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out int insertedID))
                    {
                        newDetainID = insertedID;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error inserting DetainedLicense: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }

            return newDetainID;
        }


        public static bool UpdateDetainedLicense(int DetainID, int LicenseID, DateTime DetainDate, float FineFees, int CreatedByUserID, bool IsReleased,
            DateTime? ReleaseDate, int? ReleasedByUserID, int? ReleaseApplicationID)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(DataBaseSettings.connectionString))
            {
                string query = @"
            UPDATE DetainedLicenses
            SET 
                LicenseID = @LicenseID,
                DetainDate = @DetainDate,
                FineFees = @FineFees,
                CreatedByUserID = @CreatedByUserID,
                IsReleased = @IsReleased,
                ReleaseDate = @ReleaseDate,
                ReleasedByUserID = @ReleasedByUserID,
                ReleaseApplicationID = @ReleaseApplicationID
                 WHERE DetainID = @DetainID;";

                SqlCommand command = new SqlCommand(query, connection);

                // Required fields
                command.Parameters.AddWithValue("@LicenseID", LicenseID);
                command.Parameters.AddWithValue("@DetainDate", DetainDate);
                command.Parameters.AddWithValue("@FineFees", FineFees);
                command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                command.Parameters.AddWithValue("@IsReleased", IsReleased);
                command.Parameters.AddWithValue("@DetainID", DetainID);

                // Nullable fields handled safely
                command.Parameters.AddWithValue("@ReleaseDate", ReleaseDate.HasValue ? (object)ReleaseDate.Value : DBNull.Value);
                command.Parameters.AddWithValue("@ReleasedByUserID", ReleasedByUserID.HasValue ? (object)ReleasedByUserID.Value : DBNull.Value);
                command.Parameters.AddWithValue("@ReleaseApplicationID", ReleaseApplicationID.HasValue ? (object)ReleaseApplicationID.Value : DBNull.Value);

                try
                {
                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error updating DetainedLicense: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }

            return (rowsAffected > 0);
        }


        public static bool DeleteDetainedLicense(int DetainID)
        {
            SqlConnection connection = new SqlConnection(DataBaseSettings.connectionString);
            int rows_affected = 0;

            string query = @"DELETE FROM DetainedLicenses WHERE DetainID = @DetainID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DetainID", DetainID);

            try
            {
                connection.Open();
                rows_affected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error deleting DetainedLicense: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return (rows_affected > 0);
        }


        public static bool IsDetainedLicenseExists(int DetainID)
        {
            bool Find = false;
            SqlConnection connection = new SqlConnection(DataBaseSettings.connectionString);
            string query = "SELECT Search = 1 FROM DetainedLicenses WHERE DetainID = @DetainID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DetainID", DetainID);

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
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                connection.Close();
            }

            return Find;
        }

        public static bool IsLicenseDetained(int LicenseID)
        {
            bool Find = false;
            SqlConnection connection = new SqlConnection(DataBaseSettings.connectionString);
            string query = "select top 1 Search=1 from DetainedLicenses where LicenseID=@LicenseID and IsReleased=0 order by DetainID desc;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseID", LicenseID);

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
                Console.WriteLine($"Error is detained ? : {ex.Message}");
            }
            finally
            {
                connection.Close();
            }

            return Find;
        }

        public static bool IsLicenseReleased(int LicenseID)
        {
            bool Find = false;
            SqlConnection connection = new SqlConnection(DataBaseSettings.connectionString);
            string query = "select top 1 Search=1 from DetainedLicenses where LicenseID=@LicenseID and IsReleased=1 order by DetainID desc;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseID", LicenseID);

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
                Console.WriteLine($"Error is detained ? : {ex.Message}");
            }
            finally
            {
                connection.Close();
            }

            return Find;
        }

        public static bool IsLicenseReleased_DetainID(int DetainID)
        {
            bool Find = false;
            SqlConnection connection = new SqlConnection(DataBaseSettings.connectionString);
            string query = "select top 1 Search=1 from DetainedLicenses where DetainID=@DetainID and IsReleased=1 order by DetainID desc;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DetainID", DetainID);

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
                Console.WriteLine($"Error is detained ? : {ex.Message}");
            }
            finally
            {
                connection.Close();
            }

            return Find;
        }

        public static bool IsRelease(int LicenseID)
        {
            bool isReleased = true; // Default (if no record, assume released)

            using (SqlConnection connection = new SqlConnection(DataBaseSettings.connectionString))
            {
                string query = @"
        SELECT TOP 1 IsReleased 
        FROM DetainedLicenses 
        WHERE LicenseID = @LicenseID 
        ORDER BY DetainID DESC;";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@LicenseID", LicenseID);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        isReleased = Convert.ToBoolean(result);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error reading IsReleased: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }

            return isReleased;

        }

    }
}
