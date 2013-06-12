APP = angular.module 'app', []

APP.directive 'colorRange', ->
    require: 'ngModel'

    link: (scope, elm, attrs, ctrl) ->
        elm.attr 'min', 0
        elm.attr 'max', (1 << 24) - 1

        ctrl.$formatters.push ($modelValue) ->
            parseInt($modelValue.substr(1), 16)

        ctrl.$parsers.push ($viewValue) ->
            '#' + _.str.lpad((+$viewValue).toString(16), 6, '0').toUpperCase()

APP.controller 'Ctrl', ($scope) ->
    $scope.color = '#0F0FFF'
