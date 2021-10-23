using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore.Controllers
{
    [AllowAnonymous]
    public class BlogController : Controller
    {
        IBlogService _blogService;
        ICommentService _commentService;

        public BlogController(IBlogService blogService, ICommentService commentService)
        {
            _blogService = blogService;
            _commentService = commentService;
        }
        public IActionResult Index()
        {
            var response = _blogService.GetAll();
            if (response.Success)
            {
                return View(response.Data);
            }
            return BadRequest(response.Message);
        }

        public IActionResult BlogDetails(int id)
        {
            ViewBag.i = id;
            var response = _blogService.GetAll(x => x.BlogId == id);
            ViewBag.commentCount = _commentService.GetAll(x => x.BlogId == id).Data.Count();
            if (response.Success)
            {
                return View(response.Data);
            }
            return BadRequest(response.Message);
        }
        public IActionResult BlogListByWriter()
        {
            var values = _blogService.GetListWithCategoryByWriter(1);
            return View(values.Data);
        }
        [HttpGet]
        public IActionResult BlogAdd()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            List<SelectListItem> categoryvalues = (from x in categoryManager.GetAll().Data
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryId.ToString()
                                                   }).ToList();
            ViewBag.cv = categoryvalues;
            return View();
        }
        [HttpPost]
        public IActionResult BlogAdd(Blog blog)
        {
            BlogValidatior r = new BlogValidatior();
            ValidationResult results = r.Validate(blog);
            if (results.IsValid)
            {
                blog.BlogStatus = true;
                blog.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                blog.WriterId = 1;
                _blogService.Add(blog);
                return RedirectToAction("BlogListByWriter", "Blog");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}
