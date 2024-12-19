using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DotNetBath14MTZO.SnakesAndLadderGame.Features
{
    [Table("Tbl_Players")]
    public class PlayerModel
    {
        [Key]
        public int ? PlayerId { get; set; }
        public string? PlayerName { get; set; }
        public int? PlayerCurrentPosition { get; set; }
    }

    public class PlayerResponseModel 
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }

}
