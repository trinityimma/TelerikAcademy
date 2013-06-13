APP = angular.module('app', [])

APP.directive 'byte', ->
    require: 'ngModel'

    link: (scope, elm, attrs, ctrl) ->
        elm.attr 'min', 0
        elm.attr 'max', 255

        ctrl.$formatters.push ($modelValue) ->
            parseInt $modelValue, 16

        ctrl.$parsers.push ($viewValue) ->
            _.str.lpad((+$viewValue).toString(16), 2, '0').toUpperCase()

APP.controller 'Ctrl', ($scope) ->
    $scope.r = '00'
    $scope.g = 'FF'
    $scope.b = '00'

    $scope.getBackground = ->
        '#' + $scope.r + $scope.g + $scope.b
