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
    public class ContactManager : IContactService
    {
        IContactDal _contactDal;

        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public IResponse Add(Contact q)
        {
            _contactDal.Add(q);
            return new SuccessResponse();
        }

        public IResponse Delete(Contact q)
        {
            throw new NotImplementedException();
        }

        public IDataResponse<List<Contact>> GetAll(Expression<Func<Contact, bool>> filter = null)
        {
            return new SuccessDataResponse<List<Contact>>(_contactDal.GetAll(filter));
        }

        public IDataResponse<Contact> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IResponse Update(Contact q)
        {
            throw new NotImplementedException();
        }
    }
}
