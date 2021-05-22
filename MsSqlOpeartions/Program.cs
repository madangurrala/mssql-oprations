using System;
using System.Data.SqlClient;
using System.Text;

namespace MsSqlOpeartions
{
    class Program
    {
        public static string connectionstring;
        static void Main(string[] args)
        {
            connectionstring = "connection string";
            //Path where you want to store text file
            string fileName = @"D:\repos\MsSqlOpeartions\peoplList.txt";
            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                string query = @"SELECT * FROM People";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                SqlDataReader sqlReader = cmd.ExecuteReader();

                // Change the Encoding to what you need here (UTF8, Unicode, etc)
                using (System.IO.StreamWriter writer = new System.IO.StreamWriter(fileName, false, Encoding.UTF8))
                {
                    while (sqlReader.Read())
                    {
                        writer.WriteLine(sqlReader["Id"] + "\t" + sqlReader["Name"]+ "\t" + sqlReader["Email"]); //Retrieves only Id and Email columns, change/add columns names
                    }
                }


                //close data reader
                sqlReader.Close();
                //close sql connection
                conn.Close();

            }


        }
    }
}
