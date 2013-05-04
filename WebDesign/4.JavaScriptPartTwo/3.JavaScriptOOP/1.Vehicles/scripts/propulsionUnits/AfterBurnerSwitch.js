define(function() {
    'use strict';

    function AfterBurnerSwitch() {
        this.isUp = false
    }

    AfterBurnerSwitch.prototype.toggle = function() {
        this.isUp = !this.isUp

        return this
    }

    return AfterBurnerSwitch
})
