var renderer = (function() {
    var ZOOM = 20
    var PADDING = 3

    var _context

    var _scene

    var _rows
    var _cols

    function _draw(row, col) {
        _context.fillStyle = 'lightGray'
        _context.fillRect(col * ZOOM, row * ZOOM, ZOOM - PADDING, ZOOM - PADDING)
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
            canvas.width  = cols * ZOOM - PADDING
            canvas.height = rows * ZOOM - PADDING

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
