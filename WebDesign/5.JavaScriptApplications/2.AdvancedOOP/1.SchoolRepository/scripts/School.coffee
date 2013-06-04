@School = class School
    constructor: (@name, @town) ->
        @classes = []

    addClass: ->
        @classes.push klass for klass in arguments

        return @
