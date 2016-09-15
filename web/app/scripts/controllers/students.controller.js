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
    },
    {
      selected: false,
      lastName: 'Behunin',
      firstName: 'Eliza',
      grade: '5',
      schoolName: 'Meadow Park Middle School',
      eligible: false,
      routes: []
    },
    {
      selected: false,
      lastName: 'Behunin',
      firstName: 'Grant',
      grade: '3',
      schoolName: 'Meadow Park Middle School',
      eligible: true,
      routes: [
        {
          id: 2,
          name: '25: York St'
        }
      ]
    }
  ];
  
  self.availableRoutes = [
    { id: 24, name: '24: Tucson St' },
    { id: 25, name: '25: York St' }
  ];

  self.availableSchools = [
    { id: 1, name: 'Bethany Elementary' },
    { id: 2, name: 'Meadow Park Middle School' }
  ];

  self.availableGrades = [
    { id: 1, name: 'K' },
    { id: 2, name: '1' },
    { id: 2, name: '2' },
    { id: 2, name: '3' },
    { id: 2, name: '4' },
    { id: 2, name: '5' },
    { id: 2, name: '6' },
    { id: 2, name: '7' },
    { id: 2, name: '8' },
    { id: 2, name: '9' },
    { id: 2, name: '10' },
    { id: 2, name: '11' },
    { id: 2, name: '12' }
  ];

  self.toggleAll = function () {
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

  self.addToRouteDisabled = function () {
    return self.getSelectedStudentCount() <= 0;
  };

  self.filterableRoutes = function (routes) {
    //$event.stopPropagation();
  };
}];