/*jslint vars: true */
/*global define */

define(function () {
    'use strict';

    function isEmpty(object) {
        return Object.keys(object).length === 0;
    }

    function merge(self, object) {
        var prop;

        for (prop in object) {
            if (object.hasOwnProperty(prop)) {
                if (prop !== 'constructor') {
                    self[prop] = object[prop];
                }
            }
        }

        return self;
    }

    return function extend(Child, Parent) {
        if (isEmpty(Child.prototype)) {
            Child.prototype = Object.create(Parent.prototype);
            Child.prototype.parent = Parent.prototype;
            Child.prototype.constructor = Child;
        } else {
            merge(Child.prototype, Parent.prototype);
        }
    };
});
