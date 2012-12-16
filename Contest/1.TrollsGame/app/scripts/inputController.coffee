# We inject dependency this way, so they work with minification
GAME.controller 'inputController', [
   '$scope', '$timeout', '$log', 'workerService'
  ( $scope ,  $timeout ,  $log ,  workerService ) ->

    $scope.state = 'waiting'

    $scope.callWorker = ->
        return unless $scope.input.$valid
        $scope.callWorker = -> # Only one submit
        $scope.state = 'calculating'
        $timeout ->
            workerService.fire $scope.field, $scope.moves, ->
                $scope.state = 'loaded'
                # Delete model and view (textarea.value can be long)
                $scope.field = [[]] # Has still reference in the other controller
                $scope.moves = [[]]
        , 250 # Show loading status on small input
]
