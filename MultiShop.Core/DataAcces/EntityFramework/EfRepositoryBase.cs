using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MultiShop.Core.Entities.Abstract;

namespace MultiShop.Core.DataAcces.EntityFramework
{
    public class EfRepositoryBase<TEntity, TContext> : IRepositoryBase<TEntity>
        where TEntity : class, IEntity
        where TContext : DbContext, new()
    {
        public void Add(TEntity model)
        {
            using var context = new TContext();
            var addEntity = context.Entry(model); //  Entry Sadece Add Methodu ucun yazilir 
            addEntity.State = EntityState.Added;
            context.SaveChanges();
        }

        public void Update(TEntity model)
        {
            using var context = new TContext();
            var updateEntity = context.Update(model);
            updateEntity.State = EntityState.Modified;
            context.SaveChanges();

        }

        public void Delete(TEntity model)
        {
            using var context = new TContext();
            var deleteEntity = context.Remove(model);
            deleteEntity.State = EntityState.Deleted;
            context.SaveChanges();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using var context = new TContext();
            return context.Set<TEntity>().SingleOrDefault(filter);
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>>? filter = null)
        {
            using var context = new TContext();
            return filter != null
                ? context.Set<TEntity>().Where(filter).ToList()
                : context.Set<TEntity>().ToList();

        }
    }
}
