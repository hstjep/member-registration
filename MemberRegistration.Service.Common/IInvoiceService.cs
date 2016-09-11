using MemberRegistration.Common.Filters;
using MemberRegistration.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberRegistration.Service.Common
{
    public interface IInvoiceService
    {
        #region Methods

        /// <summary>
        /// Gets invoices asynchronously.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns>The invoices.</returns>
        Task<IEnumerable<IInvoice>> GetAsync(IFilter filter = null);

        /// <summary>
        /// Gets the invoice by id asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The invoice.</returns>
        Task<IInvoice> GetAsync(Guid id);

        /// <summary>
        /// Creates a invoice (invoice) of the type IInvoice async.
        /// </summary>
        /// <param name="invoice"></param>
        /// <returns></returns>
        Task<int> AddAsync(IInvoice invoice);

        /// <summary>
        /// Gets the invoice by id asynchronously.
        /// </summary>
        /// <param name="invoiceId">The invoice identifier.</param>
        /// <returns>The invoice.</returns>
        Task<int> UpdateAsync(IInvoice invoice);

        /// <summary>
        /// Creates an invoice asynchronously.
        /// </summary>
        /// <param name="invoice">The invoice.</param>
        /// <returns></returns>
        Task<int> DeleteAsync(Guid id);

        /// <summary>
        /// Gets the invoice number asynchronous.
        /// </summary>
        /// <returns></returns>
        Task<int> GetInvoiceNumberAsync();

        #region Methods for RacunReport

        Task<IInvoice> GetRacunAsync(Guid invoiceId);

        Task<ISociety> GetSocietyAsync(Guid invoiceId);

        Task<ICustomer> GetCustomerAsync(Guid invoiceId);

        Task<IEnumerable<IInvoiceItemProduct>> GetInvoiceItemProductAsync(Guid invoiceId);

        #endregion Methods for RacunReport

        #endregion Methods
    }
}
