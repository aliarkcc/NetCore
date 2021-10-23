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
    public interface IBlogService:IGenericService<Blog>
    {
        IDataResponse<List<Blog>> GetListWithCategory();
        IDataResponse<List<Blog>> GetBlogListWriter(int id);
        public IDataResponse<List<Blog>> GetListWithCategoryByWriter(int id);
    }
}
