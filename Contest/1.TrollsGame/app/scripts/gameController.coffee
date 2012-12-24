GAME.controller 'gameController', [
   '$scope', '$rootScope', '$timeout', '$log', '$location', '$q', 'workerService'
  ( $scope ,  $rootScope ,  $timeout ,  $log ,  $location ,  $q ,  workerService ) ->

    # Page reload without input
    unless workerService.inputField
        $location.path '/'
        $location.replace()
        return

    date = new Date

    # Variables
    $scope.field = [[]] # [[1, 2, 3], [4, 5, 6], [7, 8, 9]] Matrix N*N
    $scope.queue = [[]] # [[move], [move, fall, fall, fall], [move, fall], ... ]
    $scope.result = 0
    $scope.totalAnimations = 0

    $scope.makeVendorPrefixes = do ->
        prefixes = ['-webkit-', '-moz-', '-o-', '']
        (rules) ->
            style = {}
            style["#{prefix}#{prop}"] = val for prefix in prefixes for prop, val of rules
            return style

    # MOVES
    do ->
        $scope.moving = false
        $scope.autoplay = false
        $scope.currentResult = 0
        $scope.currentState = 0 # C moves, C + 1 states
        $scope.currentSubState = -1
        $scope.currentAnimation = 0

        moves = []
        change = 0

        # No animations at max speed
        delay = (callback, t = 1) ->
            $timeout callback, $scope.getDelay t

        $scope.getDelay = (t = 1) -> if +$scope.fps.current is $scope.fps.max then 0 else t * 1000 / $scope.fps.current

        onBeforeMove = ->
            deferred = $q.defer()

            $scope.moving = true
            $scope.currentAnimation += change
            deferred.resolve()

            return deferred.promise

        onBeforeScroll = ->
            deferred = $q.defer()

            for move in moves
                $scope.towers.scrollingMove = yes unless $scope.towers.isVisible move.point
            deferred.resolve()

            return deferred.promise

        onScroll = ->
            deferred = $q.defer()

            if $scope.towers.scrollingMove
                delay ->
                    $scope.towers.makeVisible moves[0].point
                , 1
                delay ->
                    $scope.towers.scrollingMove = false
                , 2
                delay ->
                    deferred.resolve()
                , 3
            else deferred.resolve()

            return deferred.promise

        onAfterScroll = ->
            deferred = $q.defer()

            # Mark changed towers in this move
            for move, i in moves
                point = $scope.towers.get move.point
                if i is 0
                    if move.delta > 0
                        point.type = 'put'
                    else point.type = 'take'
                else point.type = 'fall' unless i is moves.length - 1 # The last falling is the same as the first one.
            $scope.flashing = on # Lock CSS animations when fps changes

            $log.log "Current state: #{$scope.currentState}. " +
              "#{if change is 1 then 'Executing' else 'Reverting'} move: #{$scope.currentState}"

            # Start current move
            delay ->
                $scope.flashing = off
                deferred.resolve()
            , 4 # 1 css transition + 2 css animation + 1 delay

            return deferred.promise

        onMove = do ->
            deferred = null # Save one deferred for all moves as closure

            (i) ->
                # Start moves
                unless i?
                    i = if change is 1 then 0 else moves.length - 1
                    deferred = $q.defer()

                move = moves[i]
                $scope.currentSubState = i

                # For each move
                if -1 < i < moves.length
                    point = $scope.towers.get move.point

                    # Get last result
                    if change is 1
                        $scope.currentResult = move.result # Going forward, take current
                    else unless i - 1 is -1
                        $scope.currentResult = moves[i - 1].result # Previous substate
                    else unless $scope.currentState - 1 is -1
                        lastMove = $scope.queue[$scope.currentState - 1]
                        $scope.currentResult = lastMove[lastMove.length - 1].result # Last substate of last state
                    else $scope.currentResult = 0 # Beginning of game

                    $log.log "  Changing: #{move.point.x}:#{move.point.y} = #{point.value} + #{change * move.delta}." +
                      " Result: #{$scope.currentResult}."

                    $scope.field[move.point.x][move.point.y] = point.value += change * move.delta # save to original
                    $scope.currentAnimation += change

                    # Call next
                    delay -> onMove i + change
                else deferred.resolve() # No more moves

                return deferred.promise

        onAfterMove = ->
            deferred = $q.defer()

            $scope.currentAnimation += change
            delete $scope.towers.get(move.point).type for move in moves # Clear marked towers

            delay ->
                $scope.moving = false
                $scope.currentSubState = -1

                $log.log "  Current state: #{$scope.currentState}. Remaining moves: #{$scope.getRemaining()}."

                deferred.resolve()

                # Start next move
                if $scope.autoplay
                    if $scope.getRemaining() then $scope.goForward() else $scope.playPause()

            return deferred.promise

        go = (ch) ->
            change = ch
            moves = $scope.queue[$scope.currentState]
            onBeforeMove().then(onBeforeScroll).then(onScroll).then(onAfterScroll).then(onMove).then(onAfterMove)

        $scope.goForward = ($event) ->
            $event?.preventDefault()
            return unless $scope.canGoForward()
            go(1).then ->
                $scope.currentState++

        $scope.goBackwards = ($event) ->
            $event?.preventDefault()
            return unless $scope.canGoBackwards()
            $scope.currentState--
            go(-1)

        $scope.getRemaining = -> $scope.queue.length - $scope.currentState
        $scope.getTotal = -> $scope.queue.length

        $scope.canGoForward = -> $scope.getRemaining() and not $scope.moving
        $scope.canGoBackwards = -> $scope.currentState and not $scope.moving

        $scope.playPause = ($event) ->
            $event?.preventDefault()
            return unless $scope.autoplay or $scope.canGoForward() # On the last move do nothing
            $scope.autoplay = not $scope.autoplay
            $log.log "Autoplay: #{$scope.autoplay}"
            $scope.goForward() if $scope.autoplay

    # TOWERS
    $scope.towers =
        field: [[]]
        count: 10 # Table size

        scrollingRow: false
        scrollingCol: false

        row: 0 # current - string
        _row: -1 # visible

        col: 0
        _col: -1

        # Get relative to view
        get: (p) -> @field[p.x - @_row][p.y - @_col]

        # When scrolling into view get random x with 2 cell padding for the falling towers
        # ******
        # *  x *
        # *    *
        # ******
        getOffset: -> Math.floor(Math.random() * (@count - 4) + 2)

        hasScrollbars: -> $scope.field.length > @count

        isVisible: (p) -> @_row <= p.x < @_row + @count and @_col <= p.y < @_col + @count
        makeVisible: (p) ->
            @row = Math.min(Math.max(p.x - @getOffset(), 0), $scope.field.length - @count)
            @col = Math.min(Math.max(p.y - @getOffset(), 0), $scope.field.length - @count)
            @make()

        goUp:    -> @row-- if not $scope.moving and +@row > 0
        goLeft:  -> @col-- if not $scope.moving and +@col > 0

        goDown:  -> @row++ if not $scope.moving and +@row + @count < $scope.field.length
        goRight: -> @col++ if not $scope.moving and +@col + @count < $scope.field.length

        make: ->
            return if +@row is @_row and +@col is @_col
            @field = []
            @_row = +@row
            @_col = +@col
            for i in [0...Math.min @count, $scope.field.length]
                @field.push []
                for j in [0...Math.min @count, $scope.field.length]
                    @field[i].push { value: $scope.field[@_row + i][@_col + j] }
            $log.log "Scrolled to row:#{@row} col:#{@col}."

    # Update view at interval; keypress can generate a lot of events if held down
    do ->
        last = 0
        timer = null
        interval = 100
        lastInverval = 200
        scrollingInterval = 300 - lastInverval # 300 is the CSS transition duration

        # Creating the function only once
        end = ->
            $scope.$apply ->
                $scope.towers.make()
                $timeout ->
                    $scope.towers.scrollingRow = false
                    $scope.towers.scrollingCol = false
                , scrollingInterval

        change = ->
            clearTimeout timer
            timer = setTimeout end, lastInverval

            if new Date - last > interval
                $scope.towers.make()
                last = new Date

        $scope.$watch 'towers.row', (newVal, oldVal)->
            return if newVal is oldVal
            $scope.towers.scrollingRow = true
            change()

        $scope.$watch 'towers.col', (newVal, oldVal)->
            return if newVal is oldVal
            $scope.towers.scrollingCol = true
            change()

    # Control speed animation
    $scope.fps =
        min:     1
        current: 2 # string
        max:     7
        step:    .25

        decrease: ($event) -> @increase $event, -@step
        increase: ($event, change = +@step) ->
            $event?.preventDefault()
            @current = +@current + change if @min <= +@current + change <= @max

    $log.log "Game started."
    $scope.field = angular.copy workerService.inputField # Save the input if the user wants to update it
    $scope.queue = workerService.moves
    $scope.totalAnimations = workerService.totalChanged + 2 * workerService.moves.length # One before and one after each move
    $scope.result = workerService.result
    $scope.towers.make()
    $log.log "Game ready in #{new Date - date}ms."
]
