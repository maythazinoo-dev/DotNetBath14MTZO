using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DotNetBath14MTZO.SnakeGame.ConsoleApp
{
    [Table("Tbl_Players")]
    public class PlayerModel
    {
        [Key]
        public int PlayerID { get; set; }
        public string? PlayerName { get; set; }
        public int CurrentPosition { get; set; }
    }


}
