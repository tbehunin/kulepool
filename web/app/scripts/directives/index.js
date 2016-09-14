'use strict';
var app = require('angular').module('webApp');

app.directive('blurOnClick', require('./blurOnClick.directive'));
app.directive('stopEventBubble', require('./stopEventBubble.directive'));