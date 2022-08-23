using SetGame.Set;

namespace SetGame.Test
{
    /// <summary>
    /// For visualization number takes form: Position3, position 2, position 1, position 0
    /// Position0: count. Digit + 1 is count.
    /// Position1: shape. 0 is squiggles, 1 is diamonds, 2 is ovals.
    /// Position2: color. 0 is red, 1 is green, 2 is blue.
    /// Position3: shading. 0 is solid, 1 is lines(shaded), 2 is empty
    /// </summary>

    [TestClass]
    public class OriginalGameIsSetTests
    {
        /// <summary>
        /// Solid red squiggles with different counts
        /// </summary>
        [TestMethod]
        public void Cards0And1And2AreASet()
        {
            /*
            0000
            0001
            0002
             */
            var game = new Game(3, 4);
            Assert.IsTrue(game.IsSet(new List<int>() { 0, 1, 2 }));
        }

        /// <summary>
        /// Red diamonds with different counts and shading
        /// </summary>
        [TestMethod]
        public void Cards58And32And3AreASet()
        {
            /*
            2011
            1012
            0010
             */
            var game = new Game(3, 4);
            Assert.IsTrue(game.IsSet(new List<int>() { 58, 32, 3 }));
        }

        /// <summary>
        /// Single diamonds with different colors and shading
        /// </summary>
        [TestMethod]
        public void Cards48And57And12AreASet()
        {
            /*
            1210
            2010
            0110
             */
            var game = new Game(3, 4);
            Assert.IsTrue(game.IsSet(new List<int>() { 48, 57, 12 }));
        }

        /// <summary>
        /// One red solid diamond, two green shaded squiggles and three blue empty ovals
        /// </summary>
        [TestMethod]
        public void Cards3And37And80AreASet()
        {
            /*
            0010
            1101
            2222
             */
            var game = new Game(3, 4);
            Assert.IsTrue(game.IsSet(new List<int>() { 3,37,80 }));
        }

        /// <summary>
        /// Two solid red squiggles, three solid red squiggles, one solid red diamond
        /// </summary>
        [TestMethod]
        public void Cards1And2And3AreNotSet()
        {
            /*
            0001
            0002
            0010
             */
            var game = new Game(3, 4);
            Assert.IsFalse(game.IsSet(new List<int>() { 1, 2, 3 }));
        }

        /// <summary>
        /// One red solid diamond, one green solid diamond and one blue shaded diamond
        /// </summary>
        [TestMethod]
        public void Cards3And12And48AreNotSet()
        {
            /*
            0010
            0110
            1210
             */
            var game = new Game(3, 4);
            Assert.IsFalse(game.IsSet(new List<int>() { 3, 12, 48 }));
        }

        /// <summary>
        /// One red solid diamond, two green shaded ovals and two blue empty squiggles
        /// </summary>
        [TestMethod]
        public void Cards3And43And73AreNotSet()
        {
            /*
            0010
            1121
            2201
             */
            var game = new Game(3, 4);
            Assert.IsFalse(game.IsSet(new List<int>() { 3, 43, 73 }));
        }
    }
}