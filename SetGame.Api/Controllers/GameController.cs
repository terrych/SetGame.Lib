using Microsoft.AspNetCore.Mvc;
using SetGame.Models;
using SetGame.Set;
using System.Diagnostics;

namespace SetGame.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var game = new Game(3, 4);
            var boardViewModel = new BoardViewModel(game);

            return View(boardViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult NewGame()
        {
            var game = new Game(3, 4);
            var boardViewModel = new BoardViewModel(game);

            return View("Index", boardViewModel);
        }

        public IActionResult FindSet()
        {
            var breakpoint = 0;

            return View("Index");
        }

        public IActionResult OpenThreeCards()
        {
            var breakpoint = 0;

            return View("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}