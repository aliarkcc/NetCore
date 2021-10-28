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
            ViewBag.cv = CategoryValues();
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
       public IActionResult DeleteBlog(int id)
        {
            var blogValue = _blogService.GetById(id);
            _blogService.Delete(blogValue.Data);
            return RedirectToAction("BlogListByWriter");
        }
        [HttpGet]
        public IActionResult EditBlog(int id)
        {
            ViewBag.cv = CategoryValues();
            var blogValue = _blogService.GetById(id);
            return View(blogValue.Data);
        }
        [HttpPost]
        public IActionResult EditBlog(Blog b)
        {
            var currentBlog = _blogService.GetById(b.BlogId);
            b.BlogCreateDate = currentBlog.Data.BlogCreateDate;
            b.WriterId = currentBlog.Data.WriterId;
            b.BlogStatus = currentBlog.Data.BlogStatus;
            ViewBag.cv = CategoryValues();
             _blogService.Update(b);
            return RedirectToAction("BlogListByWriter");
        }
        public List<SelectListItem> CategoryValues()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            List<SelectListItem> categoryValues = (from x in categoryManager.GetAll().Data
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryId.ToString()
                                                   }).ToList();
            return categoryValues;
        }
    }
}
