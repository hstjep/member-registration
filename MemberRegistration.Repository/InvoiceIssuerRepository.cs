using MemberRegistration.DAL;
using MemberRegistration.Model;
using MemberRegistration.Model.Common;
using MemberRegistration.Repository.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;

namespace MemberRegistration.Repository
{
    public class InvoiceIssuerRepository : IInvoiceIssuerRepository
    {
        #region Properties

        protected IRepository Repository { get; private set; }
    
        #endregion Properties


        #region Constructors

        public InvoiceIssuerRepository(IRepository repository)
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
        public virtual async Task<List<IInvoiceIssuer>> GetAsync()
        {
            return Mapper.Map<List<IInvoiceIssuer>>(await Repository.GetAsync<InvoiceIssuer>());
        }

        /// <summary>
        /// Gets the invoice issuer by id asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// The invoice issuer.
        /// </returns>
        public virtual async Task<IInvoiceIssuer> GetAsync(Guid id)
        {
            return Mapper.Map<InvoiceIssuerPOCO>(await Repository.GetByIDAsync<InvoiceIssuer>(id));
        }

        /// <summary>
        /// Creates an invoice issuer asynchronously.
        /// </summary>
        /// <param name="invoiceIssuer">The invoice issuer.</param>
        /// <returns></returns>
        public virtual Task<int> AddAsync(IInvoiceIssuer invoiceIssuer)
        {
            return Repository.AddAsync<DAL.InvoiceIssuer>(Mapper.Map<DAL.InvoiceIssuer>(invoiceIssuer));
        }

        /// <summary>
        /// Updates the invoice issuer asynchronously.
        /// </summary>
        /// <param name="invoiceIssuer">The invoice issuer.</param>
        /// <returns></returns>
        public virtual Task<int> UpdateAsync(IInvoiceIssuer invoiceIssuer)
        {
            return Repository.UpdateAsync<MemberRegistration.DAL.InvoiceIssuer>(Mapper.Map<MemberRegistration.DAL.InvoiceIssuer>(invoiceIssuer));
        }

        /// <summary>
        /// Removes the entity by id asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public virtual Task<int> DeleteAsync(Guid id)
        {
            return Repository.DeleteAsync<DAL.InvoiceIssuer>(id);
        }

        #endregion Methods
    }
}
