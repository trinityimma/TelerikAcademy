/*jshint es5: true */

function makeMatrix(rows, cols) {
    var matrix = new Array(rows)

    var row, col

    for (row = 0; row < rows; row++) {
        matrix[row] = new Array(cols)

        for (col = 0; col < cols; col++)
            matrix[row][col] = false
    }

    return matrix
}

function inherit(Child, Parent) {
    Child.prototype = Object.create(Parent.prototype);
    Child.prototype.parent = Parent.prototype;
    Child.prototype.constructor = Child;
}

var Point = (function() {
    function Point(row, col) {
        if (!(this instanceof Point))
            return new Point(row, col)

        this.row = row
        this.col = col
    }

    Point.ZERO  = new Point( 0,  0)
    Point.LEFT  = new Point( 0, -1)
    Point.UP    = new Point(-1,  0)
    Point.RIGHT = new Point( 0,  1)
    Point.DOWN  = new Point( 1,  0)

    Point.add = function(p1, p2) {
        return new Point
            ( p1.row += p2.row
            , p1.col += p2.col
        )
    }

    Point.prototype.invert = function() {
        this.row = -this.row
        this.col = -this.col
    }

    return Point
}())


var engine = (function() {
    var ANIMATION_DELAY = 1000 / 60

    var _controlledObject
    var _staticObjects = []

    var _renderer
    var _userInterface

    function _renderAll() {
        _renderer.add(_controlledObject)

        _staticObjects.forEach(function(obj) {
            _renderer.add(obj)
        })

        _renderer.renderAll()
    }

    function _checkForCollision(obj) {
        var i, cur
        var first, last
        var row, col

        for (i = 0; i < _staticObjects.length; i++) {
            cur = _staticObjects[i]

            first = new Point(
                Math.max(obj.position.row + obj.direction.row,
                         cur.position.row),

                Math.max(obj.position.col + obj.direction.col,
                         cur.position.col)
            )

            last = new Point(
                Math.min(obj.position.row + obj.rows + obj.direction.row,
                         cur.position.row + cur.rows),

                Math.min(obj.position.col + obj.cols + obj.direction.col,
                         cur.position.col + cur.cols)
            )

            for (row = first.row; row < last.row; row++)
                for (col = first.col; col < last.col; col++)
                    if (obj.image[row - obj.position.row - obj.direction.row][col - obj.position.col - obj.direction.col] &&
                        cur.image[row - cur.position.row][col - cur.position.col])
                            return true;
        }

        return false;
    }

    return {
        init: function(renderer, userInterface) {
            _renderer = renderer
            _userInterface = userInterface
        },

        add: function(obj) {
            _staticObjects.push(obj)
        },

        addControlled: function(obj) {
            _controlledObject = obj
        },

        run: function() {
            _renderAll()

            var input = _userInterface.processInput()

            if (input)
                _controlledObject.direction = Point[input.toUpperCase()]

            if (_checkForCollision(_controlledObject))
                _controlledObject.direction.invert()

            _controlledObject.update()

            setTimeout(engine.run, ANIMATION_DELAY)
        }
    }
}())

var renderer = (function() {
    var ZOOM = 15

    var _context

    var _scene

    var _rows
    var _cols

    function _draw(row, col) {
        _context.fillStyle = 'black'
        _context.fillRect(col * ZOOM, row * ZOOM, ZOOM, ZOOM)

        _context.strokeStyle = 'white'
        _context.strokeRect(col * ZOOM, row * ZOOM, ZOOM, ZOOM)
    }

    function _render() {
        var row, col

        _context.clearRect(0, 0, _cols * ZOOM, _rows * ZOOM)

        for (row = 0; row < _scene.length; row++) {
            for (col = 0; col < _scene[row].length; col++) {
                if (_scene[row][col])
                    _draw(row, col)
            }
        }
    }

    function _clear() {
        var row, col

        for (row = 0; row < _scene.length; row++)
            for (col = 0; col < _scene[row].length; col++)
                _scene[row][col] = false
    }

    return {
        init: function(canvas, rows, cols) {
            // Reversed
            canvas.width  = cols * ZOOM
            canvas.height = rows * ZOOM

            _context = canvas.getContext('2d')

            _rows = rows
            _cols = cols

            _scene = makeMatrix(_rows, _cols)
            _clear()
        },

        add: function(obj) {
            var first = Point(
                Math.max(obj.position.row, 0),
                Math.max(obj.position.col, 0)
            )

            var last = Point(
                Math.min(obj.position.row + obj.rows, _rows),
                Math.min(obj.position.col + obj.cols, _cols)
            )

            var row, col

            for (row = first.row; row < last.row; row++) {
                for (col = first.col; col < last.col; col++) {
                    if (obj.image[row - first.row][col - first.col])
                        _scene[row][col] = true
                }
            }
        },

        renderAll: function() {
            _render()
            _clear()
        }
    }
}())

var userInterface = (function() {
    var _input

    var _keyMap =
        { 37: 'left'
        , 38: 'up'
        , 39: 'right'
        , 40: 'down'
    }

    return {
        init: function(element) {
            // TODO: Add listener to element
            window.addEventListener('keydown', function(e) {
                _input = _keyMap[e.which]
            })
        },

        processInput: function() {
            var result = _input
            _input = void 0
            return result
        }
    }
}())

function GameObject(image, position) {
    this.image = image
    this.position = position
}

GameObject.prototype =
    { get rows() {
        return this.image.length
    }

    , get cols() {
        return this.image[0].length
    }
}

var Block = (function() {
    function Block(position) {
        GameObject.call(this, [[ true ]], position)
    }

    inherit(Block, GameObject)

    return Block
}())

var MovingObject = (function() {
    function MovingObject(image, position, direction) {
        GameObject.call(this, image, position)

        this.direction = direction
    }

    inherit(MovingObject, GameObject)

    MovingObject.prototype.update = function() {
        this.position = Point.add(this.position, this.direction)
    }

    return MovingObject
}())

;(function() {
    var ROWS = 30
    var COLS = 40

    var CANVAS = document.getElementById('canvas')

    function init() {
        renderer.init(CANVAS, ROWS, COLS)
        userInterface.init(CANVAS)

        engine.init(renderer, userInterface)
    }

    var make = (function() {
        function _makeBorders() {
            var row, col

            for (row = 0; row < ROWS; row++){
                engine.add(new Block(Point(row, 0)))
                engine.add(new Block(Point(row, COLS - 1)))
            }

            for (col = 1; col < COLS - 1; col++){
                engine.add(new Block(Point(0, col)))
                engine.add(new Block(Point(ROWS - 1, col)))
            }
        }

        function _makeSnake() {
            engine.addControlled
                ( new MovingObject([[1, 1, 1, 1, 1, 1]]
                , Point(2, 2)
                , Point.RIGHT)
            )
        }

        return function() {
            _makeBorders(), _makeSnake()
        }
    }())

    init(), make(), engine.run()
}())
