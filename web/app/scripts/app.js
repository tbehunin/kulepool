'use strict';

var angular = require('angular');
require('angular-animate');
require('angular-aria');
require('angular-cookies');
require('angular-messages');
require('angular-resource');
require('angular-route');
require('angular-sanitize');
require('angular-touch');
require('angular-ui-router');
require('angular-ui-bootstrap');

angular.module('webApp', [
    'ngAnimate',
    'ngAria',
    'ngCookies',
    'ngMessages',
    'ngResource',
    'ngRoute',
    'ngSanitize',
    'ngTouch',
    'ui.router',
    'ui.bootstrap'
  ])
  .config(function ($stateProvider, $urlRouterProvider) {
    $urlRouterProvider.otherwise('/');
    $stateProvider
      .state('home', {
        url: '/',
        templateUrl: 'views/main.html',
        controller: 'MainCtrl',
        controllerAs: 'main'
      })
      .state('about', {
        url: '/about',
        templateUrl: 'views/about.html',
        controller: 'AboutCtrl',
        controllerAs: 'about'
      })
      .state('students', {
        url: '/students',
        templateUrl: 'views/students.html',
        controller: 'StudentsController',
        controllerAs: 'students',
        resolve: {
          availableStudents: function (studentsService) {
            return studentsService.getStudents();
          },
          availableRoutes: function (studentsService) {
            return studentsService.getRoutes();
          },
          availableSchools: function (studentsService) {
            return studentsService.getSchools();
          },
          availableGrades: function (studentsService) {
            return studentsService.getGrades();
          },
          availableTags: function (studentsService) {
            return studentsService.getTags();
          }
        }
      });
  });

require('./services');
require('./shared');
require('./controllers');
require('./directives');