using MemberRegistration.Common.Filters;
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
    public class InvoiceService : IInvoiceService
    {
        #region Properties

        protected IInvoiceRepository Repository { get; private set; }
        protected ICustomerRepository CustomerRepository { get; private set; }
        protected ISocietyRepository SocietyRepository { get; private set; }
        protected IInvoiceItemRepository StavkaRepository { get; private set; }
        protected IInvoiceRepository InvoiceRepository { get; private set; }
        protected IProductRepository ProductRepository { get; private set; }
        protected IMemberRepository MemberRepository { get; private set; }

        #endregion Properties


        #region Constructors

        public InvoiceService(IInvoiceRepository repository, ICustomerRepository customerRepository, ISocietyRepository societyRepository, IInvoiceItemRepository stavkaRepository, IInvoiceRepository invoiceRepository, IProductRepository ProductRepository, IMemberRepository MemberRepository)
        {
            this.Repository = repository;
            this.CustomerRepository = customerRepository;
            this.SocietyRepository = societyRepository;
            this.StavkaRepository = stavkaRepository;
            this.InvoiceRepository = invoiceRepository;
            this.ProductRepository = ProductRepository;
            this.MemberRepository = MemberRepository;
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
        public Task<ICollectionModel<IInvoice>> GetAsync(IFilter filter)
        {
            return Repository.GetAsync(filter);
        }

        /// <summary>
        /// Gets the invoice (invoice) by id async.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The invocie.</returns>
        public Task<IInvoice> GetAsync(Guid id)
        {
            return Repository.GetAsync(id);
        }

        /// <summary>
        /// Adds an invoice (invoice) async.
        /// </summary>
        /// <param name="invoice"></param>
        /// <returns></returns>
        public Task<int> AddAsync(IInvoice invoice)
        {
            return Repository.AddAsync(invoice);
        }

        /// <summary>
        /// Updates the invoice (invoice) async.
        /// </summary>
        /// <param name="invoice"></param>
        /// <returns></returns>
        public Task<int> UpdateAsync(IInvoice invoice)
        {
            return Repository.UpdateAsync(invoice);
        }

        /// <summary>
        /// Removes the invoice by ID async.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<int> DeleteAsync(Guid id)
        {
            return Repository.DeleteAsync(id);
        }

        public Task<int> GetInvoiceNumberAsync()
        {
            return Repository.GetInvoiceNumberAsync();
        }


        #region Methods for RacunReport

        /// <summary>
        /// Gets the racun asynchronous.
        /// </summary>
        /// <param name="invoiceId">The invoice identifier.</param>
        /// <returns></returns>
        public Task<IInvoice> GetRacunAsync(Guid invoiceId)
        {
            return Repository.GetWhereAsync(invoiceId);
        }

        /// <summary>
        /// Gets the society asynchronous.
        /// </summary>
        /// <param name="invoiceId">The invoice identifier.</param>
        /// <returns></returns>
        public Task<ISociety> GetSocietyAsync(Guid invoiceId)
        {
            return SocietyRepository.GetSocietyForInvoiceAsync(invoiceId);
        }

        /// <summary>
        /// Gets the customer asynchronous.
        /// </summary>
        /// <param name="invoiceId">The invoice identifier.</param>
        /// <returns></returns>
        public Task<ICustomer> GetCustomerAsync(Guid invoiceId)
        {
            return CustomerRepository.GetCustomerForInvoiceAsync(invoiceId);
        }

        /// <summary>
        /// Gets the invoice item product asynchronous.
        /// </summary>
        /// <param name="invoiceId">The invoice identifier.</param>
        /// <returns></returns>
        public Task<IEnumerable<IInvoiceItemProduct>> GetInvoiceItemProductAsync(Guid invoiceId)
        {
            return StavkaRepository.GetInvoiceItemProductAsync(invoiceId);
        }

        #endregion Methods for RacunReport

        #endregion Methods
    }
}
