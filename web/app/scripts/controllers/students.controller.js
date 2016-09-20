'use strict';

module.exports = ['$scope', function ($scope) {
  var self = this;

  self.students = [
    {
      selected: false,
      lastName: 'Behunin',
      firstName: 'Ava',
      grade: '7',
      schoolName: 'Meadow Park Middle School',
      eligible: true,
      assignedRoutes: {
        show: false,
        routes: [
          {
            id: 1,
            name: '24: Tucson St'
          },
          {
            id: 2,
            name: '25: York St'
          }
        ]
      }
    },
    {
      selected: false,
      lastName: 'Behunin',
      firstName: 'Eliza',
      grade: '5',
      schoolName: 'Meadow Park Middle School',
      eligible: false,
      assignedRoutes: {
        show: false,
        routes: []
      }
    },
    {
      selected: false,
      lastName: 'Behunin',
      firstName: 'Grant',
      grade: '3',
      schoolName: 'Meadow Park Middle School',
      eligible: true,
      assignedRoutes: {
        show: false,
        routes: [
          {
            id: 2,
            name: '25: York St'
          }
        ]
      }
    }
  ];
  
  self.availableRoutes = [
    { id: 24, name: '24: Tucson St', selected: false },
    { id: 25, name: '25: York St', selected: false }
  ];

  self.availableSchools = [
    { id: 1, name: 'Bethany Elementary', selected: false },
    { id: 2, name: 'Meadow Park Middle School', selected: false }
  ];

  self.availableGrades = [
    { id: 1, name: 'K', selected: false },
    { id: 2, name: '1', selected: false },
    { id: 2, name: '2', selected: false },
    { id: 2, name: '3', selected: false },
    { id: 2, name: '4', selected: false },
    { id: 2, name: '5', selected: false },
    { id: 2, name: '6', selected: false },
    { id: 2, name: '7', selected: false },
    { id: 2, name: '8', selected: false },
    { id: 2, name: '9', selected: false },
    { id: 2, name: '10', selected: false },
    { id: 2, name: '11', selected: false },
    { id: 2, name: '12', selected: false }
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

  self.test = 'dlkfj';

  self.toggle = function () {
    self.open = !self.open;
  };
}];