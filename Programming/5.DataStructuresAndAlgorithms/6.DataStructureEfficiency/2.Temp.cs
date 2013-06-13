using System;
using System.Linq;
using System.Text;
using Wintellect.PowerCollections;

class Article : IComparable<Article>
{
    public string Title { get; private set; }
    public decimal Price { get; private set; }
    public string Vendor { get; private set; }
    public string Barcode { get; private set; }

    // TODO: Barcode
    public Article(string title, decimal price, string vendor, string barcode = "0")
    {
        this.Title = title;
        this.Price = price;
        this.Vendor = vendor;
        this.Barcode = barcode;
    }

    public int CompareTo(Article other)
    {
        return string.Compare(this.Title, other.Title);
    }

    public override string ToString()
    {
        return string.Join("; ",
            "Price: " + this.Price,
            "Title: " + this.Title,
            "Vendor: " + this.Vendor,
            "Barcode: " + this.Barcode
        );
    }
}

class Program
{
    static OrderedMultiDictionary<decimal, Article> byPrice =
        new OrderedMultiDictionary<decimal, Article>(true);

    static string FindProductsByPriceRange(decimal min, decimal max)
    {
        var result = byPrice.Range(min, true, max, true).Values.OrderBy(p => p.Price);

        if (!result.Any())
            return "No products found";

        return string.Join(Environment.NewLine, result);
    }

    static string AddProduct(string name, decimal price, string vendor)
    {
        var product = new Article(name, price, vendor);
        byPrice[price].Add(product);

        return "Product added";
    }

    static void Main()
    {
#if DEBUG
        Console.SetIn(new System.IO.StreamReader("../../input.txt"));
#endif

        var output = new StringBuilder();

        for (string line = null; (line = Console.ReadLine()) != "End"; )
        {
            var match = line.Split(new[] { ' ' }, 2);
            var name = match[0];
            var parameters = match[1].Split(';');

            string result = null;

            switch (name)
            {
                case "AddProduct":
                    result = AddProduct(name: parameters[0], price: decimal.Parse(parameters[1]), vendor: parameters[2]);
                    break;

                case "FindProductsByPriceRange":
                    result = FindProductsByPriceRange(min: decimal.Parse(parameters[0]), max: decimal.Parse(parameters[1]));
                    break;

                default:
                    throw new ArgumentException("Invalid command: " + name);
            }

            output.AppendLine(line);
            output.AppendLine(result);
            output.AppendLine();
        }

        Console.Write(output);
    }
}
