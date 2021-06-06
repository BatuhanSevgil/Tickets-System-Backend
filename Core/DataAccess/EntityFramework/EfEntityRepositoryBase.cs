using Core.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext>
     where TEntity : class, IEntity, new()
     where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            
            using (TContext context = new TContext())
            {
                var entityAdd = context.Entry(entity);
                entityAdd.State = EntityState.Added;
                context.SaveChanges();

            }
        }

        public TEntity AddAndOutEntity(TEntity entity)
        {

            using (TContext context=new TContext())
            {

                var OutId = context.Entry(entity);
                    OutId.State = EntityState.Added;
                context.SaveChanges();
                return entity;
            }

        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var EntityDelete = context.Entry(entity);
                EntityDelete.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);

            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null
                     ? context.Set<TEntity>().ToList()
                     : context.Set<TEntity>().Where(filter).ToList();
            }


        }


        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var UpdateEntity = context.Entry(entity);
                UpdateEntity.State = EntityState.Modified;
                context.SaveChanges();

            }
        }


    }
}
