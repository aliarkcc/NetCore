using Core.Utilities.Response;
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
        IResponse Add(Comment q);
        IResponse Delete(Comment q);
        IResponse Update(Comment q);
        IDataResponse<List<Comment>> GetAll(Expression<Func<Comment, bool>> filter = null);
        IDataResponse<Comment> GetById(int id);
    }
}
