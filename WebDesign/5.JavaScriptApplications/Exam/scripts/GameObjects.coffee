class @GameObject
    constructor: (options) ->
        { @attack, @armor, @hitPoints, @range, @speed } = options

class @Warrior extends GameObject
    constructor: ->
        super
            attack: 8
            armor: 3
            hitPoints: 15
            range: 1
            speed: 2

class @Ranger extends GameObject
    constructor: ->
        super
            attack: 8
            armor: 1
            hitPoints: 10
            range: 3
            speed: 1

