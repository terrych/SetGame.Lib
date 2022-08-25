using Microsoft.AspNetCore.Mvc;
using SetGame.Set;
using System.Diagnostics;

namespace SetGame.Controllers
{
    public class GameController : Controller //may need to later go with ControllerBase if it turns out this is MVC specific controller
    {
        private readonly ILogger<GameController> _logger;

        public GameController(ILogger<GameController> logger)
        {
            _logger = logger;
        }

        //public IActionResult Index()
        //{
        //    var game = new Game(3, 4);
        //    var boardViewModel = new BoardViewModel(game);
        //
        //    return View(boardViewModel);
        //}
        //
        //public IActionResult Privacy()
        //{
        //    return View();
        //}
        //
        //public IActionResult NewGame()
        //{
        //    var game = new Game(3, 4);
        //    var boardViewModel = new BoardViewModel(game);
        //
        //    return View("Index", boardViewModel);
        //}
        //
        //public IActionResult FindSet()
        //{
        //    var breakpoint = 0;
        //
        //    return View("Index");
        //}
        //
        //public IActionResult OpenThreeCards()
        //{
        //    var breakpoint = 0;
        //
        //    return View("Index");
        //}
        //
        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}

        // add the verb stuff
        public Game NewGame(int variations, int features) // also add setsize etc?
        {
            return new Game(3, 4); // update to inputs later
        }

        // add the verb stuff
        public List<int> FindSet() // return board with highlights
        {
            var breakpoint = 0;

            return new List<int>();
        }

        // add the verb stuff
        public List<int> OpenThreeCards() // return board
        {
            var breakpoint = 0;

            return new List<int>();
        }
    }
}