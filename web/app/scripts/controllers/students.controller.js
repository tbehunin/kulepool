'use strict';

module.exports = ['$scope', function ($scope) {
  var self = this;
  var selectedCount = 0;

  self.students = [{
      selected: false,
      lastName: 'Behunin',
      firstName: 'Ava',
      grade: '7',
      schoolName: 'Meadow Park Middle School',
      routes: [{
        id: 1,
        name: '24: Tucson St'
      }, {
        id: 2,
        name: '25: York St'
      }]
    },
    {
      selected: false,
      lastName: 'Behunin',
      firstName: 'Eliza',
      grade: '5',
      schoolName: 'Meadow Park Middle School',
      routes: []
    },
    {
      selected: false,
      lastName: 'Behunin',
      firstName: 'Grant',
      grade: '3',
      schoolName: 'Meadow Park Middle School',
      routes: [{
        id: 2,
        name: '25: York St'
      }]
    }
  ];
  
  self.routes = [{
      name: '24: Tucson St' },
    {
      name: '25: York St' }];
  
  self.selectStudent = function(student) {
    student.selected = !student.selected;
    selectedCount = selectedCount + (student.selected ? 1 : -1);
  };

  self.getSelectedStudentCount = function () {
    return selectedCount > 0 ? '(' + selectedCount + ')' : '';
  };

  self.addToRouteDisabled = function () {
    return selectedCount <= 0;
  };

  self.showRoutes = function (routes) {
    //$event.stopPropagation();
  };
}];