'use strict'

schoolsGrid = controls.GridView '#grid-view-holder'

schoolsGrid.addHeader 'Name', 'Location', 'Total Students', 'Specialty'

schoolsGrid.addRow 'PMG <br />', 'Burgas', 60, 'Math'
schoolsGrid.addRow 'TUES', 'Sofia', 500, 'IT'

academyRow = schoolsGrid.addRow 'Telerik Academy', 'Sofia', 5000, 'IT'

do ->
    academyGrid = academyRow.getNestedGrid()

    academyGrid.addHeader 'Title', 'Start Date', 'Total Students'

    academyGrid.addRow 'JS 2', '11-april-2013', 400
    academyGrid.addRow 'SEO', '15-may-2013', 400

    sliceAndDiceRow = academyGrid.addRow 'Slice and Dice', '05-april-2013', 500

    do ->
        sliceAndDiceGrid = sliceAndDiceRow.getNestedGrid()

        sliceAndDiceGrid.addHeader 'HTML', 'CSS'
        sliceAndDiceGrid.addRow 'HTML 4', 'CSS 2'
        sliceAndDiceGrid.addRow 'HTML 5', 'CSS 3'

schoolsGrid.render()

do ->
    students = (new schoolNS.Student("Student - #{i}", "Ivanov", J.random(1, 100)) for i in [1..40])

    courses = (new schoolNS.Course(i, new Date) for i in ['JS 2', 'SEO', 'S&D', 'C#'])

    courses[0].addStudents students[0..9]
    courses[1].addStudents students[10..19]
    courses[2].addStudents students[20..29]
    courses[3].addStudents students[30..39]

    for course in courses
        for student in course.students
            student.addMark course, J.random(0, 100)

    schools = [
        new schoolNS.School 'PMG', 'Burgas', 'Mathematics'
        new schoolNS.School 'TUES', 'Sofia', 'IT'
        new schoolNS.School 'Telerik Academy', 'Sofia', 'IT'
    ]

    schools[0].addCourse courses[0..1]
    schools[1].addCourse [courses[2]]
    schools[2].addCourse [courses[3]]

    setTimeout ->
        console.log "Task 4: Save to localStorage from data"

        schoolNS.schoolRepository.save 'schools-repository', schools
    , 1000

    schoolsData = null

    setTimeout ->
        console.log "Task 4: Load from localStorage and build new grid"

        schoolsData = schoolNS.schoolRepository.load('schools-repository')

        console.log schoolsData
    , 2000

    setTimeout ->
        console.log "Task 6: Build schools grid from data"

        schoolsGrid = controls.buildSchoolsGridView('#schools-grid', schoolsData)

        schoolsGrid.render()
    , 3000

    setTimeout ->
        console.log "Task 5: Get the data from the new grid"

        console.log controls.getSchoolsGridViewData(schoolsGrid)
    , 4000
