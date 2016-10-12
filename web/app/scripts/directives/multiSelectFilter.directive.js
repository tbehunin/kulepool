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

            $scope.toggleAll = function () {
                var selected = !$scope.allSelected();
                $scope.options.forEach(function (option) {
                    option.selected = selected;
                });
            };

            $scope.noneSelected = function () {
                return $scope.selectionCount() === 0;
            };

            $scope.someNotAllSelected = function () {
                var selectionCount = $scope.selectionCount();
                return selectionCount > 0 && selectionCount < $scope.options.length;
            };

            $scope.allSelected = function () {
                return $scope.selectionCount() === $scope.options.length;
            };

            $scope.anySelected = function () {
                return $scope.selectionCount() > 0;
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