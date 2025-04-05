# Game of Life

This project implements an API for Conway's Game of Life. 

Conway's Game of Life description: https://en.wikipedia.org/wiki/Conway%27s_Game_of_Life

1- Sofware preconditions
- [.NET 7 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/7.0)

2- How to run the project

dotnet restore
dotnet build
dotnet run --project src

API will be available at http://localhost:5277
To use in the browser go to http://localhost:5277/swagger/index.html

3- Available endpoints
POST /board - Set a new initial board
GET /board/{id}/next	- Returns the next state of a given board
GET /board/{id}/next/{n steps}	- Returns the state n steps aheade of a given board
GET /board/{id}/final	- Returns the final state if converges or it status at step 300

4- How to run the tests

dotnet test tests/UnitTests/GameOfLife.Tests.csproj



Developed by Agustin Nieves
