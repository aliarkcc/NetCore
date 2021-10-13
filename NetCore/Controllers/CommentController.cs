using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore.Controllers
{
    public class CommentController : Controller
    {
        ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult PartialAddComment()
        {
            ViewBag.isa = 11;
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult PartialAddComment(Comment p)
        {
            ViewBag.isa = 11;
            p.CommentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.CommentStatus = true;
            p.BlogId = 2;
            _commentService.Add(p);
            return PartialView();
        }

        public PartialViewResult CommentListByBlog(int id)
        {
            ViewBag.isa = 11;
            var values = _commentService.GetAll(x=>x.BlogId==id);
            return PartialView(values);
        }
    }
}
