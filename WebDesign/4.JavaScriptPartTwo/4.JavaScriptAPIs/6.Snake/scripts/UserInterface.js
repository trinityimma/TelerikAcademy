var userInterface = (function() {
    var _input

    var _keyMap =
        { 37: 'left'
        , 38: 'up'
        , 39: 'right'
        , 40: 'down'
    }

    return {
        init: function(element) {
            // TODO: Add listener to element
            window.addEventListener('keydown', function(e) {
                _input = _keyMap[e.which]
            })
        },

        processInput: function() {
            var result = _input
            _input = void 0
            return result
        }
    }
}())
