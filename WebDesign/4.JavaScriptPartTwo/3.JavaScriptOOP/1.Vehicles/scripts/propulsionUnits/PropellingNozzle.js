/*jslint vars: true */
/*global define */

define(function (require) {
    'use strict';

    var extend = require('extend');
    var PropulsionUnit = require('./PropulsionUnit');
    var AfterBurnerSwitch = require('./AfterBurnerSwitch');

    function PropellingNozzle(power) {
        PropulsionUnit.call(this);

        this.power = power;
        this.afterBurnerSwitch = new AfterBurnerSwitch();
    }

    extend(PropellingNozzle, PropulsionUnit);

    PropellingNozzle.prototype.produceAcceleration = function () {
        var multiplier = this.afterBurnerSwitch.isUp ? 2 : 1;

        return multiplier * this.power;
    };

    return PropellingNozzle;
});
