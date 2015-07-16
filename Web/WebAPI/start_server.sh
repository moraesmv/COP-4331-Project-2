if [ $1 == 'clearlog' ]; then
	rm log.log
fi

echo "---------------[LOG]-----------------\n" >> log.log
echo "Server Starting: "
date >> log.log

if [ $2 == 'log' ]; then
    node app.js >> log.log
else
    node app.js
fi

date >> log.log
echo "\n---------------[LOG]-----------------\n" >> log.log

echo "Log File has been created..."