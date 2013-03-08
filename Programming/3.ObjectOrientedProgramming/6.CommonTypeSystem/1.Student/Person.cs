using System;
using System.Text;

class Person
{
    public string FirstName { get; private set; }
    public string MiddleName { get; private set; }
    public string LastName { get; private set; }

    public int? Age { get; private set; }

    public Person(string firstName, string middleName, string lastName, int? age = null)
    {
        this.FirstName = firstName;
        this.MiddleName = middleName;
        this.LastName = lastName;
        this.Age = age;
    }

    public override string ToString()
    {
        StringBuilder info = new StringBuilder();

        info.AppendFormat("Name: {0} {1} {2}",
            this.FirstName, this.MiddleName, this.LastName).AppendLine();

        info.AppendLine("Age: " + (this.Age ?? -1));

        return info.ToString().TrimEnd();
    }
}
