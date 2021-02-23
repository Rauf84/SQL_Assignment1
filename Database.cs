using System;
using System.Threading.Tasks;
using System.Dynamic;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography.X509Certificates;
using System.Data.Common;
using System.Diagnostics;

namespace SQL_Assignment1
{
    class Database
    {

        public static List<string> DBNames = new List<string>();
        public static List<string> DTNames = new List<string>();
        public static List<string> DataTable = new List<string>();
        public static List<string> ColNames = new List<string>();
        public static string dbname;
        public static string ConnectionAddr { get; set; } = @"Data Source=.\SQLExpress;Integrated Security=true;database={0}";
        public static string ConnectionString { get; set; } = String.Format(ConnectionAddr,dbname);
        //en metod som skapar en ny databas
        public static string CreateDatabase(string dbname)
        {
            string cmdStr = "CREATE DATABASE " + dbname + " ; ";
            string ConnectionString = String.Format(ConnectionAddr,"");
            using (SqlConnection cnn = new SqlConnection(ConnectionString)) 
            {
                SqlCommand sqlCmd = new SqlCommand(cmdStr, cnn);
                try
                {
                    cnn.Open();
                    sqlCmd.ExecuteNonQuery();

                }
                catch (System.Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return dbname;
            }
        }

        public static void CreateDataTable(string dtname, string columns)
        {
            ConnectionString = String.Format(ConnectionAddr, dbname);
            try
            {
                using (var cnn = new SqlConnection(ConnectionString))
                {
                    cnn.Open();
                    using (var command = new SqlCommand($"CREATE TABLE {dtname} ({columns});", cnn))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public  static bool CheckDatabaseExists(string databaseName)
        {
            string sqlCreateDBQuery;
            bool result = false;

            try
            {
                var tmpConn = new SqlConnection(ConnectionString);

                sqlCreateDBQuery = string.Format("SELECT database_id FROM sys.databases WHERE Name = '{0}'", databaseName);
        
        using (tmpConn)
                {
                    using (SqlCommand sqlCmd = new SqlCommand(sqlCreateDBQuery, tmpConn))
                    {
                        tmpConn.Open();

                        object resultObj = sqlCmd.ExecuteScalar();

                        int databaseID = 0;

                        if (resultObj != null)
                        {
                            int.TryParse(resultObj.ToString(), out databaseID);
                            Console.WriteLine($"Databas med namnet {databaseName} finns redan");
                        }
                        else Console.WriteLine($"Databas med namnet {databaseName} existerar inte. Databasen skapas.");

                        tmpConn.Close();

                        result = (databaseID > 0);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                result = false;
            }

            return result;
        }

        public static void GetDBNames()
        {
            string connectionString = "Data Source =.\\SQLExpress; Integrated Security = true; ";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT name from sys.databases", con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        
                        int i = 1;
                        while (dr.Read())
                        {
                            Console.Write(i + ". ");
                            Console.WriteLine(dr[0].ToString());
                            DBNames.Add(dr[0].ToString());
                            i++;
                        }
                    }
                }
            }
        }

        public static void GetDTNames(string dbaname)
        {
            ConnectionString = String.Format(ConnectionAddr, dbname);
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT TABLE_NAME from information_schema.tables", con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        int i = 1;
                        while (dr.Read())
                        {
                            Console.Write(i + ". ");
                            Console.WriteLine(dr[0].ToString());
                            DTNames.Add(dr[0].ToString());
                            i++;
                        }
                    }
                }
            }


        }

        public static void PrintTable(string dtname)
        {
            ConnectionString = String.Format(ConnectionAddr, dbname);
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand($"SELECT * FROM {dtname}",con);
                try
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    
                    foreach (DataRow row in dt.Rows)
                    {
                        for (int i = 0; i < ColNames.Count; i++)
                        {
                            Console.Write($"{row[ColNames[i]]} ");
                        }
                            Console.WriteLine();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }


        public static void GetColumns(string tablename)
        {
            ConnectionString = String.Format(ConnectionAddr, dbname);
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand($"SELECT column_name from information_schema.columns where TABLE_NAME = '{tablename}'", con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        int i = 1;
                        while (dr.Read())
                        {
                            //Console.Write(i + ". ");
                            //Console.WriteLine(dr[0].ToString());
                            ColNames.Add(dr[0].ToString());
                            i++;
                        }
                    }
                }
            }
        }
    }
}
