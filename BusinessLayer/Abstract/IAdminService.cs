using Core.Utilities.Response;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BusinessLayer.Abstract
{
    public interface IAdminService
    {
        IResponse Add(Admin q);
        IResponse Delete(Admin q);
        IResponse Update(Admin q);
        IDataResponse<List<Admin>> GetAll(Expression<Func<About, bool>> filter = null);
        IDataResponse<Admin> GetById(int id);
    }
}
