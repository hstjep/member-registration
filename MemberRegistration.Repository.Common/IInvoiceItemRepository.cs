using MemberRegistration.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MemberRegistration.Repository.Common
{
    public interface IInvoiceItemRepository
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
        Task<int> AddAsync(IUnitOfWork unitOfWork, IInvoiceItem invoiceItem);

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

        /// <summary>
        /// Gets the invoice item product asynchronously.
        /// </summary>
        /// <param name="invoiceId">The invoice identifier.</param>
        /// <returns></returns>
        Task<IEnumerable<IInvoiceItemProduct>> GetInvoiceItemProductAsync(Guid invoiceId);

        /// <summary>
        /// Creates the unit of work.
        /// </summary>
        /// <returns></returns>
        Task<IUnitOfWork> CreateUnitOfWork();

        #endregion Methods
    }
}
