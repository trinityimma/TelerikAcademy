using System;

class Program
{
    static void Main()
    {
        Student[] students = {
            new Student("CSvetlin", "Ivanov", "Nakov", "1"),
            new Student("ASvetlin", "Ivanov", "Nakov", "2"),
            new Student("BSvetlin", "Ivanov", "Nakov", "3"),
            new Student("BSvetlin", "Ivanov", "Nakov", "4")
        };

        Array.Sort(students);

        Console.WriteLine(String.Join<Student>(Environment.NewLine + Environment.NewLine, students));


        Console.WriteLine();
        Console.WriteLine(new Person("Svetlin", "Ivanov", "Nakov", 30));
    }
}
