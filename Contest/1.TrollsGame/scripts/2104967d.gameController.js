(function() {

  GAME.controller('gameController', [
    '$scope', '$rootScope', '$timeout', '$log', function($scope, $rootScope, $timeout, $log) {
      $scope.field = [[]];
      $scope.queue = [[]];
      $scope.result = 0;
      $scope.totalAnimations = 0;
      (function() {
        var autoplayMovesLimit, autoplayedMoves, change, cssTransitionDuration, moves, onAfterMove, onAfterScroll, onBeforeMove, onBeforeScroll, onMove;
        $scope.moving = false;
        $scope.autoplay = false;
        $scope.currentResult = 0;
        $scope.currentState = 0;
        $scope.currentSubState = -1;
        $scope.currentAnimation = 0;
        cssTransitionDuration = 1000;
        autoplayedMoves = 0;
        autoplayMovesLimit = 3;
        moves = [];
        change = 0;
        onBeforeMove = function() {
          $scope.moving = true;
          $scope.currentAnimation += change;
          onBeforeScroll();
          if ($scope.towers.scrollingMove) {
            return $timeout(function() {
              $scope.towers.makeVisible(moves[0].point);
              return $timeout(function() {
                $scope.towers.scrollingMove = false;
                return $timeout(onAfterScroll, cssTransitionDuration / 3 + 1000 / $scope.fps.current);
              }, cssTransitionDuration / 3);
            }, cssTransitionDuration / 3);
          } else {
            return onAfterScroll();
          }
        };
        onBeforeScroll = function() {
          var move, _i, _len;
          for (_i = 0, _len = moves.length; _i < _len; _i++) {
            move = moves[_i];
            if (!$scope.towers.isVisible(move.point)) {
              $scope.towers.scrollingMove = true;
              return;
            }
          }
        };
        onAfterScroll = function() {
          var i, move, point, _i, _len;
          for (i = _i = 0, _len = moves.length; _i < _len; i = ++_i) {
            move = moves[i];
            point = $scope.towers.get(move.point);
            if (i === 0) {
              if (move.delta > 0) {
                point.type = 'put';
              } else {
                point.type = 'take';
              }
            } else {
              if (i !== moves.length - 1) {
                point.type = 'fall';
              }
            }
          }
          $log.log(("Current state: " + $scope.currentState + ". ") + ("" + (change === 1 ? 'Executing' : 'Reverting') + " move: " + $scope.currentState));
          return $timeout(function() {
            return onMove(change === 1 ? 0 : moves.length - 1);
          }, cssTransitionDuration + 1000 / $scope.fps.current);
        };
        onMove = function(i) {
          var lastMove, move, point;
          move = moves[i];
          $scope.currentSubState = i;
          if ((-1 < i && i < moves.length)) {
            point = $scope.towers.get(move.point);
            if (change === 1) {
              $scope.currentResult = move.result;
            } else if (i - 1 !== -1) {
              $scope.currentResult = moves[i - 1].result;
            } else if ($scope.currentState - 1 !== -1) {
              lastMove = $scope.queue[$scope.currentState - 1];
              $scope.currentResult = lastMove[lastMove.length - 1].result;
            } else {
              $scope.currentResult = 0;
            }
            $log.log(("  Changing: " + move.point.x + ":" + move.point.y + " = " + point.value + " + " + (change * move.delta) + ".") + (" Result: " + $scope.currentResult + "."));
            point.value += change * move.delta;
            $scope.field[move.point.x][move.point.y] = point.value;
            $scope.currentAnimation += change;
            return $timeout(function() {
              return onMove(i + change);
            }, 1000 / $scope.fps.current);
          } else {
            return onAfterMove();
          }
        };
        onAfterMove = function() {
          var move, _i, _len;
          $scope.currentAnimation += change;
          for (_i = 0, _len = moves.length; _i < _len; _i++) {
            move = moves[_i];
            delete $scope.towers.get(move.point).type;
          }
          return $timeout(function() {
            var evt;
            $scope.moving = false;
            $scope.currentSubState = -1;
            if (change === 1) {
              $scope.currentState++;
            }
            $log.log("  Current state: " + $scope.currentState + ". Remaining moves: " + ($scope.getRemaining()) + ".");
            if ($scope.autoplay) {
              if ($scope.getRemaining()) {
                if (++autoplayedMoves < 100) {
                  return $scope.goForward();
                } else {
                  $scope.playPause();
                  try {
                    evt = document.createEvent("Events");
                    evt.initEvent("keydown", true, true);
                    evt.view = window;
                    evt.keyCode = 32;
                    evt.charCode = 0;
                    evt.altKey = evt.ctrlKey = evt.shiftKey = evt.metaKey = false;
                    return document.querySelector('.game').dispatchEvent(evt);
                  } catch (e) {

                  }
                }
              } else {
                return $scope.playPause();
              }
            }
          }, 1000 / $scope.fps.current);
        };
        $scope.goForward = function($event) {
          if ($event != null) {
            $event.preventDefault();
          }
          if (!$scope.canGoForward()) {
            return;
          }
          moves = $scope.queue[$scope.currentState];
          change = 1;
          return onBeforeMove();
        };
        $scope.goBackwards = function($event) {
          if ($event != null) {
            $event.preventDefault();
          }
          if (!$scope.canGoBackwards()) {
            return;
          }
          --$scope.currentState;
          moves = $scope.queue[$scope.currentState];
          change = -1;
          return onBeforeMove();
        };
        $scope.getRemaining = function() {
          return $scope.queue.length - $scope.currentState;
        };
        $scope.getTotal = function() {
          return $scope.queue.length;
        };
        $scope.canGoForward = function() {
          return $scope.getRemaining() && !$scope.moving;
        };
        $scope.canGoBackwards = function() {
          return $scope.currentState && !$scope.moving;
        };
        return $scope.playPause = function($event) {
          if ($event != null) {
            $event.preventDefault();
          }
          if (!($scope.autoplay || $scope.canGoForward())) {
            return;
          }
          $scope.autoplay = !$scope.autoplay;
          $log.log("Autoplay: " + $scope.autoplay);
          if ($scope.autoplay) {
            autoplayedMoves = 0;
            return $scope.goForward();
          }
        };
      })();
      $scope.towers = {
        field: [[]],
        count: 10,
        scrollingRow: false,
        scrollingCol: false,
        row: 0,
        _row: -1,
        col: 0,
        _col: -1,
        get: function(p) {
          return this.field[p.x - this._row][p.y - this._col];
        },
        getOffset: function() {
          return Math.floor(Math.random() * (this.count - 4) + 2);
        },
        hasScrollbars: function() {
          return $scope.field.length > this.count;
        },
        isVisible: function(p) {
          var _ref, _ref1;
          return (this._row <= (_ref = p.x) && _ref < this._row + this.count) && (this._col <= (_ref1 = p.y) && _ref1 < this._col + this.count);
        },
        makeVisible: function(p) {
          this.row = Math.min(Math.max(p.x - this.getOffset(), 0), $scope.field.length - this.count);
          this.col = Math.min(Math.max(p.y - this.getOffset(), 0), $scope.field.length - this.count);
          return this.make();
        },
        goUp: function() {
          if (!$scope.moving && +this.row > 0) {
            return this.row--;
          }
        },
        goLeft: function() {
          if (!$scope.moving && +this.col > 0) {
            return this.col--;
          }
        },
        goDown: function() {
          if (!$scope.moving && +this.row + this.count < $scope.field.length) {
            return this.row++;
          }
        },
        goRight: function() {
          if (!$scope.moving && +this.col + this.count < $scope.field.length) {
            return this.col++;
          }
        },
        make: function() {
          var i, j, _i, _j, _ref, _ref1;
          if (+this.row === this._row && +this.col === this._col) {
            return;
          }
          this.field = [];
          this._row = +this.row;
          this._col = +this.col;
          for (i = _i = 0, _ref = Math.min(this.count, $scope.field.length); 0 <= _ref ? _i < _ref : _i > _ref; i = 0 <= _ref ? ++_i : --_i) {
            this.field.push([]);
            for (j = _j = 0, _ref1 = Math.min(this.count, $scope.field.length); 0 <= _ref1 ? _j < _ref1 : _j > _ref1; j = 0 <= _ref1 ? ++_j : --_j) {
              this.field[i].push({
                value: $scope.field[this._row + i][this._col + j]
              });
            }
          }
          return $log.log("Scrolled to row:" + this.row + " col:" + this.col + ".");
        }
      };
      (function() {
        var change, end, interval, last, lastInverval, scrollingInterval, timer;
        last = 0;
        timer = null;
        interval = 100;
        lastInverval = 200;
        scrollingInterval = 300 - lastInverval;
        end = function() {
          return $scope.$apply(function() {
            $scope.towers.make();
            return $timeout(function() {
              $scope.towers.scrollingRow = false;
              return $scope.towers.scrollingCol = false;
            }, scrollingInterval);
          });
        };
        change = function() {
          clearTimeout(timer);
          timer = setTimeout(end, lastInverval);
          if (new Date - last > interval) {
            $scope.towers.make();
            return last = new Date;
          }
        };
        $scope.$watch('towers.row', function(newVal, oldVal) {
          if (newVal === oldVal) {
            return;
          }
          $scope.towers.scrollingRow = true;
          return change();
        });
        return $scope.$watch('towers.col', function(newVal, oldVal) {
          if (newVal === oldVal) {
            return;
          }
          $scope.towers.scrollingCol = true;
          return change();
        });
      })();
      $scope.fps = {
        min: 1,
        current: 2,
        max: 7,
        step: .25,
        decrease: function($event) {
          return this.increase($event, -this.step);
        },
        increase: function($event, change) {
          var _ref;
          if (change == null) {
            change = +this.step;
          }
          if ($event != null) {
            $event.preventDefault();
          }
          if ((this.min <= (_ref = +this.current + change) && _ref <= this.max)) {
            return this.current = +this.current + change;
          }
        }
      };
      return $scope.$on('ready', function(e, field, moves, totalChanged, result) {
        var date;
        $log.log("Game started.");
        date = new Date;
        $scope.field = field;
        $scope.queue = moves;
        $scope.totalAnimations = totalChanged + 2 * moves.length;
        $scope.result = result;
        $scope.towers.make();
        $scope.visible = true;
        $scope.$apply();
        return $log.log("Game ready in " + (new Date - date) + "ms.");
      });
    }
  ]);

}).call(this);
