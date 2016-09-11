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
    public class InvoiceIssuerService : IInvoiceIssuerService
    {
        #region Properties

        protected IInvoiceIssuerRepository Repository { get; private set; }
    
        #endregion Properties


        #region Constructors

        public InvoiceIssuerService(IInvoiceIssuerRepository repository)
        {
            this.Repository = repository;
        }

        #endregion Constructors


        #region Methods

        /// <summary>
        /// Gets all invoice issuers asynchronously.
        /// </summary>
        /// <returns>
        /// The invoice issuers.
        /// </returns>
        public Task<List<IInvoiceIssuer>> GetAsync()
        {
            return Repository.GetAsync();
        }

        /// <summary>
        /// Gets the invoice issuer by id asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// The invoice issuer.
        /// </returns>
        public Task<IInvoiceIssuer> GetAsync(Guid id)
        {
            return Repository.GetAsync(id);
        }

        /// <summary>
        /// Creates an invoice issuer asynchronously.
        /// </summary>
        /// <param name="invoiceIssuer">The invoice issuer.</param>
        /// <returns></returns>
        public Task<int> AddAsync(IInvoiceIssuer invoiceIssuer)
        {
            return Repository.AddAsync(invoiceIssuer);
        }

        /// <summary>
        /// Updates the invoice issuer asynchronously.
        /// </summary>
        /// <param name="invoiceIssuer">The invoice issuer.</param>
        /// <returns></returns>
        public Task<int> UpdateAsync(IInvoiceIssuer invoiceIssuer)
        {
            return Repository.UpdateAsync(invoiceIssuer);
        }

        /// <summary>
        /// Removes the invoice issuer by id asynchronously.
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
