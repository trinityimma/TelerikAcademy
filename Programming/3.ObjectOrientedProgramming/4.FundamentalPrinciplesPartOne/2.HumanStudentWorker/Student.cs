using System;

class Student : Human
{
    public string Grade { get; private set; }

    public Student(string firstName, string lastName, string grade)
        : base(firstName, lastName)
    {
        this.Grade = grade;
    }

    public override string ToString()
    {
        return base.ToString(String.Format("Grade: {0}", this.Grade));
    }
}
