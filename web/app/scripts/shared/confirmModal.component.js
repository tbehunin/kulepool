'use strict';

var ctrl = function () {
    var self = this;

    self.ok = function () {
        self.close();
    };

    self.cancel = function () {
        self.dismiss();
    };
};

module.exports = {
    templateUrl: 'views/confirmModal.html',
    controller: ctrl,
    bindings: {
        resolve: '<',
        close: '&',
        dismiss: '&'
    }
};