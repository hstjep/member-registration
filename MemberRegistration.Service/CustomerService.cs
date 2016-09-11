using MemberRegistration.Common.Filters;
using MemberRegistration.Model.Common;
using MemberRegistration.Repository.Common;
using MemberRegistration.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberRegistration.Service
{
    public class CustomerService : ICustomerService
    {
        #region Properties

        protected ICustomerRepository Repository { get; private set; }
    
        #endregion Properties


        #region Constructors

        public CustomerService(ICustomerRepository repository)
        {
            this.Repository = repository;
        }

        #endregion Constructors


        #region Methods

        /// <summary>
        /// Gets all customers asynchronously.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns>
        /// The customers.
        /// </returns>
        public Task<IEnumerable<ICustomer>> GetAsync(IFilter filter = null)
        {
            return Repository.GetAsync(filter);
        }

        /// <summary>
        /// Gets the customer by id asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// The customer.
        /// </returns>
        public Task<ICustomer> GetByIDAsync(Guid id)
        {
            return Repository.GetByIDAsync(id);
        }

        /// <summary>
        /// Adds the customer asynchronously.
        /// </summary>
        /// <param name="customer">The customer.</param>
        /// <returns></returns>
        public Task<int> AddAsync(ICustomer customer)
        {
            return Repository.AddAsync(customer);
        }

        /// <summary>
        /// Updates the customer asynchronously.
        /// </summary>
        /// <param name="customer">The customer.</param>
        /// <returns></returns>
        public Task<int> UpdateAsync(ICustomer customer)
        {
            return Repository.UpdateAsync(customer);
        }

        /// <summary>
        /// Removes the customer by ID asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public Task<int> DeleteAsync(Guid id)
        {
            return Repository.DeleteAsync(id);
        }
          
        #endregion Methods
    }
}
