using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore.ViewComponents.Blog
{
    public class BlogListDashboard:ViewComponent
    {
        IBlogService _blogService;

        public BlogListDashboard(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _blogService.GetListWithCategory();
            return View(values.Data);
        }
    }
}
