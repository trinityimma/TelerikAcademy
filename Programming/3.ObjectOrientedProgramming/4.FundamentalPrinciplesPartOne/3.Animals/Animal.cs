using System;
using System.Collections.Generic;

abstract class Animal : ISound
{
    public enum Sexes { Male, Female }

    public string Name { get; private set; }
    public int Age { get; private set; }
    public Sexes Sex { get; private set; }

    public Animal(string name, int age, Sexes sex)
    {
        this.Name = name;
        this.Age = age;
        this.Sex = sex;
    }

    public void ProduceSound()
    {
        Console.WriteLine("{0} sound.", this.GetType());
    }

    public override string ToString()
    {
        List<string> info = new List<string>();

        info.Add("Type: " + this.GetType());
        info.Add("Name: " + this.Name);
        info.Add("Age: " + this.Age);
        info.Add("Sex: " + this.Sex);

        return String.Join("; ", info);
    }
}
