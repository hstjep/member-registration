using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MemberRegistration.Repository.Common
{
    public interface IRepository
    {
        #region Methods

        IUnitOfWork CreateUnitOfWork();

        /// <summary>
        /// Gets the entities asynchronously.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>The entities.</returns>
        Task<List<T>> GetAsync<T>() where T : class;

        /// <summary>
        /// Gets the entity by id asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The entity.</returns>
        Task<T> GetByIDAsync<T>(Guid id) where T : class;

        /// <summary>
        /// Creates an entity of the type T asynchronously.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        Task<int> AddAsync<T>(T entity) where T : class;

        /// <summary>
        /// Updates the entity asynchronously.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        Task<int> UpdateAsync<T>(T entity) where T : class;

        /// <summary>
        /// Removes the entity of the type T asynchronously.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        Task<int> DeleteAsync<T>(T entity) where T : class;

        /// <summary>
        /// Removes the entity by ID async.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<int> DeleteAsync<T>(Guid id) where T : class;

        /// <summary>
        /// Gets entities according to where clause that is passed in as a paramatar.
        /// Creates an IQueryable object and then applies the filter expression.
        /// </summary>
        /// <returns></returns>
        IQueryable<T> GetWhere<T>() where T : class;

        #endregion Methods
    }
}



