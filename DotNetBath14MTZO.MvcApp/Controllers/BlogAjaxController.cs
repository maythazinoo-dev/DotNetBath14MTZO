using DotNetBath14MTZO.Dbservice.Shared;
using Microsoft.AspNetCore.Mvc;


namespace DotNetBath14MTZO.MvcApp.Controllers
{
    public class BlogAjaxController : Controller
    {
        
        //private readonly BlogEfCoreService _blogEfCoreService;// call one service
        private readonly IBlogService _blogService;// call switch service
        
        public BlogAjaxController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        [ActionName("Index")]
        public IActionResult BlogList()
        {
       
            return View("BlogList");
        }


        [ActionName("GetBlogs")]
        public IActionResult GetBlogs()
        {
            var result = _blogService.GetBlogs();
            return Json(result);
        }

        [ActionName("Create")]
        public IActionResult CreateBlog()
        {
            return View("CreateBlog");
        }

        [HttpPost]
        [ActionName("Save")]
        public  IActionResult SaveBlog(BlogModel requestModel)
        {
            try
            {
                var result = _blogService.CreateBlog(requestModel);
                return Json(new { IsSuccess = true, Message = "Saving Success" });
            }
            catch (Exception ex)
            {
                return Json(new { IsSuccess = false, Message = ex.ToString() });
            }
            
        }

        [ActionName("Edit")]
        public  IActionResult EditBlog(string id)
        {
            //var item =  _blogService.GetBlog(id);
            return View("EditBlog");
        }

        [HttpPost]
        [ActionName("Update")]
        public IActionResult UpdateBlog(string id, BlogModel requestModel)
        {
            requestModel.BlogId = id;
            try
            {
                var result = _blogService.UpdateBlog(requestModel);
                return Json(new { IsSuccess = true, Message = "Saving Success" });
            }
            catch (Exception ex)
            {
                return Json(new { IsSuccess = false, Message = ex.ToString() });
            }
            
        }


        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteBlog(BlogModel requestModel)
        {
            try
            {
                var result = _blogService.DeleteBlog(requestModel.BlogId!);
                return Json(new { IsSuccess = true, Message = "Deleting Successful." });
            }
            catch (Exception ex)
            {
                return Json(new { IsSuccess = false, Message = ex.ToString() });
            }
        }
    }
}

