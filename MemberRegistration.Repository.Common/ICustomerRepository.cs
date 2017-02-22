using MemberRegistration.Common.Filters;
using MemberRegistration.DAL;
using MemberRegistration.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberRegistration.Repository.Common
{
    public interface ICustomerRepository
    {
        #region Methods

        /// <summary>
        /// Gets all customers asynchronously.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns>The customers.</returns>
        Task<ICollectionModel<ICustomer>> GetAsync(IFilter filter);

        /// <summary>
        /// Gets the customer by id asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The customer.</returns>
        Task<ICustomer> GetByIDAsync(Guid id);

        /// <summary>
        /// Gets customer by id asynchronously.
        /// </summary>
        /// <param name="customerId">The identifier.</param>
        /// <returns>The customer.</returns>
        Task<ICustomer> GetCustomerForInvoiceAsync(Guid customerId);

        /// <summary>
        /// Creates a customer asynchronously.
        /// </summary>
        /// <param name="customer">The customer.</param>
        /// <returns></returns>
        Task<int> AddAsync(ICustomer customer);

        /// <summary>
        /// Updates the customer asynchronously.
        /// </summary>
        /// <param name="customer">The customer.</param>
        /// <returns></returns>
        Task<int> UpdateAsync(ICustomer customer);

        /// <summary>
        /// Removes the customer by id asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<int> DeleteAsync(Guid id);

        #endregion Methods
    }
}
