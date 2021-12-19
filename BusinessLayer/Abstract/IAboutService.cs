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
    public interface IAboutService
    {
        IResponse Add(About q);
        IResponse Delete(About q);
        IResponse Update(About q);
        IDataResponse<List<About>> GetAll(Expression<Func<About, bool>> filter = null);
        IDataResponse<About> GetById(int id);
    }
}
