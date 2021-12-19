using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetCore.Models;
using System;
using System.IO;
using System.Linq;

namespace NetCore.Controllers
{
    public class WriterController : Controller
    {
        IWriterService _writerService;
        Context c = new Context();
        public WriterController(IWriterService writerService)
        {
            _writerService = writerService;
        }
        [Authorize]
        [AllowAnonymous]
        public IActionResult Index()
        {
            Context c = new Context();
            var userMail = User.Identity.Name;
            ViewBag.v = userMail;
            var writerName = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterName).FirstOrDefault();
            ViewBag.writerName = writerName;
            return View();
        }
        [AllowAnonymous]
        public IActionResult Test()
        {
            return View();
        }
        [AllowAnonymous]
        public PartialViewResult WriterNavbarPartial()
        {
            return PartialView();
        }
        [AllowAnonymous]
        public PartialViewResult WriterFooterPartial()
        {
            return PartialView();
        }
        [HttpGet]
        public IActionResult WriterEditProfile()
        {
            var userMail = User.Identity.Name;
            ViewBag.v = userMail;
            var writerID = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterId).FirstOrDefault();
            var writerValues = _writerService.GetById(writerID);
            return View(writerValues.Data);
        }
        [HttpPost]
        public IActionResult WriterEditProfile(Writer writer)
        {
            WriterValidator validations = new WriterValidator();
            ValidationResult result = validations.Validate(writer);
            if(result.IsValid)
            {
                _writerService.Update(writer);
                return RedirectToAction("Index","Dashboard");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult WriterAdd()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult WriterAdd(AddProfileImage p)
        {
            Writer v = new Writer();    
            if(p.WriterImage!=null)
            {
                var path = Path.GetExtension(p.WriterImage.FileName);
                var newImagename = Guid.NewGuid() + path;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFile", newImagename);
                var stream = new FileStream(location, FileMode.Create);
                p.WriterImage.CopyTo(stream);
                v.WriterImage = newImagename;
            }
            v.WriterMail = p.WriterMail;
            v.WriterAbout = p.WriterAbout;
            v.WriterStatus = true;
            v.WriterPassword = p.WriterPassword;
            v.WriterName = p.WriterName;
            _writerService.Add(v);
            return RedirectToAction("Index", "Dashboard");
        }
    }
}
