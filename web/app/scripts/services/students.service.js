'use strict';

module.exports = ['$q', '$http', function ($q, $http) {
  var self = this;
  var schoolData = [
    { id: 1, name: 'Aloha-Huber Park' },
    { id: 2, name: 'Barnes' },
    { id: 3, name: 'Beaver Acres' },
    { id: 4, name: 'Bethany' },
    { id: 5, name: 'Bonny Slope' },
    { id: 6, name: 'Cedar Mill' },
    { id: 7, name: 'Chehalem' },
    { id: 8, name: 'Cooper Mountain' },
    { id: 9, name: 'Elmonica' },
    { id: 10, name: 'Errol Hassell' },
    { id: 11, name: 'Findley' },
    { id: 12, name: 'Fir Grove' },
    { id: 13, name: 'Greenway' },
    { id: 14, name: 'Hazeldale' },
    { id: 15, name: 'Hiteon' },
    { id: 16, name: 'Jacob Wismer' },
    { id: 17, name: 'Kinnaman' },
    { id: 18, name: 'Mckay' },
    { id: 19, name: 'McKinley' },
    { id: 20, name: 'Montclair' },
    { id: 21, name: 'Nancy Ryles' },
    { id: 22, name: 'Oak Hills' },
    { id: 23, name: 'Raleigh Hills' },
    { id: 24, name: 'Raleigh Park' },
    { id: 25, name: 'Ridgewood' },
    { id: 26, name: 'Rock Creek' },
    { id: 27, name: 'Scholls Heights' },
    { id: 28, name: 'Sexton Mountain' },
    { id: 29, name: 'Springville' },
    { id: 30, name: 'Terra Linda' },
    { id: 31, name: 'Vose' },
    { id: 32, name: 'West Tualatin View' },
    { id: 33, name: 'William Walker' }
  ];
  var routeData = [
    { id: 24, name: '24: Tucson St' },
    { id: 25, name: '25: York St' }
  ];
  var gradeData = [
    { id: 1, name: 'K' },
    { id: 2, name: '1' },
    { id: 3, name: '2' },
    { id: 4, name: '3' },
    { id: 5, name: '4' },
    { id: 6, name: '5' },
    { id: 7, name: '6' },
    { id: 8, name: '7' },
    { id: 9, name: '8' },
    { id: 10, name: '9' },
    { id: 11, name: '10' },
    { id: 12, name: '11' },
    { id: 13, name: '12' }
  ];
  var tagData = [
    {id: 1, name: 'eligible'},
    {id: 2, name: 'special needs'}
  ];

  var studentData = [
    {
      lastName: 'Behunin',
      firstName: 'Ava',
      grade: gradeData[7],
      school: schoolData[0],
      tags: [tagData[0]],
      assignedRoutes: {
        routes: [routeData[0], routeData[1]]
      }
    },
    {
      lastName: 'Behunin',
      firstName: 'Eliza',
      grade: gradeData[5],
      school: schoolData[1],
      tags: [],
      assignedRoutes: {
        routes: []
      }
    },
    {
      lastName: 'Behunin',
      firstName: 'Grant',
      grade: gradeData[3],
      school: schoolData[2],
      tags: [tagData[0], tagData[1]],
      assignedRoutes: {
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
      // data = angular.isArray(query.tags) && query.tags.length > 0 ? data.filter(function (item) {
      //   return query.tags.includes(item);
      // }) : data;
      if (query.sort && query.sort.col) {
        data = data.sort(function (a, b) {
          var first = null, second = null;
          switch (query.sort.col) {
            case 'lastname':
              first = a.lastName;
              second = b.lastName;
              break;
            case 'firstname':
              first = a.firstName;
              second = b.firstName;
              break;
            case 'school':
              first = a.school.name;
              second = b.school.name;
              break;
            case 'grade':
              first = a.grade.name;
              second = b.grade.name;
              break;
          }
          if (query.sort.desc) {
            // Swap
            var tmp = first;
            first = second;
            second = tmp;
          }
          return first < second ? -1 : first > second ? 1 : 0;
        });
      }
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
  
  self.getTags = function () {
    return $q.when(tagData);
  };
}];