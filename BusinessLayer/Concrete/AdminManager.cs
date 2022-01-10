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
    public class AdminManager : IAdminService
    {
        private IAdminDal _adminDal;

        public AdminManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }

        public IResponse Add(Admin q)
        {
            throw new NotImplementedException();
        }

        public IResponse Delete(Admin q)
        {
            throw new NotImplementedException();
        }

        public IDataResponse<List<Admin>> GetAll(Expression<Func<About, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public IDataResponse<Admin> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IResponse Update(Admin q)
        {
            throw new NotImplementedException();
        }
    }
}
