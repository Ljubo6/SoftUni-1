using P01.InitialSetUp;
using System;
using System.Data.SqlClient;

namespace P03.MinionNames
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int id = int.Parse(Console.ReadLine());

            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionStringToDatabase))
            {
                connection.Open();
                string selectVillianStatement = $"SELECT Name FROM Villains WHERE Id = @Id";

                using (SqlCommand command = new SqlCommand(selectVillianStatement, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    var villainName = (string)command.ExecuteScalar();

                    if (villainName == null)
                    {
                        Console.WriteLine($"No villain with ID {id} exists in the database.");
                        return;
                    }
                    Console.WriteLine($"Villain: {villainName}");
                }

                string selectMinionsCommand = @"SELECT ROW_NUMBER() OVER(ORDER BY m.Name) as RowNum,
                                                                                            m.Name, 
                                                                                            m.Age
                                                                                       FROM MinionsVillains AS mv
                                                                                       JOIN Minions As m ON mv.MinionId = m.Id
                                                                                      WHERE mv.VillainId = @Id
                                                                                   ORDER BY m.Name";

                using (SqlCommand command = new SqlCommand(selectMinionsCommand, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (!reader.HasRows)
                        {
                            Console.WriteLine("(no minions)");
                            return;
                        }

                        while (reader.Read())
                        {
                            Console.WriteLine($"{reader[0]}. {reader[1]} {reader[2]}");
                        }
                    }
                }

            }
        }
    }
}
