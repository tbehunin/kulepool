'use strict';

module.exports = ['$scope', function ($scope) {
  var self = this;
  self.students = [
    {
      selected: false,
      lastName: 'Behunin',
      firstName: 'Ava',
      grade: '7',
      schoolName: 'Meadow Park Middle School'},
    {
      selected: false,
      lastName: 'Behunin',
      firstName: 'Eliza',
      grade: '5',
      schoolName: 'Meadow Park Middle School'},
    {
      selected: false,
      lastName: 'Behunin',
      firstName: 'Grant',
      grade: '3',
      schoolName: 'Meadow Park Middle School'}];
  
  self.select = function(student) {
    student.selected = !student.selected;
  };
}];