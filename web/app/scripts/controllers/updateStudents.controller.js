'use strict';

module.exports = [
  '$stateParams', function ($stateParams) {
  var self = this;
  console.log($stateParams.selectedStudents);
}];