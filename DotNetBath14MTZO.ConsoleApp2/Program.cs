// See https://aka.ms/new-console-template for more information
using DotNetBath14MTZO.Shared;

Console.WriteLine("Hello, World!");

IBlogService blogService = new BlogService();
blogService.CreateBlog(new BlogModel
{
    BlogId = Guid.NewGuid().ToString(),
    BlogTitle = "Blog Title",
    BlogAuthor="Blog Author",
    BlogContent="Blog Content"
});