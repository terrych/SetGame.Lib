using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SetGame.Api.Database.Read.QueryHandlers;
using SetGame.Api.Database.Write.CommandHandlers;
using SetGame.Api.Database.Write.Commands;
using SetGame.Api.Set;
using SetGame.Set;
using System.Diagnostics;
using System.Runtime.Serialization.Formatters.Binary;

namespace SetGame.Controllers
{
    [ApiController]
    [Route("Game")]
    //[ApiExplorerSettings(IgnoreApi = true)]
    public class GameController : ControllerBase //may need to later go with ControllerBase if it turns out this is MVC specific controller
    {
        private readonly ILogger<GameController> _logger;
        private readonly ICommandHandler<NewGameCommand, Game> _createGameCommandHandler;
        private readonly ICommandHandler<UpdateGameCommand> _updateGameCommandHandler;
        private readonly IQueryHandler<Guid, Game> _gameQueryHandler;
        
        public GameController(ILogger<GameController> logger, ICommandHandler<NewGameCommand, Game> createGameCommandHandler, ICommandHandler<UpdateGameCommand> updateGameCommandHandler, IQueryHandler<Guid, Game> gameQueryHandler)
        {
            _logger = logger;
            _createGameCommandHandler = createGameCommandHandler;
            _updateGameCommandHandler = updateGameCommandHandler;
            _gameQueryHandler = gameQueryHandler;
        }

        [HttpGet("NewGame")]
        public GameViewModel NewGame(int variations, int features) // also add setsize etc?
        {
            var newGame = new Game(variations, features);
            _createGameCommandHandler.Execute(new NewGameCommand() { Game = newGame });

            return newGame.ToViewModel();
        }

        [HttpGet("FindSet")]
        public GameViewModel FindSet(/*Guid gameId*/) // return board with highlights
        {
            var breakpoint = 0;

            return new Game(3, 4).ToViewModel(); ;
        }

        [HttpGet("OpenThreeCards")]
        public GameViewModel OpenThreeCards(Guid gameId) // return board
        {
            var theGame = _gameQueryHandler.Execute(gameId);
            theGame.DealCards(3);
            _updateGameCommandHandler.Execute(new UpdateGameCommand() { GameId = theGame.Id, Game = theGame });
            return theGame.ToViewModel();
        }

        [HttpPut("SubmitSet")]
        public GameViewModel SubmitSet(/*Guid gameId,*/ [FromBody] List<List<int>> input) // return board
        {
            var breakpoint = 0;
            return new Game(3, 4).ToViewModel(); ;
        }
    }
}