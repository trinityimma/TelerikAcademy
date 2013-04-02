console.debug    = console.debug    || function() { }
console.group    = console.group    || function() { }
console.groupEnd = console.groupEnd || function() { }

var Solve = (function() {
    'use strict';

    var vars = { }

      , commands =
            { sum: function(arr) {
                return arr.reduce(function(a, b) {
                    return a + b
                })
            }

            , min: function(arr) {
                return Math.min.apply(Math, arr)
            }

            , max: function(arr) {
                return Math.max.apply(Math, arr)
            }

            , avg: function(arr) {
                return parseInt(commands.sum(arr) / arr.length, 10)
            }

            , make: function(arr) {
                return arr
            }
        }

    function addRange(arr, els) {
        els.forEach(function(el) {
            arr.push(el)
        })
    }

    function executeCommand(name, cmd, list) {
        console.debug('NAME:', name, 'CMD:', cmd, 'LIST', list)

        if (!(cmd in commands))
            return console.error('INVALID CMD:', cmd)

        var result = []

        try {
            list.forEach(function(el) {
                if (!isNaN(+el)) result.push(+el)

                else if (el in vars) addRange(result, vars[el])

                else throw new Error(el)
            })
        }

        catch (e) {
            return console.error('INVALID ELEMENT:', e.message)
        }

        vars[name] = cmd !== 'make' && [commands[cmd](result)] || result

        console.debug('RESULT:', vars[name])
    }

    function parseCommand(command) {
        // Last command
        if (!command.match(/^\s*def/))
            command = 'def __result__ ' + command

        console.group(command)

        try {
            var match = command.match(/^\s*def\s*(\S*)\s*(\S*)\s*\[\s*(.+?)\s*\]/)

            if (!match) throw new Error('INVALID COMMAND')

            console.debug('P1:', match[1], 'P2:', match[2], 'P3:', match[3])

            executeCommand(match[1], match[2] || 'make', match[3].split(/\s*,\s*/))
        }

        catch (e) {
            console.error(e.message)
        }

        console.groupEnd()
    }

    return function(args) {
        while (args.length) {
            parseCommand(args.shift())

            if (vars['__result__']) return vars['__result__'][0]
        }
    }
}())
