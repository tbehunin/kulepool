'use strict';

var ctrl = ['modalService', function (modalService) {
    var self = this;

    self.deleteTag = function () {
        var modalText = {
            title: 'Confirm Delete',
            body: 'Are you sure you want to delete tag \'' + self.data.tagName + '\' from \'' + self.data.objectName + '\'?'
        };
        modalService.openConfirmModal(modalText).then(function () {
            self.onDelete();
        });
    };
}];

module.exports = {
    templateUrl: 'views/tag.html',
    controller: ctrl,
    controllerAs: '$ctrl',
    bindings: {
        data: '=tcData',
        onDelete: '&tcOnDelete'
    }
};