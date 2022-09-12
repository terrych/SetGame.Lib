using Microsoft.EntityFrameworkCore;
using SetGame.Api.Database.Models;

namespace SetGame.Api.Database
{
    public class SetGameContext : DbContext
    {
        public SetGameContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<GameModel> Games { get; set; }
    }
}
