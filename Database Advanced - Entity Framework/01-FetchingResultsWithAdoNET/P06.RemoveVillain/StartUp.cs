using P01.InitialSetUp;
using System;
using System.Data.SqlClient;

namespace P06.RemoveVillain
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int villainId = int.Parse(Console.ReadLine());
            string villainName;
            int releasedMinions;

            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionStringToDatabase))
            {
                connection.Open();

                string selectVillainQuery = @"SELECT Name FROM Villains WHERE Id = @villainId";
                using (SqlCommand command = new SqlCommand(selectVillainQuery, connection))
                {
                    command.Parameters.AddWithValue("@villainId", villainId);
                    villainName = (string)command.ExecuteScalar();

                    if(villainName == null)
                    {
                        Console.WriteLine("No such villain was found.");
                        return;
                    }
                }

                string deleteFromManyToManyTableQuery = @"DELETE FROM MinionsVillains WHERE VillainId = @villainId";
                using (SqlCommand command = new SqlCommand(deleteFromManyToManyTableQuery, connection))
                {
                    command.Parameters.AddWithValue("@villainId", villainId);
                    releasedMinions = command.ExecuteNonQuery();
                }

                string deleteFromVillainTableQuery = @"DELETE FROM Villains WHERE Id = @villainId";
                using (SqlCommand command = new SqlCommand(deleteFromVillainTableQuery, connection))
                {
                    command.Parameters.AddWithValue("@villainId", villainId);
                    command.ExecuteNonQuery();
                }
            }

            Console.WriteLine($"{villainName} was deleted.");
            Console.WriteLine($"{releasedMinions} minions were released.");
        }
    }
}
