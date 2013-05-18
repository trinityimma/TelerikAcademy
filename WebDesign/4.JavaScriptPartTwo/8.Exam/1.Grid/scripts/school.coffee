'use strict'

@studentNS ?= {}

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

schoolRepository = do ->
    save: (id, schoolsData) ->
        window.localStorage[id] = JSON.stringify schoolsData

    load: (id) ->
        JSON.parse(window.localStorage[id]).map (schoolData) ->
            School.deserialize schoolData

@schoolNS = { Student, Course, School, schoolRepository}
