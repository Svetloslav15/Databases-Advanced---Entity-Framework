using exercise;
using System;
using System.Data.SqlClient;

namespace Problem3
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int id = int.Parse(Console.ReadLine());
            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();
                string villageNameQuery = @"SELECT Name FROM Villains WHERE Id = @Id";

                using (SqlCommand command = new SqlCommand(villageNameQuery, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    string villName = (string)command.ExecuteScalar();
                    if (villName == null)
                    {
                        Console.WriteLine($"No villain with ID: {id} exists in the database.");
                        return;
                    }
                    Console.WriteLine($"Villain: {villName}");
                }

                string minionsQuery = @"SELECT ROW_NUMBER() OVER (ORDER BY m.Name) as RowNum,
                                         m.Name, 
                                         m.Age
                                    FROM MinionsVillains AS mv
                                    JOIN Minions As m ON mv.MinionId = m.Id
                                   WHERE mv.VillainId = @Id
                                ORDER BY m.Name";

                using (SqlCommand command = new SqlCommand(minionsQuery, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        int rows = 0;
                        while (reader.Read())
                        {
                            long rowNumber = (long)reader[0];
                            string name = (string)reader[1];
                            int age = (int)reader[2];
                            rows++;
                            Console.WriteLine($"{rowNumber}. {name} {age}");
                        }
                        if (rows == 0)
                        {
                            Console.WriteLine("No minions");
                        }
                    }
                }
            }
        }
    }
}
