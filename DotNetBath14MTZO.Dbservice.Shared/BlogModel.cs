using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetBath14MTZO.Dbservice.Shared;

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
    public bool IsSuccess { get; set; }
    public string Message { get; set; }
    public BlogModel data { get; set; }
}

public class BlogListResponseModel
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; }
    public List<BlogModel> data { get; set; }
}
