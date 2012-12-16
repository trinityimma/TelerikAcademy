(function() {

  GAME.controller('inputController', [
    '$scope', '$timeout', '$log', 'workerService', function($scope, $timeout, $log, workerService) {
      $scope.state = 'waiting';
      return $scope.callWorker = function() {
        if (!$scope.input.$valid) {
          return;
        }
        $scope.callWorker = function() {};
        $scope.state = 'calculating';
        return $timeout(function() {
          return workerService.fire($scope.field, $scope.moves, function() {
            $scope.state = 'loaded';
            $scope.field = [[]];
            return $scope.moves = [[]];
          });
        }, 250);
      };
    }
  ]);

}).call(this);
