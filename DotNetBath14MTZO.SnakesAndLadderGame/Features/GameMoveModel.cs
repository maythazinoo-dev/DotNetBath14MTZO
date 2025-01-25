using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetBath14MTZO.SnakesAndLadderGame.Features
{
    [Table("Tbl_GameMoves")]
    public class GameMoveModel
    {
        [Key]
        public int MoveId { get; set; }
        public int GameId { get; set; }
        public int PlayerId { get; set;}
        public int FromCell {  get; set; }  
        public int ToCell { get; set; }
        public DateTime MoveDate { get; set; }

    }


    public class GameMoveResponseModel
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}


