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
    public class NotificationManager : INotificationService
    {
        INotificationDal _notificationDal;

        public NotificationManager(INotificationDal notificationDal)
        {
            _notificationDal = notificationDal;
        }

        public IResponse Add(Notification q)
        {
            throw new NotImplementedException();
        }

        public IResponse Delete(Notification q)
        {
            throw new NotImplementedException();
        }

        public IDataResponse<List<Notification>> GetAll(Expression<Func<Notification, bool>> filter = null)
        {
            return new SuccessDataResponse<List<Notification>>(_notificationDal.GetAll(x=>x.NotificationStatus==true));
        }

        public IDataResponse<Notification> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IResponse Update(Notification q)
        {
            throw new NotImplementedException();
        }
    }
}
