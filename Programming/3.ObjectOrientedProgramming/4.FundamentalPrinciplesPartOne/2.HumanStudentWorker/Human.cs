using System;
using System.Text;

abstract class Human
{
    private const string SuffixIndentation = "  ";

    public string FirstName { get; private set; }
    public string LastName { get; private set; }

    public Human(string firstName, string lastName)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
    }

    public string ToString(string suffix = "")
    {
        StringBuilder info = new StringBuilder();

        info.AppendFormat("Name: {0} {1}", this.FirstName, this.LastName).AppendLine();

        if(!String.IsNullOrEmpty(suffix)) info.Append(suffix);

        info.Replace(Environment.NewLine, Environment.NewLine + SuffixIndentation);

        return info.ToString().TrimEnd();
    }
}
