using Core.Utilities.Response;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICategoryService
    {
        IResponse Add(Category q);
        IResponse Delete(Category q);
        IResponse Update(Category q);
        IDataResponse<List<Category>> GetAll(Expression<Func<Category, bool>> filter = null);
        IDataResponse<Category> GetById(int id);
    }
}
