using P01.InitialSetUp;
using System;
using System.Data.SqlClient;

namespace P09.StoredProcedure
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int id = int.Parse(Console.ReadLine());
            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionStringToDatabase))
            {
                connection.Open();
                string upsGetOlderProc = "EXEC usp_GetOlder @id";

                using (SqlCommand command = new SqlCommand(upsGetOlderProc, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        reader.Read();
                        Console.WriteLine($"{reader[0]} – {reader[1]} years old");
                    }
                }
            }
        }
    }
}
