@Person = class Person
    constructor: (@firstName, @lastName, @age) ->

    toString: ->
       @constructor.name.toUpperCase() + ": " + ("#{key}: #{value}" for own key, value of @).join('; ')
