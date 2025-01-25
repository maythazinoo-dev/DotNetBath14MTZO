using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetBath14MTZO.SnakeGame.ConsoleApp
{
    [Table("Tbl_GameBoard")]
    public class BoardModel
    {
        [Key]
        public int BoardID { get; set; }
        public int CellNumber { get; set; }
        public string? CellType { get; set; }
        public int? MoveToCell { get; set; }

    }



}
