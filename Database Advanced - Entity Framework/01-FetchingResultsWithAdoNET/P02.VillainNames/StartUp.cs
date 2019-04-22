using P01.InitialSetUp;
using System;
using System.Data.SqlClient;

namespace P02.VillainNames
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionStringToDatabase))
            {
                connection.Open();

                string selectStatement = @"  SELECT v.Name, COUNT(mv.VillainId) AS MinionsCount  
                                               FROM Villains AS v 
                                               JOIN MinionsVillains AS mv ON v.Id = mv.VillainId 
                                           GROUP BY v.Id, v.Name 
                                           HAVING COUNT(mv.VillainId) > 3 
                                           ORDER BY COUNT(mv.VillainId)";

                using (SqlCommand command = new SqlCommand(selectStatement, connection))
                {
                    using(SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"{reader[0]} - {reader[1]}");
                        }
                    }
                }
            }
        }
    }
}
