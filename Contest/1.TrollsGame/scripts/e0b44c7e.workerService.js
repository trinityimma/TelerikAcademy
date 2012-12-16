(function() {

  GAME.service('workerService', [
    '$log', '$rootScope', function($log, $rootScope) {
      return {
        fire: function(field, moves, callback) {
          var startTime, worker;
          $log.log('Firing worker.');
          startTime = new Date;
          worker = new Worker('scripts/8eb56ff6.workerController.js');
          worker.addEventListener('error', function(e) {
            return $log.log("Error on line " + e.lineno + ": " + e.message + ".");
          }, false);
          worker.addEventListener('message', function(e) {
            if (e.data.result != null) {
              $log.log("Worker finished in " + (new Date - startTime) + "ms.");
              if (typeof callback === "function") {
                callback();
              }
              return $rootScope.$broadcast('ready', field, e.data.moves, e.data.totalChanged, e.data.result);
            } else {
              return $log.log(e.data);
            }
          }, false);
          return worker.postMessage({
            field: field,
            moves: moves
          });
        }
      };
    }
  ]);

}).call(this);
