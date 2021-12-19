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
    public interface IContactService
    {
        IResponse Add(Contact q);
        IResponse Delete(Contact q);
        IResponse Update(Contact q);
        IDataResponse<List<Contact>> GetAll(Expression<Func<Contact, bool>> filter = null);
        IDataResponse<Contact> GetById(int id);
    }
}
