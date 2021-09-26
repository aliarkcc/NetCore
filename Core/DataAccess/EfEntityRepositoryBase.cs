using Core.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    public class EfEntityRepositoryBase<Tentity, TContext> : IEntityRepository<Tentity>
        where Tentity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public void Add(Tentity entity)
        {
            using (TContext db= new TContext())
            {
                var addedEntity = db.Entry(entity);
                addedEntity.State = EntityState.Added;
                db.SaveChanges();
            }
        }

        public void Delete(Tentity entity)
        {
            using (TContext db= new TContext())
            {
                var deletedEntity = db.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public Tentity Get(Expression<Func<Tentity, bool>> filter)
        {
            using (TContext db= new TContext())
            {
                return db.Set<Tentity>().SingleOrDefault(filter);
            }
        }

        public List<Tentity> GetAll(Expression<Func<Tentity, bool>> filter = null)
        {
            using (TContext db= new TContext())
            {
                return filter == null
                    ? db.Set<Tentity>().ToList()
                    : db.Set<Tentity>().Where(filter).ToList();
            }
        }

        public void Update(Tentity entity)
        {
            using (TContext db= new TContext())
            {
                var updatedEntity = db.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}
