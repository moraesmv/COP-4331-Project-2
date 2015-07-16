var PORT = process.env.PORT || 8080;

// When requiring the routes folder, it automatically gets the index.js file
var routes = require('./routes');
var site = require('./routes/site');
var api = require('./routes/api');
// Neccessary libs
var express = require('express');
var logger = require('morgan');
var http = require('http');
var fs = require('fs');
var bodyParser = require('body-parser');

// Creates the express app that we use for most of our routing operations
var app = express();
var path = require('path');


// Some middleware
app.set('view engine', 'jade');
app.use(logger('dev'));
app.use(bodyParser.json());
// Load files from the Schema 



// app.use(express.static(__dirname + '/public'));
// Routing for the different pages
app.get('/', site.index);

app.get('/api/:level/:board', api.getBoard);
app.get('/api/:level', api.getLevel);
app.get('/api/', api.allLevels);
app.get('/:page', site.page);

app.post('/api/debug', api.addEntry);

// app.delete('/api/debug', api.clearboard);

process.on('uncaughtException', function (err) {
    console.log(err);
}); 

process.on('SIGINT', function(){
    console.log('Exiting');
    api.shutdown();
    process.exit(0);
});

http.createServer(app).listen(PORT, function () {
    console.log("Listening on port: " + PORT);
});