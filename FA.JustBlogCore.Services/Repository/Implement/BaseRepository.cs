using FA.JustBlogCore.Services.Model;
using FA.JustBlogCore.Services.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace FA.JustBlogCore.Services.Repository.Implement
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected DbContext _context;

        public BaseRepository(DbContext context)
        {
            _context = context;
        }

        public virtual void Add(TEntity entity)
        {
            this._context.Entry(entity).State = EntityState.Added;
        }

        public void Delete(TEntity entity)
        {
            this._context.Entry(entity).State = EntityState.Deleted;
        }

        public void Delete(Guid id)
        {
            TEntity entity = this.Find(id);
            if (entity != null)
            {
                this._context.Entry(entity).State = EntityState.Deleted;
            }
        }

        public void Dispose()
        {
            this._context.Dispose();
        }

        public TEntity Find(Guid id)
        {
            return this._context.Set<TEntity>().Find(id);
        }

        public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return this._context.Set<TEntity>().Where(predicate);
        }

        public IQueryable<TEntity> GetAll()
        {
            return this._context.Set<TEntity>();
        }

        public virtual void Update(TEntity entity)
        {
            this._context.Entry(entity).State = EntityState.Modified;
        }
    }
}