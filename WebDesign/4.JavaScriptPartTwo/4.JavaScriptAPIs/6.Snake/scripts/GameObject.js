define(function() {
    'use strict';

    function noop() {

    }

    function GameObject(image, position, color) {
        this.image = image
        this.position = position
        this.color = color
    }

    GameObject.prototype =
        { get rows() {
            return this.image.length
        }

        , get cols() {
            return this.image[0].length
        }

        , update: noop

        , respondToCollision: noop
    }

    return GameObject
})
