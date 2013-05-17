'use strict'

@controls ?= {}

_compareTo = (a, b) ->
    unless isNaN a - b then a - b else a.toString().localeCompare b.toString()

class GridViewRow
    constructor: ->
        @data = []
        @nestedGrid = null

    addColumn: (args) ->
        @data.push col for col in args

        return @

    getNestedGrid: ->
        @nestedGrid = new GridView()

    _renderData = (parent) ->
        tr = J('<tr />')

        tr.append J('<td />').text(col) for col in @data

        if @nestedGrid?
            tr.addClass 'nestedRow'

            tr.click (e) ->
                e.stopPropagation()

                J(this.nextElementSibling).toggle()

        parent.append tr

    _renderNested = (parent) ->
        return unless @nestedGrid?

        td = J('<td />').attr('colspan', @data.length)
        tr = J('<tr />').hide().append(td)

        @nestedGrid.render td
        parent.append tr

    render: (parent) ->
        _renderData.call @, parent
        _renderNested.call @, parent

@controls.GridView = class GridView
    constructor: (selector) ->
        return new GridView selector unless @ instanceof GridView

        @element = J selector

        @header = []
        @data = []

        @sortAscending = 1 # TODO: Save the current col

    addHeader: ->
        @header.push col for col in arguments

    addRow: ->
        row = new GridViewRow().addColumn arguments
        @data.push row

        return row

    _renderHeader = (parent) ->
        return unless @header.length

        tr = J('<tr />')

        for col, i in @header
            a = J('<a />').attr('href', '#').text(col)

            do (i) =>
                self = this

                a.click (e) ->
                    e.stopPropagation()
                    e.preventDefault()

                    self.sortAscending *= -1

                    self.data.sort (row1, row2) ->
                        self.sortAscending * _compareTo row1.data[i], row2.data[i]

                    parent = J(this).parent().parent().parent().parent()

                    parent.children().remove()

                    self.render(parent)

            tr.append J('<th />').append(a)

        parent.append tr

    _renderData = (parent) ->
        row.render parent for row in @data

    render: (parent) ->
        unless parent?
            parent = @element
            @element.children().remove()

        table = J('<table />').addClass('table').addClass('table-bordered')

        _renderHeader.call @, table
        _renderData.call @, table

        parent.append(table)

@controls.buildSchoolsGridView = (selector, schools) ->
    schoolsGrid = controls.GridView selector

    schoolsGrid.addHeader 'Name', 'Location', 'Total Students', 'Specialty'

    for school in schools
        courseRow = schoolsGrid.addRow school.name, school.location, school.numberOfCourses, school.specialty
        courseGrid = courseRow.getNestedGrid()

        courseGrid.addHeader 'Title', 'Start date', 'Number of Students'

        for course in school.courses
            studentRow = courseGrid.addRow course.title, course.startDate, course.numberOfStudents
            studentGrid = studentRow.getNestedGrid()

            studentGrid.addHeader 'First Name', 'Last Name', 'Grade', 'Mark'

            for student in course.students
                studentGrid.addRow student.firstName, student.lastName, student.grade, student.getMark(course)

    return schoolsGrid

@controls.getSchoolsGridViewData = (grid) ->
    schoolsData = grid.data.map (schoolRow) ->
        schoolData = {}

        schoolData.name = schoolRow.data[0]
        schoolData.location = schoolRow.data[1]
        schoolData.specialty = schoolRow.data[3]

        schoolData.courses = schoolRow.nestedGrid.data.map (courseRow) ->
            courseData = {}

            courseData.title = courseRow.data[0]
            courseData.startDate = courseRow.data[1]

            courseData.student = courseRow.nestedGrid.data.map (studentRow) ->
                studentData = {}

                studentData.firstName = studentRow.data[0]
                studentData.lastName = studentRow.data[1]
                studentData.grade = studentRow.data[2]

                studentData.marks = {}
                studentData.marks[courseData.title] = studentRow.data[3]

                return studentData

            return courseData

        return schoolData
