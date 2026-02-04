using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccessLayer
{
    public class clsCRUDTestTypesDAL
    {
       

        public static bool GetTestTypeByID(int TestTypeID, ref string TestTypeTitle, ref string TestTypeDescription,ref float TestTypeFees)
        {
            bool Find = true;
            SqlConnection connection = new SqlConnection(DataBaseSettings.connectionString);
            string query = "select * from TestTypes where TestTypeID=@TestTypeID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    Find = true;
                    TestTypeTitle = (string)reader["TestTypeTitle"];
                    TestTypeDescription = (string)reader["TestTypeDescription"];
                    TestTypeFees = Convert.ToSingle(reader["TestTypeFees"]);
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


        public static DataTable GetTestTypeTable()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(DataBaseSettings.connectionString);
            string query = "select * from TestTypes ;";
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

        public static int AddNewTestType(int TestTypeID, string TestTypeTitle,string TestTypeDescription,float TestTypeFees)
        {
            int ID = -1;
            SqlConnection connection = new SqlConnection(DataBaseSettings.connectionString);
            string query = @"insert into TestTypes(TestTypeTitle,TestTypeDescription,TestTypeFees)
                values (@TestTypeTitle, @TestTypeDescription,@TestTypeFees);
                         select SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestTypeTitle", TestTypeTitle);
            command.Parameters.AddWithValue("@TestTypeDescription", TestTypeDescription);
            command.Parameters.AddWithValue("@TestTypeFees", TestTypeFees);
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

        public static bool UpdateTestType(int TestTypeID, string TestTypeTitle, string TestTypeDescription, float TestTypeFees)
        {
            SqlConnection connection = new SqlConnection(DataBaseSettings.connectionString);
            int rows_affected = 0;
            string query = @"update TestTypes 
             set TestTypeTitle=@TestTypeTitle,TestTypeDescription=@TestTypeDescription,TestTypeFees=@TestTypeFees
			 where TestTypeID=@TestTypeID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestTypeTitle", TestTypeTitle);
            command.Parameters.AddWithValue("@TestTypeDescription", TestTypeDescription);
            command.Parameters.AddWithValue("@TestTypeFees", TestTypeFees);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
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

        public static bool DeleteTestType(int TestTypeID)
        {
            SqlConnection connection = new SqlConnection(DataBaseSettings.connectionString);
            int rows_affected = 0;
            string query = @"delete TestTypes where TestTypeID=@TestTypeID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestTypeID",TestTypeID);
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

        public static bool IsTestTypeExists(int TestTypeID)
        {
            bool Find = false;
            SqlConnection connection = new SqlConnection(DataBaseSettings.connectionString);
            string query = "select Search=1 from TestTypes where TestTypeID=@TestTypeID";
            SqlCommand command = new SqlCommand(query, connection);
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
                Console.WriteLine($"Error Is Exists {ex.Message}");
            }
            finally
            {
                connection.Close();
            }
            return Find;
        }

        
    }
}
