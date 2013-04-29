/*jshint es5: true */

;(function() {
    var ROWS = 22
    var COLS = 30

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

            engine.add(new Block(Point(ROWS / 2, COLS / 2)))
        }

        function _makeEnviroment() {
            engine.add(new MovingObject([[ true ]], Point(2, 2), Point.RIGHT))
            engine.add(new MovingObject([[ true ]], Point(2, COLS - 3), Point.LEFT))

            engine.add(new MovingObject([[ true ]], Point(2, 5), Point.DOWN))
            engine.add(new MovingObject([[ true ]], Point(ROWS - 3, 5), Point.UP))

            engine.add(new MovingObject([[ true ]], Point(5, 5), Point(1, 1)))
            engine.add(new MovingObject([[ true ]], Point(13, 13), Point(-1, -1)))
        }

        function _makeBall() {
            // engine.addControlled(new MovingObject([[ true ]], Point(2, 6), Point(1, 1)))
        }

        return function() {
            _makeBorders(), _makeEnviroment(), _makeBall()
        }
    }())

    init(), make(), engine.run()
}())
