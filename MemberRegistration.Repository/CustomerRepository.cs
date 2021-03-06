﻿using MemberRegistration.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MemberRegistration.Model.Common;
using MemberRegistration.DAL;
using MemberRegistration.Model;
using System.Data.Entity;
using System.Linq.Expressions;
using MemberRegistration.Common.Filters;
using PagedList;

namespace MemberRegistration.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        #region Properties

        protected IRepository Repository { get; private set; }

        #endregion Properties


        #region Constructors

        public CustomerRepository(IRepository repository)
        {
            this.Repository = repository;
        }

        #endregion Constructors


        #region Methods

        /// <summary>
        /// Gets all customers asynchronously.
        /// </summary>
        /// <param name="filter"></param>
        /// <returns>The customers.</returns>
        public virtual async Task<IEnumerable<ICustomer>> GetAsync(IFilter filter = null)
        {
            if (filter != null)
            {
                var customers = Mapper.Map<IEnumerable<CustomerPOCO>>(
                    await Repository.GetWhere<Customer>()
                    .OrderBy(k => k.LastName)
                    .ToListAsync());

                if (!string.IsNullOrWhiteSpace(filter.SearchString))
                {
                    customers = customers.Where(k => k.FullName.ToUpper()
                        .Contains(filter.SearchString.ToUpper()))
                        .ToList();
                }

                return customers;
            }
            else
            {
                return Mapper.Map<IEnumerable<CustomerPOCO>>(await Repository.GetWhere<Customer>().ToListAsync());
            }
        }

        /// <summary>
        /// Gets the customer by id asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public virtual async Task<ICustomer> GetByIDAsync(Guid id)
        {
            return Mapper.Map<CustomerPOCO>(await Repository.GetWhere<Customer>().Where(c => c.Id == id).FirstOrDefaultAsync());
        }

        /// <summary>
        /// Gets the customer for the invoice asynchronously.
        /// </summary>
        /// <param name="invoiceId">The invoice identifier.</param>
        /// <returns>The customer.</returns>
        public virtual async Task<ICustomer> GetCustomerForInvoiceAsync(Guid invoiceId)
        {
            var invoice = await Repository.GetWhere<Invoice>().Where(r => r.Id == invoiceId).FirstOrDefaultAsync();
            return Mapper.Map<CustomerPOCO>(await Repository.GetWhere<Customer>().Where(p => p.Id == invoice.CustomerId).FirstOrDefaultAsync());
        }

        /// <summary>
        /// Creates a customer asynchronously.
        /// </summary>
        /// <param name="customer">The customer.</param>
        /// <returns></returns>
        public virtual Task<int> AddAsync(ICustomer customer)
        {
            return Repository.AddAsync<DAL.Customer>(Mapper.Map<DAL.Customer>(customer));
        }

        /// <summary>
        /// Updates the customer asynchronously.
        /// </summary>
        /// <param name="customer">The customer.</param>
        /// <returns></returns>
        public virtual Task<int> UpdateAsync(ICustomer customer)
        {
            return Repository.UpdateAsync<MemberRegistration.DAL.Customer>(Mapper.Map<MemberRegistration.DAL.Customer>(customer));
        }

        /// <summary>
        /// Removes the customer by id asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public virtual Task<int> DeleteAsync(Guid id)
        {
            return Repository.DeleteAsync<DAL.Customer>(id);
        }

        #endregion Methods
    }
}
