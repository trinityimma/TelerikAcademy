addEventListener 'message', (e) ->
    Game =
        field: e.data.field
        moves: e.data.moves
        result: 0
        log: []

    States =
        queue: [] # Contains all moves
        totalChanged: 0
        addState: (point, delta, result) -> @queue.push [{point, delta, result}]
        addToState: (point, delta, result) -> @queue[@queue.length - 1].push {point, delta, result}

    class Point
        directions = [
            new Point(0, -1), new Point(-1, 0)
            new Point(1,  0), new Point( 0, 1)
        ]

        constructor: (@x, @y) ->
        getValue: -> Game.field[@x][@y]

        _changeValue: (v) -> Game.field[@x][@y] += v
        changeValue: (delta, falling) ->
            Game.log.push "  Move: #{States.queue.length}" if not falling
            Game.log.push "    Changing #{@x}:#{@y} = #{@getValue()} + #{delta}."

            States.totalChanged++

            if -1 < @getValue() + delta
                @_changeValue delta
                Game.result -= delta

            States[if falling then 'addToState' else 'addState'](@, delta, Game.result)

            return @

        checkNeighbours: ->
            for direction in directions
                next = new Point(@x + direction.x, @y + direction.y)

                if -1 < next.x < Game.field.length and
                   -1 < next.y < Game.field.length

                    if 0 < @getValue() is next.getValue()
                        falling = true
                        next.changeValue(-next.getValue(), true)

            @changeValue(-@getValue(), true) if falling

    postMessage "  Received field #{Game.field.length}*#{Game.field.length}."
    postMessage "  Received #{Game.moves.length} moves."

    # Move is ['put / take', 'i', 'j']
    for move in Game.moves
        new Point(move[1], move[2]).
          changeValue({put: 1, take: -1}[move[0]]).
          checkNeighbours()

    # Ready, post data
    Game.log.push "  Total towers changed: #{States.totalChanged}"
    Game.log.push "  Result: #{Game.result}"

    postMessage Game.log.join('\n')

    postMessage
        moves: States.queue
        totalChanged: States.totalChanged
        result: Game.result
, false
