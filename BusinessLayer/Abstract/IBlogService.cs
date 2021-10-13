using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IBlogService
    {
        void Add(Blog blog);
        void Delete(Blog blog);
        void Update(Blog blog);
        List<Blog> GetAll(Expression<Func<Blog,bool>>filter=null);
        Blog GetById(int id);
        List<Blog> GetListWithCategory();
        List<Blog> GetBlogListWriter(int id);
    }
}
