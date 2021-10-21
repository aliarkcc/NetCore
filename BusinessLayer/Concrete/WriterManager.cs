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
    public class WriterManager : IWriterService
    {
        IWriterDal _writerDal;

        public WriterManager(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }

        public IResponse Add(Writer q)
        {
            _writerDal.Add(q);
            return new SuccessResponse();
        }

        public IResponse Delete(Writer q)
        {
            throw new NotImplementedException();
        }

        public IDataResponse<List<Writer>> GetAll(Expression<Func<Writer, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public IDataResponse<Writer> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResponse<List<Writer>> GetListWithCategory()
        {
            throw new NotImplementedException();
        }

        public IResponse Update(Writer q)
        {
            throw new NotImplementedException();
        }
    }
}
