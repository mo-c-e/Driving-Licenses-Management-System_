using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccessLayer
{
    public class clsTestTypeDAL
    {
        public static DataTable GetTestTypes()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(DataBaseSettings.connectionString);
            string query = "select * from TestTypes";
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

        public static bool UpdateTestTypes(int TestTypeID, string TestTypeTitle,string TestTypeDescription, float TestTypeFees)
        {

            SqlConnection connection = new SqlConnection(DataBaseSettings.connectionString);
            int rows_affected = 0;
            string query = @"update TestTypes
             set TestTypeTitle=@TestTypeTitle,TestTypeDescription=@TestTypeDescription, TestTypeFees=@TestTypeFees
			   where TestTypeID=@TestTypeID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestTypeTitle",TestTypeTitle);
            command.Parameters.AddWithValue("@TestTypeDescription",TestTypeDescription);
            command.Parameters.AddWithValue("@TestTypeFees",TestTypeFees);
            command.Parameters.AddWithValue("@TestTypeID",TestTypeID);
            try
            {
                connection.Open();
                rows_affected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                Console.WriteLine("Error_UpdateTest : {0}", ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return (rows_affected > 0);

        }

        public static bool FindTestTypeByID(int TestTypeID, ref string TestTypeTitle,ref string TestTypeDescription, ref float TestTypeFees)
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
                Console.WriteLine("Error Find Func : {0}", ex.Message);

            }
            finally
            {
                connection.Close();
            }
            return Find;

        }
    }
}
