using System;
using System.Linq;
using System.Collections;

class Program
{
    static void Print(IEnumerable list)
    {
        foreach (var item in list) Console.WriteLine(item);

        Console.WriteLine();
    }

    static void Main()
    {
        var students = new[] {
            new { FirstName = "Pesho", LastName = "Ivanov", Age = 17 },
            new { FirstName = "Gosho", LastName = "Petrov", Age = 19 },
            new { FirstName = "Pepi",  LastName = "Ruseva", Age = 25 }
        };

        // Exercise 3
        Print(students.Where(student =>
            student.FirstName.CompareTo(student.LastName) < 0
        ));

        // Exercise 4
        Print(students.Where(student =>
            18 < student.Age && student.Age < 24
        ));

        // Exercise 5A
        Print(students.OrderByDescending(student =>
            student.FirstName
        ).ThenByDescending(student =>
            student.LastName
        ));

        // Exercise 5B
        Print(
            from student in students

            orderby student.FirstName descending,
                    student.LastName descending

            select student
        );
    }
}
