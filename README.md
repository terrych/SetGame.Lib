# SetGame

A version of the game [Set](https://www.playmonster.com/brands/set/) but with some additional features built on top of it.


## Description

*I wrote this project as an excuse to try out ReactJS and try out some different algorithms for finding sets on the board. This repo has been split out from the other repo (SetGame) originally containing these classes as part of a website. This is a separate repo as it seemed like a good candidate for a nuget package.*


## How to play Set
The original game of Set consists of a deck of 81 cards. This cards each have four features: the colours, the shapes, the shadings and the numbers. Within each of these features there are 3 variations (e.g. there are 3 colours: red, green and blue. The cards will have either 1, 2 or 3 of their shape). 12 cards are dealt onto the board and players race to find a Set. 

A set is 3 cards which have the same, or different variations for each of these features on each of their cards.

The first player to find a set (in the card game they would yell "Set") gets to keep these cards and 3 more cards are dealt from the deck to replace the removed cards (unless there are more than 12 cards on the board). If there are no sets on the board 3 more cards can be dealt to try and ensure there will be a set on the board. If the deck is empty and there are no sets on the board then the game ends and the winner is the player who has found the most sets.

### Some numbers and strategy related to the above
The number of cards in a deck is given by the number of variations, v, (default 3) to the power of the number of features, f, (default 4). This gives us the 3^4 = 81 cards in a deck for the default game of Set. A set should be the same size as the number of variations for all viable forms of the game.

If you pick any two cards in the default game of Set, one of the remaining 79 cards will form the set. This means that the number of possible sets is the number of ways of choosing (v-1) cards from the deck. In the case of the default game this is 81C2 = (81×80)/(3-1) = 81×40 = 3240 possible sets.

With a board size of 12 (the default) and set size of 3, for a computer to iterate through all possible pairs of cards on the board there are a maximum of 12C2 = 66 possible combinations to check (of course if we get to the final two cards on the board we can discount this being a possible set since we must have already found a set containing these two cards by now, however in practice it's probably not worth ignoring this case in the code). This is a fairly reasonable number of combinations of cards to check, however this could stop being the case in larger versions of the game. The worst case number to check will grow with O(b^(v-1)) where b is the board size.

In the default version of the game, for there to be no sets on the board we cannot have more than (v-1)^f cards on the board. This is the maximum number of cards we can have where none of the combinations of v cards will have either all the same or all different values for each member of the set. In the default game this is 2^4 = 16 cards. To see this, note that for each possible set there must be at least on feature that has all possible variations. This means that to have no sets and the maximum possible number of cards, we must be missing one variation from all features across all cards on the deck. This leaves us with (v-1) variations for each of the f features hence (v-1)^f cards.

## Tidy-up/fixes needed
+ The Game class is way too big.

