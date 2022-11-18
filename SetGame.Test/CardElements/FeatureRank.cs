using CM = System.ComponentModel;

namespace SetGame.Lib.Test.CardElements
{
    public enum FeatureRank
    {
        [CM.Description("SetGame.Set.CardElements.FeatureEnums.Count")]
        Count = 0,
        [CM.Description("SetGame.Set.CardElements.FeatureEnums.Shape")]
        Shape = 1,
        [CM.Description("SetGame.Set.CardElements.FeatureEnums.Colour")]
        Colour = 2,
        [CM.Description("SetGame.Set.CardElements.FeatureEnums.Shading")]
        Shading = 3,
    }
}
