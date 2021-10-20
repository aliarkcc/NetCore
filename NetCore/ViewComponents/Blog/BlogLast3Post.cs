using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore.ViewComponents.Blog
{
    public class BlogLast3Post:ViewComponent
    {
        IBlogService _blogService;

        public BlogLast3Post(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _blogService.GetAll().Take(3).ToList();
            return View(values);
        }
    }
}
