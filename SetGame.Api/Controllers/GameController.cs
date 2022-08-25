using Microsoft.AspNetCore.Mvc;
using SetGame.Set;
using System.Diagnostics;

namespace SetGame.Controllers
{
    public class GameController : Controller //may need to later go with ControllerBase if it turns out this is MVC specific controller
    {
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