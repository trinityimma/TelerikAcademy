'use strict';

function inherit(base) {
    this.prototype = new base()
    this.constructor = this

    // var prop

    //for (prop in object)
    //    if (object.hasOwnProperty(prop))
    //        this[prop] = object[prop]

    // return this
}


function circleArea(radius) {
    return 2 * Math.PI * radius;
}

function Vehicle(speed, propulsionUnit) {
    this.speed = speed
    this.propulsionUnit = propulsionUnit
}

Vehicle.prototype.accelerate = function() {
    this.speed += this.propulsionUnit.produceAcceleration()
}

function LandVehicle(wheels) {
    this.wheels = wheels
}

LandVehicle.prototype.accelerate = function() {
    var firstWheel = this.wheels[0]
      , accelerationPerWheel = firstWheel.produceAcceleration()

    return accelerationPerWheel * this.wheels.length
}

function AirVehicle(propellingNozzle) {
    this.propellingNozzle = propellingNozzle
}

AirVehicle.prototype.ToggleAfterBurner = function() {
    return this.propellingNozzle.toggleSwitch()
}

function WaterVehicle(propellers) {
    this.propellers = propellers
}

WaterVehicle.prototype.toggleDirection = function() {
    this.propellers.forEach(function(propeller) {
        propeller.toggleDirection()
    })
}

function AmphibiousVehicle(propeller, wheels) {
    this.propeller = propeller
    this.wheels = wheels
}

AmphibiousVehicle.prototype.

(function() {
    var extendedVehicles = [LandVehicle, AirVehicle, WaterVehicle, AmphibiousVehicle]

    extendedVehicles.forEach(function(ExtendedVehicle) {
        inherit.call(ExtendedVehicle, Vehicle)
    })
}())

function PropulsionUnit(acceleration) {
    this.acceleration = acceleration
}

function Wheel(radius) {
    this.radius = radius
}

Wheel.prototype.produceAcceleration = function() {
    return circleArea(this.radius)
}

function PropellingNozzle(power, isSwitchOn) {
    this.power = power
    this.isSwitchOn = isSwitchOn
}

PropellingNozzle.prototype.produceAcceleration = function() {
    var multiplier = (this.afterBurnerSwitch == null) ? 1 : 2

    return multiplier * this.power
}

PropellingNozzle.prototype.toggleSwitch = function() {
    return this.afterBurnerSwitch = !this.afterBurnerSwitch
}

function Propeller(numberOfFins, isClockWise) {
    this.numberOfFins = numberOfFins
    this.isClockWise = isClockWise
}

Propeller.prototype.produceAcceleration = function() {
    var multiplier = this.spinDirection ? 1 : -1

    return multiplier * this.numberOfFins
}

Propeller.prototype.toggleDirection = function() {
    this.isClockWise = !this.isClockWise
}

(function() {
    var extendededPropulsionUnits = [Wheel, PropellingNozzle, Propeller]

    extendededPropulsionUnits.forEach(function(ExtendedPropulsionUnit) {
        inherit.call(ExtendedPropulsionUnit, PropulsionUnit)
    })
}())
