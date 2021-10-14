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
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.isq = 4;
            return View();
        }
        [HttpGet]
        public PartialViewResult PartialAddComment(int ids)
        {
            ViewBag.isq = 4;
            return PartialView(ViewBag.isq);
        }
        [HttpPost]
        public PartialViewResult PartialAddComment(Comment p)
        {
            p.CommentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.CommentStatus = true;
            p.BlogId = 2;
            _commentService.Add(p);
            return PartialView();
        }

        public PartialViewResult CommentListByBlog(int id)
        {
            var values = _commentService.GetAll(x=>x.BlogId==id);
            return PartialView(values);
        }
    }
}
