using System;
using System.Data;
using System.Data.SqlClient;
using CM = System.Configuration.ConfigurationManager;

namespace Splash
{
    public static class DataAccess
    {
        private static string connectionString = CM.ConnectionStrings["XYZCharity"].ConnectionString;
        public static DataTable GetData(string sql)
        {
            DataTable dt = new DataTable();


            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(dt);
            }

            return dt;
        }

        public static DataSet GetData(string[] sqlStatements)
        {
            DataSet ds = new DataSet();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = String.Join(";", sqlStatements);
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                for (int i = 0; i < sqlStatements.Length; i++)
                {
                    da.TableMappings.Add(i.ToString(), $"Data{i}");
                }
                da.Fill(ds);
            }

            return ds;
        }

        public static object GetValue(string sql)
        {
            object retVal;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                retVal = cmd.ExecuteScalar();
            }

            return retVal;
        }

    }
}
