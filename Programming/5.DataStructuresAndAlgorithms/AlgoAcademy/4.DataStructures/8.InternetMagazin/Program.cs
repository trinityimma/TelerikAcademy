using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Collections.Generic;
using Wintellect.PowerCollections;

public class Product
{
    public string Name { get; private set; }

    public string Producer { get; private set; }

    public decimal Price { get; private set; }

    public Product(string name, string producer, decimal price)
    {
        this.Name = name;
        this.Producer = producer;
        this.Price = price;
    }

    public override string ToString()
    {
        var result = "{" + this.Name + ";" + this.Producer + ";" + this.Price.ToString("0.00") + "}";
        return result;
    }
}

public class ShoppingCenter
{
    private readonly MultiDictionary<string, Product> byName =
        new MultiDictionary<string, Product>(true);

    private readonly MultiDictionary<string, Product> byProducer =
        new MultiDictionary<string, Product>(true);

    private readonly MultiDictionary<Tuple<string, string>, Product> byNameAndProducer =
        new MultiDictionary<Tuple<string, string>, Product>(true);

    private readonly OrderedMultiDictionary<decimal, Product> byPrice =
        new OrderedMultiDictionary<decimal, Product>(true,
            (x, y) => x.CompareTo(y),
            (x, y) => 0
        );

    private void CheckCount()
    {
        Debug.Assert(
            this.byName.KeyValuePairs.Count == this.byProducer.KeyValuePairs.Count &&
            this.byName.KeyValuePairs.Count == this.byNameAndProducer.KeyValuePairs.Count &&
            this.byName.KeyValuePairs.Count == this.byPrice.KeyValuePairs.Count
        );
    }

    public void AddProduct(Product product)
    {
        this.byName[product.Name].Add(product);
        this.byProducer[product.Producer].Add(product);
        this.byNameAndProducer[Tuple.Create(product.Name, product.Producer)].Add(product);
        this.byPrice[product.Price].Add(product);

        CheckCount();
    }

    public IEnumerable<Product> FindProductsByName(string name)
    {
        var products = this.byName[name];
        return products;
    }

    public IEnumerable<Product> FindProductsByProducer(string producer)
    {
        var products = this.byProducer[producer];
        return products;
    }

    public IEnumerable<Product> FindProductsByPriceRange(decimal min, decimal max)
    {
        var products = this.byPrice.Range(min, true, max, true).Values;
        return products;
    }

    public int DeleteProducts(string producer)
    {
        var products = this.byProducer[producer];
        var count = products.Count;

        foreach (var product in products)
        {
            this.byName[product.Name].Remove(product);
            this.byNameAndProducer[Tuple.Create(product.Name, product.Producer)].Remove(product);
            this.byPrice[product.Price].Remove(product);
        }

        this.byProducer.Remove(producer);

        CheckCount();
        return count;
    }

    public int DeleteProducts(string name, string producer)
    {
        var nameAndProducer = Tuple.Create(name, producer);

        var products = this.byNameAndProducer[nameAndProducer];
        var count = products.Count;

        foreach (var product in products)
        {
            this.byName[product.Name].Remove(product);
            this.byProducer[product.Producer].Remove(product);
            this.byPrice[product.Price].Remove(product);
        }

        this.byNameAndProducer.Remove(nameAndProducer);

        CheckCount();
        return count;
    }
}

public static class Program
{
    private static readonly StringBuilder Output = new StringBuilder();

    private static void PrintProducts(IEnumerable<Product> products)
    {
        if (!products.Any())
        {
            Output.AppendLine("No products found");
            return;
        }

        var sorted = products
            .OrderBy(x => x.Name)
            .ThenBy(x => x.Producer)
            .ThenBy(x => x.Price);

        foreach (var product in sorted)
        {
            Output.AppendLine(product.ToString());
        }
    }

    public static void Main()
    {
#if DEBUG
        Console.SetIn(new StreamReader("../../input.txt"));
        Debug.Listeners.Add(new ConsoleTraceListener());
#endif

        var date = DateTime.Now;

        var separator = new[] { ' ' };

        var shoppingCenter = new ShoppingCenter();

        foreach (int i in Enumerable.Range(0, int.Parse(Console.ReadLine())))
        {
            var line = Console.ReadLine();
            var splitted = line.Split(separator, 2);
            var name = splitted[0];
            var parameters = splitted[1].Split(';');

#if DEBUG
            Output.AppendLine();
            Output.AppendLine(line);
#endif

            switch (name)
            {
                case "AddProduct":
                    {
                        var product = new Product(
                            name: parameters[0],
                            price: decimal.Parse(parameters[1]),
                            producer: parameters[2]
                        );

                        shoppingCenter.AddProduct(product);

                        Output.AppendLine("Product added");
                        break;
                    }

                case "FindProductsByName":
                    {
                        var products = shoppingCenter.FindProductsByName(parameters[0]);

                        PrintProducts(products);

                        break;
                    }

                case "FindProductsByProducer":
                    {
                        var products = shoppingCenter.FindProductsByProducer(parameters[0]);

                        PrintProducts(products);

                        break;
                    }

                case "FindProductsByPriceRange":
                    {
                        var products = shoppingCenter.FindProductsByPriceRange(
                            min: decimal.Parse(parameters[0]),
                            max: decimal.Parse(parameters[1])
                        );

                        PrintProducts(products);

                        break;
                    }

                case "DeleteProducts":
                    {
                        int deletedCount;

                        switch (parameters.Length)
                        {
                            case 1:
                                deletedCount = shoppingCenter.DeleteProducts(
                                    producer: parameters[0]
                                );

                                break;

                            case 2:
                                deletedCount = shoppingCenter.DeleteProducts(
                                    name: parameters[0],
                                    producer: parameters[1]
                                );

                                break;

                            default:
                                throw new ArgumentException("DeleteProducts");
                        }

                        if (deletedCount == 0)
                        {
                            Output.AppendLine("No products found");
                            break;
                        }

                        Output.AppendLine(deletedCount + " products deleted");

                        break;
                    }

                default:
                    throw new ArgumentException("Invalid command: " + name);
            }
        }

#if !DEBUG || DEBUG
        Console.Write(Output);
#endif

        Debug.WriteLine(DateTime.Now - date);
    }
}
