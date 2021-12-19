using BusinessLayer.Abstract;
using Core.Utilities.Response;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BusinessLayer.Concrete
{

    public class MessageManager:IMessageService
    {
        IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public IResponse Add(Message q)
        {
            throw new NotImplementedException();
        }

        public IResponse Delete(Message q)
        {
            throw new NotImplementedException();
        }

        public IDataResponse<List<Message>> GetAll(Expression<Func<Message, bool>> filter = null)
        {
            return new SuccessDataResponse<List<Message>>(_messageDal.GetAll());
        }

        public IDataResponse<Message> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResponse<List<Message>> GetInboxListByWriter(string p)
        {
            return new SuccessDataResponse<List<Message>>(_messageDal.GetAll(x => x.Receiver == p));
        }

        public IResponse Update(Message q)
        {
            throw new NotImplementedException();
        }
    }
}
