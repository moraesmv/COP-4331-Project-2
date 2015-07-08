var Entry = require('./schemas/entry');
var Leaderboard = require('./schemas/leaderboard');
var Level = require('./schemas/level');

var mongoose = require('mongoose');
mongoose.connect('mongodb://localhost/test');

exports.level = function(req, res){
    mongoose.model('Level').findOne(function(err, level){
        level.save();
        res.send(level);
    });
};

exports.addEntry = function(req, res){
    mongoose.model('Entry').insert(req.body);
    mongoose.model('Entry').find(function(err, entry){
        res.send(entry);
    });
};