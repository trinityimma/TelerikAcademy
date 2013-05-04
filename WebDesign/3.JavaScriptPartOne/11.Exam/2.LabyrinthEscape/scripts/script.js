console.debug = console.debug || function() { }

var Solve = (function() {
    'use strict';

    var N, M

      , R, C

      , matrix

      , directions = { d: [1, 0], r: [0, 1], u: [-1, 0], l: [0, -1] }

    function getValue(row, col) {
        return row * M + col + 1
    }

    function isInside(row, col) {
        return 0 <= row && row < N &&
               0 <= col && col < M
    }

    function visit(row, col) {
        matrix[row][col] = 'X'
    }

    function isVisited(row, col) {
        return matrix[row][col] === 'X'
    }

    function traverse() {
        var row = R
          , col = C

          , sum = 0
          , length = 0

          , direction

        while (true) {
            console.debug('ROW:', row, 'COL:', col, 'SUM:', sum, 'LENGTH:', length)

            if (!isInside(row, col))
                return 'out ' + sum

            if (isVisited(row, col))
                return 'lost ' + length

            length++
            sum += getValue(row, col)

            // In this order
            direction = directions[matrix[row][col]]
            visit(row, col)

            row += direction[0]
            col += direction[1]
        }
    }

    return function(args) {
        var splitted

        splitted = args.shift().split(' ')
        N = +splitted[0]
        M = +splitted[1]

        splitted = args.shift().split(' ')
        R = +splitted[0]
        C = +splitted[1]

        matrix = args.map(function(row) {
            return row.split('')
        })

        return traverse()
    }
}())
