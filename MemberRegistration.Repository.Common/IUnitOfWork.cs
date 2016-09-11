using System;
using System.Threading.Tasks;

namespace MemberRegistration.Repository.Common
{
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Commits operations asynchronously.
        /// </summary>
        /// <returns></returns>
        Task<int> CommitAsync();

        /// <summary>
        /// Adds the entity asynchronously.
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
        /// Deletes the entity asynchronously.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        Task<int> DeleteAsync<T>(T entity) where T : class;

        /// <summary>
        /// Deletes the entity by id asynchronously.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<int> DeleteAsync<T>(Guid id) where T : class;
    }
}
