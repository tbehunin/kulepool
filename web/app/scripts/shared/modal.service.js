'use strict';

module.exports = ['$uibModal', function ($uibModal) {
  var self = this;

  self.openConfirmModal = function (textData) {
    var options = {
      animation: true,
      component: 'confirmModalComponent',
      resolve: {
        modalText: textData
      }
    };
    var modal = $uibModal.open(options);

    return modal.result;
  };
}];