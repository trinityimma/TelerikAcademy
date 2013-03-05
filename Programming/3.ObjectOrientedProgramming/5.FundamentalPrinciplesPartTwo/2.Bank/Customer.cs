using System;

abstract class Customer
{
    public string Name { get; private set; }

    public Customer(string name)
    {
        this.Name = name;
    }

    public override string ToString()
    {
        return String.Format("Type: {0}; Name: {1}", this.GetType(), this.Name);
    }
}
