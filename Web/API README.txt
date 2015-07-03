http://168.235.74.170:8080
Link for site and api.

Placeholder API
http://168.235.74.170:8080/api/
this will get you json data for a list of leaderboard entries.
Sample single Json Object that you'll get back
  {
    "Id": 1,
    "Score": 1,
    "Initials": "111",
    "LevelCompleteTime": 111,
    "Date": "2011-11-11T00:00:00"
  }





IGNORE THESE FOR NOW
so far we are able to send requests to the api and receive the different
responses for leaderboard entries.
API Links for sending requests:
/api/TopTimesTodayEntries **
/api/TopTimesAllTimeEntries
/api/TopScoresTodayEntries **
/api/TopScoresAllTimeEntries
none currently have limits on how many entries they can hold.

**these aren't fully setup for sorting and holding only top ? amount of entries yet

