using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using Core.Utilities.Response;
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
        public IResponse Add(Blog q)
        {
            q.BlogStatus = true;
            q.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            q.WriterId = 1;
            _blogDal.Add(q);
            return new SuccessResponse();
        }

        public IResponse Delete(Blog q)
        {
            _blogDal.Delete(q);
            return new SuccessResponse();
        }

        public IDataResponse<List<Blog>> GetAll(Expression<Func<Blog, bool>> filter = null)
        {
            if(filter==null)
            {
                var data=_blogDal.GetAll().ToList();
                return new SuccessDataResponse<List<Blog>>(data);
            }
            else
            {
                var data = _blogDal.GetAll(filter).ToList();
                return new SuccessDataResponse<List<Blog>>(data);
            }
        }

        public IDataResponse<List<Blog>> GetBlogListWriter(int id)
        {
            var data=_blogDal.GetAll(x => x.WriterId == id).ToList();
            return new SuccessDataResponse<List<Blog>>(data);
        }

        public IDataResponse<Blog> GetById(int id)
        {
            var data =  _blogDal.Get(b => b.BlogId == id);
            return new SuccessDataResponse<Blog>(data);
        }


        public IDataResponse<List<Blog>> GetListWithCategory()
        {
            var data= _blogDal.GetListWithCategory();
            return new SuccessDataResponse<List<Blog>>(data);
        }

        public IResponse Update(Blog q)
        {
            _blogDal.Update(q);
            return new SuccessResponse();
        }
        public IDataResponse<List<Blog>> GetListWithCategoryByWriter(int id)
        {
            return new SuccessDataResponse<List<Blog>>(_blogDal.GetListWithCategoryByWriter(id));
        }
    }
}
