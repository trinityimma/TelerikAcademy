var Solve = (function() {
    'use strict';

    return function(args) {
        args.shift() // N

        var arr = args.map(function(n) {
            return +n
        })

          , currentSum = arr[0]
          , maxSum = currentSum

          , i

        for (i = 1; i < arr.length; i++) {
            currentSum = Math.max(0, currentSum) + arr[i]

            maxSum = Math.max(currentSum, maxSum)
        }

        return maxSum
    }
}())
