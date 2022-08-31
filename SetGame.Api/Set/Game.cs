namespace SetGame.Set
{
    public class Game
    {
        public Guid Id { get; private set; }

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

        private int[] PositionalValues;

        public int BoardSize { get; private set; }

        public int SetSize { get; private set; }

        public List<int[]> Board { get; private set; }

        /// <summary>
        /// Original is 3 variations, 4 features (count, shape, shading and colour)
        /// </summary>
        /// <param name="variations"></param>
        /// <param name="features"></param>
        public Game(int variations, int features)
        {
            Id = Guid.NewGuid();
            Deck = new List<int>();
            Variations = variations;
            Features = features;
            BoardSize = variations * features; // will probably need to mess with this
            Board = new List<int[]>();
            RandGen = new Random();
            PositionalValues = new int[features];
            SetSize = variations;
            for (int i = 0; i < features; i++)
            {
                PositionalValues[i] = (int) Math.Pow(variations, i);
            }
            
            Deck = Enumerable.Range(0, (int) Math.Pow(variations, features)).ToList();
            DealCards(BoardSize);
        }

        public void DealCards(int countToDeal)
        {
            for (int i = 0; i < countToDeal; i++)
            {
                var cardIndex = RandGen.Next(Deck.Count);
                Board.Add(IntegerToCard(Deck[cardIndex]));
                Deck.RemoveAt(cardIndex);
            }
        }

        public bool CheckSet(IEnumerable<int> submittedCards)
        {
            var toReturn = IsSet(submittedCards);
            if (toReturn)
            {
                foreach (var card in submittedCards)
                {
                    // do removal and stuff
                }
            }

            return toReturn;
        }

        /* Note that if we knew we were playing the original, this method would
         * be as simple as checking if the positional values summed to 0, 3 or 6
         * since this would mean we have either {000,111,012(or different orders),222}
         * and nothing else.
         * Unfortunately since I have decided on more complicated requirements I cannot do that.
         */
        public bool IsSet(IEnumerable<int> submittedCards)
        {
            if (submittedCards.Count() != SetSize)
            {
                return false;
            }

            var convertedCards = new List<int[]>();
            foreach (var card in submittedCards)
            {
                convertedCards.Add(DecimalToBaseVariations(card));
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

        public int[] IntegerToCard(int cardValue)
        {
            return DecimalToBaseVariations(cardValue);
        }

        public int CardToInteger(int[] cardFeatures)
        {
            var toReturn = 0;
            for (int i = 0; i < cardFeatures.Length; i++)
            {
                toReturn += PositionalValues[i] * cardFeatures[i];
            }
            return toReturn;
        }

        private int[] DecimalToBaseVariations(int theDecimal)
        {
            int[] toReturn = new int[Features];
            int remainder = theDecimal;
            for (int i = Features - 1; i >= 0; i--)
            {
                toReturn[i] = remainder / PositionalValues[i];
                remainder = remainder % PositionalValues[i];
            }

            return toReturn;
        }
    }
}
