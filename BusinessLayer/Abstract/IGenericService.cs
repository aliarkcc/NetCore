using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public  interface IGenericService<T>
    {
        void Add(T q);
        void Delete(T q);
        void Update(T q);
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        T GetById(int id);
    }
}
