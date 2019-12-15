using System;
using System.Data.SqlClient;

namespace _6.Remove_Villain
{
    class Program
    {
        private static string connectionString =
            "Server=ACER\\SQLEXPRESS;" +
            "Database=MinionsDB;" +
            "Integrated Security=true";

        private static SqlConnection connection = new SqlConnection(connectionString);

        private static SqlTransaction transaction;
        static void Main(string[] args)
        {
            int id = int.Parse(Console.ReadLine());

            connection.Open();

            using (connection)
            {
                transaction = connection.BeginTransaction();

                try
                {
                    var cmd = new SqlCommand();
                    cmd.Connection = connection;
                    cmd.Transaction = transaction;
                    cmd.CommandText = "SELECT Name FROM Villains WHERE Id = @villainId";
                    cmd.Parameters.AddWithValue("@villainId", id);
                    var value = cmd.ExecuteScalar();

                    if (value == null)
                    {
                        throw new ArgumentException("No such villain was found.");
                    }

                    string villianName = (string)value;
                    cmd.CommandText = @"DELETE FROM MinionsVillains 
                                        WHERE VillainId = @villainId";

                    int minionsDelete = cmd.ExecuteNonQuery();

                    cmd.CommandText = @"DELETE FROM Villains
                                        WHERE Id = @villainId";
                    cmd.ExecuteNonQuery();

                    transaction.Commit();

                    Console.WriteLine($"{villianName} was deleted.");
                    Console.WriteLine($"{minionsDelete} minions were released.");
                }
                catch (ArgumentException ane)
                {
                    try
                    {
                        Console.WriteLine(ane.Message);
                        transaction.Rollback();
                    }
                    catch (Exception e )
                    {
                        Console.WriteLine(e.Message);
                    }
                }

                catch(Exception e)
                {
                    try
                    {
                        Console.WriteLine(e.Message);
                        transaction.Rollback();
                    }
                    catch (Exception re)
                    {
                        Console.WriteLine(re.Message);
                    }
                }
                
            }
            
        }
    }
}
