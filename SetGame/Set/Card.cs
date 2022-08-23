namespace SetGame.Set
{
    public class Card
    {
        public int Value { get; private set; }

        public int[] Features { get; private set; }

        public Card(int featureCount, int variationsCount, int value)
        {
            Value = value;
        }

        // Will take the feature count from length of features array. Currently will not plan for this being incorrectly provided.
        public Card(int variationsCount, int[] features)
        {
            Features = features;
        }
    }
}
