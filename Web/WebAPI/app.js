
// When requiring the routes folder, it automatically gets the index.js file
var routes = require('./routes');
var site = require('./routes/site');
var leaderboard = require('./routes/leaderboard');
var express = require('express');
var logger = require('morgan');
var http = require('http');

// Creates the express app that we use for most of our routing operations
var app = express();
var path = require('path');


// Some middleware
app.set('view engine', 'jade');
app.use(logger('dev'));

// app.use(express.static(__dirname + '/public'));

// Rounting for the different pages
app.get('/', site.index);
app.get('/api/', leaderboard.leaderboard);

// This will be used once the DB is setup and routing is configured
// app.get('/api/:timeframe/:type', leaderboard.api);

app.get('/:page', site.page);

http.createServer(app).listen(8080, function () {
    console.log("Listening on port: 8080");
});