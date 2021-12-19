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
    public class Message2Manager : IMessage2Service
    {
        IMessage2Dal _message2Dal;

        public Message2Manager(IMessage2Dal message2Dal)
        {
            _message2Dal = message2Dal;
        }

        public IResponse Add(Message2 q)
        {
            throw new NotImplementedException();
        }

        public IResponse Delete(Message2 q)
        {
            throw new NotImplementedException();
        }

        public IDataResponse<List<Message2>> GetAll(Expression<Func<Message2, bool>> filter = null)
        {
            var values = _message2Dal.GetAll();
            return new SuccessDataResponse<List<Message2>>(values);
        }

        public IDataResponse<Message2> GetById(int id)
        {
            return new SuccessDataResponse<Message2>(_message2Dal.Get(x => x.MessageID == id));
        }

        public IDataResponse<List<Message2>> GetInboxListByWriter(int id)
        {
            return new SuccessDataResponse<List<Message2>>(_message2Dal.GetListWithMessageByWriter(id));
        }

        public IResponse Update(Message2 q)
        {
            throw new NotImplementedException();
        }
    }
}
