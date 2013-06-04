@Class = class Class
    constructor: (@name, @formTeacher, capacity) ->
        @students = new Array capacity

    addStudent: ->
        @students.push student for student in arguments

        return @
