var mongoose = require('mongoose');
var Schema = mongoose.Schema;
var ObjectId = Schema.ObjectId;
var Leaderboard = mongoose.model("Leaderboard");

var Level = new Schema({
    Name    :   String,
    Description :   String,
    Leaderboards    :   [{
        type : ObjectId,
        ref : 'Leaderboard'
    }]
});

mongoose.model('Level', Level);