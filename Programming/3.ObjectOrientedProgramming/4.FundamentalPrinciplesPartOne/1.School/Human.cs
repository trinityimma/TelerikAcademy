using System;

class Human : IComparable<Human>
{
    public string FirstName { get; private set; }
    public string MiddleName { get; private set; }
    public string LastName { get; private set; }

    public Human(string firstName, string middleName, string lastName)
    {
        this.FirstName = firstName;
        this.MiddleName = middleName;
        this.LastName = lastName;
    }

    public int CompareTo(Human other)
    {
        return this.ToString().CompareTo(other.ToString());
    }

    public override string ToString()
    {
        return String.Format("{0} {1} {2}", this.FirstName, this.MiddleName, this.LastName);
    }
}
