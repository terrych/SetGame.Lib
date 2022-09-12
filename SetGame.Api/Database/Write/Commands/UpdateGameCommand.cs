using SetGame.Set;

namespace SetGame.Api.Database.Write.Commands
{
    public class UpdateGameCommand
    {
        public Guid GameId { get; set; }
        public Game Game { get; set; }
    }
}
