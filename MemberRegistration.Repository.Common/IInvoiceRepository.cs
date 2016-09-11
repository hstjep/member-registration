using MemberRegistration.Common.Filters;
using MemberRegistration.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberRegistration.Repository.Common
{
    public interface IInvoiceRepository
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
        /// Gets the invoice by id asynchronously.
        /// </summary>
        /// <param name="invoiceId">The invoice identifier.</param>
        /// <returns>The invoice.</returns>
        Task<IInvoice> GetWhereAsync(Guid invoiceId);

        /// <summary>
        /// Creates an invoice asynchronously.
        /// </summary>
        /// <param name="invoice">The invoice.</param>
        /// <returns></returns>
        Task<int> AddAsync(IInvoice invoice);

        /// <summary>
        /// Updates the invoice asynchronously.
        /// </summary>
        /// <param name="invoice"></param>
        /// <returns></returns>
        Task<int> UpdateAsync(IInvoice invoice);

        /// <summary>
        /// Removes the invoice by id asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<int> DeleteAsync(Guid id);

        /// <summary>
        /// Gets the invoice number asynchronously.
        /// </summary>
        /// <returns>The invoice number.</returns>
        Task<int> GetInvoiceNumberAsync();

        #endregion Methods
    }
}
