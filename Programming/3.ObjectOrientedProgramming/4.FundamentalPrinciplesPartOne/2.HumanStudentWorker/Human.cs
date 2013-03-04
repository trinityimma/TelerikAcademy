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

    protected string ToString(string suffix)
    {
        StringBuilder info = new StringBuilder();

        info.AppendLine(base.ToString()); // Called from inherited classes; same as Human.ToString()

        info.AppendLine(suffix).Replace(Environment.NewLine, Environment.NewLine + SuffixIndentation);

        return info.ToString().TrimEnd();
    }

    public override string ToString()
    {
        return String.Format("Name: {0} {1}", this.FirstName, this.LastName);
    }
}
