using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetBath14MTZO.Emoji.MinimalApi.Feautres
{
    [Table("Tbl_Emoji")]
    public class EmojiModel
    {
        [Key]
        public int? EmojiId { get; set; }
        public string Emoji {  get; set; }
        public string Name { get; set; }
        public string Shortname { get; set; }
        public string Unicode { get; set; }
        public string Html { get; set; }
        public string Category { get; set; }
        [Column("EmojiOrder")]
        public string? Order { get; set; }
        
    }

    public class EmojiResponseModel
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public EmojiModel Data { get; set; }
    }
    
    public class EmojiListResponseModel
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public List<EmojiModel> Data { get; set; }
    }

    public class EmojiRequestModel
    {
        public List<EmojiModel> Emojis { get; set; }
    }

}

