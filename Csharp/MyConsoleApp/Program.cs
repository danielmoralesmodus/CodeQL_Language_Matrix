using System;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;

namespace MyConsoleApp
{
    [ExcludeFromCodeCoverage]
    class Program
    {
        static void Main(string[] args)
        {
            Calculator calculator = new Calculator();

            int sum = calculator.Add(3, 4);
            Console.WriteLine($"3 + 4 = {sum}");

            int difference = calculator.Subtract(7, 4);
            Console.WriteLine($"7 - 4 = {difference}");

            Console.WriteLine("Enter username:");
            string username = Console.ReadLine();

            // Vulnerable SQL query
            string query = "SELECT * FROM Users WHERE Username = '" + username + "'";
            string connString = "";

            // Assume connString contains the connection string to your database
            using (SqlConnection connection = new SqlConnection(connString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine("Welcome " + reader["Username"]);
                }

                reader.Close();
            }
        }
    }
}
