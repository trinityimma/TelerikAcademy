/*jslint vars: true */
/*global define */

define(function (require) {
    'use strict';

    var extend = require('extend');
    var Vehicle = require('./Vehicle');

    function WaterVehicle() {
        var propellers = Array.prototype.slice.call(arguments);

        Vehicle.call(this, propellers);
    }

    extend(WaterVehicle, Vehicle);

    WaterVehicle.prototype.togglePropellersSpinDirection = function () {
        this.propulsionUnits.forEach(function (propeller) {
            propeller.toggleDirection();
        });

        return this;
    };

    return WaterVehicle;
});
