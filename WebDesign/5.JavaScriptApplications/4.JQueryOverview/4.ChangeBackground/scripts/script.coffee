# TODO: Refactor, use watch

_convertNumberToHex = (number) ->
    '#' + _.str.lpad((+number).toString(16), 6, '0').toUpperCase()

@Ctrl = ($scope) ->
    $scope.style =
        background: '#FFFFFF'

    $scope.number = (1 << 24) - 1

    $scope.change = ->
        $scope.style.background = _convertNumberToHex($scope.number)
