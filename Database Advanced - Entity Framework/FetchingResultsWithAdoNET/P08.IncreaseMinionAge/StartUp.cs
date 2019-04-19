using P01.InitialSetUp;
using System;
using System.Data.SqlClient;
using System.Linq;

namespace P08.IncreaseMinionAge
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int[] minionsId = Console.ReadLine().Split().Select(int.Parse).ToArray();

            using(SqlConnection connection = new SqlConnection(Configuration.ConnectionStringToDatabase))
            {
                connection.Open();

                string updateMinionQuery = @"UPDATE Minions
                                                SET Name = UPPER(LEFT(Name, 1)) + SUBSTRING(Name, 2, LEN(Name)), Age += 1
                                              WHERE Id = @Id";

                foreach (var id in minionsId)
                {
                    using(SqlCommand command = new SqlCommand(updateMinionQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);
                        command.ExecuteNonQuery();
                    }
                }

                string selectMinionsQuery = "SELECT Name, Age FROM Minions";
                using (SqlCommand command = new SqlCommand(selectMinionsQuery, connection))
                {
                    using(SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"{reader[0]} {reader[1]}");
                        }
                    }
                }
            }
        }
    }
}
