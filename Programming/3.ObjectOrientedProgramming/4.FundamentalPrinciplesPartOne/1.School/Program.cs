using System;

class Program
{
    static void Main()
    {
        // Sorted
        Console.WriteLine(new School("ФМИ")
            {
                new Class("Компютърни науки").AddStudent(
                    new Student("Светлин", "Иванов", "Наков"),
                    new Student("Пешо", "Иванов", "Наков"),
                    new Student("Гошо", "Иванов", "Наков"),
                    new Student("Преслав", "Иванов", "Георгиев"),
                    new Student("Преслав", "Иванов", "Георгиев"),
                    new Student("Преслав", "Иванов", "Георгиев"),
                    new Student("Преслав", "Иванов", "Георгиев"),
                    new Student("Преслав", "Иванов", "Георгиев"),
                    new Student("Преслав", "Иванов", "Георгиев")
                ).RemoveStudent(
                    new Student("Гошо", "Иванов", "Наков")
                ).AddTeacher(
                    new Teacher("Николай", "Иванов", "Костов").AddDiscipline(
                        new Discipline("Анализ", 3, 3),
                        new Discipline("Геометрия", 1, 2),
                        new Discipline("Алгебра", 1, 1),
                        new Discipline("Алгебра", 1, 1),
                        new Discipline("Алгебра", 1, 1)
                    ).RemoveDiscipline(
                        new Discipline("Геометрия")
                    )
                ),

                new Class("Информатика").AddStudent(
                    new Student("Александър", "Иванов", "Наков"),
                    new Student("Антоний", "Иванов", "Наков"),
                    new Student("Владислав", "Иванов", "Наков")
                ).AddTeacher(
                    new Teacher("Преслав", "Иванов", "Костов").AddDiscipline(
                        new Discipline("Алгебра", 3, 3)
                    ),
                    new Teacher("Филип", "Иванов", "Георгиев").AddDiscipline(
                        new Discipline("Дискретна математика", 3, 3)
                    )
                )
            }
        );
    }
}
