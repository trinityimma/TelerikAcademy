using System;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<Student> students = new List<Student>()
        {
            new Student("Светлин", "Иванов", "08 А"),
            new Student("Пешо", "Иванов", "08 А"),
            new Student("Гошо", "Иванов", "10 А"),
            new Student("Преслав", "Иванов", "10 А"),
            new Student("Александър", "Иванов", "10 Б"),
            new Student("Антоний", "Иванов", "08 Б"),
            new Student("Владислав", "Иванов", "10 Б"),
            new Student("Владислав", "Иванов", "12 А"),
            new Student("Гошо", "Иванов", "12 А"),
            new Student("Преслав", "Иванов", "12 Б"),
            new Student("Филип", "Иванов", "12 Б")
        };

        List<Worker> workers = new List<Worker>()
        {
            new Worker("Владислав", "Иванов", 22, 26),
            new Worker("Светлин", "Иванов", 73, 26),
            new Worker("Гошо", "Иванов", 233, 25),
            new Worker("Преслав", "Иванов", 97, 45),
            new Worker("Владислав", "Иванов", 261, 44),
            new Worker("Александър", "Иванов", 173, 52),
            new Worker("Пешо", "Иванов", 172, 36),
            new Worker("Антоний", "Иванов", 172, 35),
            new Worker("Преслав", "Иванов", 57, 43),
            new Worker("Гошо", "Иванов", 108, 51),
            new Worker("Филип", "Иванов", 107, 35)
        };

        // Toggle between tasks
        if (true)
        {
            students.OrderBy(
               student => student.Grade
            ).Print();

            workers.OrderByDescending(
                worker => worker.GetMoneyPerHour()
            ).Print();
        }

        else
        {
            List<Human> humans = new List<Human>();

            humans.AddRange(students);
            humans.AddRange(workers);

            humans.OrderBy(
                human => human.ToString()
            ).Print();
        }
    }
}
