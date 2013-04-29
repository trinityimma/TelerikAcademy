define(function(require) {
    'use strict';

    var KEY_MAP =
        { 37: 'left'
        , 38: 'up'
        , 39: 'right'
        , 40: 'down'
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
