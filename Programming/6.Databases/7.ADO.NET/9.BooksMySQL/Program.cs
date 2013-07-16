using System;
using MySql.Data.MySqlClient;

class Program
{
    static void Main()
    {
        var dbCon = new MySqlConnection("Server=localhost;Database=books;Uid=root;Pwd=123456;Encrypt=true;");

        dbCon.Open();

        using (dbCon)
        {
            // READ
            {
                var cmd = new MySqlCommand("SELECT * FROM books", dbCon);

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
                var cmd = new MySqlCommand("INSERT INTO books VALUES(@title, @author, @publishDate, @isbn)", dbCon);
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
