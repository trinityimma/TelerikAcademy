using System;

class Student : Human, ICommentable
{
    public int ClassNumber { get; private set; }

    public string Comment { get; set; }

    public Student(string firstName, string middleName, string lastName)
        : base(firstName, middleName, lastName)
    {
    }
}
