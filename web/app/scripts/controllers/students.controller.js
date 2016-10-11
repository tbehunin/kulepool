'use strict';

module.exports = [
  '$scope', 'studentsService', 'availableStudents', 'availableRoutes', 'availableSchools', 'availableGrades', 'availableTags', function ($scope, studentsService, availableStudents, availableRoutes, availableSchools, availableGrades, availableTags) {
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
  self.availableTags = availableTags;

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
      tags: getSelectedIds(self.availableTags),
      sort: currentSort
    }).then(function (data) {
      self.students = data;
    });
  };

  self.sort = function (col) {
    currentSort = {col: col, desc: currentSort.col === col ? !currentSort.desc : false};
    self.filterStudents();
  };

  self.isCurrentSort = function (col, desc) {
    return currentSort.col === col && (desc === undefined || currentSort.desc === desc);
  };

  self.test = 'dlkfj';
  self.deleteTag = function (tag, student) {
    // todo
  };

  self.toggle = function () {
    self.open = !self.open;
  };
}];