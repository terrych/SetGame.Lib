using SetGame.Api.Set;

namespace SetGame.Set
{
    public class Game
    {
        public Guid Id { get; set; }

        /// <summary>
        /// Number of variations on each feature possible e.g. for original this would be 3 {count can be 1,2 or 3}.
        /// Also how many you need to make a set.
        /// Mathematically the base or radix for the card numbers.
        /// </summary>
        public int Variations { get; set; }

        /// <summary>
        /// Number of features e.g. shape, count, shading, colour.
        /// Original game has 4.
        /// Mathematically the power for the card numbers.
        /// </summary>
        public int Features { get; set; }

        public List<int> Deck;

        private Random RandGen;

        public int[] PositionalValues;

        public int BoardSize { get; set; }

        public int SetSize { get; set; }

        public List<int[]> Board { get; set; }

        public List<int[]> SelectedCards { get; set; }

        /// <summary>
        /// Meant to be used when clicking "Find Set" so player is made aware of possible set. Integers are indexes of cards on board in set.
        /// </summary>
        public List<int> HighlightedCards { get; set; }

        public Game()
        {
            RandGen = new Random();
        }

        /// <summary>
        /// Original is 3 variations, 4 features (count, shape, shading and colour)
        /// </summary>
        /// <param name="variations"></param>
        /// <param name="features"></param>
        public Game InitializeNewGame(int variations, int features)
        {
            Id = Guid.NewGuid();
            Deck = new List<int>();
            Variations = variations;
            Features = features;
            BoardSize = variations * features; // will probably want to mess with this or add as a setting
            Board = new List<int[]>();
            SelectedCards = new List<int[]>();
            RandGen = new Random();
            PositionalValues = new int[features];
            SetSize = variations;
            for (int i = 0; i < features; i++)
            {
                PositionalValues[i] = (int)Math.Pow(variations, i);
            }

            Deck = Enumerable.Range(0, (int)Math.Pow(variations, features)).ToList();
            DealCards(BoardSize);

            return this;
        }

        /* Need to run experiments on hashset initialization & lookup time vs list lookup time for collections of the size we will be dealing with. 
         * For 3,4 set I would be unsurprised if list is quicker, but beyond that we may be seeing hashset become faster.
         * 
         * If we pick any two cards, we have determined the remaining cards required for a set so the number of lookups required will be a product of 
         * the number of combinations of two cards on the board (the boardcount-1 triangular number) and the setSize-2.
         * 
         * Maybe mess with hash sets for feature values for quicker lookup (use join etc to narrow down plausible space).
         * 
         * I will start with just the list collection since I am only building for 3,4 set for now.
         */
        public List<int> FindSet() // This method is pretty much the reason why I bothered with this project. The goal will be to optimize it.
        {
            List<int> toReturn = new List<int>();
            for (int i = 0; i < Board.Count; i++)
            {
                for (int j = i + 1; j < Board.Count; j++)
                {
                    toReturn.Add(i);
                    toReturn.Add(j);
                    int[] required = RequiredForSet(Board[i], Board[j]); // array or list?
                    bool isSet = true;

                    var index = Board.FindIndex(x => x.SequenceEqual(required));
                    if (index == -1)
                    {
                        isSet = false;
                        toReturn.RemoveAll(x => true); // don't need to remove all, but it's easier for now
                    }
                    else toReturn.Add(index);

                    if (isSet) 
                        return toReturn;
                }
            }

            return new List<int>();
        }

        private int[] RequiredForSet(int[] ints1, int[] ints2) // This only works for set size and variation 3, will need to change all this. For now looking for MVP
        {
            int[] result = new int[ints1.Length];
            for (int i = 0; i < ints1.Length; i++)
            {
                if (ints1[i] == ints2[i]) result[i] = ints1[i];
                else result[i] = 3 - ints1[i] - ints2[i];
            }

            return result;
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

        public GameViewModel ToViewModel()
        {
            return ToViewModel(string.Empty);
        }

        public GameViewModel ToViewModel(string message)
        {
            var gvm = new GameViewModel()
            {
                Id = Id,
                Variations = Variations,
                Features = Features,
                BoardSize = BoardSize,
                SetSize = SetSize,
                Board = Board,
                SelectedCards = SelectedCards,
                HighlightedCards = HighlightedCards,
                Message = message
            };
            return gvm;
        }

        public int[] IntegerToCard(int cardValue)
        {
            return DecimalToBaseVariations(cardValue);
        }

        public int CardArrayToInteger(int[] cardFeatures)
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
