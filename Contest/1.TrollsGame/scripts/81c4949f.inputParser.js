(function() {

  GAME.directive('matrix', [
    '$log', '$timeout', function($log, $timeout) {
      return {
        require: 'ngModel',
        link: function(scope, elm, attrs, ctrl) {
          var check, parse, startTimer;
          parse = function($viewValue) {
            var $modelValue, cell, cmd, cols, i, j, max, min, row, rows, startIndex, _i, _j, _k, _len, _len1, _ref;
            if (!$viewValue) {
              return ctrl.$setValidity('required', false);
            }
            if (!angular.isArray($viewValue)) {
              try {
                $modelValue = JSON.parse('[[' + $viewValue.replace(/^\s*/gm, '').replace(/\s*$/gm, '').replace(/\n/g, '],[').replace(/([a-z]+)/g, '"$1"').replace(/\s+/g, ',') + ']]');
              } catch (err) {
                return ctrl.$setValidity('matrix', false);
              }
            } else {
              $modelValue = $viewValue;
            }
            rows = +attrs.matrixRows;
            cols = +attrs.matrixCols;
            min = +attrs.matrixMin;
            max = +attrs.matrixMax;
            cmd = attrs.matrixCommand != null;
            if (!($modelValue.length === rows || cmd && $modelValue.length < rows)) {
              ctrl.errorLength = $modelValue.length;
              ctrl.$setValidity('matrixRows', false);
              return $modelValue;
            }
            for (i = _i = 0, _len = $modelValue.length; _i < _len; i = ++_i) {
              row = $modelValue[i];
              if (row.length !== cols) {
                ctrl.errorRow = i;
                ctrl.errorLength = row.length;
                ctrl.$setValidity('matrixCols', false);
                return $modelValue;
              }
              startIndex = 0;
              if (cmd) {
                startIndex = 1;
                if (!(row[0] === 'put' || row[0] === 'take')) {
                  ctrl.errorRow = i;
                  ctrl.$setValidity('matrixCommand', false);
                  return $modelValue;
                }
              }
            }
            for (i = _j = 0, _len1 = $modelValue.length; _j < _len1; i = ++_j) {
              row = $modelValue[i];
              for (j = _k = startIndex, _ref = row.length; startIndex <= _ref ? _k < _ref : _k > _ref; j = startIndex <= _ref ? ++_k : --_k) {
                cell = row[j];
                if (parseInt(cell, 10) !== cell) {
                  ctrl.errorRow = i;
                  ctrl.errorCol = j;
                  ctrl.errorCell = row[j];
                  ctrl.$setValidity('matrixPattern', false);
                  return $modelValue;
                }
                if (!(cell >= min)) {
                  ctrl.errorRow = i;
                  ctrl.errorCol = j;
                  ctrl.errorCell = cell;
                  ctrl.$setValidity('matrixMin', false);
                  return $modelValue;
                }
                if (!(cell <= max)) {
                  ctrl.errorRow = i;
                  ctrl.errorCol = j;
                  ctrl.errorCell = cell;
                  ctrl.$setValidity('matrixMax', false);
                  return $modelValue;
                }
              }
            }
            return $modelValue;
          };
          check = function($viewValue) {
            var date, value;
            ctrl.parsing = false;
            scope.input.$setValidity("" + ctrl.$name + "Parsing", true);
            if (!scope.input.n.$valid) {
              return;
            }
            date = new Date;
            value = parse($viewValue);
            if (value) {
              $log.log("Parsed " + ctrl.$name + " " + value.length + "*" + value[0].length + " in " + (new Date - date) + "ms.");
            }
            return value;
          };
          startTimer = (function() {
            var checkTimer, validationDelay;
            validationDelay = 400;
            checkTimer = null;
            return function(watch, callback) {
              var key;
              $timeout.cancel(checkTimer);
              for (key in ctrl.$error) {
                ctrl.$setValidity(key, true);
              }
              scope.input.$setValidity("" + ctrl.$name + "Parsing", false);
              ctrl.parsing = watch || true;
              ctrl.$pristine = false;
              if (!watch) {
                scope.$apply();
              }
              return checkTimer = $timeout(callback, validationDelay);
            };
          })();
          scope.$watch('n', function(newVal, oldVal) {
            var wasParsing;
            if (newVal === oldVal) {
              return;
            }
            wasParsing = ctrl.parsing && ctrl.parsing === !'watch';
            return startTimer('watch', function() {
              if (wasParsing || !ctrl.$modelValue) {
                return check(elm.val());
              } else {
                return check(ctrl.$modelValue);
              }
            });
          });
          elm.unbind('input').unbind('keydown').unbind('change').bind('input keydown', function() {
            return startTimer(false, function() {
              return ctrl.$setViewValue(elm.val());
            });
          });
          ctrl.$parsers.push(check);
          return ctrl.$formatters.push(function($modelValue) {
            var row;
            $log.log("Formatting input " + ctrl.$name + ".");
            return ((function() {
              var _i, _len, _results;
              _results = [];
              for (_i = 0, _len = $modelValue.length; _i < _len; _i++) {
                row = $modelValue[_i];
                _results.push(row.join(' '));
              }
              return _results;
            })()).join('\n');
          });
        }
      };
    }
  ]);

}).call(this);
