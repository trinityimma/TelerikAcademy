/*jshint es5: true */

function Point(row, col) {
    if (!(this instanceof Point))
        return new Point(row, col)

    this.row = row
    this.col = col
}

var engine = (function() {
    var ANIMATION_DELAY = 60

    var _allObjects = []

    var _renderer
    var _userInterface

    function _renderAll() {
        _allObjects.forEach(function(obj) {
            _renderer.add(obj)
        })

        _renderer.renderAll()
    }

    return {
        init: function(renderer, userInterface) {
            _renderer = renderer
            _userInterface = userInterface
        },

        add: function(obj) {
            _allObjects.push(obj)
        },

        run: function() {
            _renderAll()
            _userInterface.processInput()

            setTimeout(engine.run, ANIMATION_DELAY)
        }
    }
}())

function makeMatrix(rows, cols) {
    var matrix = new Array(rows)

    var row, col

    for (row = 0; row < rows; row++) {
        matrix[row] = new Array(cols)

        for (col = 0; col < cols; col++)
            matrix[row][col] = 0
    }

    return matrix
}

var renderer = (function() {
    var ZOOM = 15

    var _scene

    var _context

    var _rows
    var _cols

    function _draw(row, col) {
        _scene.fillStyle = 'black'
        _scene.fillRect(col * ZOOM, row * ZOOM, ZOOM, ZOOM)

        _scene.strokeStyle = 'white'
        _scene.strokeRect(col * ZOOM, row * ZOOM, ZOOM, ZOOM)
    }

    function _render() {
        var row, col

        for (row = 0; row < _context.length; row++) {
            for (col = 0; col < _context[row].length; col++) {
                if (_context[row][col])
                    _draw(row, col)
            }
        }
    }

    function _clear() {
        var row, col

        for (row = 0; row < _context.length; row++)
            for (col = 0; col < _context[row].length; col++)
                _context[row][col] = 0
    }

    return {
        init: function(canvas, rows, cols) {
            // Reversed
            canvas.width  = cols * ZOOM
            canvas.height = rows * ZOOM

            _scene = canvas.getContext('2d')

            _rows = rows
            _cols = cols

            _context = makeMatrix(_rows, _cols)
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
                    _context[row][col] = true
                }
            }
        },

        renderAll: function() {
            _render()
            _clear()
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

function Block(position) {
    return new GameObject([[1]], position)
}

var userInterface = (function() {
    var _input

    var _keyMap =
        { 37: 'left'
        , 38: 'up'
        , 39: 'right'
        , 40: 'down'
    }

    window.addEventListener('keydown', function(e) {
        _input = _keyMap[e.which]
    })

    return {
        processInput: function() {
            if (_input) console.log(_input)

            var result = _input
            _input = void 0
            return result
        }
    }
}())

;(function() {
    var ROWS = 30
    var COLS = 40

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

    renderer.init(document.getElementById('canvas'), ROWS, COLS)
    engine.init(renderer, userInterface)

    _makeBorders()
    engine.add(new GameObject([[1, 1, 1, 1, 1, 1]], Point(2, 2)))

    engine.run()
}())

