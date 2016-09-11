using MemberRegistration.Model.Common;
using MemberRegistration.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MemberRegistration.Model;
using MemberRegistration.DAL;
using System.Data.Entity;
using System.Linq.Expressions;

namespace MemberRegistration.Repository
{
    public class InvoiceItemRepository : IInvoiceItemRepository
    {
        #region Properties

        protected IRepository Repository { get; private set; }

        #endregion Properties


        #region Constructors

        public InvoiceItemRepository(IRepository repository)
        {
            this.Repository = repository;
        }

        #endregion Constructors


        #region Methods

        /// <summary>
        /// Gets the invoice by id.
        /// </summary>
        /// <param name="invoiceId">The invoice identifier.</param>
        /// <returns>
        /// The invoice.
        /// </returns>
        public virtual IEnumerable<IInvoiceItem> Get(Guid invoiceId)
        {
            return Mapper.Map<IEnumerable<InvoiceItemPOCO>>(Repository.GetWhere<InvoiceItem>().Where(s => s.InvoiceId == invoiceId).ToList());
        }

        /// <summary>
        /// Gets the invoice item by id asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// The invoice item.
        /// </returns>
        public virtual async Task<IInvoiceItem> GetAsync(Guid id)
        {
            return Mapper.Map<InvoiceItemPOCO>(await Repository.GetByIDAsync<InvoiceItem>(id));          
        }

        /// <summary>
        /// Adds an invoice item asynchronously.
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="invoiceItem">The invoice item.</param>
        /// <returns></returns>
        public virtual Task<int> AddAsync(IUnitOfWork unitOfWork, IInvoiceItem invoiceItem)
        {
            return unitOfWork.AddAsync<InvoiceItem>(Mapper.Map<InvoiceItem>(invoiceItem));
        }

        /// <summary>
        /// Updates the invoice item asynchronously.
        /// </summary>
        /// <param name="invoiceItem">The invoice item.</param>
        /// <returns></returns>
        public virtual Task<int> UpdateAsync(IInvoiceItem invoiceItem)
        {
            return Repository.UpdateAsync<MemberRegistration.DAL.InvoiceItem>(Mapper.Map<MemberRegistration.DAL.InvoiceItem>(invoiceItem));
        }

        /// <summary>
        /// Removes the invoice item by id asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public virtual async Task<int> DeleteAsync(Guid id)
        {
            IUnitOfWork unitOfWork = await CreateUnitOfWork();
            await unitOfWork.DeleteAsync<DAL.InvoiceItem>(id);
            return await unitOfWork.CommitAsync();
        }

        /// <summary>
        /// Gets the invoice item product asynchronously.
        /// </summary>
        /// <param name="invoiceId">The invoice identifier.</param>
        /// <returns></returns>
        public virtual async Task<IEnumerable<IInvoiceItemProduct>> GetInvoiceItemProductAsync(Guid invoiceId)
        {
            var invoice = await Repository.GetByIDAsync<Invoice>(invoiceId);

            var invoiceItems = (from rS in Repository.GetWhere<InvoiceItem>()
                            join p in Repository.GetWhere<Product>() on rS.ProductId equals p.Id
                            join c in Repository.GetWhere<Member>() on rS.MemberId equals c.Id
                            where (rS.InvoiceId == invoice.Id)
                            select new InvoiceItemProductPOCO
                            {
                                ProductName = p.Name,
                                Year = rS.Year,
                                MemberFirstName = c.FirstName,
                                MemberLastName = c.LastName,
                                Quantity = rS.Quantity,
                                Price = p.Price,
                                Amount = rS.Value,
                                MeasuringUnit = p.MeasuringUnit,
                                CurrencyUnit =  rS.CurrencyUnit
                            });

            return invoiceItems;
        }

        /// <summary>
        /// Creates the unit of work.
        /// </summary>
        /// <returns></returns>
        public Task<IUnitOfWork> CreateUnitOfWork()
        {
            return Task.FromResult(Repository.CreateUnitOfWork());
        }

        #endregion Methods
    }
}

