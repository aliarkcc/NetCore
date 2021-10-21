using BusinessLayer.Abstract;
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
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public IResponse Add(Category q)
        {
            _categoryDal.Add(q);
            return new SuccessResponse();
        }

        public IResponse Delete(Category q)
        {
            _categoryDal.Delete(q);
            return new SuccessResponse();
        }

        public IDataResponse<List<Category>> GetAll(Expression<Func<Category, bool>> filter = null)
        {
            var data = _categoryDal.GetAll();
            return new SuccessDataResponse<List<Category>>(data);
        }

        public IDataResponse<Category> GetById(int id)
        {
            var data = _categoryDal.Get(x => x.CategoryId == id);
            return new SuccessDataResponse<Category>(data);
        }

        public IResponse Update(Category q)
        {
            _categoryDal.Update(q);
            return new SuccessResponse();
        }
    }
}
