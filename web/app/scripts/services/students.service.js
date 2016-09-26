'use strict';

module.exports = ['$q', '$http', function ($q, $http) {
  var self = this;

  self.getStudents = function (query) {
    var data = [
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
    return $q.when(data);
  };
  
  self.getRoutes = function (query) {
    var data = [
      { id: 24, name: '24: Tucson St', selected: false },
      { id: 25, name: '25: York St', selected: false }
    ];
    return $q.when(data);
  };
  
  self.getSchools = function (query) {
    var data = [
      { id: 1, name: 'Bethany Elementary', selected: false },
      { id: 2, name: 'Meadow Park Middle School', selected: false }
    ];
    return $q.when(data);
  };
  
  self.getGrades = function (query) {
    var data = [
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
    return $q.when(data);
  };
}];