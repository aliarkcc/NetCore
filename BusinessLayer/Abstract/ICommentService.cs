using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICommentService
    {
        void Add(Comment comment);
        //void Delete(Comment comment);
        //void Update(Comment comment);
        List<Comment> GetAll(Expression<Func<Comment, bool>> filter = null);
        //Comment GetById(int id);
    }
}
