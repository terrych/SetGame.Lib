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
            List<int[]> submittedCardsArray = new List<int[]>();
            List<int> submittedCardsInt = new List<int>();
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
            submittedCardsArray.Add(cardOne);
            submittedCardsArray.Add(cardTwo);
            submittedCardsArray.Add(cardThree);
            submittedCardsInt.Add(TheGame.CardArrayToInteger(cardOne));
            submittedCardsInt.Add(TheGame.CardArrayToInteger(cardTwo));
            submittedCardsInt.Add(TheGame.CardArrayToInteger(cardThree));

            Assert.IsTrue(TheGame.IsSet(submittedCardsInt) && TheGame.IsSet(submittedCardsArray));
        }

        /// <summary>
        /// Red diamonds with different counts and shading
        /// </summary>
        [TestMethod]
        public void RedDiamondsWithDifferentShadingAndCountsAreSet()
        {
            List<int[]> submittedCardsArray = new List<int[]>();
            List<int> submittedCardsInt = new List<int>();
            int[] cardOne = new int[TheGame.Features];
            int[] cardTwo = new int[TheGame.Features];
            int[] cardThree = new int[TheGame.Features];
            cardOne[(int)FeatureRank.Count] = (int)Count.Three;
            cardOne[(int)FeatureRank.Shape] = (int)Shape.Diamond;
            cardOne[(int)FeatureRank.Colour] = (int)Colour.Red;
            cardOne[(int)FeatureRank.Shading] = (int)Shading.Open;
            cardTwo[(int)FeatureRank.Count] = (int)Count.Two;
            cardTwo[(int)FeatureRank.Shape] = (int)Shape.Diamond;
            cardTwo[(int)FeatureRank.Colour] = (int)Colour.Red;
            cardTwo[(int)FeatureRank.Shading] = (int)Shading.Striped;
            cardThree[(int)FeatureRank.Count] = (int)Count.One;
            cardThree[(int)FeatureRank.Shape] = (int)Shape.Diamond;
            cardThree[(int)FeatureRank.Colour] = (int)Colour.Red;
            cardThree[(int)FeatureRank.Shading] = (int)Shading.Solid;
            submittedCardsArray.Add(cardOne);
            submittedCardsArray.Add(cardTwo);
            submittedCardsArray.Add(cardThree);
            submittedCardsInt.Add(TheGame.CardArrayToInteger(cardOne));
            submittedCardsInt.Add(TheGame.CardArrayToInteger(cardTwo));
            submittedCardsInt.Add(TheGame.CardArrayToInteger(cardThree));

            Assert.IsTrue(TheGame.IsSet(submittedCardsInt) && TheGame.IsSet(submittedCardsArray));
        }

        /// <summary>
        /// Single diamonds with different colors and shading
        /// </summary>
        [TestMethod]
        public void SingleDiamondsWithDifferentColorsAndShadingAreSet()
        {
            List<int[]> submittedCardsArray = new List<int[]>();
            List<int> submittedCardsInt = new List<int>();
            int[] cardOne = new int[TheGame.Features];
            int[] cardTwo = new int[TheGame.Features];
            int[] cardThree = new int[TheGame.Features];
            cardOne[(int)FeatureRank.Count] = (int)Count.One;
            cardOne[(int)FeatureRank.Shape] = (int)Shape.Diamond;
            cardOne[(int)FeatureRank.Colour] = (int)Colour.Blue;
            cardOne[(int)FeatureRank.Shading] = (int)Shading.Striped;
            cardTwo[(int)FeatureRank.Count] = (int)Count.One;
            cardTwo[(int)FeatureRank.Shape] = (int)Shape.Diamond;
            cardTwo[(int)FeatureRank.Colour] = (int)Colour.Red;
            cardTwo[(int)FeatureRank.Shading] = (int)Shading.Open;
            cardThree[(int)FeatureRank.Count] = (int)Count.One;
            cardThree[(int)FeatureRank.Shape] = (int)Shape.Diamond;
            cardThree[(int)FeatureRank.Colour] = (int)Colour.Green;
            cardThree[(int)FeatureRank.Shading] = (int)Shading.Solid;
            submittedCardsArray.Add(cardOne);
            submittedCardsArray.Add(cardTwo);
            submittedCardsArray.Add(cardThree);
            submittedCardsInt.Add(TheGame.CardArrayToInteger(cardOne));
            submittedCardsInt.Add(TheGame.CardArrayToInteger(cardTwo));
            submittedCardsInt.Add(TheGame.CardArrayToInteger(cardThree));

            Assert.IsTrue(TheGame.IsSet(submittedCardsInt) && TheGame.IsSet(submittedCardsArray));
        }

        /// <summary>
        /// One red solid diamond, two green shaded squiggles and three blue empty ovals
        /// </summary>
        [TestMethod]
        public void OneRedSolidDiamondTwoGreenShadedSquigglesAndThreeBlueEmptyOvalsAreSet()
        {
            List<int[]> submittedCardsArray = new List<int[]>();
            List<int> submittedCardsInt = new List<int>();
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
            cardTwo[(int)FeatureRank.Shading] = (int)Shading.Striped;
            cardThree[(int)FeatureRank.Count] = (int)Count.Three;
            cardThree[(int)FeatureRank.Shape] = (int)Shape.Oval;
            cardThree[(int)FeatureRank.Colour] = (int)Colour.Blue;
            cardThree[(int)FeatureRank.Shading] = (int)Shading.Open;
            submittedCardsArray.Add(cardOne);
            submittedCardsArray.Add(cardTwo);
            submittedCardsArray.Add(cardThree);
            submittedCardsInt.Add(TheGame.CardArrayToInteger(cardOne));
            submittedCardsInt.Add(TheGame.CardArrayToInteger(cardTwo));
            submittedCardsInt.Add(TheGame.CardArrayToInteger(cardThree));

            Assert.IsTrue(TheGame.IsSet(submittedCardsInt) && TheGame.IsSet(submittedCardsArray));
        }

        /// <summary>
        /// Two solid red squiggles, three solid red squiggles, one solid red diamond
        /// </summary>
        [TestMethod]
        public void TwoSolidRedSquigglesThreeSolidRedSquigglesAndOneSolidRedDiamondAreNotSet()
        {
            List<int[]> submittedCardsArray = new List<int[]>();
            List<int> submittedCardsInt = new List<int>();
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
            submittedCardsArray.Add(cardOne);
            submittedCardsArray.Add(cardTwo);
            submittedCardsArray.Add(cardThree);
            submittedCardsInt.Add(TheGame.CardArrayToInteger(cardOne));
            submittedCardsInt.Add(TheGame.CardArrayToInteger(cardTwo));
            submittedCardsInt.Add(TheGame.CardArrayToInteger(cardThree));

            Assert.IsTrue(!TheGame.IsSet(submittedCardsInt) && !TheGame.IsSet(submittedCardsArray));
        }

        /// <summary>
        /// One red solid diamond, one green solid diamond and one blue shaded diamond
        /// </summary>
        [TestMethod]
        public void OneRedSolidDiamondOneGreenSolidDiamondAndOneBlueShadedDiamondAreNotSet()
        {
            List<int[]> submittedCardsArray = new List<int[]>();
            List<int> submittedCardsInt = new List<int>();
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
            cardThree[(int)FeatureRank.Shading] = (int)Shading.Striped;
            submittedCardsArray.Add(cardOne);
            submittedCardsArray.Add(cardTwo);
            submittedCardsArray.Add(cardThree);
            submittedCardsInt.Add(TheGame.CardArrayToInteger(cardOne));
            submittedCardsInt.Add(TheGame.CardArrayToInteger(cardTwo));
            submittedCardsInt.Add(TheGame.CardArrayToInteger(cardThree));

            Assert.IsTrue(!TheGame.IsSet(submittedCardsInt) && !TheGame.IsSet(submittedCardsArray));
        }

        /// <summary>
        /// One red solid diamond, two green shaded ovals and two blue empty squiggles
        /// </summary>
        [TestMethod]
        public void OneRedSolidDiamondTwoGreenShadedOvalsAndTwoBlueEmptySquigglesAreNotSet()
        {
            List<int[]> submittedCardsArray = new List<int[]>();
            List<int> submittedCardsInt = new List<int>();
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
            cardTwo[(int)FeatureRank.Shading] = (int)Shading.Striped;
            cardThree[(int)FeatureRank.Count] = (int)Count.Two;
            cardThree[(int)FeatureRank.Shape] = (int)Shape.Squiggle;
            cardThree[(int)FeatureRank.Colour] = (int)Colour.Blue;
            cardThree[(int)FeatureRank.Shading] = (int)Shading.Open;
            submittedCardsArray.Add(cardOne);
            submittedCardsArray.Add(cardTwo);
            submittedCardsArray.Add(cardThree);
            submittedCardsInt.Add(TheGame.CardArrayToInteger(cardOne));
            submittedCardsInt.Add(TheGame.CardArrayToInteger(cardTwo));
            submittedCardsInt.Add(TheGame.CardArrayToInteger(cardThree));

            Assert.IsTrue(!TheGame.IsSet(submittedCardsInt) && !TheGame.IsSet(submittedCardsArray));
        }
    }
}