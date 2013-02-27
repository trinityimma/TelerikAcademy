using System;
using System.Linq;
using System.Collections.Generic;

static class IEnumerableExtensions
{
    public static void Print(this IEnumerable<object> list)
    {
        foreach (var item in list) Console.WriteLine(item);

        Console.WriteLine();
    }
}

class Program
{
    static void Main()
    {
        var students = new[] {
            new { FirstName = "Pesho", LastName = "Ivanov", Age = 17 },
            new { FirstName = "Gosho", LastName = "Petrov", Age = 19 },
            new { FirstName = "Pepi",  LastName = "Ruseva", Age = 25 }
        };

        // Exercise 3
        students.Where(student =>
            student.FirstName.CompareTo(student.LastName) < 0
        ).Print();

        // Exercise 4
        students.Where(student =>
            18 < student.Age && student.Age < 24
        ).Print();

        // Exercise 5A
        students.OrderByDescending(student =>
            student.FirstName
        ).ThenByDescending(student =>
            student.LastName
        ).Print();

        // Exercise 5B
        (from student in students
            orderby student.FirstName descending,
                    student.LastName descending
            select student
        ).Print();
    }
}
