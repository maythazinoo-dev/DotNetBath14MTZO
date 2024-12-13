using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetBath14MTZO.ConsoleApp4;

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
    public BlogModel blogModel { get; set; }
}

public class BlogListResponseModel
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; }
    public List<BlogModel> blogModels { get; set; }
}

