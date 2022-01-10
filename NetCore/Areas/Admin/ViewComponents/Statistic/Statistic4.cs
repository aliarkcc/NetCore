using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace NetCore.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic4:ViewComponent
    {

        Context context = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.v1 = context.Admins.Where(x => x.AdminId == 1).Select(y => y.Name).FirstOrDefault();
            ViewBag.v2 = context.Admins.Where(x => x.AdminId == 1).Select(y => y.ImageURL).FirstOrDefault();
            return View();
        }
    }
}
