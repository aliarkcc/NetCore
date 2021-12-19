using Core.DataAccess;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EfMessage2Dal : EfEntityRepositoryBase<Message2, Context>, IMessage2Dal
    {
        public List<Message2> GetListWithMessageByWriter(int id)
        {
            using (Context db = new Context())
            {
                return db.Message2s.Include(x => x.SenderWriter).Where(x => x.ReceiverID == id).ToList();
            }
        }
    }
}
