using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using SetGame.Set;

namespace SetGame.Test
{
    [TestClass]
    public class CheckSetTests
    {
        [TestMethod]
        public void IfBoardIsBiggerThanBoardSizeThenItWillBeSmallerAfterSetSelection()
        {
            string jsonGame = "{\"Deck\":[0,1,2,3,7,8,9,10,12,13,14,15,16,17,18,20,21,23,24,25,26,28,30,32,33,34,35,36,37,39,40,41,42,43,46,48,49,50,52,54,55,57,58,59,63,64,66,67,68,69,70,71,72,73,74,76,77,78,79,80],\"PositionalValues\":[1,3,9,27],\"Id\":\"cbca3be9-d48f-4cef-a6a4-14210aed607a\",\"Variations\":3,\"Features\":4,\"BoardSize\":12,\"SetSize\":3,\"Board\":[[2,2,2,1],[2,2,1,1],[0,2,0,0],[1,2,0,2],[2,0,2,1],[0,2,2,1],[0,1,2,2],[1,1,2,0],[0,0,2,1],[2,0,1,1],[2,2,0,2],[2,1,0,0],[2,0,1,0],[1,1,0,1],[2,0,0,2]],\"SelectedCards\":[],\"HighlightedCards\":null}";
            var theGame = JsonConvert.DeserializeObject<Game>(jsonGame);
            // the set is [1,8,13]
            theGame.CheckSet(new int[3] { 1, 13, 8 });
            Assert.IsTrue(theGame.Board.Count() == theGame.BoardSize);
        }

        [TestMethod]
        public void IfThereAreNoCardsLeftInTheDeckWeDoNotGetAnArgumentOutOfRangeException()
        {
            try
            {
                string jsonGame = "{\"Deck\":[],\"PositionalValues\":[1,3,9,27],\"Id\":\"ac509696-2da5-4d98-88cd-4da2ccead5a1\",\"Variations\":3,\"Features\":4,\"BoardSize\":12,\"SetSize\":3,\"Board\":[[2,1,0,1],[0,1,2,0],[2,0,1,2],[1,1,0,2],[1,0,2,0],[2,1,2,2],[1,0,1,1],[1,1,2,0],[2,0,2,2],[0,0,0,0],[0,1,0,1],[0,0,0,1]],\"SelectedCards\":[],\"HighlightedCards\":null}";
                var theGame = JsonConvert.DeserializeObject<Game>(jsonGame);
                // the set is [2,4,11]
                var thisIsTrueOrJsonInvalidForTest = theGame.CheckSet(new int[3]{ 2,11,4 });
                Assert.IsTrue(thisIsTrueOrJsonInvalidForTest, "Might need a new jsonGame.");
            }
            catch (ArgumentOutOfRangeException)
            {
                Assert.Fail("It's an ArgumentOutOfRangeException. This is bad.");
            }
            catch 
            {
                Assert.Fail("We got an exception, and it was not an ArgumentOutOfRangeException. Not sure how. If I thought anyone else was going to get harmed by this I would include useful info, but since it's almost certainly going to be and I want to play a prank on future me, I won't do that. Have fun future me, I'm sure you'll figure it out quickly ;P.");
            }
        }

        [TestMethod]
        public void StayAtBoardSizeCardsIfReplacementCardsInDeckAndWereAlreadyAtBoardSize()
        {
            string jsonGame = "{\"Deck\":[80,79,78],\"PositionalValues\":[1,3,9,27],\"Id\":\"ac509696-2da5-4d98-88cd-4da2ccead5a1\",\"Variations\":3,\"Features\":4,\"BoardSize\":12,\"SetSize\":3,\"Board\":[[2,1,0,1],[0,1,2,0],[2,0,1,2],[1,1,0,2],[1,0,2,0],[2,1,2,2],[1,0,1,1],[1,1,2,0],[2,0,2,2],[0,0,0,0],[0,1,0,1],[0,0,0,1]],\"SelectedCards\":[],\"HighlightedCards\":null}";
            var theGame = JsonConvert.DeserializeObject<Game>(jsonGame);
            // the set is [2,4,11]
            theGame.CheckSet(new int[3] { 2, 11, 4 });
            Assert.IsTrue(theGame.Board.Count() == theGame.BoardSize);
        }
    }
}
