using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetBath14MTZO.SnakesAndLadderGame.Features
{
    [Table("Tbl_Game")]
    public class GameModel
    {
        [Key]
        public int GameId { get; set; }
        public string? GameStatus { get; set; }
        public int CurrentPlayerId { get; set; }
    }

    public class GameResponseModel {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
