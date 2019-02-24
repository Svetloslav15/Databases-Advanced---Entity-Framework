using exercise;
using System;
using System.Data.SqlClient;

namespace Problem4
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] minionInfo = Console.ReadLine().Split();
            string[] villainInfo = Console.ReadLine().Split();

            string minionName = minionInfo[1];
            int age = int.Parse(minionInfo[2]);
            string townName = minionInfo[3];

            string villainName = villainInfo[1];

            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();
                string townIdQuery = @"SELECT Id FROM Towns WHERE Name = @townName";
                using (SqlCommand command = new SqlCommand(townIdQuery, connection))
                {
                    command.Parameters.AddWithValue("@townName", townName);
                    int? id = (int?)command.ExecuteScalar();

                    if (id == null)
                    {
                        AddTown(connection, townName);
                    }
                    AddMinion(connection, minionName, age, townName);

                    int? villainId = GetVillainByName(connection, villainName);
                    int minionId = GetMinionByName(connection, villainName);
                    AddMinionVillain(connection, villainId, minionId);
                }
            }
        }

        private static void AddMinionVillain(SqlConnection connection, int? villainId, int minionId)
        {
            string query = @"INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (@villainId, @minionId)";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@villainId", villainId);
                command.Parameters.AddWithValue("@minionId", minionId);
                command.ExecuteNonQuery();
            }
            Console.WriteLine($"Successfully added {minionId} to be minion of villainId");
        }

        private static int GetMinionByName(SqlConnection connection, string minionName)
        {
            string query = @"SELECT Id FROM Minions WHERE Name = @Name";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Name", minionName);
                return (int)command.ExecuteScalar();
            }
        }

        private static int? GetVillainByName(SqlConnection connection, string villainName)
        {
            string query = @"SELECT Id FROM Villains WHERE Name = @Name";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Name", villainName);
                return (int?)command.ExecuteScalar();
            }
        }

        private static void AddMinion(SqlConnection connection, string minionName, int age, string townName)
        {
            string query = @"INSERT INTO Minions (Name, Age, TownId) VALUES (@nam, @age, @townId)";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@nam", minionName);
                command.Parameters.AddWithValue("@age", age);
                command.Parameters.AddWithValue("@townName", townName);
                command.ExecuteNonQuery();
            }
            Console.WriteLine($"Minion {minionName} was added to the database.");

        }

        private static void AddTown(SqlConnection connection, string townName)
        {
            string query = @"INSERT INTO Towns (Name) VALUES (@townName)";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@townName", townName);
                command.ExecuteNonQuery();
            }
            Console.WriteLine($"Town {townName} was added to the database.");
        }
    }
}
