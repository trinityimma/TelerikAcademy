define(function(require) {
    'use strict';

    var extend = require('extend')
    var Vehicle = require('./Vehicle')

    function AirVehicle(propellingNozzle) {
        Vehicle.call(this, [propellingNozzle])
    }

    extend(AirVehicle, Vehicle)

    AirVehicle.prototype.toggleAfterBurner = function() {
        this.propulsionUnits.forEach(function(propellingNozzle) {
            propellingNozzle.afterBurnerSwitch.toggle()
        })

        return this
    }

    return AirVehicle
})
