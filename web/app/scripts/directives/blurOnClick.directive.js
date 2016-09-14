'use strict';

module.exports = [function () {
    return {
        restrict: 'A',
        link: function (scope, element) {
            element.on('click', function () {
                element[0].blur();
            });
        }
    };
}];