using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccessLayer
{
    public class clsDriversDAL
    {
        int DriverID;
        int PersonID;
        int CreatedByUserID;
        DateTime CreatedDate;

        public static bool GetDriversByID(int DriverID, ref int PersonID,ref int CreatedByUserID,ref DateTime CreatedDate)
        {
            bool Find = true;
            SqlConnection connection = new SqlConnection(DataBaseSettings.connectionString);
            string query = "select * from Drivers where DriverID=@DriverID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DriverID", DriverID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    Find = true;
                    PersonID = (int)reader["PersonID"];
                     CreatedByUserID= (int)reader["CreatedByUserID"];
                    CreatedDate = (DateTime)reader["CreatedDate"];
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
                Console.WriteLine("Error getdriverbyID : {0}", ex.Message);

            }
            finally
            {
                connection.Close();
            }
            return Find;

        }

        public static bool GetDriversByPersonID(ref int DriverID,  int PersonID, ref int CreatedByUserID, ref DateTime CreatedDate)
        {
            bool Find = true;
            SqlConnection connection = new SqlConnection(DataBaseSettings.connectionString);
            string query = "select * from Drivers where PersonID=@PersonID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    Find = true;
                    DriverID = (int)reader["DriverID"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    CreatedDate = (DateTime)reader["CreatedDate"];
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
                Console.WriteLine("Error getdriverbyID : {0}", ex.Message);

            }
            finally
            {
                connection.Close();
            }
            return Find;

        }

        public static DataTable GetDriversTable()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(DataBaseSettings.connectionString);
            string query = "select * from Drivers_View";
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



        public static int AddNewDriver( int PersonID,int CreatedByUserID,DateTime CreatedDate)
        {
            int ID = -1;
            SqlConnection connection = new SqlConnection(DataBaseSettings.connectionString);
            string query = @"insert into Drivers(PersonID,CreatedByUserID,CreatedDate)
                values (@PersonID,@CreatedByUserID,@CreatedDate);
                         select SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@CreatedDate", CreatedDate);
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

                Console.WriteLine("Error adding: {0}", ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return ID;
        }

        public static bool UpdateDriver(int DriverID, int PersonID,  int CreatedByUserID,  DateTime CreatedDate)
        {
            SqlConnection connection = new SqlConnection(DataBaseSettings.connectionString);
            int rows_affected = 0;
            string query = @"update Drivers set PersonID=@PersonID,CreatedByUserID=@CreatedByUserID,CreatedDate=@CreatedDate where DriverID=@DriverID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DriverID", DriverID);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@CreatedDate",CreatedDate);
            command.Parameters.AddWithValue("@PersonID", PersonID);
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

        public static bool DeleteDriver(int DriverID)
        {
            SqlConnection connection = new SqlConnection(DataBaseSettings.connectionString);
            int rows_affected = 0;
            string query = @"delete Drivers where DriverID=@DriverID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DriverID",DriverID);
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

        public static bool IsDiverExistsByPersonID(int PersonID)
        {
            bool Find = false;
            SqlConnection connection = new SqlConnection(DataBaseSettings.connectionString);
            string query = "select search=1 from Drivers where PersonID=@PersonID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);
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
                Console.WriteLine($"Error is exists {ex.Message}");
            }
            finally
            {
                connection.Close();
            }
            return Find;
        }

        public static bool IsDriverExists(int DriverID)
        {
            bool Find = false;
            SqlConnection connection = new SqlConnection(DataBaseSettings.connectionString);
            string query = "select search=1 from Drivers where DriverID=@DriverID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DriverID",DriverID);
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
    }
}
