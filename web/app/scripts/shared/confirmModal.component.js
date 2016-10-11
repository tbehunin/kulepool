'use strict';

var ctrl = function () {
    var self = this;

    self.ok = function () {
        console.log('clicked ok');
        self.close();
    };

    self.cancel = function () {
        console.log('clicked cancel');
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