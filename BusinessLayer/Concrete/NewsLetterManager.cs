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
    public class NewsLetterManager : INewsLetterService
    {
        INewsLetterDal _newsLetterDal;

        public NewsLetterManager(INewsLetterDal newsLetterDal)
        {
            _newsLetterDal = newsLetterDal;
        }

        public IResponse Add(NewsLetter q)
        {
            _newsLetterDal.Add(q);
            return new SuccessResponse();
        }

        public IResponse Delete(NewsLetter q)
        {
            throw new NotImplementedException();
        }

        public IDataResponse<List<NewsLetter>> GetAll(Expression<Func<NewsLetter, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public IDataResponse<NewsLetter> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IResponse Update(NewsLetter q)
        {
            throw new NotImplementedException();
        }
    }
}
