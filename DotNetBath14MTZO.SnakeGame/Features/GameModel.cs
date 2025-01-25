using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetBath14MTZO.SnakeGame.Features
{
    [Table("Tbl_Game")]
    public class GameModel
    {
        [Key]
        public int GameID { get; set; }
        public string? GameStatus { get; set; }
        public int? CurrentPlayerID { get; set; }
        [ForeignKey("CurrentPlayerID")]
        public PlayerModel? CurrentPlayer { get; set; }
        public int? members { get; set; }
    }


}
