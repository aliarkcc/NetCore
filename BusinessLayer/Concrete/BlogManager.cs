using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class BlogManager : IBlogService
    {
        IBlogDal _blogDal;
        public BlogManager(IBlogDal blogDal)
        {
            _blogDal = blogDal;
        }

        public void Add(Blog blog)
        {
            _blogDal.Add(blog);
        }

        public void Delete(Blog blog)
        {
            throw new NotImplementedException();
        }

        public List<Blog> GetAll(Expression<Func<Blog, bool>> filter = null)
        {
            return filter == null
                ? _blogDal.GetAll().ToList()
                : _blogDal.GetAll(filter).ToList();
        }

        public List<Blog> GetBlogListWriter(int id)
        {
            return _blogDal.GetAll(x => x.WriterId == id).ToList();
        }

        public Blog GetById(int id)
        {
            return _blogDal.Get(b => b.BlogId == id);
        }
        public List<Blog> GetListWithCategory()
        {
            return _blogDal.GetListWithCategory();
        }

        public void Update(Blog blog)
        {
            throw new NotImplementedException();
        }
    }
}
