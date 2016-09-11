using MemberRegistration.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberRegistration.Repository.Common
{
    public interface IInvoiceIssuerRepository
    {
        #region Methods

        /// <summary>
        /// Gets all invoice issuers asynchronously.
        /// </summary>
        /// <returns>The invoice issuers.</returns>
        Task<List<IInvoiceIssuer>> GetAsync();

        /// <summary>
        /// Gets the invoice issuer by id asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The invoice issuer.</returns>
        Task<IInvoiceIssuer> GetAsync(Guid id);

        /// <summary>
        /// Creates an invoice issuer asynchronously.
        /// </summary>
        /// <param name="invoiceIssuer">The invoice issuer.</param>
        /// <returns></returns>
        Task<int> AddAsync(IInvoiceIssuer invoiceIssuer);

        /// <summary>
        /// Updates the invoice issuer asynchronously.
        /// </summary>
        /// <param name="invoiceIssuer">The invoice issuer.</param>
        /// <returns></returns>
        Task<int> UpdateAsync(IInvoiceIssuer invoiceIssuer);

        /// <summary>
        /// Removes the invoice issuer by id asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<int> DeleteAsync(Guid id);

        #endregion Methods
    }
}
