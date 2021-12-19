﻿using Core.DataAccess;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EfNotificationDal:EfEntityRepositoryBase<Notification,Context>,INotificationDal
    {
    }
}
