define(function(require) {
    'use strict';

    var Point = require('Point')

    var ANIMATION_DELAY = 1000 / 5

    function Engine(renderer, userInterface) {
        this.controlledObject = null

        this.allObjects = []
        this.staticObjects = []
        this.movingObjects = []

        this.renderer = renderer
        this.userInterface = userInterface
    }

    var _checkForCollision = (function() {
        function _checkInDirection(obj, objDirection) {
            var i, cur
            var first, last
            var row, col

            for (i = 0; i < this.allObjects.length; i++) {
                cur = this.allObjects[i]

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
                        if (obj.image
                                [row - (obj.position.row + objDirection.row)]
                                [col - (obj.position.col + objDirection.col)] &&

                            cur.image
                                [row - cur.position.row]
                                [col - cur.position.col]
                        )
                                return true
            }

            return false
        }

        return function(obj) {
            var direction = obj.direction || Point.ZERO

            var force = new Point
                ( _checkInDirection.call(this, obj, new Point(direction.row, 0)) && direction.row || 0
                , _checkInDirection.call(this, obj, new Point(0, direction.col)) && direction.col || 0
            )

            // Diagonal
            if (force.equals(Point.ZERO) && _checkInDirection.call(this, obj, direction))
                force = direction

            force = Point.invert(force)

            return force.equals(Point.ZERO) ? null : force;
        }
    }())

    Engine.prototype =
        { add: function(obj) {
            if (obj.direction) this.movingObjects.push(obj)
            else this.staticObjects.push(obj)

            this.allObjects.push(obj)
        }

        , addControlled: function(obj) {
            this.controlledObject = obj

            return this.add(obj)
        }

        , run: (function() {
            function _renderAll() {
                var self = this

                this.allObjects.forEach(function(obj) {
                    self.renderer.add(obj)
                })

                this.renderer.renderAll()
            }

            return function() {
                var self = this

                var input

                _renderAll.call(this)

                input = this.userInterface.processInput()

                if (input && this.controlledObject) {
                    this.controlledObject.direction = Point[input.toUpperCase()] // TODO: Decouple
                }

                this.movingObjects.forEach(function(obj) {
                    var collision = _checkForCollision.call(self, obj)

                    collision && obj.respondToCollision(collision)
                })

                this.movingObjects.forEach(function(obj) {
                    obj.update()
                })

                setTimeout(this.run.bind(this), ANIMATION_DELAY)
            }
        }())
    }

    return Engine
})
