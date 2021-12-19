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
            return new SuccessDataResponse<Writer>(_writerDal.Get(x => x.WriterId == id));
        }
        public IDataResponse<List<Writer>> GetWriterById(int id)
        {
            return new SuccessDataResponse<List<Writer>>(_writerDal.GetAll(x=>x.WriterId==id));
        }

        public IResponse Update(Writer q)
        {
            _writerDal.Update(q);
            return new SuccessResponse();
        }
    }
}
