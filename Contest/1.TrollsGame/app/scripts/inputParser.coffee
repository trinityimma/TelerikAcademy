# Custom directive for input validation
GAME.directive 'matrix', [
   '$log', '$timeout',
  ( $log ,  $timeout ) ->
    require: 'ngModel'

    # Link template to scope
    link: (scope, elm, attrs, ctrl) ->
        # Parse can take up to 300ms if we send $viewValue
        parse = ($viewValue) ->
            # Check for empty string
            return ctrl.$setValidity('required', false) unless $viewValue

            # Parse two-dimensional array
            # This is the bottleneck
            unless angular.isArray $viewValue
                try
                    $modelValue = JSON.parse '[[' +
                        $viewValue.
                          replace(/^\s*/gm      , ''      ). # Trim front of line
                          replace(/\s*$/gm      , ''      ). # Trim end of line. Very slow.
                          replace(/\n/g         , '],['   ). # Remove new lines
                          replace(/([a-z]+)/g   , '"$1"'  ). # Make strings
                          replace(/\s+/g        , ','     )+ # Trim middle
                    ']]'
                catch err
                    return ctrl.$setValidity 'matrix', false
            else $modelValue = $viewValue # Nothing changed, use old

            rows  = +attrs.matrixRows
            cols  = +attrs.matrixCols
            min   = +attrs.matrixMin
            max   = +attrs.matrixMax
            cmd   =  attrs.matrixCommand?

            # Check matrix rows
            unless $modelValue.length is rows or cmd and $modelValue.length < rows
                ctrl.errorLength = $modelValue.length
                ctrl.$setValidity 'matrixRows', false
                return $modelValue

            # Check matrix columns
            for row, i in $modelValue
                # Check the number of columns
                unless row.length is cols
                    ctrl.errorRow = i
                    ctrl.errorLength = row.length
                    ctrl.$setValidity 'matrixCols', false
                    return $modelValue

                # Check matrix command if set
                startIndex = 0
                if cmd
                    startIndex = 1
                    unless row[0] is 'put' or row[0] is 'take'
                        ctrl.errorRow = i
                        ctrl.$setValidity 'matrixCommand', false
                        return $modelValue

            # Check each cell
            for row, i in $modelValue
                for j in [startIndex...row.length]
                    cell = row[j]

                    # Check for matrix pattern
                    unless parseInt(cell, 10) is cell
                        ctrl.errorRow = i
                        ctrl.errorCol = j
                        ctrl.errorCell = row[j]
                        ctrl.$setValidity 'matrixPattern', false
                        return $modelValue

                    # Check for matrix min
                    unless cell >= min
                        ctrl.errorRow = i
                        ctrl.errorCol = j
                        ctrl.errorCell = cell
                        ctrl.$setValidity 'matrixMin', false
                        return $modelValue

                    # Check for matrix max
                    unless cell <= max
                        ctrl.errorRow = i
                        ctrl.errorCol = j
                        ctrl.errorCell = cell
                        ctrl.$setValidity 'matrixMax', false
                        return $modelValue

            # Everything is valid
            return $modelValue

        check = ($viewValue) ->
            ctrl.parsing = false
            scope.input.$setValidity "#{ctrl.$name}Parsing", true
            return unless scope.input.n.$valid # Don't try validating with wrong n

            date = new Date
            value = parse $viewValue
            $log.log "Parsed #{ctrl.$name} #{value.length}*#{value[0].length} in #{new Date - date}ms." if value
            return value

        startTimer = do ->
            validationDelay = 400
            checkTimer = null
            (watch, callback) ->
                $timeout.cancel checkTimer # Race condition
                ctrl.$setValidity key, true for key of ctrl.$error # Hide errors
                scope.input.$setValidity "#{ctrl.$name}Parsing", false # Disable form submit
                ctrl.parsing = watch || true
                ctrl.$pristine = false
                scope.$apply() unless watch # Watch calls $digest already
                checkTimer = $timeout callback, validationDelay

        # Watch for changes of n and revalidate field and moves
        scope.$watch 'n', (newVal, oldVal) ->
            return if newVal is oldVal
            wasParsing = ctrl.parsing and ctrl.parsing is not 'watch'
            startTimer 'watch', ->
                if wasParsing or not ctrl.$modelValue
                    check elm.val()
                else check ctrl.$modelValue

        # Validate on keydown, with a little delay
        # Default is ng-model-instant
        elm.unbind('input').unbind('keydown').unbind('change').bind 'input keydown', ->
            startTimer false, ->
                ctrl.$setViewValue elm.val() # Calls parser internally

        # View to model parser
        ctrl.$parsers.push check

        # Model to view formatter
        ctrl.$formatters.push ($modelValue) ->
            $log.log "Formatting input #{ctrl.$name}."
            (row.join(' ') for row in $modelValue).join('\n')
]
