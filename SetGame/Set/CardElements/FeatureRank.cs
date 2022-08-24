using SetGame.Set.CardElements.FeatureEnums;
using System.ComponentModel;

namespace SetGame.Set.CardElements
{
    public enum FeatureRank
    {
        [Description("SetGame.Set.CardElements.FeatureEnums.Count")]
        Count = 0,
        [Description("SetGame.Set.CardElements.FeatureEnums.Shape")]
        Shape = 1,
        [Description("SetGame.Set.CardElements.FeatureEnums.Colour")]
        Colour = 2,
        [Description("SetGame.Set.CardElements.FeatureEnums.Shading")]
        Shading = 3,
    }
}
