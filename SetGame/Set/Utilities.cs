namespace SetGame.Set
{
    public static class Utilities
    {
        /// <summary>
        /// Converts from decimal to base provided. Positional values for base can be provided to prevent extra calculation.
        /// </summary>
        /// <param name="theDecimal"></param>
        /// <param name="features"></param>
        /// <param name="baseValues"></param>
        /// <returns></returns>
        public static int[] DecimalToBaseFeatureCount(int theDecimal, int features, int[] baseValues)
        {
            if (!baseValues.Any())
            {
                baseValues = new int[features];
                for (int i = 0; i < features; i++)
                {
                    baseValues[i] = (int)Math.Pow(variations, i);
                }
            }

            int[] toReturn = new int[features];
            int remainder = theDecimal;
            for (int i = features - 1; i >= 0; i--)
            {
                toReturn[i] = remainder / baseValues[i];
                remainder = remainder % baseValues[i];
            }

            return toReturn;
        }
    }
}
