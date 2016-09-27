'use strict';

module.exports = [
  '$scope', 'studentsService', 'availableStudents', 'availableRoutes', 'availableSchools', 'availableGrades', function ($scope, studentsService, availableStudents, availableRoutes, availableSchools, availableGrades) {
  var self = this;
  var currentSort = {};

  function getSelectedIds(list) {
    return list.filter(function (item) {
      return item.selected;
    }).map(function (item) {
      return item.id || item.value;
    });
  }

  self.students = availableStudents;
  self.availableRoutes = availableRoutes;
  self.availableSchools = availableSchools;
  self.availableGrades = availableGrades;
  self.availableEligibility = [
    { name: 'Eligible', value: true, selected: false },
    { name: 'Ineligible', value: false, selected: false }
  ];

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

  self.filterStudents = function () {
    studentsService.getStudents({
      schools: getSelectedIds(self.availableSchools),
      grades: getSelectedIds(self.availableGrades),
      eligibility: getSelectedIds(self.availableEligibility),
      sort: currentSort
    }).then(function (data) {
      self.students = data;
    });
  };

  self.sort = function (col) {
    var desc = currentSort.col === col ? !currentSort.desc : false;
    currentSort = {col = col, desc: desc};
    self.filterStudents();
  };

  self.test = 'dlkfj';

  self.toggle = function () {
    self.open = !self.open;
  };
}];