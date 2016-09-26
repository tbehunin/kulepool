'use strict';

module.exports = [
  '$scope', 'studentsService', 'availableStudents', 'availableRoutes', 'availableSchools', 'availableGrades', function ($scope, studentsService, availableStudents, availableRoutes, availableSchools, availableGrades) {
  var self = this;

  self.students = availableStudents;
  self.availableRoutes = availableRoutes;
  self.availableSchools = availableSchools;
  self.availableGrades = availableGrades;

  self.toggleAllStudents = function () {
    self.students.forEach(function (item) {
      item.selected = !!self.selectAllChecked;
    });
  };
  
  self.selectStudent = function (student) {
    student.selected = !student.selected;
  };

  self.getSelectedStudentCount = function () {
    return self.students.filter(function (item) {
      return item.selected;
    }).length;
  };

  self.hideAllPopups = function () {
    self.students.forEach(function (student) {
      student.assignedRoutes.show = false;
    });
  };

  self.test = 'dlkfj';

  self.toggle = function () {
    self.open = !self.open;
  };
}];