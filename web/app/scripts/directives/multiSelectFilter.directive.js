'use strict';

module.exports = ['$filter', '$document', function ($filter, $document) {
    return {
        restrict: 'AE',
        scope: {
            options: '=msfOptions'
        },
        templateUrl: 'views/multiSelectFilter.html',
        link: function ($scope, $element) {
            $scope.toggleDropdown = function () {
                $scope.isOpen = !$scope.isOpen;
            };

            $scope.toggleOption = function (option) {
                option.selected = !option.selected;
            }

            var closeHandler = function (event) {
                if (!$element[0].contains(event.target)) {
                    $scope.$apply(function () {
                        $scope.isOpen = false;
                    });
                }
            };

            $document.on('click', closeHandler);
        }
    };
}];