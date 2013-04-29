define(function() {
    'use strict';

    function Point(row, col) {
        if (!(this instanceof Point))
            return new Point(row, col)

        this.row = row || 0
        this.col = col || 0
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

    Point.prototype =
        { invert: function() {
            this.row = -this.row
            this.col = -this.col

            return this
        }

        , equals: function(other) {
            return this.row === other.row &&
                   this.col === other.col
        }
    }

    return Point
})
