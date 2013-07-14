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
            var cmd = new SqlCommand("SELECT COUNT(*) FROM Categories", dbCon);

            var result = cmd.ExecuteScalar();

            Console.WriteLine(result);
        }
    }
}
