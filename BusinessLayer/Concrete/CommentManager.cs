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
    public class CommentManager : ICommentService
    {
        ICommentDal _commentDal;

        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }

        public IResponse Add(Comment q)
        {
            throw new NotImplementedException();
        }

        public IResponse Delete(Comment c)
        {
            throw new NotImplementedException();
        }

        public IDataResponse<List<Comment>> GetAll(Expression<Func<Comment, bool>> filter = null)
        {
            if (filter == null)
            {
               return new SuccessDataResponse<List<Comment>>(_commentDal.GetAll().ToList());
            }
            else
            {
               return new SuccessDataResponse<List<Comment>>( _commentDal.GetAll(filter).ToList());
            }
        }

        public IDataResponse<Comment> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IResponse Update(Comment q)
        {
            throw new NotImplementedException();
        }
    }
}
