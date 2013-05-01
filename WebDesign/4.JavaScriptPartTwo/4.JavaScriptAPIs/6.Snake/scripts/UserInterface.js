define(function(require) {
    'use strict';

    var KEY_MAP =
        { 37: 'LEFT'
        , 38: 'UP'
        , 39: 'RIGHT'
        , 40: 'DOWN'
    }

    function UserInterface(element) {
        var self = this

        this.input = null

        // TODO: Add listener to element
        window.addEventListener('keydown', function(e) {
            self.input = KEY_MAP[e.which]
        })
    }

    UserInterface.prototype =
        { processInput: function() {
            var result = this.input
            this.input = null
            return result
        }
    }

    return UserInterface
})
