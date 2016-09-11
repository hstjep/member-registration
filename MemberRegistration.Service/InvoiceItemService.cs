using MemberRegistration.Model.Common;
using MemberRegistration.Repository.Common;
using MemberRegistration.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MemberRegistration.Model;

namespace MemberRegistration.Service
{
    public class InvoiceItemService : IInvoiceItemService
    {
        #region Properties

        protected IInvoiceItemRepository Repository { get; private set; }
        protected IProductRepository ProductRepository { get; private set; }
        protected IInvoiceRepository InvoiceRepository { get; private set; }
        protected IMembershipFeeRepository MembershipFeeRepository { get; private set; }

        #endregion Properties


        #region Constructors

        public InvoiceItemService(IInvoiceItemRepository repository, IProductRepository productRepository, IInvoiceRepository invoiceRepository, IMembershipFeeRepository membershipFeeRepository)
        {
            this.Repository = repository;
            this.ProductRepository = productRepository;
            this.InvoiceRepository = invoiceRepository;
            this.MembershipFeeRepository = membershipFeeRepository;
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
        public IEnumerable<IInvoiceItem> Get(Guid invoiceId)
        {
            return Repository.Get(invoiceId);
        }

        /// <summary>
        /// Gets the invoice item by id asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// The invoice item.
        /// </returns>
        public Task<IInvoiceItem> GetAsync(Guid id)
        {
            return Repository.GetAsync(id);
        }

        /// <summary>
        /// Adds an invoice item asynchronously.
        /// </summary>
        /// <param name="invoiceItem">The invoice item.</param>
        /// <returns></returns>
        public async Task<int> AddAsync(IInvoiceItem invoiceItem)
        {
            IUnitOfWork unitOfWork = await Repository.CreateUnitOfWork();

            var product = await ProductRepository.GetWhereAsync(invoiceItem.ProductId);

            if (product.Name.Contains("Članarina"))
            {
                var invoice = await InvoiceRepository.GetAsync(invoiceItem.InvoiceId);               
                var expYear = (DateTime.Today.Year - invoiceItem.Year) - 1;

                await Repository.AddAsync(unitOfWork, invoiceItem);

                var membershipFee = new MembershipFeePOCO
                {
                    Id = Guid.NewGuid(),
                    MemberId = invoiceItem.MemberId,
                    InvoiceId = invoiceItem.InvoiceId,
                    InvoiceItemId = invoiceItem.Id,
                    Year = invoiceItem.Year,
                    PaymentStatus = MemberRegistration.Common.PaymentStatus.Da,
                    Amount = invoiceItem.Value,
                    PaymentDate = invoice.PaymentDate,
                    ExpirationDate = invoice.PaymentDate.AddYears(-expYear)
                };

                await MembershipFeeRepository.AddAsync(unitOfWork, membershipFee);
                return await unitOfWork.CommitAsync();
            }
            else
            {
                await Repository.AddAsync(unitOfWork, invoiceItem);
                return await unitOfWork.CommitAsync();
            }
        }

        /// <summary>
        /// Updates the invoice item asynchronously.
        /// </summary>
        /// <param name="invoiceItem">The invoice item.</param>
        /// <returns></returns>
        public Task<int> UpdateAsync(IInvoiceItem invoiceItem)
        {
            return Repository.UpdateAsync(invoiceItem);
        }

        /// <summary>
        /// Removes the invoice item by id asynchronously.
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
