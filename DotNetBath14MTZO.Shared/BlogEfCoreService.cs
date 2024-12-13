using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DotNetBath14MTZO.Shared;

public class BlogEfCoreService : IBlogService
{
    private readonly AppDbContext _context;
    public BlogEfCoreService()
    {
        _context = new AppDbContext();
    }

    public List<BlogModel> GetBlogs()
    {
        var list = _context.Blogs.ToList();
        return list;
    }

    public BlogModel GetBlog(string Id)
    {
        var item = _context.Blogs.AsNoTracking().FirstOrDefault(x => x.BlogId == Id);
        return item!;
    }

    public BlogResponseModel CreateBlog([FromBody] BlogModel requestModel)
    {

        _context.Blogs.Add(requestModel);
        int result = _context.SaveChanges();
        BlogResponseModel model = new BlogResponseModel();
        string message = result > 0 ? "Create is successful" : "Create is Failed";
        model.IsSuccess = result > 0;
        model.Message = message;
        return model;
    }

    public BlogResponseModel UpsertBlog(BlogModel requestModel)
    {
        BlogResponseModel model = new BlogResponseModel();
        var item = _context.Blogs.AsNoTracking().FirstOrDefault(x => x.BlogId == requestModel.BlogId);
        if (item is null)
        {
            model = CreateBlog(requestModel);
            return model;
        }

        if (!string.IsNullOrEmpty(requestModel.BlogTitle))
        {
            item.BlogTitle = requestModel.BlogTitle;
        }
        if (!string.IsNullOrEmpty(requestModel.BlogAuthor))
        {
            item.BlogAuthor = requestModel.BlogAuthor;
        }
        if (!string.IsNullOrEmpty(requestModel.BlogContent))
        {
            item.BlogContent = requestModel.BlogContent;
        }


        _context.Entry(item).State = EntityState.Modified;
        int result = _context.SaveChanges();

        string message = result > 0 ? "Update Successful!!!!!!!!!" : "Update Failed!!!!!!";
        model.IsSuccess = result > 0;
        model.Message = message;
        return model;

    }

    public BlogResponseModel UpdateBlog(BlogModel requestModel)
    {
        var blog = GetBlog(requestModel.BlogId!);
        if (blog is null)
        {
            return new BlogResponseModel()
            {
                IsSuccess = false,
                Message = "Not Found Data"
            };
        }

        if (string.IsNullOrEmpty(requestModel.BlogTitle))
        {
            blog.BlogTitle = requestModel.BlogTitle;
        }
        if (string.IsNullOrEmpty(requestModel.BlogAuthor))
        {
            blog.BlogAuthor = requestModel.BlogAuthor;
        }
        if (string.IsNullOrEmpty(requestModel.BlogContent))
        {
            blog.BlogContent = requestModel.BlogContent;
        }

        _context.Entry(blog).State = EntityState.Modified;
        int result = _context.SaveChanges();
        string message = result > 0 ? "Updating Successful !!!" : "Updating Failed !!!!";
        BlogResponseModel model = new BlogResponseModel();
        model.IsSuccess = result > 0;
        model.Message = message;
        return model;
    }

    public BlogResponseModel DeleteBlog(string id)
    {
        var item = _context.Blogs.AsNoTracking().FirstOrDefault(b => b.BlogId == id);
        int result = _context.SaveChanges();
        string message = result > 0 ? "Delete is successful !!!" : "Delete is failed !!!";
        BlogResponseModel model = new BlogResponseModel();
        model.IsSuccess = result > 0;
        model.Message = message;
        return model;

    }
}
