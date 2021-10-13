using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore.ViewComponents.Blog
{
    public class WriterLastBlog:ViewComponent
    {
        IBlogService _blogService;

        public WriterLastBlog(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _blogService.GetBlogListWriter(1);
            return View(values);
        }
    }
}
