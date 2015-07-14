var Entry = require('./schemas/entry');
var Leaderboard = require('./schemas/leaderboard');
var Level = require('./schemas/level');


var mongoose = require('mongoose');
mongoose.connect('mongodb://localhost/test');

var EntryModel = mongoose.model('Entry');
var LeaderboardModel = mongoose.model('Leaderboard');
var LevelModel = mongoose.model('Level')

exports.allLevels = function(req, res){
    console.log('in alllevels');
    // mongoose.model('Level').findOne(function(err, level){
    //     level.save();
    //     res.send(level);
    // });
    
    mongoose.model('Leaderboard').find(function(err, lb){
        mongoose.model('Leaderboard')
            .populate(lb, {path: 'Entries'}, function(err, lb){
                res.send(lb);
        });
    });
};

exports.getLevel = function(req, res){
    console.log('in getlevel')
    var level = req.params.level;
    
    LevelModel.findOne({Id : level})
        .populate('Leaderboards')
        .lean()
        .exec(function(err, doc){
            
            if(err) res.send(500);
            
            console.log(doc);
            
            var options = {
               path: 'Leaderboards.Entries',
               model : 'Entry' 
            };
            
            LevelModel.populate(doc, options, function(err, lvl){
                if(err) res.send('there was an error');
                res.send(lvl.Leaderboards);
                // res.send(lvl);
            });
        });
    
    // res.send('All leaderboards from Level: ' + level);
};

exports.getBoard = function(req, res){
    console.log('in getboard');
    
    var level = req.params.level;
    var board = req.params.board;
    
    LevelModel.findOne({Id : level})
        .populate('Leaderboards')
        .lean()
        .exec(function(err, doc){
            
            if(err) res.send(500);
            
            console.log(doc);
            
            var options = {
               path: 'Leaderboards.Entries',
               model : 'Entry' 
            };
            
            LevelModel.populate(doc, options, function(err, lvl){
                if(err) res.send('there was an error');
                
                var sorted = lvl.Leaderboards[board].Entries;
                sorted = sorted.sort(function(a, b){
                    var byScore = b.Score - a.Score;
                    var byTime = a.LevelTime - b.LevelTime;
                    
                    return (board < 2 )? byScore : byTime;
                });
                
                res.send(sorted);
                // res.send(lvl.Leaderboards[board]);
            });
        });
    
    // res.send('Leaderboard' + board + 'from Level: ' + level);
};


exports.addEntry = function(req, res){
    console.log('in addentry');
    // {entries: #, boards: #, levels: #}
    var lvlinfo = req.body;
    
    if(!lvlinfo.id){
        res.send('no id given')
    } 
    else {
        var level = Level.newLevel(lvlinfo.name, lvlinfo.id);
        // level.save();
        
        var boards = [];
        
        boards.push(Leaderboard.newBoard("All Time High Scores: Level " + lvlinfo.id, 0));
        boards.push(Leaderboard.newBoard("Today's High Scores: Level " + lvlinfo.id, 1));
        boards.push(Leaderboard.newBoard("All Time Best Times: Level " + lvlinfo.id, 2));
        boards.push(Leaderboard.newBoard("Today's Best Times: Level " + lvlinfo.id, 3));
        
        boards.forEach(function(element) {
            // element.save();
            
            for(var i = 0; i < randomInt(50); i++){
                var entry = Entry.newEntry();
                // entry.save();
                
                element.Entries.push(entry);
                // console.log(entry)
            }
            level.Leaderboards.push(element);
        }, this);
        
        console.log(level);
        res.send(level);
    }
};

exports.shutdown = function(){
    mongoose.disconnect();
};

function randomInt(num){
    return Math.floor(Math.random() * num);
};