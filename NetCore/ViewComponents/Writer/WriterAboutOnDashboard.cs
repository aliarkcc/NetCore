using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore.ViewComponents.Writer
{  
    public class WriterAboutOnDashboard:ViewComponent
    {
        IWriterService _writerService;
        Context c = new Context();
        public WriterAboutOnDashboard(IWriterService writerService)
        {
            _writerService = writerService;
        }
        public IViewComponentResult Invoke(int id)
        {
            
            var userMail = User.Identity.Name;
            ViewBag.v = userMail;
            var writerID = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterId).FirstOrDefault();
            var values = _writerService.GetWriterById(writerID);
            return View(values.Data); ;
        }
    }
}
