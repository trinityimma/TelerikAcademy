# Localhost Node.JS server used for Adobe Edge Inspect
connect = require 'connect'
connect.createServer(
	connect.static __dirname
).listen 8080