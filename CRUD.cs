using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace SQL_Assignment1
{
    class CRUD
    {
        public static void CreateObject(string dtname)
        {
            string sqlcom = "";
            string sqlvalues = "";
            Console.WriteLine($"Du har valt att lägga till en objekt i {dtname} tabellen:");
            for (int i = 1; i < Database.ColNames.Count; i++)
            {
                Console.Write($"Mata in {Database.ColNames[i]}: ");
                sqlcom = sqlcom + Database.ColNames[i];
                sqlvalues = sqlvalues + $"'{ Console.ReadLine()}'";
                if (i != Database.ColNames.Count-1)
                {
                    sqlcom = sqlcom + ", ";
                    sqlvalues = sqlvalues + ", ";
                }
            }

            Database.ConnectionString = String.Format(Database.ConnectionAddr, Database.dbname);
            try
            {
                using (var cnn = new SqlConnection(Database.ConnectionString))
                {
                    cnn.Open();
                    using (var command = new SqlCommand($"INSERT INTO {dtname} ({sqlcom}) VALUES ({sqlvalues});", cnn))
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

        public static void DeleteObject(string dtname, string customerID)
        {
            Database.ConnectionString = String.Format(Database.ConnectionAddr, Database.dbname);
            try
            {
                using (var cnn = new SqlConnection(Database.ConnectionString))
                {
                    cnn.Open();
                    using (var command = new SqlCommand($"DELETE FROM {dtname} WHERE {Database.ColNames[0]} = {customerID}", cnn))
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
        public static void ChangeObject(string dtname)
        {
            Console.Write("Vilket objekt vill du ändra, ID: ");
            string customerID = Console.ReadLine();
            string sqlcom = "";

            for (int i = 1; i < Database.ColNames.Count; i++)
            {
                Console.Write($"Mata in ny värde på {Database.ColNames[i]}: ");
                sqlcom =sqlcom +  Database.ColNames[i] + " = " + "'"+ Console.ReadLine()+"'";
                if (i != Database.ColNames.Count - 1)
                {
                    sqlcom = sqlcom + ", ";
                }
            }

            Database.ConnectionString = String.Format(Database.ConnectionAddr, Database.dbname);
            try
            {
                using (var cnn = new SqlConnection(Database.ConnectionString))
                {
                    cnn.Open();
                    using (var command = new SqlCommand($"UPDATE {dtname} SET {sqlcom} WHERE {Database.ColNames[0]} = {customerID};", cnn))
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
    }
}
