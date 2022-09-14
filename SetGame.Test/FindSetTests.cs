using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using SetGame.Set;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetGame.Test
{

    [TestClass]
    public class FindSetTests
    {
        [TestMethod]
        public void ThisBoardHasASet()
        {
            string jsonGame = "{\"id\":\"933336d8-626a-4785-8fc5-de75058f7d32\",\"variations\":3,\"features\":4,\"boardSize\":12,\"setSize\":3,\"board\":[[2,0,0,1],[1,0,0,0],[1,2,1,2],[0,2,2,2],[0,2,1,2],[2,2,2,1],[0,0,0,0],[0,1,2,0],[0,1,0,1],[2,2,0,1],[1,1,0,0],[2,0,2,2]],\"selectedCards\":[],\"highlightedCards\":[],\"message\":\"Is a set!\"}";
            var theGame = JsonConvert.DeserializeObject<Game>(jsonGame);
            Assert.IsTrue(theGame.FindSet().Any());
        }

        [TestMethod]
        public void ThisBoardDoesNotHaveASet()
        {
            string jsonGame = "{\"id\":\"933336d8-626a-4785-8fc5-de75058f7d32\",\"variations\":3,\"features\":4,\"boardSize\":12,\"setSize\":3,\"board\":[[0,0,2,1],[1,0,0,0],[1,0,1,0],[0,2,2,2],[0,2,1,2],[2,2,2,1],[0,0,0,0],[1,0,2,2],[0,1,0,1],[2,2,0,1],[0,0,0,2],[2,0,2,2]],\"selectedCards\":[],\"highlightedCards\":[],\"message\":\"No set was found, deal more cards.\"}";
            var theGame = JsonConvert.DeserializeObject<Game>(jsonGame);
            Assert.IsFalse(theGame.FindSet().Any());
        }
    }
}
