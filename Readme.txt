---DeltaX IMDB---
(Assignment Round)     Candidate Name: S.V.Bhalaji     Candidate's Portfolio:        Designation: Full-Stack Developer

Problem : 
---------
Design the database and build a REST API for a movie application like IMDB. The database should be a
relational database with following relationships:

● An actor can act in multiple movies.
● A movie can have multiple actors.
● A movie has only one producer.
● A producer can produce multiple movies.

Tools Considered:
-----------------
1. Developed endpoints with ASP.NET core 5.0 Web API's.
2. Database used is MySQL.
3. The package MySqlConnector is used to connect to MySqlDatabase.

API Endpoints:
--------------
1. Get all movies from Database named 'imdb':

Endpoint : https://localhost/api/IMDB

2. Get particular movies from database 'imdb':

Endpoint : https://localhost/api/IMDB/{title}

3. Post new movies to database 'imdb':

Endpoint: https://localhost/api/IMDB
{title:<string>,actors:<string>,producer:<string>,comments:<string>}

4. Update the actor and producer information in movies

Endpoint: https://localhost/api/IMDB/{title}

5. Delete a particular Movie
Endpoint: https://localhost/api/IMDB/title?title=The%20tomorrow%20war 

Note:
-----
The screenshots of particular endpoints have also attached with the same repository. I am also apologizing for not hosting this app since I do not have much 
resources currently to make this possible.
 