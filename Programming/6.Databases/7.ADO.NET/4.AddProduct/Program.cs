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
                    insert Products values
	                    (@name, 1, 1, 1, 1, 1, 1, 1, 0)
                ", dbCon);

            // TODO: add other parameters
            cmd.Parameters.AddWithValue("@name", "New Product");

            cmd.ExecuteNonQuery();
            var result = new SqlCommand("SELECT @@Identity", dbCon).ExecuteScalar();

            Console.WriteLine("Product added: {0}", result);
        }
    }
}
