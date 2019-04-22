using System;
using System.Data.SqlClient;
using System.Linq;
using P01.InitialSetUp;

namespace P04.AddMinion
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string[] minionInfo = Console.ReadLine().Split().Skip(1).ToArray();
            string[] villainInfo = Console.ReadLine().Split().Skip(1).ToArray();

            string villainName = villainInfo[0];
            string minionName = minionInfo[0];
            string townName = minionInfo[2];

            int? villainId;
            int? minionId;
            int? townId;

            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionStringToDatabase))
            {
                connection.Open();
                string villainQuery = "SELECT Id FROM Villains WHERE Name = @Name";
                string minionQuery = "SELECT Id FROM Minions WHERE Name = @Name";
                string townQuery = "Select Id FROM Towns WHERE Name = @townName";
                string insertManyToManyStatement = "INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (@villainId, @minionId)";

                using (SqlCommand command = new SqlCommand(townQuery, connection))
                {
                    command.Parameters.AddWithValue("@townName", townName);
                    townId = (int?)command.ExecuteScalar();

                    if(townId == null)
                    {
                        AddNewTown(connection, townName);
                        townId = (int?)command.ExecuteScalar();
                    }
                }

                using (SqlCommand command = new SqlCommand(villainQuery, connection))
                {
                    command.Parameters.AddWithValue("@Name", villainName);
                    villainId = (int?)command.ExecuteScalar();

                    if (villainId == null)
                    {
                        AddNewVillain(connection, villainName);
                        villainId = (int?)command.ExecuteScalar();
                    }
                }

                using (SqlCommand command = new SqlCommand(minionQuery, connection))
                {
                    command.Parameters.AddWithValue("@Name", minionName);
                    minionId = (int?)command.ExecuteScalar();
                    if(minionId == null)
                    {
                        AddNewMinion(minionInfo, townId, connection, minionName);
                        minionId = (int?)command.ExecuteScalar();
                    }
                }

                using(SqlCommand command = new SqlCommand(insertManyToManyStatement, connection))
                {
                    command.Parameters.AddWithValue("villainId", villainId);
                    command.Parameters.AddWithValue("minionId", minionId);
                    command.ExecuteNonQuery();
                    Console.WriteLine($"Successfully added {minionName} to be minion of {villainName}.");
                }
            }
        }

        private static void AddNewMinion(string[] minionInfo, int? townId, SqlConnection connection, string minionName)
        {
            string insertStatement = "INSERT INTO Minions (Name, Age, TownId) VALUES (@name, @age, @townId)";
            using (SqlCommand command = new SqlCommand(insertStatement, connection))
            {
                command.Parameters.AddWithValue("@name", minionName);
                command.Parameters.AddWithValue("@age", int.Parse(minionInfo[1]));
                command.Parameters.AddWithValue("@townId", townId);
                command.ExecuteNonQuery();
            }
        }

        private static void AddNewVillain(SqlConnection connection, string villainName)
        {
            string insertStatement = "INSERT INTO Villains (Name, EvilnessFactorId)  VALUES (@villainName, 4)";
            using (SqlCommand command = new SqlCommand(insertStatement, connection))
            {
                command.Parameters.AddWithValue("@villainName", villainName);
                command.ExecuteNonQuery();
                Console.WriteLine($"Villain {villainName} was added to the database.");
            }
        }

        private static void AddNewTown(SqlConnection connection, string townName)
        {
            string insertNewTownStatement = "INSERT INTO Towns (Name) VALUES (@townName)";
            using (SqlCommand insertCommand = new SqlCommand(insertNewTownStatement, connection))
            {
                insertCommand.Parameters.AddWithValue("@townName", townName);
                insertCommand.ExecuteNonQuery();
                Console.WriteLine($"Town {townName} was added to the database.");
            }
        }
    }
}
