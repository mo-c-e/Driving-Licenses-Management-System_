using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccessLayer
{
    public class clsCountriesDAL
    {
        public static bool GetCountryInfoByID(int CountryID,ref string CountryName)
        {
            bool Find = true;
            SqlConnection connection = new SqlConnection(DataBaseSettings.connectionString);
            string query = "select * from Countries where CountryID=@CountryID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CountryID", CountryID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    Find = true;
                    CountryName = (string)reader["CountryName"];
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

        public static bool GetCountryInfoByName(string CountryName, ref int CountryID)
        {
            bool Find = true;
            SqlConnection connection = new SqlConnection(DataBaseSettings.connectionString);
            string query = "select * from Countries where CountryName=@CountryName";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CountryName", CountryName);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    Find = true;
                    CountryID = (int)reader["CountryID"];
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

        public static DataTable GetCountries()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(DataBaseSettings.connectionString);
            string query = "select * from Countries;";
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

    }
}
