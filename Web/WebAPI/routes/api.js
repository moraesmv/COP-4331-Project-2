var Entry = require('./schemas/entry');
var Leaderboard = require('./schemas/leaderboard');
var Level = require('./schemas/level');


var mongoose = require('mongoose');
mongoose.connect('mongodb://localhost/test');

var EntryModel = mongoose.model('Entry');
var LeaderboardModel = mongoose.model('Leaderboard');
var LevelModel = mongoose.model('Level')

exports.allLevels = function(req, res){
    // mongoose.model('Level').findOne(function(err, level){
    //     level.save();
    //     res.send(level);
    // });
    
    mongoose.model('Leaderboard').find(function(err, lb){
        mongoose.model('Leaderboard').populate(lb, {path: 'Entries'}, function(err, lb){
            res.send(lb);
        });
    });
};

exports.getLevel = function(req, res){
    var level = req.level;
    
    res.send('All leaderboards from Level: ' + level);
};

exports.getBoard = function(req, res){
    var level = req.params.level;
    var board = req.params.board;
    
    res.send('Leaderboard' + board + 'from Level: ' + level);
};


exports.addEntry = function(req, res){

    var json = req.body;
    
    var entry = new EntryModel({
        Initials : "abc"
    });
};