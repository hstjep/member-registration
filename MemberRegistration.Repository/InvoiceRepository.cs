using MemberRegistration.Model.Common;
using MemberRegistration.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MemberRegistration.DAL;
using MemberRegistration.Model;
using System.Data.Entity;
using MemberRegistration.Common.Filters;

namespace MemberRegistration.Repository
{
    public class InvoiceRepository : IInvoiceRepository
    {
        #region Properties

        protected IRepository Repository { get; private set; }

        #endregion Properties


        #region Constructors

        public InvoiceRepository(IRepository repository)
        {
            this.Repository = repository;
        }

        #endregion Constructors


        #region Methods

        /// <summary>
        /// Gets invoices asynchronously.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns>
        /// The invoices.
        /// </returns>
        public async Task<IEnumerable<IInvoice>> GetAsync(IFilter filter = null)
        {
            if (filter != null)
            {
                var invoices = Mapper.Map<List<IInvoice>>(await Repository.GetWhere<Invoice>().OrderByDescending(r => r.Number).ToListAsync());

                if (!string.IsNullOrWhiteSpace(filter.SearchString))
                {
                    invoices = invoices.Where(f => f.Customer.LastName != null 
                    && f.Customer.LastName.ToUpper()
                        .Contains(filter.SearchString.ToUpper())
                        || f.Customer.FirstName.ToUpper()
                        .Contains(filter.SearchString.ToUpper()))
                        .ToList();
                }
                return invoices;
            }
            else
            {
                return Mapper.Map<IEnumerable<IInvoice>>(await Repository.GetWhere<Invoice>().ToListAsync());
            }
        }

        /// <summary>
        /// Gets the invoice by id asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// The invoice.
        /// </returns>
        public async Task<IInvoice> GetAsync(Guid id)
        {
            return Mapper.Map<InvoicePOCO>(await Repository.GetByIDAsync<Invoice>(id));
        }

        /// <summary>
        /// Gets the invoice by id asynchronously.
        /// </summary>
        /// <param name="invoiceId">The invoice identifier.</param>
        /// <returns>
        /// The invoice.
        /// </returns>
        public virtual async Task<IInvoice> GetWhereAsync(Guid invoiceId)
        {
            return Mapper.Map<InvoicePOCO>(await Repository.GetWhere<Invoice>().Where(p => p.Id == invoiceId).FirstOrDefaultAsync());           
        }

        /// <summary>
        /// Updates the invoice asynchronously.
        /// </summary>
        /// <param name="invoice"></param>
        /// <returns></returns>
        public virtual Task<int> UpdateAsync(IInvoice invoice)
        {
            return Repository.UpdateAsync<MemberRegistration.DAL.Invoice>(Mapper.Map<MemberRegistration.DAL.Invoice>(invoice));
        }

        /// <summary>
        /// Creates an invoice asynchronously.
        /// </summary>
        /// <param name="invoice">The invoice.</param>
        /// <returns></returns>
        public virtual Task<int> AddAsync(IInvoice invoice)
        {
            return Repository.AddAsync<DAL.Invoice>(Mapper.Map<DAL.Invoice>(invoice));
        }

        /// <summary>
        /// Removes the invoice by id asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public virtual Task<int> DeleteAsync(Guid id)
        {
            return Repository.DeleteAsync<DAL.Invoice>(id);
        }

        /// <summary>
        /// Gets the invoice number asynchronously.
        /// </summary>
        /// <returns>
        /// The invoice number.
        /// </returns>
        public virtual Task<int> GetInvoiceNumberAsync()
        {
            var lastInvoice = Repository.GetWhere<Invoice>()
              .OrderByDescending(i => i.PaymentDate.Year)
              .ThenByDescending(i => i.Number)
              .Select(i => new { i.Number, i.PaymentDate.Year })
              .FirstOrDefault();

            if (lastInvoice != null)
            {
                if (lastInvoice.Year < DateTime.Today.Year)
                {
                    return Task.FromResult(1);
                }
                else
                {
                    return Task.FromResult(lastInvoice.Number + 1);
                }
            }
            else
            {
                return Task.FromResult(1);
            }
        }

        #endregion Methods
    }
}
