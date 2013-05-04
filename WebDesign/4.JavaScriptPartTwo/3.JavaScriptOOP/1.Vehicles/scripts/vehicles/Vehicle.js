define(function(require) {
    'use strict';

    var utils = require('utils')

    function Vehicle(propulsionUnits) {
        this.propulsionUnits = propulsionUnits

        this.speed = 0
    }

    Vehicle.prototype.accelerate = function() {
        this.speed += utils.sum(this.propulsionUnits, function(unit) {
            return unit.produceAcceleration()
        })
    }

    return Vehicle
})
