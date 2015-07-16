var mongoose = require('mongoose');
var Schema = mongoose.Schema;
var ObjectId = Schema.ObjectId;

var Entry = new Schema({
    // Id          :   Number,
    Initials    :   String,
    Score       :   Number,
    LevelTime   :   Number,
    Date        :   Date
});

mongoose.model('Entry', Entry);

exports.newEntry = function(){
    var Entry = mongoose.model('Entry');
    var names = ['xav', 'guf', 'mar', 'bob'];
    
    var entry = new Entry({
        Initials : names[Math.floor(Math.random() * 4)],
        Score : Math.floor((Math.random() * 1000) + 1),
        LevelTime : Math.floor(Math.random() * 360),
        Date : Date.now()
    });
    
    entry.save();
    return entry;
};