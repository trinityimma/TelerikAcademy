var Solve = (function() {
    'use strict';

    return function(args) {
        args.shift() // N

        var currentSum = Number.NEGATIVE_INFINITY
          , maxSum = currentSum

        args.forEach(function(el) {
            currentSum = +el + Math.max(currentSum, 0)

            maxSum = Math.max(maxSum, currentSum)
        })

        return maxSum
    }
}())
