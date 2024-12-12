﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetBath14MTZO.RestApi.Features.Blog
{
    [Table("Tbl_Blog")]
    public class BlogModel
    {
        [Key]
        public string? BlogId { get; set; }  
        public string? BlogTitle { get; set; }
        public string? BlogAuthor { get; set; }
        public string? BlogContent { get; set; }
    }
    public class BlogResponseModel
    {
        public bool IsSuccess {get; set;}
        public string Message {get ; set;}
    }

}
