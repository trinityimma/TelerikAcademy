define(function() {
    'use strict';

    function _isEmpty(object) {
        return Object.keys(object).length === 0
    }

    function _merge(self, object) {
        var prop

        for (prop in object) {
            if (object.hasOwnProperty(prop)) {
                if (prop !== 'constructor') {
                    self[prop] = object[prop]
                }
            }
        }

        return self
    }

    return function extend(Child, Parent) {
        if (_isEmpty(Child.prototype)) {
            Child.prototype = Object.create(Parent.prototype)
            Child.prototype.parent = Parent.prototype
            Child.prototype.constructor = Child
        } else {
            _merge(Child.prototype, Parent.prototype)
        }
    }
})
