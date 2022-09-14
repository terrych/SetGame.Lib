using Microsoft.VisualStudio.TestTools.UnitTesting;
using SetGame.Set;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetGame.Test
{
    [TestClass]
    public class BaseConverterTests
    {
        [TestMethod]
        public void BaseConverterWorksBothWays()
        {
            const int variations = 4;
            const int features = 5;

            bool allTheSame = true;
            int theNumberThatBrokeIt = -1;
            var testGame = new Game().InitializeNewGame(variations, features);
            for (int i = 0; i < Math.Pow(variations, features); i++) //0 to 1023 if I am correct
            {
                if( i != testGame.CardArrayToInteger(testGame.IntegerToCard(i)))
                {
                    allTheSame = false;
                    break;
                }
            }

            Assert.IsTrue(allTheSame, $"The number {theNumberThatBrokeIt} broke the test.");
        }
    }
}
