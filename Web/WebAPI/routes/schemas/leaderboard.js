var mongoose = require('mongoose');
var Schema = mongoose.Schema;
var ObjectId = Schema.ObjectId;

var Entry = mongoose.model("Entry");

var Leaderboard = new Schema({
    Name    :   {type: String, unique: true},
    Description :   String,
    Entries :   [Entry]
});

mongoose.model('Leaderboard', Leaderboard);