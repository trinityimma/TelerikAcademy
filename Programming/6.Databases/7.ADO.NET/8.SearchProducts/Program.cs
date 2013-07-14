using System;
using System.Data.SqlClient;
using _1.NumberOfRowsInCategoriesTab;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        // var query = "cha";  // Console.ReadLine(); // Coalition is case-insensitive
        var query = "asd%asd'asd'''asd\"asd_asd";

        var dbCon = new SqlConnection(Settings.Default.DBConnectionString);

        dbCon.Open();

        using (dbCon)
        {
            const string EscapingChar = "╥";

            var escapedQuery = query;
            escapedQuery = Regex.Replace(escapedQuery, @"([%_\""])", m => EscapingChar + m.Groups[1].Value);
            escapedQuery = escapedQuery.Replace("'", "''");

            Console.WriteLine(escapedQuery);

            var pattern = "%" + escapedQuery + "%"; // TODO

            var sql = string.Format("SELECT productName FROM Products WHERE productName LIKE '{0}' ESCAPE '☺'", pattern);
            var cmd = new SqlCommand(sql, dbCon);

            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    var productName = reader["productName"];

                    Console.WriteLine("Product: {0}", productName);
                }
            }
        }
    }
}
