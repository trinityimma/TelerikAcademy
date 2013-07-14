using System;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using _1.NumberOfRowsInCategoriesTab;

class Program
{
    static void WriteBinaryFile(string filePath, byte[] fileContents)
    {
        using (var stream = File.OpenWrite(filePath))
            stream.Write(fileContents, 0, fileContents.Length);
    }

    static void Main()
    {
        var dbCon = new SqlConnection(Settings.Default.DBConnectionString);

        dbCon.Open();

        using (dbCon)
        {
            var cmd = new SqlCommand("SELECT categoryName, picture from Categories", dbCon);

            using (var reader = cmd.ExecuteReader())
            {
                string directoryPath = "../../CategoryPictures/";

                while (reader.Read())
                {
                    var image = (byte[])reader["picture"];
                    var categoryName = (string)reader["categoryName"];

                    var fileName = WebUtility.UrlEncode(categoryName).ToLower() + ".jpg";
                    WriteBinaryFile(directoryPath + fileName, image.Skip(78).ToArray());

                    Console.WriteLine("{0} saved", fileName);
                }
            }
        }
    }
}
