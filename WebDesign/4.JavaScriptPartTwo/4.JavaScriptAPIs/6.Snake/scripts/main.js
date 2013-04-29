define(function(require) {
    'use strict';

    var Point = require('Point')

    var Engine = require('Engine')
    var Renderer = require('Renderer')
    var UserInterface = require('UserInterface')

    var GameObject = require('GameObject')
    var MovingObject = require('MovingObject')
    var Block = require('Block')

    var ROWS = 22
    var COLS = 30

    var CANVAS = document.getElementById('canvas')

    var _engine

    function init() {
        var renderer = new Renderer(CANVAS, ROWS, COLS)
        var userInterface = new UserInterface(CANVAS)

        _engine = new Engine(renderer, userInterface)
    }

    var make = (function() {
        function _makeBorders() {
            var row, col

            for (row = 0; row < ROWS; row++){
                _engine.add(new Block(Point(row, 0)))
                _engine.add(new Block(Point(row, COLS - 1)))
            }

            for (col = 1; col < COLS - 1; col++){
                _engine.add(new Block(Point(0, col)))
                _engine.add(new Block(Point(ROWS - 1, col)))
            }

            _engine.add(new Block(Point(COLS / 2, COLS / 2)))
        }

        function _makeEnviroment() {
            _engine.add(new MovingObject([[ true ]], Point(2, 2), Point.RIGHT))
            _engine.add(new MovingObject([[ true ]], Point(2, COLS - 3), Point.LEFT))

            // _engine.add(new MovingObject([[ true ]], Point(2, 5), Point.DOWN))
            // _engine.add(new MovingObject([[ true ]], Point(ROWS - 3, 5), Point.UP))

            // _engine.add(new MovingObject([[ true ]], Point(5, 5), Point(1, 1)))
            // _engine.add(new MovingObject([[ true ]], Point(13, 13), Point(-1, -1)))

            _engine.add(new MovingObject([[ true ]], Point(5, 5), Point(-1, -1)))
        }

        function _makeBall() {
            // _engine.addControlled(new MovingObject([[ true ]], Point(2, 6), Point(1, 1)))
        }

        return function() {
            _makeBorders(), _makeEnviroment(), _makeBall()
        }
    }())

    init(), make(), _engine.run()
})
