using Core.DataAccess;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EfBlogDal : EfEntityRepositoryBase<Blog, Context>, IBlogDal
    {
        public List<Blog> GetListWithCategory()
        {
            using (Context db= new Context())
            {
                return db.Blogs.Include(x => x.Category).ToList();
            }
        }
    }
}