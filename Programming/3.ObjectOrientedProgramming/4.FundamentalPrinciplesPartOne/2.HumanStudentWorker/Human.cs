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

        info.AppendLine(this.GetName());

        info.AppendLine(suffix).Replace(
            Environment.NewLine, Environment.NewLine + SuffixIndentation
        );

        return info.ToString().TrimEnd();
    }

    // TODO: Join with ToString and fix inheritance
    private string GetName()
    {
        return String.Format("Name: {0} {1}", this.FirstName, this.LastName);
    }

    public override string ToString()
    {
        return this.GetName();
    }
}
