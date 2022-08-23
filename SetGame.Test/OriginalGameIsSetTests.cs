using Microsoft.VisualStudio.TestTools.UnitTesting;
using SetGame.Set;
using SetGame.Set.CardElements;
using SetGame.Set.CardElements.FeatureEnums;

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
    public class OriginalGameIsSetTests : OriginalGameTests
    {
        /// <summary>
        /// Solid red squiggles with different counts
        /// </summary>
        [TestMethod]
        public void RedSolidSquigglesWithDifferentCountsAreSet()
        {
            List<int> submittedCards = new List<int>();
            int[] cardOne = new int[TheGame.Features];
            int[] cardTwo = new int[TheGame.Features];
            int[] cardThree = new int[TheGame.Features];
            cardOne[(int)FeatureRank.Count] = (int)Count.One;
            cardOne[(int)FeatureRank.Shape] = (int)Shape.Squiggle;
            cardOne[(int)FeatureRank.Colour] = (int)Colour.Red;
            cardOne[(int)FeatureRank.Shading] = (int)Shading.Solid;
            cardTwo[(int)FeatureRank.Count] = (int) Count.Two;
            cardTwo[(int)FeatureRank.Shape] = (int)Shape.Squiggle;
            cardTwo[(int)FeatureRank.Colour] = (int)Colour.Red;
            cardTwo[(int)FeatureRank.Shading] = (int)Shading.Solid;
            cardThree[(int)FeatureRank.Count] = (int) Count.Three;
            cardThree[(int)FeatureRank.Shape] = (int)Shape.Squiggle;
            cardThree[(int)FeatureRank.Colour] = (int)Colour.Red;
            cardThree[(int)FeatureRank.Shading] = (int)Shading.Solid;
            submittedCards.Add(TheGame.CardToInteger(cardOne));
            submittedCards.Add(TheGame.CardToInteger(cardTwo));
            submittedCards.Add(TheGame.CardToInteger(cardThree));

            Assert.IsTrue(TheGame.IsSet(submittedCards));
        }

        /// <summary>
        /// Red diamonds with different counts and shading
        /// </summary>
        [TestMethod]
        public void RedDiamondsWithDifferentShadingAndCountsAreSet()
        {
            List<int> submittedCards = new List<int>();
            int[] cardOne = new int[TheGame.Features];
            int[] cardTwo = new int[TheGame.Features];
            int[] cardThree = new int[TheGame.Features];
            cardOne[(int)FeatureRank.Count] = (int)Count.Three;
            cardOne[(int)FeatureRank.Shape] = (int)Shape.Diamond;
            cardOne[(int)FeatureRank.Colour] = (int)Colour.Red;
            cardOne[(int)FeatureRank.Shading] = (int)Shading.Empty;
            cardTwo[(int)FeatureRank.Count] = (int)Count.Two;
            cardTwo[(int)FeatureRank.Shape] = (int)Shape.Diamond;
            cardTwo[(int)FeatureRank.Colour] = (int)Colour.Red;
            cardTwo[(int)FeatureRank.Shading] = (int)Shading.Shaded;
            cardThree[(int)FeatureRank.Count] = (int)Count.One;
            cardThree[(int)FeatureRank.Shape] = (int)Shape.Diamond;
            cardThree[(int)FeatureRank.Colour] = (int)Colour.Red;
            cardThree[(int)FeatureRank.Shading] = (int)Shading.Solid;
            submittedCards.Add(TheGame.CardToInteger(cardOne));
            submittedCards.Add(TheGame.CardToInteger(cardTwo));
            submittedCards.Add(TheGame.CardToInteger(cardThree));

            Assert.IsTrue(TheGame.IsSet(submittedCards));
        }

        /// <summary>
        /// Single diamonds with different colors and shading
        /// </summary>
        [TestMethod]
        public void SingleDiamondsWithDifferentColorsAndShadingAreSet()
        {
            List<int> submittedCards = new List<int>();
            int[] cardOne = new int[TheGame.Features];
            int[] cardTwo = new int[TheGame.Features];
            int[] cardThree = new int[TheGame.Features];
            cardOne[(int)FeatureRank.Count] = (int)Count.One;
            cardOne[(int)FeatureRank.Shape] = (int)Shape.Diamond;
            cardOne[(int)FeatureRank.Colour] = (int)Colour.Blue;
            cardOne[(int)FeatureRank.Shading] = (int)Shading.Shaded;
            cardTwo[(int)FeatureRank.Count] = (int)Count.One;
            cardTwo[(int)FeatureRank.Shape] = (int)Shape.Diamond;
            cardTwo[(int)FeatureRank.Colour] = (int)Colour.Red;
            cardTwo[(int)FeatureRank.Shading] = (int)Shading.Empty;
            cardThree[(int)FeatureRank.Count] = (int)Count.One;
            cardThree[(int)FeatureRank.Shape] = (int)Shape.Diamond;
            cardThree[(int)FeatureRank.Colour] = (int)Colour.Green;
            cardThree[(int)FeatureRank.Shading] = (int)Shading.Solid;
            submittedCards.Add(TheGame.CardToInteger(cardOne));
            submittedCards.Add(TheGame.CardToInteger(cardTwo));
            submittedCards.Add(TheGame.CardToInteger(cardThree));

            Assert.IsTrue(TheGame.IsSet(submittedCards));
        }

        /// <summary>
        /// One red solid diamond, two green shaded squiggles and three blue empty ovals
        /// </summary>
        [TestMethod]
        public void OneRedSolidDiamondTwoGreenShadedSquigglesAndThreeBlueEmptyOvalsAreSet()
        {
            List<int> submittedCards = new List<int>();
            int[] cardOne = new int[TheGame.Features];
            int[] cardTwo = new int[TheGame.Features];
            int[] cardThree = new int[TheGame.Features];
            cardOne[(int)FeatureRank.Count] = (int)Count.One;
            cardOne[(int)FeatureRank.Shape] = (int)Shape.Diamond;
            cardOne[(int)FeatureRank.Colour] = (int)Colour.Red;
            cardOne[(int)FeatureRank.Shading] = (int)Shading.Solid;
            cardTwo[(int)FeatureRank.Count] = (int)Count.Two;
            cardTwo[(int)FeatureRank.Shape] = (int)Shape.Squiggle;
            cardTwo[(int)FeatureRank.Colour] = (int)Colour.Green;
            cardTwo[(int)FeatureRank.Shading] = (int)Shading.Shaded;
            cardThree[(int)FeatureRank.Count] = (int)Count.Three;
            cardThree[(int)FeatureRank.Shape] = (int)Shape.Oval;
            cardThree[(int)FeatureRank.Colour] = (int)Colour.Blue;
            cardThree[(int)FeatureRank.Shading] = (int)Shading.Empty;
            submittedCards.Add(TheGame.CardToInteger(cardOne));
            submittedCards.Add(TheGame.CardToInteger(cardTwo));
            submittedCards.Add(TheGame.CardToInteger(cardThree));

            Assert.IsTrue(TheGame.IsSet(submittedCards));
        }

        /// <summary>
        /// Two solid red squiggles, three solid red squiggles, one solid red diamond
        /// </summary>
        [TestMethod]
        public void TwoSolidRedSquigglesThreeSolidRedSquigglesAndOneSolidRedDiamondAreNotSet()
        {
            List<int> submittedCards = new List<int>();
            int[] cardOne = new int[TheGame.Features];
            int[] cardTwo = new int[TheGame.Features];
            int[] cardThree = new int[TheGame.Features];
            cardOne[(int)FeatureRank.Count] = (int)Count.Two;
            cardOne[(int)FeatureRank.Shape] = (int)Shape.Squiggle;
            cardOne[(int)FeatureRank.Colour] = (int)Colour.Red;
            cardOne[(int)FeatureRank.Shading] = (int)Shading.Solid;
            cardTwo[(int)FeatureRank.Count] = (int)Count.Three;
            cardTwo[(int)FeatureRank.Shape] = (int)Shape.Squiggle;
            cardTwo[(int)FeatureRank.Colour] = (int)Colour.Red;
            cardTwo[(int)FeatureRank.Shading] = (int)Shading.Solid;
            cardThree[(int)FeatureRank.Count] = (int)Count.One;
            cardThree[(int)FeatureRank.Shape] = (int)Shape.Diamond;
            cardThree[(int)FeatureRank.Colour] = (int)Colour.Red;
            cardThree[(int)FeatureRank.Shading] = (int)Shading.Solid;
            submittedCards.Add(TheGame.CardToInteger(cardOne));
            submittedCards.Add(TheGame.CardToInteger(cardTwo));
            submittedCards.Add(TheGame.CardToInteger(cardThree));

            Assert.IsFalse(TheGame.IsSet(submittedCards));
        }

        /// <summary>
        /// One red solid diamond, one green solid diamond and one blue shaded diamond
        /// </summary>
        [TestMethod]
        public void OneRedSolidDiamondOneGreenSolidDiamondAndOneBlueShadedDiamondAreNotSet()
        {
            List<int> submittedCards = new List<int>();
            int[] cardOne = new int[TheGame.Features];
            int[] cardTwo = new int[TheGame.Features];
            int[] cardThree = new int[TheGame.Features];
            cardOne[(int)FeatureRank.Count] = (int)Count.One;
            cardOne[(int)FeatureRank.Shape] = (int)Shape.Diamond;
            cardOne[(int)FeatureRank.Colour] = (int)Colour.Red;
            cardOne[(int)FeatureRank.Shading] = (int)Shading.Solid;
            cardTwo[(int)FeatureRank.Count] = (int)Count.One;
            cardTwo[(int)FeatureRank.Shape] = (int)Shape.Diamond;
            cardTwo[(int)FeatureRank.Colour] = (int)Colour.Green;
            cardTwo[(int)FeatureRank.Shading] = (int)Shading.Solid;
            cardThree[(int)FeatureRank.Count] = (int)Count.One;
            cardThree[(int)FeatureRank.Shape] = (int)Shape.Diamond;
            cardThree[(int)FeatureRank.Colour] = (int)Colour.Blue;
            cardThree[(int)FeatureRank.Shading] = (int)Shading.Shaded;
            submittedCards.Add(TheGame.CardToInteger(cardOne));
            submittedCards.Add(TheGame.CardToInteger(cardTwo));
            submittedCards.Add(TheGame.CardToInteger(cardThree));

            Assert.IsFalse(TheGame.IsSet(submittedCards));
        }

        /// <summary>
        /// One red solid diamond, two green shaded ovals and two blue empty squiggles
        /// </summary>
        [TestMethod]
        public void OneRedSolidDiamondTwoGreenShadedOvalsAndTwoBlueEmptySquigglesAreNotSet()
        {
            List<int> submittedCards = new List<int>();
            int[] cardOne = new int[TheGame.Features];
            int[] cardTwo = new int[TheGame.Features];
            int[] cardThree = new int[TheGame.Features];
            cardOne[(int)FeatureRank.Count] = (int)Count.One;
            cardOne[(int)FeatureRank.Shape] = (int)Shape.Diamond;
            cardOne[(int)FeatureRank.Colour] = (int)Colour.Red;
            cardOne[(int)FeatureRank.Shading] = (int)Shading.Solid;
            cardTwo[(int)FeatureRank.Count] = (int)Count.Two;
            cardTwo[(int)FeatureRank.Shape] = (int)Shape.Oval;
            cardTwo[(int)FeatureRank.Colour] = (int)Colour.Green;
            cardTwo[(int)FeatureRank.Shading] = (int)Shading.Shaded;
            cardThree[(int)FeatureRank.Count] = (int)Count.Two;
            cardThree[(int)FeatureRank.Shape] = (int)Shape.Squiggle;
            cardThree[(int)FeatureRank.Colour] = (int)Colour.Blue;
            cardThree[(int)FeatureRank.Shading] = (int)Shading.Empty;
            submittedCards.Add(TheGame.CardToInteger(cardOne));
            submittedCards.Add(TheGame.CardToInteger(cardTwo));
            submittedCards.Add(TheGame.CardToInteger(cardThree));

            Assert.IsFalse(TheGame.IsSet(submittedCards));
        }
    }
}