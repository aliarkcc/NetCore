﻿using Core.DataAccess;
using Core.Utilities.Response;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IWriterDal:IEntityRepository<Writer>
    {
    }
}
