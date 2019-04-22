using P01.InitialSetUp;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace P07.PrintAllMinionNames
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            LinkedList<string> names = new LinkedList<string>();

            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionStringToDatabase))
            {
                connection.Open();

                string selectNamesQuery = "SELECT Name FROM Minions";
                using(SqlCommand command = new SqlCommand(selectNamesQuery, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            names.AddLast((string)reader[0]);
                        }
                    }
                }
            }

            while (names.Count > 0)
            {
                Console.WriteLine(names.First.Value);
                names.RemoveFirst();
                if(names.Count > 0)
                {
                    Console.WriteLine(names.Last.Value);
                    names.RemoveLast();
                }
            }
        }
    }
}
