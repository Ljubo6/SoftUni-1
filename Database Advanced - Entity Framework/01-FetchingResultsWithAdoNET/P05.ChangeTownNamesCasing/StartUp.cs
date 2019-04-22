using P01.InitialSetUp;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace P05.ChangeTownNamesCasing
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string countryName = Console.ReadLine();

            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionStringToDatabase))
            {
                connection.Open();
                int updatedTownsCount = UpdateTownsCasing(countryName, connection);

                List<string> towns = new List<string>();
                if (updatedTownsCount > 0)
                {
                    Console.WriteLine($"{updatedTownsCount} town names were affected.");
                    Console.WriteLine(GenerateTownsList(connection, towns, countryName));
                }
                else
                {
                    Console.WriteLine("No town names were affected.");
                }
            }

        }

        private static string GenerateTownsList(SqlConnection connection, List<string> towns, string countryName)
        {
            string selectTownNamesQuery = @"SELECT t.Name 
                                                      FROM Towns as t
                                                      JOIN Countries AS c ON c.Id = t.CountryCode
                                                     WHERE c.Name = @countryName";

            using (SqlCommand command = new SqlCommand(selectTownNamesQuery, connection))
            {
                command.Parameters.AddWithValue("@countryName", countryName);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        towns.Add((string)reader[0]);
                    }
                }
            }

            return $"[{string.Join(", ", towns)}]";
        }

        private static int UpdateTownsCasing(string countryName, SqlConnection connection)
        {
            string updateTownsQuery = @"UPDATE Towns
                                           SET Name = UPPER(Name)
                                         WHERE CountryCode = (SELECT c.Id FROM Countries AS c WHERE c.Name = @countryName)";
            using (SqlCommand command = new SqlCommand(updateTownsQuery, connection))
            {
                command.Parameters.AddWithValue("@countryName", countryName);
                return command.ExecuteNonQuery();
            }
        }
    }
}
