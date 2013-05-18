'use strict'

class Student
    constructor: (@firstName, @lastName, @grade) ->
        @marks = {}

    addMark: (course, mark) ->
        @marks[course.title] = mark

    getMark: (course) ->
        @marks[course.title]

    # toString: ->
    #    'STUDENT: ' + ("#{key}: #{value}" for own key, value of @).join('; ')

    @deserialize = (studentData) ->
        student = new Student studentData.firstName, studentData.lastName, parseInt(studentData.grade, 10)

        student.marks = studentData.marks

        return student

class Course
    constructor: (@title, @startDate) ->
        @numberOfStudents = 0
        @students = []

    addStudents: (students) ->
        @numberOfStudents +=students.length
        @students.push student for student in students

        return @

    @deserialize = (courseData) ->
        course = new Course courseData.title, new Date(courseData.startDate)

        course.addStudents courseData.students.map (student) ->
            Student.deserialize(student)

class School
    constructor: (@name, @location, @specialty) ->
        @numberOfCourses = 0
        @courses = []

    addCourse: (courses) ->
        @numberOfCourses += courses.length
        @courses.push course for course in courses

        return @

    @deserialize = (schoolData) ->
        school = new School schoolData.name, schoolData.location, schoolData.specialty

        school.addCourse schoolData.courses.map (course) ->
            Course.deserialize(course)

class schoolRepository
    @save = (id, schoolsData) ->
        window.localStorage[id] = JSON.stringify schoolsData

    @load = (id) ->
        schoolRepository.deserialize JSON.parse(window.localStorage[id])

    @deserialize = (schooslData) ->
        schooslData.map (schoolData) ->
            School.deserialize schoolData

@schoolNS = { Student, Course, School, schoolRepository }

@controls.buildSchoolsGridView = (selector, schools) ->
    schoolsGrid = controls.GridView selector
    schoolsGrid.addHeader 'Name', 'Location', 'Number of Courses', 'Specialty'

    for school in schools
        courseRow = schoolsGrid.addRow school.name, school.location, school.numberOfCourses, school.specialty

        continue unless school.courses.length

        courseGrid = courseRow.getNestedGrid()
        courseGrid.addHeader 'Title', 'Start date', 'Number of Students'

        for course in school.courses
            studentRow = courseGrid.addRow course.title, course.startDate, course.numberOfStudents

            continue unless course.students.length

            studentGrid = studentRow.getNestedGrid()
            studentGrid.addHeader 'First Name', 'Last Name', 'Grade', 'Mark'

            for student in course.students
                studentGrid.addRow student.firstName, student.lastName, student.grade, student.getMark(course)

    return schoolsGrid

@controls.getSchoolsGridViewData = (grid) ->
    schoolsData = grid.data.map (schoolRow) ->
        schoolData =
            name: schoolRow.data[0]
            location: schoolRow.data[1]
            specialty: schoolRow.data[3]

        schoolData.courses = (schoolRow.nestedGrid?.data ? []).map (courseRow) ->
            courseData =
                title: courseRow.data[0]
                startDate: courseRow.data[1]

            courseData.students = (courseRow.nestedGrid?.data ? []).map (studentRow) ->
                studentData =
                    firstName: studentRow.data[0]
                    lastName: studentRow.data[1]
                    grade: studentRow.data[2]
                    marks: {}

                studentData.marks[courseData.title] = studentRow.data[3]

                return studentData
            return courseData
        return schoolData

    schoolRepository.deserialize schoolsData
