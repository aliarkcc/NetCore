using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using Core.Aspect.Validation;
using Core.CrossCuttingConcerns;
using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore.Controllers
{
    public class RegisterController : Controller
    {
        IWriterService _writerService;

        public RegisterController(IWriterService writerService)
        {
            _writerService = writerService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        //[ValidationAspect(typeof(WriterValidator))]
        public IActionResult Index(Writer writer)
        {
            WriterValidator rules = new WriterValidator();
            ValidationResult validation = rules.Validate(writer);
            if (validation.IsValid)
            {
                writer.WriterStatus = true;
                writer.WriterAbout = "Deneme";
                _writerService.Add(writer);
                return RedirectToAction("Index", "Blog");
            }
            else
            {
                foreach (var item in validation.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();

        }
    }
}
