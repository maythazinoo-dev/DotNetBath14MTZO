using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetBath14MTZO.SnakesAndLadderGame.Features
{
    [Table("Tbl_GameBoard")]
    public class BoardModel
    {
        [Key]
        public int BoardId { get; set; }
        public int BoardCellNumber { get; set; }
        public string? BoardCellType { get; set; }
        public int? BoardMoveToCell { get; set; }

    }
    public class BoardResponseModel {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
}
    
   
}
