using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SetGame.Api.Database.Models
{
    [Table("Game")]
    public class GameModel
    {
        [Key]
        public Guid Id { get; set; }

        public string GameJson { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
