using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DVLD_DataAccessLayer
{
    public class clsAppTypesDAL
    {
        public static DataTable GetAppTypes()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(DataBaseSettings.connectionString);
            string query = "select * from ApplicationTypes;";
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

        public static bool UpdateAppTypes(int ApplicationTypeID,string ApplicationTypeTitle,float ApplicationFees)
        {

            SqlConnection connection = new SqlConnection(DataBaseSettings.connectionString);
            int rows_affected = 0;
            string query = @"update ApplicationTypes
             set ApplicationTypeTitle=@ApplicationTypeTitle,ApplicationFees=@ApplicationFees
			   where ApplicationTypeID=@ApplicationTypeID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID );
            command.Parameters.AddWithValue("@ApplicationTypeTitle",ApplicationTypeTitle);
            command.Parameters.AddWithValue("@ApplicationFees", ApplicationFees);
            try
            {
                connection.Open();
                rows_affected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                Console.WriteLine("Error : {0}", ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return (rows_affected > 0);
        
    }

        public static bool FindByAppTypeID(int ApplicationTypeID,ref string ApplicationTypeTitle, ref float ApplicationFees)
        {
            bool Find = true;
            SqlConnection connection = new SqlConnection(DataBaseSettings.connectionString);
            string query = "select * from ApplicationTypes where ApplicationTypeID=@ApplicationTypeID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    Find = true;
                    ApplicationTypeTitle = (string)reader["ApplicationTypeTitle"];
                    // For float use ToSingle
                    ApplicationFees = Convert.ToSingle(reader["ApplicationFees"]);
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
