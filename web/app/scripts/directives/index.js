'use strict';
var app = require('angular').module('webApp');

app.directive('blurOnClick', require('./blurOnClick.directive'));
app.directive('multiselect', require('./multiselect.directive'));
app.directive('multiSelectFilter', require('./multiSelectFilter.directive'));