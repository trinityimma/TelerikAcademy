using System;
using System.Text;
using System.Collections.Generic;

class Class : ICommentable, IComparable<Class>
{
    private readonly SortedSet<Student> students = new SortedSet<Student>();
    private readonly SortedSet<Teacher> teachers = new SortedSet<Teacher>();

    public string Name { get; private set; }

    public string Comment { get; set; }

    public Class(string name)
    {
        this.Name = name;
    }

    public Class AddStudent(params Student[] students)
    {
        foreach (Student student in students)
            this.students.Add(student);

        return this;
    }

    public Class RemoveStudent(Student student)
    {
        this.students.Remove(student);

        return this;
    }

    public Class AddTeacher(params Teacher[] teachers)
    {
        foreach (Teacher teacher in teachers)
            this.teachers.Add(teacher);

        return this;
    }

    public Class RemoveTeacher(Teacher teacher)
    {
        this.teachers.Remove(teacher);

        return this;
    }

    public int CompareTo(Class other)
    {
        return this.Name.CompareTo(other.Name);
    }

    public override string ToString()
    {
        StringBuilder info = new StringBuilder();

        info.AppendLine("# Class name: " + this.Name);

        info.AppendLine("# Teachers:");
        info.AppendLine(this.teachers.ToString<Teacher>());

        info.AppendLine("# Students:");
        info.AppendLine(this.students.ToString<Student>());

        return info.TrimEnd().ToString();
    }
}
