'use strict';
var app = require('angular').module('webApp');

app.service('modalService', require('./modal.service'));
app.component('confirmModalComponent', require('./confirmModal.component'));
app.component('tagComponent', require('./tag.component'));