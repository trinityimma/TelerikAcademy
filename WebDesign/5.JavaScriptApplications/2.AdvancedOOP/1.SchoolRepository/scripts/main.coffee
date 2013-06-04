console.log 'DEMO'

do ->
    person = new Person 'Pesho', 'Ivanov', 20
    console.log person.toString()

    student = new Student 'Svetlin', 'Nakov', 30, 8
    console.log student.toString()

    teacher = new Teacher 'Nikolay', 'Kostov', 20, 'Software'
    console.log teacher.toString()

    school = new School 'Telerik Academy', 'Sofia', 1000
    console.log school

    klass = new Class '8a', teacher, 25
    console.log klass

console.log 'DEMO'

do ->
    teacher = new Teacher 'Nikolay', 'Kostov', 20, 'Software'

    students = (new Student("Student - #{i}", "Ivanov", _.random(1, 100)) for i in [1..40])

    classes = (new Class(i, teacher, _.random(20, 30)) for i in ['JS I', 'JS II', 'SEO', 'S&D'])

    for i in [0...4]
        classes[i].addStudent student for student in students[(i * 10)...((i + 1) * 10)]

    schools = [
        new School 'PMG', 'Burgas', 100
        new School 'TUES', 'Sofia', 200
        new School 'Telerik Academy', 'Sofia', 500
    ]

    schools[0].addClass classes[0], classes[1]
    schools[1].addClass classes[2]
    schools[2].addClass classes[3]

    console.log schools
