'use strict';
var app = require('angular').module('webApp');

app.controller('MainCtrl', require('./main'));
app.controller('AboutCtrl', require('./about'));
app.controller('StudentsController', require('./students.controller'));
app.controller('updateStudentsController', require('./updateStudents.controller'));