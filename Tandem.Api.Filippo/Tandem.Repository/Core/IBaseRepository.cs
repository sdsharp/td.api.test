using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Tandem.Domain.Entities;

namespace Tandem.Repository.Core
{
    public interface IBaseRepository<T> where T : class, IEntity
    {
        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        EntityEntry<T> Add(T entity);

        /// <summary>
        /// Update the specified entity.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        T Update(T entity);

        /// <summary>
        /// Gets as queryable.
        /// </summary>
        /// <returns></returns>
        IQueryable<T> AsQueryable();

        /// <summary>
        /// Filters a sequence of values based on a predicate.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns></returns>
        IQueryable<T> Where(Expression<Func<T, Boolean>> predicate);

        /// <summary>
        /// Saves all changes made in this context to the underlying database asynchronous.
        /// </summary>
        /// <returns></returns>
        Task SaveChangesAsync();
    }
}