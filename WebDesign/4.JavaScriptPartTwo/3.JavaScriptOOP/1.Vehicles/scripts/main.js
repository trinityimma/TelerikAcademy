/*jslint vars: true, devel: true */
/*global define */

define(function (require) {
    'use strict';

    var LandVehicle = require('vehicles/LandVehicle');
    var AirVehicle = require('vehicles/AirVehicle');
    var WaterVehicle = require('vehicles/WaterVehicle');
    var AmphibiousVehicle = require('vehicles/AmphibiousVehicle');

    var Wheel = require('propulsionUnits/Wheel');
    var Propeller = require('propulsionUnits/Propeller');
    var PropellingNozzle = require('propulsionUnits/PropellingNozzle');

    console.group('Land Vehicle');
    (function () {
        var landVehicle = (function() {
            var wheel1 = new Wheel(5);
            var wheel2 = new Wheel(5);
            var wheel3 = new Wheel(5);
            var wheel4 = new Wheel(5);

            return new LandVehicle(wheel1, wheel2, wheel3, wheel4);
        }());

        landVehicle.accelerate();
        console.log(landVehicle.speed);

        landVehicle.accelerate();
        console.log(landVehicle.speed);
    }());
    console.groupEnd();

    console.group('Air Vehicle');
    (function () {
        var airVehicle = new AirVehicle(new PropellingNozzle(50));

        console.group('Afterburner Switch: DOWN');
        (function () {
            airVehicle.accelerate();
            console.log(airVehicle.speed);

            airVehicle.accelerate();
            console.log(airVehicle.speed);
        }());
        console.groupEnd();

        airVehicle.toggleAfterBurner();

        console.group('Afterburner Switch: UP');
        (function () {
            airVehicle.accelerate();
            console.log(airVehicle.speed);

            airVehicle.accelerate();
            console.log(airVehicle.speed);
        }());
        console.groupEnd();
    }());
    console.groupEnd();

    console.group('Water Vehicle');
    (function () {
        var waterVehicle = (function() {
            var propeller1 = new Propeller(20);
            var propeller2 = new Propeller(20);

            return new WaterVehicle(propeller1, propeller2);
        }());

        console.group('Spin Direction: CLOCKWISE');
        (function () {
            waterVehicle.accelerate();
            console.log(waterVehicle.speed);

            waterVehicle.accelerate();
            console.log(waterVehicle.speed);
        }());
        console.groupEnd();

        waterVehicle.togglePropellersSpinDirection();

        console.group('Spin Direction: COUNTERCLOCKWISE');
        (function () {
            waterVehicle.accelerate();
            console.log(waterVehicle.speed);

            waterVehicle.accelerate();
            console.log(waterVehicle.speed);
        }());
        console.groupEnd();
    }());
    console.groupEnd();

    console.group('Amphibious Vehicle');
    (function () {
        var amphibiousVehicle = (function() {
            var propeller1 = new Propeller(20);
            var propeller2 = new Propeller(20);
            var propellers = [propeller1, propeller2];

            var wheel1 = new Wheel(5);
            var wheel2 = new Wheel(5);
            var wheels = [wheel1, wheel2];

            return new AmphibiousVehicle(wheels, propellers);
        }());

        console.group('Propulsion Unit: WHEELS');
        (function () {
            amphibiousVehicle.accelerate();
            console.log(amphibiousVehicle.speed);

            amphibiousVehicle.accelerate();
            console.log(amphibiousVehicle.speed);
        }());
        console.groupEnd();

        amphibiousVehicle.togglePropulsionUnit();

        console.group('Propulsion Unit: PROPELLER');
        (function () {
            console.group('Spin Direction: CLOCKWISE');
            (function () {
                amphibiousVehicle.accelerate();
                console.log(amphibiousVehicle.speed);

                amphibiousVehicle.accelerate();
                console.log(amphibiousVehicle.speed);
            }());
            console.groupEnd();

            amphibiousVehicle.togglePropellersSpinDirection();

            console.group('Spin Direction: COUNTERCLOCKWISE');
            (function () {
                amphibiousVehicle.accelerate();
                console.log(amphibiousVehicle.speed);

                amphibiousVehicle.accelerate();
                console.log(amphibiousVehicle.speed);
            }());
            console.groupEnd();
        }());
        console.groupEnd();
    }());
    console.groupEnd();
});
