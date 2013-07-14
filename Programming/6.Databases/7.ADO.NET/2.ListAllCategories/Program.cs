using System;
using System.Data.SqlClient;
using _1.NumberOfRowsInCategoriesTab;

class Program
{
    static void Main()
    {
        var dbCon = new SqlConnection(Settings.Default.DBConnectionString);

        dbCon.Open();

        using (dbCon)
        {
            var cmd = new SqlCommand("SELECT categoryName, description FROM Categories", dbCon);

            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    var categoryName = reader["categoryName"];
                    var description = reader["description"];

                    Console.WriteLine("Category {0}: {1}", categoryName, description);
                }
            }
        }
    }
}
