'use strict';

module.exports = ['$filter', '$document', function ($filter, $document) {
    return {
        restrict: 'AE',
        scope: {
            options: '=msfOptions',
            onClose: '&msfOnClose'
        },
        templateUrl: 'views/multiSelectFilter.html',
        link: function ($scope, $element) {
            $scope.toggleDropdown = function () {
                $scope.isOpen = !$scope.isOpen;
            };

            $scope.toggleOption = function (option) {
                option.selected = !option.selected;
            };

            $scope.toggleAll = function (value) {
                $scope.options.forEach(function (option) {
                    option.selected = value;
                });
            };

            $scope.anySelected = function () {
                return $scope.options.some(function (option) {
                    return option.selected;
                });
            };

            $scope.selectionCount = function () {
                return $scope.options.filter(function (option) {
                    return option.selected;
                }).length;
            };

            $scope.getTooltipTitle = function () {
                return $scope.options.filter(function (option) {
                    return option.selected;
                }).map(function (option) {
                    return option.name;
                }).join(', ');
            };

            $scope.allOptionsSelection = function (value) {
                return $scope.options.every(function (option) {
                    return !!option.selected === value;
                });
            };

            var closeHandler = function (event) {
                if ($element[0].contains(event.target)) {
                    event.stopPropagation();
                    $scope.$apply(function () {
                        $scope.onClose();
                    });
                }
                else {
                    $scope.$apply(function () {
                        $scope.isOpen = false;
                    });
                }
            };

            $document.on('click', closeHandler);
        }
    };
}];