'use strict';

module.exports = ['$filter', '$document', function ($filter, $document) {
    return {
        restrict: 'E',
        scope: {
            name: '=tName',
            onRemove: '&tOnRemove'
        },
        templateUrl: 'views/tag.html',
        link: function ($scope, $element) {
            $scope.tagClick = function ($event) {
                $event.stopPropagation();
            }
            $scope.removeTag = function () {
                $scope.onRemove();
            };
        }
    };
}];