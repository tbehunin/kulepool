'use strict';

module.exports = [
  '$scope', '$state', 'studentsService', 'availableStudents', 'availableRoutes', 'availableSchools', 'availableGrades', 'availableTags', function ($scope, $state, studentsService, availableStudents, availableRoutes, availableSchools, availableGrades, availableTags) {
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
    var selected = !self.allSelected();
    self.students.forEach(function (item) {
      item.selected = selected;
    });
  };
  
  self.selectStudent = function (student) {
    student.selected = !student.selected;
  };

  self.noneSelected = function () {
    return self.selectionCount() === 0;
  };

  self.someNotAllSelected = function () {
    var selectionCount = self.selectionCount();
    return selectionCount > 0 && selectionCount < self.students.length;
  };

  self.allSelected = function () {
    return self.selectionCount() === self.students.length;
  };

  self.anySelected = function () {
    return self.selectionCount() > 0;
  };

  self.selectionCount = function () {
    return self.students.filter(function (option) {
        return !!option.selected;
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
  self.removeTag = function (tag, student) {
    studentsService.removeTag(tag, student).then(function () {
      self.filterStudents();
    });
  };

  self.toggle = function () {
    self.open = !self.open;
  };

  self.updateStudents = function () {
    $state.go('updateStudents', {
      selectedStudents: self.students.filter(function (student) {
        return student.selected;
      })
    });
  };
}];