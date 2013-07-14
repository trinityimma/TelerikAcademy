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
            var cmd = new SqlCommand(@"
                    select p.ProductName, c.CategoryName from products p
                    join categories c on p.CategoryID = c.CategoryID
                ", dbCon);

            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    var productName = reader["ProductName"];
                    var categoryName = reader["CategoryName"];

                    Console.WriteLine("Category: {0} - {1}", categoryName, productName);
                }
            }
        }
    }
}
