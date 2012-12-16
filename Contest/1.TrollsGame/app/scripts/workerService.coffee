GAME.service 'workerService', [
   '$log', '$rootScope',
  ( $log ,  $rootScope ) ->

    # Start a Web Worker
    fire: (field, moves, callback) ->
        $log.log 'Firing worker.'
        startTime = new Date
        worker = new Worker 'scripts/workerController.js'

        # On error
        worker.addEventListener 'error', (e) ->
            $log.log "Error on line #{e.lineno}: #{e.message}."
        , false

        # Call callback if we have a result; else log the message
        # Using global events for communication with controllers
        worker.addEventListener 'message', (e) ->
            if e.data.result?
                $log.log "Worker finished in #{new Date - startTime}ms."
                callback?()
                $rootScope.$broadcast 'ready', field, e.data.moves, e.data.totalChanged, e.data.result
            else $log.log e.data
        , false

        # Post user input
        worker.postMessage { field, moves }
]
