
namespace DotNetBath14MTZO.RestApi.Features.Blog
{
    public class BlogModel
    {
        public string? BlogId    { get; set; }
        public string? BlogTitle { get; set; }
        public string? BlogAuthor { get; set; }
        public string? BlogContent { get; set; }

        internal static void UseDeveloperExceptionPage()
        {
            throw new NotImplementedException();
        }
    }
    public class BlogResponseModel
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }

}
