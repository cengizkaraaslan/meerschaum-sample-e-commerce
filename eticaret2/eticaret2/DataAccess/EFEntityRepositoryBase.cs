using eticaret.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ticaret.DataAccess;

namespace eticaret.DataAccess
{
    public class EFEntityRepositoryBase<TEntity, TContex> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContex : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            using (var context = new TContex())
            {
                var added = context.Entry(entity);
                added.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (var context = new TContex())
            {
                var added = context.Entry(entity);
                added.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContex())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);

            }
        }

        public List<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContex())
            {
                return filter == null
                    ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(filter).ToList();

            }   
        }

        public void Update(TEntity entity)
        {
            using (var context = new TContex())
            {
                var added = context.Entry(entity);
                added.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
