using System;
using System.Data.SQLite;

class Program
{
    static void Main()
    {
        var dbCon = new SQLiteConnection("Data Source=../../mydb.db");

        dbCon.Open();

        using (dbCon)
        {
            // READ
            {
                var cmd = new SQLiteCommand("SELECT * FROM books", dbCon);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var title = reader["title"];
                        var author = reader["author"];
                        var publishDate = reader["publishDate"];
                        var isbn = reader["isbn"];

                        Console.WriteLine(string.Join("; ", title, author, publishDate, isbn));
                    }
                }
            }

            // INSERT
            {
                var cmd = new SQLiteCommand("INSERT INTO books VALUES(@id, @title, @author, @publishDate, @isbn)", dbCon);
                cmd.Parameters.AddWithValue("@id", "3"); // TODO auto increment
                cmd.Parameters.AddWithValue("@title", "JS");
                cmd.Parameters.AddWithValue("@author", "Pesho");
                cmd.Parameters.AddWithValue("@publishDate", "2010-01-01");
                cmd.Parameters.AddWithValue("@isbn", "789");

                cmd.ExecuteNonQuery();

                Console.WriteLine("Book added.");
            }
        }
    }
}
