var mongoose = require('mongoose');
var Schema = mongoose.Schema;
var ObjectId = Schema.ObjectId;

var Entry = mongoose.model("Entry");

var Leaderboard = new Schema({
    Id : {type: Number, required: true},
    Name    :  String,
    Description :   String,
    Entries :   [{
        type : ObjectId,
        ref: 'Entry'
    }]
});

mongoose.model('Leaderboard', Leaderboard);

exports.newBoard = function(name, id){
    var Leaderboard = mongoose.model('Leaderboard');
    var new_board = new Leaderboard({
        Id : id,
        Name : name,
        Description : "This is a test leaderboard",
        Entries : []
    });
    new_board.save(function(err){
        console.log(err);
    });
    return new_board;
};