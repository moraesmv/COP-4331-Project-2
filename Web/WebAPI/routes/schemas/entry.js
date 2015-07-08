var mongoose = require('mongoose');
var Schema = mongoose.Schema;
var ObjectId = Schema.ObjectId;

var Entry = new Schema({
    Initials    :   String,
    Score       :   Number,
    LevelTime   :   Number,
    Date        :   Date
});

mongoose.model('Entry', Entry);