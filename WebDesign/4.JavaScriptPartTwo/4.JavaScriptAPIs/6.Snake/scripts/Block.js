define(function(require) {
    'use strict';

    var utils = require('utils')
    var GameObject = require('GameObject')

    function Block(position) {
        GameObject.call(this, [[ true ]], position)
    }

    utils.inherit(Block, GameObject)

    return Block
})
