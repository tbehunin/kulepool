'use strict';

module.exports = [function () {
    return {
        restrict: 'E',
        scope: {
            name: '=tName',
            onRemove: '&tOnRemove'
        },
        templateUrl: 'views/tag.html',
        link: function ($scope) {
            $scope.tagClick = function ($event) {
                $event.stopPropagation();
            };
            $scope.removeTag = function () {
                $scope.onRemove();
            };
        }
    };
}];