var express = require('express');
var jdbc = new ( require('jdbc') );
 
var config = {
  libpath: __dirname + './sajdbc4.jar',
  libs: [],
  drivername: 'sybase.jdbc4.sqlanywhere.IDriver',
  url: 'jdbc:sqlanywhere:DSN=awrds2k',
 
};
jdbc.initialize(config, function(err, res) {
  if (err) {
    console.log(err);
  }
});
var app = express();

var quotes = [
  { author : 'Audrey Hepburn', text : "Nothing is impossible, the word itself says 'I'm possible'!"},
  { author : 'Walt Disney', text : "You may not realize it when it happens, but a kick in the teeth may be the best thing in the world for you"},
  { author : 'Unknown', text : "Even the greatest was once a beginner. Don't be afraid to take that first step."},
  { author : 'Neale Donald Walsch', text : "You are afraid to die, and you're afraid to live. What a way to exist."}
];

var genericQueryHandler = function(err, results) {
  if (err) {
    console.log(err);
	
  } else if (results) {
    console.log("Query completed successfully");	
  }
  
  jdbc.close(function(err) {
    if(err) {
      console.log(err);
    } else {
      console.log("Connection closed successfully!");
    }
  });
 
};

app.get('/', function(req, res) {
 
	
	console.log('Received request from '  + req.headers.host);	
	res.send("Nothing here");	
		
	
});

app.options('/', function(req, res)
	{
		res.setHeader("Allow", "GET, OPTIONS");
		res.send("OK");
	
	}

)

app.get('/aac_lookup', function(req, res) {
 
	try 
	{
		console.log('Received request from '  + req.headers.host + '... Opening DB Connection');	
		
		jdbc.open(function(err, conn) {
			if (conn) 
			{
			
				jdbc.executeQuery("SELECT * FROM fmds.aac_lookup", function(err, results)
				{
					genericQueryHandler(err, results);
					if(err)
					{
						res.statusCode = 500;
						return res.send("Error 500: Internal Server Error");
						
					}
					return res.json(results);
					
				});
 
			}
		});	
	}
	catch (e) 
	{
		console.log(e.message);
		res.statusCode = 500;
		res.send('Error 500: Internal Server Error');
	}
	
});

app.options('/aac_lookup', function(req, res)
	{
		res.setHeader("Allow", "GET, OPTIONS");
		res.send("OK");
	
	}

)

app.get('/quote', function(req, res) {
  res.json(quotes);
});

app.get('/quote/:id', function(req, res) {
  if(quotes.length <= req.params.id || req.params.id < 0) {
    res.statusCode = 404;
    return res.send('Error 404: No quote found');
  }  
var q = quotes[req.params.id];
  res.json(q);
});

app.listen(process.env.PORT || 80);