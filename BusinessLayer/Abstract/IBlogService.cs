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
    public interface IBlogService
    {
        IResponse Add(Blog q);
        IResponse Delete(Blog b);
        IResponse Update(Blog q);
        IDataResponse<List<Blog>> GetAll(Expression<Func<Blog, bool>> filter = null);
        IDataResponse<Blog> GetById(int id);
        IDataResponse<List<Blog>> GetListWithCategory();
        IDataResponse<List<Blog>> GetBlogListWriter(int id);
        IDataResponse<List<Blog>> GetListWithCategoryByWriter(int id);
    }
}
