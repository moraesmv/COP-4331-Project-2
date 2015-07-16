var mongoose = require('mongoose');
var Schema = mongoose.Schema;
var ObjectId = Schema.ObjectId;
var Leaderboard = mongoose.model("Leaderboard");

var Level = new Schema({
    Id : {type: Number, unique: true, required: true},
    Name    :   String,
    Description :   String,
    Leaderboards    :   [{
        type : ObjectId,
        ref : 'Leaderboard'
    }]
});

mongoose.model('Level', Level);

exports.newLevel = function(name, id){
    var Level = mongoose.model('Level');
    var level = new Level({
        Id: id,
        Name : name || "temp name",
        Description : "This is a level in our project",
        Leaderboards : []
    });
    
    level.save();
    return level;
};