﻿using SetGame.Lib.Test.CardElements;
using SetGame.Lib.Test.CardElements.FeatureEnums;

namespace SetGame.Test
{
    [TestClass]
    public class OriginalGameCardToIntTests : OriginalGameTests
    {
        [TestMethod]
        public void OneBlueShadedDiamondIs48()
        {
            int[] theCard = new int[TheGame.Features];
            theCard[(int)FeatureRank.Count] = (int)Count.One;
            theCard[(int)FeatureRank.Shape] = (int)Shape.Diamond;
            theCard[(int)FeatureRank.Colour] = (int)Colour.Blue;
            theCard[(int)FeatureRank.Shading] = (int)Shading.Striped;

            Assert.IsTrue(TheGame.CardArrayToInteger(theCard) == 48);
        }

        [TestMethod]
        public void ThreeRedShadedSquigglesIs29()
        {
            int[] theCard = new int[TheGame.Features];
            theCard[(int)FeatureRank.Count] = (int)Count.Three;
            theCard[(int)FeatureRank.Shape] = (int)Shape.Squiggle;
            theCard[(int)FeatureRank.Colour] = (int)Colour.Red;
            theCard[(int)FeatureRank.Shading] = (int)Shading.Striped;

            Assert.IsTrue(TheGame.CardArrayToInteger(theCard) == 29);
        }
    }
}