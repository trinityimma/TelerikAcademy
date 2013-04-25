/*jslint vars: true */
/*global define */

define(function (require) {
    'use strict';

    var extend = require('extend');
    var Vehicle = require('./Vehicle');

    function LandVehicle(wheel1, wheel2, wheel3, wheel4) {
        Vehicle.call(this, [wheel1, wheel2, wheel3, wheel4]);
    }

    extend(LandVehicle, Vehicle);

    return LandVehicle;
});
