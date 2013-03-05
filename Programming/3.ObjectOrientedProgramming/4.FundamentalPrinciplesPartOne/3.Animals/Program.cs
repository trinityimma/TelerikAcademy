using System;
using System.Linq;

class Program
{
    static void Main()
    {
        Animal[] animals = new Animal[] {
            new Tomcat("Pesho", 2),
            new Kitten("Mimi", 4),
            new Dog("Sharo", 3, Sex.Male),
            new Frog("Kermit", 5, Sex.Male)
        };

        Cat[] cats = new Cat[]
        {
            new Kitten("Mimi", 2),
            new Tomcat("Gosho", 6)
        };

        Console.WriteLine("# Animals");
        foreach (Animal animal in animals)
            Console.WriteLine(animal);

        Console.WriteLine("# Produce sound");
        foreach (ISound animal in animals)
            Console.WriteLine(animal.ProduceSound());

        Console.WriteLine("# Average");
        Console.WriteLine(animals.Average(animal => animal.Age));
        Console.WriteLine(cats.Average(cat => cat.Age));
    }
}
