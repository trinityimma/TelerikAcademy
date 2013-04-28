using System;

public class Student : IComparable<Student>
{
    private string name = null;
    public string Name
    {
        get { return this.name; }
        private set
        {
            if (value == null)
                throw new ArgumentNullException("Name");

            this.name = value;
        }
    }

    private int id = 0;
    public int Id
    {
        get { return this.id; }
        private set
        {
            if (!(10000 <= value && value <= 99999))
                throw new ArgumentOutOfRangeException("Id");

            this.id = value;
        }
    }

    public Student(string name, int id)
    {
        this.Name = name;
        this.Id = id;
    }

    public int CompareTo(Student other)
    {
        return this.Id.CompareTo(other.Id);
    }
}
