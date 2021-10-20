using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace NetCore.Controllers
{
    public class LoginController : Controller
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Index(Writer p)
        {
            Context c = new Context();
            var dataValue = c.Writers.FirstOrDefault(x => x.WriterMail == p.WriterMail && x.WriterPassword == p.WriterPassword);
            if(dataValue!=null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,p.WriterMail)
                };
                var useridentity = new ClaimsIdentity(claims, "a");
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("Index", "Writer");
            }
            else
            {
                return View();
            }
        }
        //public IActionResult Index(Writer p)
        //{
        //    Context c = new Context();
        //    var dataValue = c.Writers.FirstOrDefault(x => x.WriterMail == p.WriterMail && x.WriterPassword == p.WriterPassword);
        //    if(dataValue!=null)
        //    {
        //        HttpContext.Session.SetString("username", p.WriterMail);
        //        return RedirectToAction("Index", "Writer");
        //    }
        //    else
        //    {
        //        return View();
        //    }
        //}

    }
}
