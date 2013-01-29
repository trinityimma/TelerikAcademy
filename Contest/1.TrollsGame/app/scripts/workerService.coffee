GAME.service 'workerService', [
   '$log', '$rootScope', '$location'
  ( $log ,  $rootScope ,  $location ) ->

    # Start a Web Worker
    fire: (field, moves, callback) ->
        $log.log 'Firing worker.'
        startTime = new Date
        worker = new Worker 'scripts/workerController.js'
        @inputField = field
        @inputMoves = moves

        # On error
        worker.addEventListener 'error', (e) ->
            $log.log "Error on line #{e.lineno}: #{e.message}."
        , false

        # Call callback if we have a result; else log the message
        worker.addEventListener 'message', (e) =>
            if e.data.result?
                $log.log "Worker finished in #{new Date - startTime}ms."
                @[key] = value for own key, value of e.data
                callback?()
                $location.path '/game.html'
                $rootScope.$apply()
            else $log.log e.data
        , false

        # Post user input
        worker.postMessage { field, moves }
]
