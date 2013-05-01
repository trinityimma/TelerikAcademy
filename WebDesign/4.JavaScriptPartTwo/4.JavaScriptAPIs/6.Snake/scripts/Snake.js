define(function(require) {
    'use strict';

    var utils = require('utils')
    var MovingObject = require('MovingObject')
    var Point = require('Point')

    function _getPosition() {
        return this.parts.reduce(function(result, part) {
            result.row = Math.min(result.row, part.row)
            result.col = Math.min(result.col, part.col)

            return result
        }, new Point(Infinity, Infinity))
    }

    function _getImage() {
        var image = [[]]

        var first = _getPosition.call(this)

        // TODO: Optimize bounding box
        this.parts.forEach(function(part) {
            image[part.row - first.row] = image[part.row - first.row] || []

            image[part.row - first.row][part.col - first.col] = true
        })

        return image
    }

    function Snake(position) {
        this.parts =
            [ Point.add(position, Point(0, 0))
            , Point.add(position, Point(0, 1))
            , Point.add(position, Point(0, 2))
            , Point.add(position, Point(0, 3))
        ]

        MovingObject.call(this, _getImage.call(this), _getPosition.call(this), Point.RIGHT)
    }

    utils.inherit(Snake, MovingObject)

    Snake.prototype.update = function() {
        var currentHead = this.parts[this.parts.length - 1]
        var nextHead = Point.add(currentHead, this.direction)

        if (utils.contains(this.parts, nextHead))
            return this.respondToCollision()

        this.parts.shift()
        this.parts.push(nextHead)

        this.image = _getImage.call(this)
        this.position = _getPosition.call(this)
    }

    Snake.prototype.respondToCollision = function() {
        console.log('Game over!')

        this.respondToCollision =
        this.update = function() {

        }
    }

    Snake.prototype.handleInput = (function() {
        var _unallowed =
            { 'LEFT' : 'RIGHT'
            , 'RIGHT': 'LEFT'

            , 'UP'   : 'DOWN'
            , 'DOWN' : 'UP'
        }

        // TODO: Decouple UserInterface and Point
        return function(input) {
            if (!this.direction.equals(Point[_unallowed[input]]))
                this.direction = Point[input]
        }
    }())

    return Snake
})
