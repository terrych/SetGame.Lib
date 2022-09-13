namespace SetGame.Api.Set
{
    public class GameViewModel
    {
        public Guid Id { get; set; }

        public int Variations { get; set; }

        public int Features { get; set; }

        public int BoardSize { get; set; }

        public int SetSize { get; set; }

        public List<int[]> Board { get; set; }

        public List<int[]> SelectedCards { get; set; }

        public List<int> HighlightedCards { get; set; }

        public string Message { get; set; }
    }
}
