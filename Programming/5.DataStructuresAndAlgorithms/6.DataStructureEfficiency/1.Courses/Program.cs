using System;
using System.Linq;
using Wintellect.PowerCollections;

class Student : IComparable<Student>
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }

    public Student(string firstName, string lastName)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
    }

    public int CompareTo(Student other)
    {
        return string.Compare(this.LastName, other.LastName) * 2 +
            string.Compare(this.FirstName, other.LastName);
    }

    public override string ToString()
    {
        return string.Format("{0} {1}", this.FirstName, this.LastName);
    }
}

class Program
{
    static OrderedMultiDictionary<string, Student> byCourse =
        new OrderedMultiDictionary<string, Student>(true);

    static string FindStudentsByCourse(string course)
    {
        var result = byCourse[course];

        if (!result.Any())
            return "No students found";

        return string.Join(", ", result);
    }

    static string AddStudent(string firstName, string lastName, string course)
    {
        var student = new Student(firstName, lastName);
        byCourse[course].Add(student);

        return "Student added";
    }

    static void Main()
    {
#if DEBUG
        Console.SetIn(new System.IO.StreamReader("../../input.txt"));
#endif

        for (string line = null; (line = Console.ReadLine()) != null; )
        {
            var match = line.Split('|').Select(m => m.Trim()).ToArray();

            AddStudent(firstName: match[0], lastName: match[1], course: match[2]);
        }

        Console.WriteLine(string.Join(Environment.NewLine,
            byCourse.Keys.Select(course =>
                string.Format("{0}: {1}", course, FindStudentsByCourse(course))
            )
        ));
    }
}
