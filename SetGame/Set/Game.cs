namespace SetGame.Set
{
    public class Game
    {
        /// <summary>
        /// Number of variations on each feature possible e.g. for original this would be 3 {count can be 1,2 or 3}.
        /// Also how many you need to make a set.
        /// Mathematically the base or radix for the card numbers.
        /// </summary>
        public int Variations { get; private set; }

        /// <summary>
        /// Number of features e.g. shape, count, shading, colour.
        /// Original game has 4.
        /// Mathematically the power for the card numbers.
        /// </summary>
        public int Features { get; private set; }

        private List<int> Deck;

        private Random RandGen;

        private int[] BaseValues;

        public int BoardSize { get; private set; }

        public HashSet<int> Board { get; private set; }

        /// <summary>
        /// Original is 3 variations and 4 features (count, shape, shading and colour).
        /// </summary>
        /// <param name="variations"></param>
        /// <param name="features"></param>
        public Game(int variations, int features)
        {
            Deck = new List<int>();
            Variations = variations;
            Features = features;
            BoardSize = variations * features;
            Board = new HashSet<int>();
            RandGen = new Random();
            BaseValues = new int[features];
            for (int i = 0; i < features; i++)
            {
                BaseValues[i] = (int) Math.Pow(variations, i);
            }
            
            Deck = Enumerable.Range(0, (int)Math.Pow(variations, features)).ToList();
            InitialDeal(BoardSize);
        }

        public void InitialDeal(int countToDeal)
        {
            for (int i = 0; i < countToDeal; i++)
            {
                var cardIndex = RandGen.Next(Deck.Count);
                Board.Add(Deck[cardIndex]);
                Deck.RemoveAt(cardIndex);
            }
        }

        /* Note that if we knew we were playing the original, this method would
         * be as simple as checking if the positional values summed to 0, 3 or 6
         * since this would mean we have either {000,111,012(or different orders),222}
         * and nothing else.
         * Unfortunately since I have decided on more complicated requirements I cannot do that.
         */
        public bool IsSet(IEnumerable<int> submittedCards)
        {
            var convertedCards = new List<int[]>();
            foreach (var card in submittedCards)
            {
                convertedCards.Add(DecimalToBaseFeatureCount(card));
            }

            var hashSet = new HashSet<int>();
            for (int i = 0; i < Features; i++) // for each feature
            {
                foreach (var card in convertedCards) // collect the values
                {
                    hashSet.Add(card[i]);
                }

                // and check if they are all the same or all different
                if (hashSet.Count != 1 && hashSet.Count != Variations)
                {
                    // if neither, it's not a set
                    return false;
                }

                hashSet.Clear();
            }

            return true;
        }

        private int[] DecimalToBaseFeatureCount(int theDecimal)
        {
            int[] toReturn = new int[Features];
            int remainder = theDecimal;
            for (int i = Features - 1; i >= 0; i--)
            {
                toReturn[i] = remainder / BaseValues[i];
                remainder = remainder % BaseValues[i];
            }

            return toReturn;
        }
    }
}
