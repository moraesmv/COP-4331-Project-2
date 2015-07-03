var fun = require('pun');
var $ = fun.$;


exports.leaderboard = function (req, res) {
	res.json([{"Id":1,"Score":1,"Initials":"111","LevelCompleteTime":111,"Date":"2011-11-11T00:00:00"},{"Id":2,"Score":123,"Initials":"xrb","LevelCompleteTime":123,"Date":"2012-09-02T00:00:00"},{"Id":3,"Score":150,"Initials":"xrb","LevelCompleteTime":12,"Date":"2009-09-09T00:00:00"},{"Id":4,"Score":125,"Initials":"aaa","LevelCompleteTime":134,"Date":"1995-07-27T00:00:00"}]);
};

exports.api = function (req, res) {
    var timeframe = req.params.timeframe;
    var scoretype = req.params.type;
    var dir = [timeframe, scoretype];
    console.log(dir);
    if(dir == [ 'alltime', 'score' ])
    {
        console.log('good');
    }
    else
    {
        console.log('bad');
    }
};