var path = require('path');

exports.page = function (req, res) {
	res.sendFile(path.join(__dirname + '/site/' + req.params.page), function (err) {
		if(err)
		{
			res.send("Cannot find the specified webpage");
		}
	});
};

exports.index = function (req, res) {
    res.sendFile(path.join(__dirname + '/site/intro.htm'));  
};
