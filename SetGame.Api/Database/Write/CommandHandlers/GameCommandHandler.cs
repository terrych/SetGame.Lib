using Newtonsoft.Json;
using SetGame.Api.Database.Models;
using SetGame.Api.Database.Write.Commands;
using SetGame.Set;

namespace SetGame.Api.Database.Write.CommandHandlers
{
    public class GameCommandHandler : ICommandHandler<NewGameCommand, Game>, ICommandHandler<UpdateGameCommand>
    {
        private readonly SetGameContext _setGameContext;

        public GameCommandHandler(SetGameContext setGameContext)
        {
            _setGameContext = setGameContext;
        }

        public Game Execute(NewGameCommand command)
        {
            var now = DateTime.Now;
            _setGameContext.Games.Add(
                new GameModel() 
                { 
                    Id = command.Game.Id, 
                    GameJson = JsonConvert.SerializeObject(command.Game),
                    Created = now,
                    LastUpdated = now
                });
            _setGameContext.SaveChanges();
            return command.Game;
        }

        public void Execute(UpdateGameCommand command)
        {
            var theGame = _setGameContext.Games.Where(x => x.Id.Equals(command.GameId)).FirstOrDefault();
            theGame.GameJson = JsonConvert.SerializeObject(command.Game);
            _setGameContext.SaveChanges();
        }
    }
}
