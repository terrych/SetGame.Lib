# SetGame

A version of the game [Set](https://www.playmonster.com/brands/set/) but with some additional features built on top of it.


## Description

*I wrote this project as an excuse to try out ReactJS and try out some different algorithms for finding sets on the board. As such this ReadMe is not going to be focused on the usual tech side of things but I will try to summarize that side of things before moving onto the more interesting stuff.*

The back-end project (SetGame.Api) is written in C# and it communicates with the UI via a [.Net 6.0 Web Api](https://learn.microsoft.com/en-us/aspnet/core/tutorials/min-web-api?view=aspnetcore-6.0&tabs=visual-studio). I have currently been developing it on a Windows 11 machine and have configured Entity Framework to use MSSqlServer so any changes may require adjustments to the config for this project.

The front-end project (SetGame.Web) is a React project and was mostly created following [this](https://learn.microsoft.com/en-us/visualstudio/javascript/tutorial-asp-net-core-with-react?source=recommendations&view=vs-2022). Likely the most important thing to ensure in the config here is that the proxy url in package.json and the appProxy target in setupProxy.js is the same as the applicationUrl in SetGame.Api's launchSettings.json.


## How to play Set
The original game of Set consists of a deck of 81 cards. This cards each have four features: the colours, the shapes, the shadings and the numbers. Within each of these features there are 3 variations (e.g. there are 3 colours: red, green and blue. The cards will have either 1, 2 or 3 of their shape). 12 cards are dealt onto the board and players race to find a Set. 

A set is 3 cards which have the same, or different variations for each of these features on each of their cards.

The first player to find a set (in the card game they would yell "Set") gets to keep these cards and 3 more cards are dealt from the deck to replace the removed cards (unless there are more than 12 cards on the board). If there are no sets on the board 3 more cards can be dealt to try and ensure there will be a set on the board. If the deck is empty and there are no sets on the board then the game ends and the winner is the player who has found the most sets.

### Some numbers and strategy related to the above
*Coming soon*

## Tidy-up/fixes needed
+ The Game class is way too big.
+ The submit set code in Board.js is currently only giving a good UX if there is low latency.
+ A lot of CSS work around centering icons and ensuring app is usable when window is resized.
+ Add a timer to the front end.

## Planned Features (no order of priority)
+ Adjust colours functionality for red-green colour-blind people. May need to change how card shapes are rendered.
+ Make number of features and variations configurable.
+ Multiplayer (try using SignalR, deal 3 cards if no set found after certain time, may need signature to authenticate game state).
+ Play against computer (configurable time taken for computer to find set (with random variation)).
