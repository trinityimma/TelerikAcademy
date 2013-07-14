using System;
using System.Data.OleDb;

class Program
{
    static void Main()
    {
        var dbCon = new OleDbConnection(string.Format("Provider=Microsoft.ACE.OLEDB.12.0; Data Source={0}; Extended Properties=\"Excel 12.0 Xml; HDR=YES\";",
            "../../Scores.xlsx"));

        dbCon.Open();

        using (dbCon)
        {
            // READ
            {
                var cmd = new OleDbCommand("SELECT * FROM [Лист1$]", dbCon);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine(string.Join("\t | ", reader.GetString(0), reader.GetDouble(1)));
                    }
                }
            }

            // INSERT
            {
                var cmd = new OleDbCommand("INSERT INTO [Лист1$] VALUES(@name, @score)", dbCon);
                cmd.Parameters.AddWithValue("@name", "Pesho");
                cmd.Parameters.AddWithValue("@score", 30);

                cmd.ExecuteNonQuery();

                Console.WriteLine("Score added.");
            }
        }
    }
}
