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

        public void Add(About q)
        {
            throw new NotImplementedException();
        }


        public void Delete(About q)
        {
            throw new NotImplementedException();
        }

        public List<About> GetAll(Expression<Func<About, bool>> filter = null)
        {
            return _aboutDal.GetAll().ToList();
        }

        public About GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(About q)
        {
            throw new NotImplementedException();
        }
    }
}
