using Microsoft.AspNetCore.Mvc;
using SetGame.Set;
using System.Diagnostics;

namespace SetGame.Controllers
{
    [ApiController]
    [Route("Game")]
    //[ApiExplorerSettings(IgnoreApi = true)]
    public class GameController : ControllerBase //may need to later go with ControllerBase if it turns out this is MVC specific controller
    {
        private readonly ILogger<GameController> _logger;
        
        public GameController(ILogger<GameController> logger)
        {
            _logger = logger;
        }

        [HttpGet("NewGame")]
        public Game NewGame(int variations, int features) // also add setsize etc?
        {
            return new Game(3, 4); // update to inputs later
        }

        [HttpGet("FindSet")]
        public List<int> FindSet() // return board with highlights
        {
            var breakpoint = 0;

            return new List<int>();
        }

        [HttpGet("OpenThreeCards")]
        public List<int> OpenThreeCards() // return board
        {
            var breakpoint = 0;

            return new List<int>();
        }
    }
}