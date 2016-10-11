'use strict';

var ctrl = ['modalService', function (modalService) {
    var self = this;

    self.removeTag = function () {
        var modalText = {
            title: 'Remove Tag',
            body: 'Are you sure you want to remove the \'' + self.data.tagName + '\' tag from \'' + self.data.objectName + '\'?'
        };
        modalService.openConfirmModal(modalText).then(function () {
            self.onRemove();
        });
    };
}];

module.exports = {
    templateUrl: 'views/tag.html',
    controller: ctrl,
    controllerAs: '$ctrl',
    bindings: {
        data: '=tcData',
        onRemove: '&tcOnRemove'
    }
};