using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace FA.JustBlogCore.Services.Repository.Interface
{
    public interface IBaseRepository<TEntity> : IDisposable where TEntity : class
    {
        void Add(TEntity entity);

        void Delete(TEntity entity);

        void Delete(Guid id);

        void Update(TEntity entity);

        TEntity Find(Guid id);

        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        IQueryable<TEntity> GetAll();
    }
}