using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MemberRegistration.ViewModels;
using MemberRegistration.Service.Common;
using MemberRegistration.Model.Common;
using MemberRegistration.Model;
using MemberRegistration.Common.Filters;
using AutoMapper;
using PagedList;
using System.Globalization;

namespace MemberRegistration.Controllers
{
    [Authorize(Roles = "Admin")]
    public class InvoiceController : Controller
    {
        #region Properties

        protected IInvoiceService Service { get; private set; }
        protected IProductService ProductService { get; private set; }
        protected IResponsiblePersonService ResponsiblePersonService { get; private set; }
        protected IInvoiceIssuerService InvoiceIssuerService { get; private set; }
        protected ICustomerService CustomerService { get; private set; }
        protected ISocietyService SocietyService { get; private set; }

        #endregion Properties


        #region Constructors

        public InvoiceController(IInvoiceService service, IProductService ProductService, IInvoiceIssuerService invoiceIssuerService, IResponsiblePersonService ResponsiblePersonService, ICustomerService customerService, ISocietyService societyService)
        {
            this.Service = service;
            this.ProductService = ProductService;
            this.InvoiceIssuerService = invoiceIssuerService;
            this.ResponsiblePersonService = ResponsiblePersonService;
            this.CustomerService = customerService;
            this.SocietyService = societyService;
        }

        #endregion Constructors

       
        #region Methods

        /// <summary>
        /// Gets all invoices.
        /// </summary>
        /// <returns>The invoices.</returns>
        public async Task<ActionResult> Index(string searchTerm, int pageNumber = 1, int pageSize = 15)
        {
            var invoices = Mapper.Map<IEnumerable<InvoiceViewModel>>(
                await Service.GetAsync(new Common.Filters.Filter(searchTerm, pageNumber, pageSize)))
                .ToPagedList(pageNumber, pageSize);

            var invoicePagedList = new StaticPagedList<InvoiceViewModel>(invoices, invoices.GetMetaData());
            return View(invoicePagedList);
        }


        /// <summary>
        /// Gets the invoice by id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The invoice.</returns>
        public async Task<ActionResult> Details(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IInvoice invoice = await Service.GetAsync(id);
            if (invoice == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<InvoiceViewModel>(invoice));
        }

        /// <summary>
        /// Gets user interface for creating a new invoice.
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> Create()
        {
            ViewBag.InvoiceNumber = await Service.GetInvoiceNumberAsync();
            ViewBag.InvoiceIssuerId = new SelectList(await InvoiceIssuerService.GetAsync(), "Id", "FullName");
            ViewBag.ResponsiblePersonId = new SelectList(await ResponsiblePersonService.GetAsync(), "Id", "FullName");
            ViewBag.SocietyId = new SelectList(await SocietyService.GetAsync(), "Id", "Name");
            
            return View();
        }


        /// <summary>
        /// Creates an invoice.
        /// </summary>
        /// <param name="invoice"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,SocietyId,CustomerId,Number,PaymentDate,MaturityDate,PaymentMethod,InvoiceIssuerId,ResponsiblePersonId")] InvoiceViewModel invoice)
        {
            invoice.MaturityDate = invoice.PaymentDate.AddDays(30);

            if (ModelState.IsValid)
            {
                await Service.AddAsync(AutoMapper.Mapper.Map<InvoicePOCO>(invoice));
                return RedirectToAction("Index");
            }

            ViewBag.InvoiceIssuerId = new SelectList(await InvoiceIssuerService.GetAsync(), "Id", "FullName");
            ViewBag.ResponsiblePersonId = new SelectList(await ResponsiblePersonService.GetAsync(), "Id", "FullName");
            ViewBag.SocietyId = new SelectList(await SocietyService.GetAsync(), "Id", "Name");
            
            return View(invoice);
        }

        /// <summary>
        /// Gets the invoice by id for editing.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The invoice.</returns>
        public async Task<ActionResult> Edit(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IInvoice invoice = await Service.GetAsync(id);
            if (invoice == null)
            {
                return HttpNotFound();
            }

            ViewBag.InvoiceIssuerId = new SelectList(await InvoiceIssuerService.GetAsync(), "Id", "FullName", invoice.InvoiceIssuerId);
            ViewBag.ResponsiblePersonId = new SelectList(await ResponsiblePersonService.GetAsync(), "Id", "FullName", invoice.ResponsiblePersonId);
            ViewBag.SocietyId = new SelectList(await SocietyService.GetAsync(), "Id", "Name", invoice.SocietyId);

            return View(Mapper.Map<InvoiceViewModel>(invoice));
        }

        /// <summary>
        /// Updates the invoice.
        /// </summary>
        /// <param name="invoice">The invoice.</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,SocietyId,CustomerId,Number,PaymentDate,MaturityDate,PaymentMethod,InvoiceIssuerId,ResponsiblePersonId")] InvoiceViewModel invoice)
        {
            if (ModelState.IsValid)
            {
                await Service.UpdateAsync(AutoMapper.Mapper.Map<InvoicePOCO>(invoice));
                return RedirectToAction("Index");
            }
            return View();
        }

        /// <summary>
        /// Gets the invoice by id for deleting.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The invoice.</returns>
        public async Task<ActionResult> Delete(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var invoice = await Service.GetAsync(id);
            if (invoice == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<InvoiceViewModel>(invoice));
        }

        /// <summary>
        /// Deletes the invoice.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            await Service.DeleteAsync(id);
            return RedirectToAction("Index");
        }


        /// <summary>
        /// Gets the product price for JS calculations in the _AddInvoiceItem partial view.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<JsonResult> PopulateProduct(Guid id)
        {
            ProductViewModel productResult = new ProductViewModel();

            IProduct product = await ProductService.GetWhereAsync(id);

            if (product != null)
            {
                productResult.Price = product.Price;
            }

            return Json(productResult);
        }

        /// <summary>
        /// Saves needed invoice data in the local variables and "prints" the invoice.
        /// </summary>
        /// <param name="invoiceId">The invoice identifier.</param>
        /// <returns>"Printed" invoice.</returns>
        [AllowAnonymous]
        public async Task<ActionResult> InvoiceReport(Guid invoiceId)
        {
            if (invoiceId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var invoice = await Service.GetAsync(invoiceId);
            var society = await Service.GetSocietyAsync(invoiceId);
            var customer = await Service.GetCustomerAsync(invoiceId);
            var invoiceItems = await Service.GetInvoiceItemProductAsync(invoiceId);

            ViewBag.Total = invoiceItems.Sum(x => x.Amount);
            return View(new Tuple<ISociety, ICustomer, IInvoice, IEnumerable<IInvoiceItemProduct>>(society, customer, invoice, invoiceItems));
        }

        [AllowAnonymous]
        public async Task<ActionResult> InvoiceReportEng(Guid invoiceId)
        {
            if (invoiceId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var invoice = await Service.GetAsync(invoiceId);
            var society = await Service.GetSocietyAsync(invoiceId);
            var customer = await Service.GetCustomerAsync(invoiceId);
            var invoiceItems = await Service.GetInvoiceItemProductAsync(invoiceId);

            ViewBag.Total = invoiceItems.Sum(x => x.Amount);
            return View(new Tuple<ISociety, ICustomer, IInvoice, IEnumerable<IInvoiceItemProduct>>(society, customer, invoice, invoiceItems));
        }

        #endregion Methods

    }
}
