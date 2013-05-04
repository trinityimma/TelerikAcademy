define(function(require) {
    'use strict';

    var extend = require('extend')
    var PropulsionUnit = require('./PropulsionUnit')

    var spinDirection = {
        CLOCKWISE: 0,
        COUNTERCLOCKWISE: 1
    }

    function Propeller(numberOfFins) {
        PropulsionUnit.call(this)

        this.numberOfFins = numberOfFins

        this.spinDirection = spinDirection.CLOCKWISE
    }

    extend(Propeller, PropulsionUnit)

    Propeller.prototype.produceAcceleration = function() {
        var multiplier = (this.spinDirection === spinDirection.CLOCKWISE) ? 1 : -1

        return multiplier * this.numberOfFins
    }

    Propeller.prototype.toggleDirection = function() {
        var isClockwise = (this.spinDirection === spinDirection.CLOCKWISE)

        this.spinDirection = spinDirection[isClockwise ? 'COUNTERCLOCKWISE' : 'CLOCKWISE']

        return this
    }

    return Propeller
})
