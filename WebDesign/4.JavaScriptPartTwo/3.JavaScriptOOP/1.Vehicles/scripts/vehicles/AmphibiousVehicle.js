/*jslint vars: true */
/*global define */

define(function (require) {
    'use strict';

    var extend = require('extend');
    var Vehicle = require('./Vehicle');
    var LandVehicle = require('./LandVehicle');
    var WaterVehicle = require('./WaterVehicle');

    function AmphibiousVehicle(wheels, propellers) {
        Vehicle.call(this, wheels); // Starts in land mode

        this.wheels = wheels;
        this.propellers = propellers;
    }

    extend(AmphibiousVehicle, Vehicle);
    extend(AmphibiousVehicle, LandVehicle);
    extend(AmphibiousVehicle, WaterVehicle);

    AmphibiousVehicle.prototype.togglePropulsionUnit = function () {
        var isWheels = (this.propulsionUnits === this.wheels);

        this.propulsionUnits = isWheels ? this.propellers : this.wheels;

        return this;
    };

    return AmphibiousVehicle;
});
