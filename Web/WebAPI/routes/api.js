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
    
    // res.send('All leaderboards from Level: ' + level);
    
    mongoose.model('Level').find(function(err, lvl){
        mongoose.model('Level').populate(lvl, {path: 'Leaderboards'}, function(err, lvl){
            res.send(lvl);
        });
    });
};

exports.getBoard = function(req, res){
    var level = req.params.level;
    var board = req.params.board;
    
    res.send('Leaderboard' + board + 'from Level: ' + level);
};


exports.addEntry = function(req, res){

    var json = req.body;
    var names = ['xavier', 'guf', 'marcus', 'bobby'];
    
    var board = new Leaderboard({
        Name : "Leaderboard 1",
        Description : "This is a test leaderboard",
        Entries : []
    });
    
    for(var i = 0; i < 10; i++){
        var entry = new EntryModel({
            Initials : names[Math.floor(Math.random() * 4)],
            Score : Math.floor((Math.random() * 1000) + 1),
            LevelTime : Math.floor(Math.random() * 360),
            Date : Date.now()
        });
        entry.save();
        board.entries.push(entry);
    }
    
    board.save();
    
    var level = new Level({
        Name : "Level 1",
        Description : "This is Level one of our project",
        Leaderboards : []
    });
    
    level.leaderboards.push(board);
    level.save();
};