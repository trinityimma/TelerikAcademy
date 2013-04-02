var Solve = (function() {
    'use strict';

    return function(args) {
        args.shift() // N

        var currentSum = 0
          , maxSum = Number.NEGATIVE_INFINITY

        args.forEach(function(el) {
            currentSum = +el + Math.max(currentSum, 0)

            maxSum = Math.max(maxSum, currentSum)
        })

        return maxSum
    }
}())
