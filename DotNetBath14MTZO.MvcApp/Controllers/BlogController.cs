
using DotNetBath14MTZO.Dbservice.Shared;
using Microsoft.AspNetCore.Mvc;


namespace DotNetBath14MTZO.MvcApp.Controllers
{
    public class BlogController : Controller
    {
        
        //private readonly BlogEfCoreService _blogEfCoreService;// call one service
        private readonly IBlogService _blogService;// call switch service
        
        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        [ActionName("Index")]
        public IActionResult BlogList()
        {
            var lst =  _blogService.GetBlogs();
            return View("BlogList", lst);
        }


        [ActionName("Create")]
        public IActionResult CreateBlog()
        {
            return View("CreateBlog",new BlogModel());// new BlogModel carry data
        }

        [HttpPost]
        [ActionName("Save")]
        public  IActionResult SaveBlog(BlogModel requestModel)
        {
            List<string> errorList = new List<string>();
            if (string.IsNullOrEmpty(requestModel.BlogTitle))
            {
                errorList.Add("Blog Title is required");
            }
            if (string.IsNullOrEmpty(requestModel.BlogAuthor))
            {
                errorList.Add("Blog Author is required");
            }
            if (string.IsNullOrEmpty(requestModel.BlogContent))
            {
                errorList.Add("Blog Content is required");
            }

            if (errorList.Count > 0)
            {
                ViewBag.IsValidationError = true;
                ViewBag.ValidationErrors = errorList;
                return View("CreateBlog", requestModel);
            }


            var result =  _blogService.CreateBlog(requestModel);
            ViewBag.IsSuccess=result.IsSuccess;
            ViewBag.Message=result.Message;

            TempData["IsSuccess"] = result.IsSuccess;
            TempData["Message"] = result.Message;

            HttpContext.Session.SetString("IsSuccess", result.IsSuccess.ToString());
            HttpContext.Session.SetString("Message", result.Message);

            //return View("CreateBlog");
            return RedirectToAction("Index");
        }

        [ActionName("Edit")]
        public  IActionResult EditBlog(string id)
        {
            var item =  _blogService.GetBlog(id);
            return View("EditBlog",item);
        }

        [HttpPost]
        [ActionName("Update")]
        public IActionResult UpdateBlog(string id, BlogModel requestModel)
        {
            requestModel.BlogId = id;
            var result = _blogService.UpdateBlog(requestModel);
            return RedirectToAction("Index");
        }


        [HttpDelete]
        [ActionName("Delete")]
        public IActionResult DeleteBlog(string id)
        {
            var result =  _blogService.DeleteBlog(id);
            return RedirectToAction("Index");
        }
    }
}

