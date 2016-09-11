using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MemberRegistration.DAL;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;
using MemberRegistration.Repository.Common;
using System.Transactions;

namespace MemberRegistration.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Properties

        protected ApplicationDbContext DbContext { get; set; }

        #endregion Properties


        #region Constructors

        public UnitOfWork(ApplicationDbContext db)
        {
            if (db == null)
            {
                throw new ArgumentException("DbContext");
            }
            DbContext = db;
        }

        #endregion Constructors


        #region Methods

        /// <summary>
        /// Adds the entity asynchronously.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public virtual Task<int> AddAsync<T>(T entity) where T : class
        {
            try
            {
                DbEntityEntry dbEntityEntry = DbContext.Entry(entity);
                if (dbEntityEntry.State != EntityState.Detached)
                {
                    dbEntityEntry.State = EntityState.Added;
                }
                else
                {
                    DbContext.Set<T>().Add(entity);
                }
                return Task.FromResult(1);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Updates the entity asynchronously.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public virtual Task<int> UpdateAsync<T>(T entity) where T : class
        {
            try
            {
                DbEntityEntry dbEntityEntry = DbContext.Entry(entity);
                if (dbEntityEntry.State == EntityState.Detached)
                {
                    DbContext.Set<T>().Attach(entity);
                }
                dbEntityEntry.State = EntityState.Modified;
                return Task.FromResult(1);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Deletes the entity asynchronously.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public virtual Task<int> DeleteAsync<T>(T entity) where T : class
        {
            try
            {
                DbEntityEntry dbEntityEntry = DbContext.Entry(entity);
                if (dbEntityEntry.State != EntityState.Deleted)
                {
                    dbEntityEntry.State = EntityState.Deleted;
                }
                else
                {
                    DbContext.Set<T>().Attach(entity);
                    DbContext.Set<T>().Remove(entity);
                }
                return Task.FromResult(1);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Deletes the entity by id asynchronously.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public virtual Task<int> DeleteAsync<T>(Guid id) where T : class
        {
            var entity = DbContext.Set<T>().Find(id);
            if (entity == null)
            {
                return Task.FromResult(0);
            }
            return DeleteAsync<T>(entity);
        }

        /// <summary>
        /// Commits operations asynchronously.
        /// </summary>
        /// <returns></returns>
        public async Task<int> CommitAsync()
        {
            int result = 0;
            using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                result = await DbContext.SaveChangesAsync();
                scope.Complete();
            }
            return result;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            DbContext.Dispose();
        }

        #endregion Methods

    }
}
    


       
