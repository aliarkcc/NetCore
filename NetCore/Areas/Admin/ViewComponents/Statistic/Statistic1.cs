using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic1:ViewComponent
    {
        IBlogService _blogService;
        IContactService _contactService;
        ICommentService _commentService;

        public Statistic1(IBlogService blogService, IContactService contactService, ICommentService commentService)
        {
            _blogService = blogService;
            _contactService = contactService;
            _commentService = commentService;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.blogCount = _blogService.GetAll().Data.Count;
            ViewBag.contactCount = _contactService.GetAll().Data.Count;
            ViewBag.commentCount = _commentService.GetAll().Data.Count;
            return View();
        }
    }
}