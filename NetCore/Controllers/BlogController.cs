using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore.Controllers
{
    [AllowAnonymous]
    public class BlogController : Controller
    {
        IBlogService _blogService;
        ICommentService _commentService;

        public BlogController(IBlogService blogService,ICommentService commentService)
        {
            _blogService = blogService;
            _commentService = commentService;
        }
        public IActionResult Index()
        {
            var response = _blogService.GetListWithCategory();
            if(response.Success)
            {
                return View(response.Data);
            }
            return BadRequest(response.Message);
        }

        public IActionResult BlogDetails(int id)
        {
            ViewBag.i = id;
            var response = _blogService.GetAll(x=>x.BlogId==id);
            ViewBag.commentCount = _commentService.GetAll(x => x.BlogId == id).Data.Count();
            if (response.Success)
            {
                return View(response.Data);
            }
            return BadRequest(response.Message);
        }
    }
}
