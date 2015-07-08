var mongoose = require('mongoose');
var Schema = mongoose.Schema;

var Leaderboard = mongoose.model("Leaderboard");

var Level = new Schema({
    Name    :   String,
    Description :   String,
    Leaderboards    :   [Leaderboard]
});

mongoose.model('Level', Level);