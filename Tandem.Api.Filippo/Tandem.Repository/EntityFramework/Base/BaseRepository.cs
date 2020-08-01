using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Tandem.Domain.Entities;
using Tandem.Repository.Core;

namespace Tandem.Repository.EntityFramework.Base
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class, IEntity
    {
        private readonly IContext _context;
        private readonly DbSet<T> _dbSet;

        public BaseRepository(IContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public EntityEntry<T> Add(T entity)
        {
            return _dbSet.Add(entity);
        }

        public T Update(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        public virtual IQueryable<T> AsQueryable()
        {
            return _dbSet.AsQueryable();
        }

        public IQueryable<T> Where(Expression<Func<T, Boolean>> predicate)
        {
            return AsQueryable().Where(predicate);
        }

        /// <summary>
        /// Saves all changes made in this context to the underlying database asynchronously.
        /// </summary>
        /// <returns></returns>
        public virtual async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public virtual async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
