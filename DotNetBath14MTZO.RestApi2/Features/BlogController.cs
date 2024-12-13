using DotNetBath14MTZO.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace DotNetBath14MTZO.RestApi2.Features;

[Route("api/[controller]")]
[ApiController]
public class BlogController : ControllerBase
{
    private readonly IBlogService _blogService;
    public BlogController()
    {
        //_blogService = new BlogService();
        //_blogService = new BlogDapperService();
        _blogService = new BlogEfCoreService();
    }

    [HttpGet]

    public IActionResult GetBlogs()
    {
        try 
        {
            var blog = _blogService.GetBlogs();
            BlogListResponseModel model = new BlogListResponseModel()
            {
                IsSuccess = true,
                data = blog,
                Message="success"
            };
            return Ok(model);
        } 
        catch (Exception ex) 
        { 
            return StatusCode(500,new BlogListResponseModel
            {
                Message = ex.ToString(),
            });
        }
        

    }

    [HttpGet("{id}")]
    public IActionResult GetBlog(string id)
    {
        try 
        {
            var blog = _blogService.GetBlog(id);
            if (blog is null)
            {
                return NotFound(new BlogListResponseModel
                {
                    Message = "No data found"
                });
            }
            return Ok(new BlogResponseModel
            {
                Message="Success",
                IsSuccess=true,
                data=blog
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new BlogResponseModel
            {
                Message = ex.ToString(),
            });
        }

    }

    [HttpPost]
    public IActionResult CreateBlog(BlogModel requestModel)
    {
        try 
        {
            var blog = _blogService.CreateBlog(requestModel);
            if (!blog.IsSuccess)
            {
                return BadRequest(blog);
            }
            return Ok(blog);

        } catch (Exception ex) 
        {
            return StatusCode(500, new BlogResponseModel
            {
                Message = ex.ToString()
            });
        }
      
    }

    [HttpPut("{id}")]
    public IActionResult UpsertBlog(string id, BlogModel requestModel)
    {
        requestModel.BlogId = id;
        var blog = _blogService.UpdateBlog(requestModel);
        if (!blog.IsSuccess)
        {
            return BadRequest(blog);
        }
        return Ok(blog);
    }

    [HttpPatch("{id}")]
    public IActionResult UpdateBlog(string id, BlogModel requestModel)
    {
        requestModel.BlogId = id;
        var blog = _blogService.UpdateBlog(requestModel);
        if (!blog.IsSuccess)
        {
            return BadRequest(blog);
        }
        return Ok(blog);
    }
    [HttpDelete("{id}")]
    public IActionResult DeleteBlog(string id)
    {
        try
        {
            var blog = _blogService.DeleteBlog(id);
            if (!blog.IsSuccess)
            {
                return BadRequest(blog);
            }
            return Ok(blog);

        }
        catch (Exception ex)
        {
            return StatusCode(500, new BlogResponseModel
            {
                Message = ex.ToString()
            });
        }

    }
}
