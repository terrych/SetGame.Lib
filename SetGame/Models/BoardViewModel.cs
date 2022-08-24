using SetGame.Set;
using SetGame.Set.CardElements;
using SetGame.Set.CardElements.FeatureEnums;
using System.Text;

namespace SetGame.Models
{
    public class BoardViewModel
    {
        public List<Card> Cards { get; private set; }

        public BoardViewModel(Game game)
        {
            Cards = new List<Card>();

            foreach (var cardValue in game.Board)
            {
                Cards.Add(new Card(game, cardValue));
            }
        }
    }

    public class Card
    {
        public Dictionary<string, string> Attributes { get; private set; }
        public string Image { get; private set; }

        public Card(Game game, int value)
        {
            Attributes = new Dictionary<string, string>();

            var card = game.IntegerToCard(value);
            for (int i = 0; i < game.Features; i++)
            {
                var feature = ((FeatureRank)i).ToString();
                var enumType = Type.GetType("SetGame.Set.CardElements.FeatureEnums." + feature);
                Attributes[feature] = enumType == typeof(Count) ? (card[i]+1).ToString() : Enum.ToObject(enumType, card[i]).ToString();
            }
            Attributes["CardValue"] = value.ToString();

            var sb = new StringBuilder();
            sb.Append(Attributes["Shape"]);
            sb.Append("_");
            sb.Append(Attributes["Shading"]);
            sb.Append("_");
            sb.Append(Attributes["Colour"]);
            sb.Append(".png");

            Image = sb.ToString().ToLowerInvariant();
        }
    }
}
