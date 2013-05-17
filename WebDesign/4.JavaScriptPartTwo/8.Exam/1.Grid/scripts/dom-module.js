/*jshint laxcomma: true, asi: true, curly: false, eqnull: true, bitwise: false, browser: true */

// # J library

this.J = (function() {
/*jshint validthis: true */

'use strict';

// ## Constructor

var J = (function() {
    var _voidTag = /^<(\w+) \/>$/

    function _defaultCtor() {
        void 0
    }

    function _createHtmlElementCtor(voidTag) {
        var tagName = voidTag.match(_voidTag)[1]

          , htmlElement = document.createElement(tagName)

        _htmlElementCtor.call(this, htmlElement)
    }

    function _htmlElementCtor(htmlElement) {
        _arrayOfObjectsCtor.call(this, [htmlElement])
    }

    function _arrayOfObjectsCtor(objects) {
        J.merge(this, objects)
    }

    function _selectorCtor(selector, context) {
        var self = this

        context = context || [document]

        J.each(context, function() {
            _arrayOfObjectsCtor.call(self, this.querySelectorAll(selector))
        })
    }

    return function(selector, context) {
        if (!(this instanceof J))
            return new J(selector, context)

        this.length = 0

        if (selector == null)
            _defaultCtor.call(this)

        else if (_voidTag.test(selector))
            _createHtmlElementCtor.call(this, selector)

        else if (selector instanceof HTMLElement)
            _htmlElementCtor.call(this, selector)

        else if (Array.isArray(selector))
            _arrayOfObjectsCtor.call(this, selector)

        else _selectorCtor.call(this, selector, context)
    }
}())

// ## Static Methods

// ### Array-like and Object Manipulation
!(function() {
    function _isArrayLike() {
        return 'length' in this
    }

    function _initialize() {
        return _isArrayLike.call(this) ? [] : {}
    }

    // TODO: Check only once and not on each iteration
    function _insert(property, value) {
        return _isArrayLike.call(this) ?
            this.push(value) :
            this[property] = value
    }

    J.each = (function() {
        function _eachArray(callback) {
            var i

            for (i = 0; i < this.length; i++)
                if (callback.call(this[i], i) === false)
                    break

            return this
        }

        function _eachObject(callback) {
            var i

            for (i in this)
                if (this.hasOwnProperty(i))
                    if (callback.call(this[i], i) === false)
                        break

            return this
        }

        return function(object, callback) {
            return _isArrayLike.call(object) ?
                _eachArray.call(object, callback) :
                _eachObject.call(object, callback)
        }
    }())

    J.map =
    J.select = function(object, callback) {
        var result = _initialize.call(object)

        J.each(object, function(i) {
            var mapped = callback.call(this, i)

            _insert.call(result, i, mapped)
        })

        return result
    }

    // #### Filter/Reject & Any/All
    ;(function() {
        function _invertPredicate(callback) {
            return function() {
                return !callback.apply(this, arguments)
            }
        }

        J.filter =
        J.where = function(object, callback) {
            var result = _initialize.call(object)

            J.each(object, function(i) {
                if (callback.call(this, i))
                    _insert.call(result, i, this)
            })

            return result
        }

        J.reject = function(object, callback) {
            return J.filter(object, _invertPredicate(callback))
        }

        J.any =
        J.some = function(object, callback) {
            var result = false

            J.each(object, function(i) {
                if (callback.call(this, i)) {
                    result = true

                    return false
                }
            })

            return result
        }

        J.all =
        J.every = function(object, callback) {
            return !J.any(object, _invertPredicate(callback))
        }
    }())

    J.uniq = function(object) {
        var result = _initialize.call(object)

        J.each(object, function(i) {
            if (!J.contains(result, this))
               _insert.call(result, i, this)
        })

        return result
    }

    J.merge = function(object, elements) {
        J.each(elements, function(i) {
            _insert.call(object, i, this)
        })

        return object
    }
}())

J.contains = function(object, element) {
    return J.any(object, function() {
        return this === element
    })
}

J.range = function(min, maxInclusive) {
    if (arguments.length === 1) return J.range(0, min)

    var result = new Array(maxInclusive - min + 1)

    return J.each(result, function(i) {
        result[i] = min + i
    })
}

J.toArray = function(object) {
    return J.map(object, function() {
        return this
    })
}

// ### Random Generators

J.random = function(min, maxInclusive) {
    if (arguments.length === 1) return J.random(0, min)

    var possibleNumbers = maxInclusive - min + 1

    return min + Math.floor(Math.random() * possibleNumbers)
}

// ### Elements manipulation
;(function() {
    J.prototype.push = function(element) {
        return this[this.length++] = element
    }

    J.prototype.get = function(index) {
        return arguments.length === 0 ?
            J.toArray(this) :
            this[index]
    }

    J.prototype.size = function() {
        return this.length
    }
}())

// ## Prototype

// ### Elements higher-order functions

// Example: J.prototype.filter(callback) = J.filter(this, callback)
;(function() {
    function _extendProto(methodNames, resultFunction) {
        J.each(methodNames, function() {
            var methodName = this

            J.prototype[methodName] = function() {
                var methodArguments = J.merge([this], arguments)

                  , returnedValue = J[methodName].apply(this, methodArguments)

                return resultFunction.call(this, returnedValue)
            }
        })
    }

    ;(function() {
        var methodNames = ['each', 'map', 'select', 'any', 'some', 'all', 'every']

        _extendProto(methodNames, function(returnedValue) {
            return returnedValue
        })
    }())

    ;(function() {
        var methodNames = ['filter', 'where', 'reject']

        _extendProto(methodNames, function(returnedValue) {
            return new J(returnedValue)
        })
    }())
}())

// ### Events
;(function() {
    ;(function() {
        var _events =
            [ 'blur', 'focus', 'focusin', 'focusout', 'load', 'resize', 'scroll', 'unload', 'click', 'dblclick'
            , 'mousedown', 'mouseup', 'mousemove', 'mouseover', 'mouseout', 'change', 'select', 'submit', 'keydown'
            , 'keypress', 'keyup', 'error', 'contextmenu'
        ]

        J.each(_events, function() {
            var event = this

            J.prototype[event] = function() {
                var methodArguments = J.merge([event], arguments)

                return J.prototype.on.apply(this, methodArguments)
            }
        })
    }())

    J.prototype.on = function(event, callback) {
        return this.each(function() {
            this.addEventListener(event, callback)
        })
    }
}())

// ### DOM Manipulation
;(function() {

    // Example: body.append(div) = div.appendTo(body)
    ;(function() {
        var pairedMethods =
            { 'prepend': 'prependTo'
            , 'append' : 'appendTo'

            , 'before': 'insertBefore'
            , 'after' : 'insertAfter'
        }

        J.each(pairedMethods, function(implementedMethod) {
            J.prototype[this] = function(elements) {
                elements[implementedMethod](this)

                return this
            }
        })
    }())

    ;(function() {
        function _eachEach(elements, callback) {
            return this.each(function() {
                var parentElement = this

                elements.each(function() {
                    callback.call(parentElement, this) // Chrome bug: .cloneNode(true)
                })
            })
        }

        J.prototype.prepend = function(elements) {
            return _eachEach.call(this, elements, function(newElement) {
                this.insertBefore(newElement, this.firstChild)
            })
        }

        J.prototype.append = function(elements) {
            return _eachEach.call(this, elements, function(newElement) {
                this.appendChild(newElement)
            })
        }

        J.prototype.before = function(elements) {
            return _eachEach.call(this, elements, function(newElement) {
                this.parentNode.insertBefore(newElement, this)
            })
        }

        J.prototype.after = function(elements) {
            return _eachEach.call(this, elements, function(newElement) {
                this.parentNode.insertBefore(newElement, this.nextElementSibling)
            })
        }
    }())

    ;(function() {
        function _filteredMap(callback) {
            var result = J.map(this, function() {
                return callback.call(this)
            })

            return J.reject(result, function() {
                return this === null
            })
        }

        J.prototype.prev = function() {
            var result = _filteredMap.call(this, function() {
                return this.previousElementSibling
            })

            return new J(result)
        }

        J.prototype.next = function() {
            var result = _filteredMap.call(this, function() {
                return this.nextElementSibling
            })

            return new J(result)
        }

        J.prototype.parent = function() {
            var result = _filteredMap.call(this, function() {
                return this.parentNode
            })

            result = J.uniq(result)

            return new J(result)
        }

        J.prototype.children = function() {
            var result = []

            J.each(this, function() {
                J.merge(result, this.children)
            })

            return new J(result)
        }
    }())

    J.prototype.remove = function() {
        return this.each(function() {
            this.parentNode.removeChild(this)
        })
    }
}())

// ### Attributes
;(function() {
    function _getAttribute(attribute) {
        var firstElement = this[0]

        return firstElement.getAttribute(attribute)
    }

    function _setAttribute(attribute, value) {
        return this.each(function() {
            this.setAttribute(attribute, value)
        })
    }

    function _removeAttribute(attribute) {
        return this.each(function() {
            this.removeAttribute(attribute)
        })
    }

    J.prototype.attr = function(attribute, value) {
        return arguments.length === 1 ?
            _getAttribute.call(this, attribute) :
            _setAttribute.call(this, attribute, value)
    }

    J.prototype.removeAttr = function(attribute) {
        _removeAttribute.call(this, attribute)
    }
}())

// ### Classes
;(function() {
    J.prototype.hasClass = function(className) {
        return this.any(function() {
            return this.classList.contains(className)
        })
    }

    J.prototype.addClass = function(className) {
        return this.each(function() {
            this.classList.add(className)
        })
    }

    J.prototype.removeClass = function(className) {
        return this.each(function() {
            this.classList.remove(className)
        })
    }

    J.prototype.toggleClass = function(className) {
        return this.each(function() {
            this.classList.toggle(className)
        })
    }
}())

// ### CSS Properties
;(function() {
    function _getCss(property) {
        var firstElement = this[0]

        return getComputedStyle(firstElement)[property]
    }

    function _setCss(property, value) {
        return this.each(function() {
            this.style[property] = value
        })
    }

    J.prototype.css = function(camelCasedProperty, value) {

        return arguments.length === 1 ?
            _getCss.call(this, camelCasedProperty) :
            _setCss.call(this, camelCasedProperty, value)
    }
}())

// ### Show/hide
;(function() {
    function _isHidden() {
        return this.css('display') === 'none'
    }

    // **TODO**: Restore the original display (`inline, table ...`).
    function _showHide(show) {
        return this.css('display', show ? 'block' : 'none')
    }

    J.prototype.show = function() {
       return _showHide.call(this, true)
    }

    J.prototype.hide = function() {
        return _showHide.call(this, false)
    }

    J.prototype.toggle = function() {
        return this.each(function() {
            var self = new J(this)

            _showHide.call(self, _isHidden.call(self))
        })
    }
}())

// ### Text
;(function() {
    function _getText() {
        var firstElement = this[0]

        return firstElement.textContent
    }

    function _setText(text) {
        return this.each(function() {
            this.textContent = text
        })
    }

    J.prototype.text = function(text) {
        return arguments.length === 0 ?
            _getText.call(this) :
            _setText.call(this, text)
    }
}())

return J
}())
