'use strict';

module.exports = ['$q', '$http', function ($q, $http) {
  var self = this;
  var schoolData = [
    { id: 1, name: 'Aloha-Huber Park', selected: false },
    { id: 2, name: 'Barnes', selected: false },
    { id: 3, name: 'Beaver Acres', selected: false },
    { id: 4, name: 'Bethany', selected: false },
    { id: 5, name: 'Bonny Slope', selected: false },
    { id: 6, name: 'Cedar Mill', selected: false },
    { id: 7, name: 'Chehalem', selected: false },
    { id: 8, name: 'Cooper Mountain', selected: false },
    { id: 9, name: 'Elmonica', selected: false },
    { id: 10, name: 'Errol Hassell', selected: false },
    { id: 11, name: 'Findley', selected: false },
    { id: 12, name: 'Fir Grove', selected: false },
    { id: 13, name: 'Greenway', selected: false },
    { id: 14, name: 'Hazeldale', selected: false },
    { id: 15, name: 'Hiteon', selected: false },
    { id: 16, name: 'Jacob Wismer', selected: false },
    { id: 17, name: 'Kinnaman', selected: false },
    { id: 18, name: 'Mckay', selected: false },
    { id: 19, name: 'McKinley', selected: false },
    { id: 20, name: 'Montclair', selected: false },
    { id: 21, name: 'Nancy Ryles', selected: false },
    { id: 22, name: 'Oak Hills', selected: false },
    { id: 23, name: 'Raleigh Hills', selected: false },
    { id: 24, name: 'Raleigh Park', selected: false },
    { id: 25, name: 'Ridgewood', selected: false },
    { id: 26, name: 'Rock Creek', selected: false },
    { id: 27, name: 'Scholls Heights', selected: false },
    { id: 28, name: 'Sexton Mountain', selected: false },
    { id: 29, name: 'Springville', selected: false },
    { id: 30, name: 'Terra Linda', selected: false },
    { id: 31, name: 'Vose', selected: false },
    { id: 32, name: 'West Tualatin View', selected: false },
    { id: 33, name: 'William Walker', selected: false }
  ];
  var routeData = [
    { id: 24, name: '24: Tucson St', selected: false },
    { id: 25, name: '25: York St', selected: false }
  ];
  var gradeData = [
    { id: 1, name: 'K', selected: false },
    { id: 2, name: '1', selected: false },
    { id: 3, name: '2', selected: false },
    { id: 4, name: '3', selected: false },
    { id: 5, name: '4', selected: false },
    { id: 6, name: '5', selected: false },
    { id: 7, name: '6', selected: false },
    { id: 8, name: '7', selected: false },
    { id: 9, name: '8', selected: false },
    { id: 10, name: '9', selected: false },
    { id: 11, name: '10', selected: false },
    { id: 12, name: '11', selected: false },
    { id: 13, name: '12', selected: false }
  ];

  var studentData = [
    {
      selected: false,
      lastName: 'Behunin',
      firstName: 'Ava',
      grade: gradeData[7],
      school: schoolData[0],
      eligible: true,
      assignedRoutes: {
        show: false,
        routes: [routeData[0], routeData[1]]
      }
    },
    {
      selected: false,
      lastName: 'Behunin',
      firstName: 'Eliza',
      grade: gradeData[5],
      school: schoolData[1],
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
      grade: gradeData[3],
      school: schoolData[2],
      eligible: true,
      assignedRoutes: {
        show: false,
        routes: [routeData[1]]
      }
    }
  ];

  self.getStudents = function (query) {
    var data = studentData;
    if (query) {
      data = angular.isArray(query.schools) && query.schools.length > 0 ? data.filter(function (item) {
        return query.schools.includes(item.school.id);
      }) : data;
      data = angular.isArray(query.grades) && query.grades.length > 0 ? data.filter(function (item) {
        return query.grades.includes(item.grade.id);
      }) : data;
    }
    return $q.when(data);
  };
  
  self.getRoutes = function () {
    return $q.when(routeData);
  };
  
  self.getSchools = function () {
    return $q.when(schoolData);
  };
  
  self.getGrades = function () {
    return $q.when(gradeData);
  };
}];