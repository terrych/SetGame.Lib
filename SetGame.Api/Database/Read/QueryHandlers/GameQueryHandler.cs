using Newtonsoft.Json;
using SetGame.Api.Database.Models;
using SetGame.Set;

namespace SetGame.Api.Database.Read.QueryHandlers
{
    public class GameQueryHandler : IQueryHandler<Guid, Game>
    {
        private readonly SetGameContext _setGameContext;

        public GameQueryHandler(SetGameContext setGameContext)
        {
            _setGameContext = setGameContext;
        }

        public Game Execute(Guid query)
        {
            GameModel gameModel = _setGameContext.Games.Where(x => x.Id.Equals(query)).First();
            Game game = JsonConvert.DeserializeObject<Game>(gameModel.GameJson);
            return game;
        }
    }
}
