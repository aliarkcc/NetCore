using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore.Controllers
{
    public class DashboardController : Controller
    {
        IBlogService _blogService;
        ICategoryService _categoryService;

        public DashboardController(IBlogService blogService, ICategoryService categoryService)
        {
            _blogService = blogService;
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            Context c = new Context();
            var userMail = User.Identity.Name;
            ViewBag.v = userMail;
            var writerID = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterId).FirstOrDefault();
            ViewBag.v1 = _blogService.GetAll().Data.Count();
            ViewBag.v2 = _blogService.GetBlogListWriter(writerID).Data.Count();
            ViewBag.v3 = _categoryService.GetAll().Data.Count();
            return View();
        }
    }
}
