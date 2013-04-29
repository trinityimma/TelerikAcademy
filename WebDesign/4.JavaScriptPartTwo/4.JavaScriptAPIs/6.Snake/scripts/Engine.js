var engine = (function() {
    var ANIMATION_DELAY = 1000 / 5

    var _controlledObject

    var _allObjects = []
    var _staticObjects = []
    var _movingObjects = []

    var _renderer
    var _userInterface

    function _renderAll() {
        _allObjects.forEach(function(obj) {
            _renderer.add(obj)
        })

        _renderer.renderAll()
    }

    var _checkForCollision = (function() {
        function _checkInDirection(obj, objDirection) {
            var i, cur
            var first, last
            var row, col

            var curDirection

            for (i = 0; i < _allObjects.length; i++) {
                cur = _allObjects[i]

                first = new Point(
                    Math.max(obj.position.row + objDirection.row,
                             cur.position.row),

                    Math.max(obj.position.col + objDirection.col,
                             cur.position.col)
                )

                last = new Point(
                    Math.min(obj.position.row + obj.rows + objDirection.row,
                             cur.position.row + cur.rows),

                    Math.min(obj.position.col + obj.cols + objDirection.col,
                             cur.position.col + cur.cols)
                )

                for (row = first.row; row < last.row; row++)
                    for (col = first.col; col < last.col; col++)
                        if (obj.image[row - (obj.position.row + objDirection.row)][col - (obj.position.col + objDirection.col)] &&
                            cur.image[row - cur.position.row][col - cur.position.col])
                                return true
            }

            return false
        }

        return function(obj) {
            var direction = obj.direction || Point.ZERO

            var _result = new Point()

            _result.row = _checkInDirection(obj, new Point(direction.row, 0)) && -direction.row || 0
            _result.col = _checkInDirection(obj, new Point(0, direction.col)) && -direction.col || 0

            // Diagonal
            if (_result.equals(Point.ZERO) && _checkInDirection(obj, direction))
                _result = direction.invert()

            // return (_result.row || _result.col) && _result;
            return _result.equals(Point.ZERO) ? null : _result;
        }
    }())

    return {
        init: function(renderer, userInterface) {
            _renderer = renderer
            _userInterface = userInterface
        },

        add: function(obj) {
            if (obj.direction)
                _movingObjects.push(obj)

            else _staticObjects.push(obj)

            _allObjects.push(obj)
        },

        addControlled: function(obj) {
            _controlledObject = obj

            engine.add(obj)
        },

        run: function() {
            _renderAll()

            var input = _userInterface.processInput()

            if (input && _controlledObject)
                _controlledObject.direction = Point[input.toUpperCase()]

            _movingObjects.forEach(function(obj) {
                var collision = _checkForCollision(obj)

                if (collision) {
                    obj.respondToCollision(collision)

                    // console.log('collision')
                }

                obj.update()
            })

            setTimeout(engine.run, ANIMATION_DELAY)
        }
    }
}())
