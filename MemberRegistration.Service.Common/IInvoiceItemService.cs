using MemberRegistration.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberRegistration.Service.Common
{
    public interface IInvoiceItemService
    {
        #region Methods

        /// <summary>
        /// Gets the invoice by id.
        /// </summary>
        /// <param name="invoiceId">The invoice identifier.</param>
        /// <returns>The invoice.</returns>
        IEnumerable<IInvoiceItem> Get(Guid invoiceId);

        /// <summary>
        /// Gets the invoice item by id asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The invoice item.</returns>
        Task<IInvoiceItem> GetAsync(Guid id);

        /// <summary>
        /// Adds an invoice item asynchronously.
        /// </summary>
        /// <param name="invoiceItem">The invoice item.</param>
        /// <returns></returns>
        Task<int> AddAsync(IInvoiceItem invoiceItem);

        /// <summary>
        /// Updates the invoice item asynchronously.
        /// </summary>
        /// <param name="invoiceItem">The invoice item.</param>
        /// <returns></returns>
        Task<int> UpdateAsync(IInvoiceItem invoiceItem);

        /// <summary>
        /// Removes the invoice item by id asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<int> DeleteAsync(Guid id);

        #endregion Methods
    }
}
