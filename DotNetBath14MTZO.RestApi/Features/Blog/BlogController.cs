using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNetBath14MTZO.RestApi.Features.Blog
{
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
            var blog = _blogService.GetBlogs();
            return Ok(blog);
        }

        [HttpGet("{id}")]
        public IActionResult GetBlog(string id)
        {
            var item = _blogService.GetBlog(id);
            if (item is null)
            {
                return NotFound("No Data Found");
            }
            return Ok(item);
        }
        [HttpPost]
        public IActionResult CreateBlog(BlogModel requestModel)
        {
            var item = _blogService.CreateBlog(requestModel);
            if (!item.IsSuccess)
            {
                return BadRequest(item);
            }

            return Ok(item);
        }

        [HttpPut("{id}")]
        public IActionResult UpsertBlog(string id, BlogModel requestModel)
        {
            requestModel.BlogId = id;
            var model = _blogService.UpsertBlog(requestModel);
            if (!model.IsSuccess)
            {
                return BadRequest(model);
            }
            return Ok();

        }

        [HttpPatch("{id}")]
        public IActionResult UpdateBlog(string id, BlogModel requestModel)
        {
            requestModel.BlogId = id;
            var model = _blogService.UpdateBlog(requestModel);
            if (!model.IsSuccess)
            {
                return BadRequest(model);
            }
            return Ok(model);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBlog(string id)
        {
            var item = _blogService.DeleteBlog(id);
            if (!item.IsSuccess) 
            { 
                return BadRequest(item);
            }
            return Ok();
        }
    }
}
