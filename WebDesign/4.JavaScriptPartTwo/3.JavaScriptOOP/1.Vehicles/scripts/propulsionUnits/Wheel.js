define(function(require) {
    'use strict';

    var utils = require('utils')
    var extend = require('extend')
    var PropulsionUnit = require('./PropulsionUnit')

    function Wheel(radius) {
        PropulsionUnit.call(this)

        this.radius = radius
    }

    extend(Wheel, PropulsionUnit)

    Wheel.prototype.produceAcceleration = function() {
        return utils.math.circle.perimeter(this.radius)
    }

    return Wheel
})
