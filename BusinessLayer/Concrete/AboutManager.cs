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
    public class AboutManager : IAboutService
    {
        IAboutDal _aboutDal;

        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public IResponse Add(About q)
        {
            throw new NotImplementedException();
        }

        public IResponse Delete(About q)
        {
            throw new NotImplementedException();
        }

        public IDataResponse<List<About>> GetAll(Expression<Func<About, bool>> filter = null)
        {
            var data = _aboutDal.GetAll();
            return new SuccessDataResponse<List<About>>(data);
        }

        public IDataResponse<About> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IResponse Update(About q)
        {
            throw new NotImplementedException();
        }
    }
}
