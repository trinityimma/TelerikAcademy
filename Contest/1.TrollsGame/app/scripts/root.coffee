@GAME = angular.module 'game', ['ui.directives'], [
   '$routeProvider'
  ( $routeProvider ) ->

    $routeProvider.when '/',
        templateUrl: 'templates/input.html'
        controller: 'inputController'

    $routeProvider.when '/game.html',
        templateUrl: 'templates/game.html'
        controller: 'gameController'

    $routeProvider.otherwise
        redirectTo: '/'
]
