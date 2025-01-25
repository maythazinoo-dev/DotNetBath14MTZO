using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetBath14MTZO.SnakeAndLadder.Shared
{
    [Table("Tbl_GameMoves")]
    public class GameMoveModel
    {
        [Key]
        public int MoveID { get; set; }
        public int GameID { get; set; }
        [ForeignKey("GameID")]
        public GameModel? Game { get; set; }
        public int PlayerID { get; set; }
        [ForeignKey("PlayerID")]
        public PlayerModel? Player { get; set; }
        public int FromCell { get; set; }
        public int ToCell { get; set; }
        public DateTime MoveDate { get; set; } = DateTime.Now;

    }

}


