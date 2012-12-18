(function() {

  addEventListener('message', function(e) {
    var Game, Point, States, move, _i, _len, _ref;
    Game = {
      field: e.data.field,
      moves: e.data.moves,
      result: 0,
      log: []
    };
    States = {
      queue: [],
      totalChanged: 0,
      addState: function(point, delta, result) {
        return this.queue.push([
          {
            point: point,
            delta: delta,
            result: result
          }
        ]);
      },
      addToState: function(point, delta, result) {
        return this.queue[this.queue.length - 1].push({
          point: point,
          delta: delta,
          result: result
        });
      }
    };
    Point = (function() {
      var directions;

      directions = [new Point(0, -1), new Point(-1, 0), new Point(1, 0), new Point(0, 1)];

      function Point(x, y) {
        this.x = x;
        this.y = y;
      }

      Point.prototype.getValue = function() {
        return Game.field[this.x][this.y];
      };

      Point.prototype._changeValue = function(v) {
        return Game.field[this.x][this.y] += v;
      };

      Point.prototype.changeValue = function(delta, falling) {
        if (!falling) {
          Game.log.push("  Move: " + States.queue.length);
        }
        Game.log.push("    Changing " + this.x + ":" + this.y + " = " + (this.getValue()) + " + " + delta + ".");
        States.totalChanged++;
        if (-1 < this.getValue() + delta) {
          this._changeValue(delta);
          Game.result -= delta;
        }
        States[falling ? 'addToState' : 'addState'](this, delta, Game.result);
        return this;
      };

      Point.prototype.checkNeighbours = function() {
        var direction, falling, next, _i, _len, _ref, _ref1, _ref2;
        for (_i = 0, _len = directions.length; _i < _len; _i++) {
          direction = directions[_i];
          next = new Point(this.x + direction.x, this.y + direction.y);
          if ((-1 < (_ref = next.x) && _ref < Game.field.length) && (-1 < (_ref1 = next.y) && _ref1 < Game.field.length)) {
            if ((0 < (_ref2 = this.getValue()) && _ref2 === next.getValue())) {
              falling = true;
              next.changeValue(-next.getValue(), true);
            }
          }
        }
        if (falling) {
          return this.changeValue(-this.getValue(), true);
        }
      };

      return Point;

    })();
    postMessage("  Received field " + Game.field.length + "*" + Game.field.length + ".");
    postMessage("  Received " + Game.moves.length + " moves.");
    _ref = Game.moves;
    for (_i = 0, _len = _ref.length; _i < _len; _i++) {
      move = _ref[_i];
      new Point(move[1], move[2]).changeValue({
        put: 1,
        take: -1
      }[move[0]]).checkNeighbours();
    }
    Game.log.push("  Total towers changed: " + States.totalChanged);
    Game.log.push("  Result: " + Game.result);
    postMessage(Game.log.join('\n'));
    return postMessage({
      moves: States.queue,
      totalChanged: States.totalChanged,
      result: Game.result
    });
  }, false);

}).call(this);
