using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MemberRegistration.Service.Common;
using MemberRegistration.ViewModels;
using MemberRegistration.Model.Common;
using MemberRegistration.Model;
using MemberRegistration.Common.Filters;
using AutoMapper;
using MemberRegistration.Common;

namespace MemberRegistration.Controllers
{
    [Authorize(Roles = "Admin")]
    public class InvoiceItemController : Controller
    {
        #region Properties

        protected IInvoiceItemService Service { get; private set; }
        protected IInvoiceService InvoiceService { get; set; }
        protected IProductService ProductService { get; private set; }
        protected IMemberService MemberService { get; private set; }

        #endregion Properties


        #region Constructors

        public InvoiceItemController(IInvoiceItemService service, IInvoiceService invoiceService, IProductService productService, IMemberService memberService)
        {
            this.Service = service;
            this.InvoiceService = invoiceService;
            this.ProductService = productService;
            this.MemberService = memberService;
        }

        #endregion Constructors


        #region Methods

        /// <summary>
        /// Gets the invoice item by id for editing.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<ActionResult> Edit(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var invoiceItem = await Service.GetAsync(id);
            if (invoiceItem == null)
            {
                return HttpNotFound();
            }

            ViewBag.InvoiceId = new SelectList(await InvoiceService.GetAsync(), "Id", "Number", invoiceItem.InvoiceId);
            ViewBag.MemberId = new SelectList(await MemberService.GetAsync(), "Id", "LastName", invoiceItem.MemberId);
            ViewBag.ProductId = new SelectList(await ProductService.GetAsync(), "Id", "Name", invoiceItem.ProductId);
            ViewBag.Year = new SelectList(Enumerable.Range(2011, (DateTime.Today.Year - 2011) + 2), invoiceItem.Year);
            
            return View(Mapper.Map<InvoiceItemViewModel>(invoiceItem));
        }

        /// <summary>
        /// Updates the invoice item.
        /// </summary>
        /// <param name="invoiceItem">The invoice item.</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,InvoiceId,ProductId,Year,MemberId,CurrencyUnit,Quantity,Value")] InvoiceItemViewModel invoiceItem)
        {
            if (ModelState.IsValid)
            {
                await Service.UpdateAsync(AutoMapper.Mapper.Map<InvoiceItemPOCO>(invoiceItem));
                return RedirectToAction("Details", "Invoice", new { id = invoiceItem.InvoiceId });
            }
            return View();
        }


        /// <summary>
        /// Gets the invoice item by id for deleting.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>View for deleting the invoice item.</returns>
        public async Task<ActionResult> Delete(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IInvoiceItem invoiceItem = await Service.GetAsync(id);
            if (invoiceItem == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<InvoiceItemViewModel>(invoiceItem));
        }

        /// <summary>
        /// Deletes the invoice item.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            IInvoiceItem invoiceItem = await Service.GetAsync(id);
            await Service.DeleteAsync(id);
            return RedirectToAction("Details", "Invoice", new { id = invoiceItem.InvoiceId }); 
        }

        #endregion Methods

        #region Methods for Partial Views

        /// <summary>
        /// Returns Partial View to display items of the invoice.
        /// </summary>
        /// <param name="RacunZId"></param>
        /// <returns></returns>
        public PartialViewResult _InvoiceItemForInvoice(Guid invoiceId)
        {
            var invoiceItems = Service.Get(invoiceId);
            ViewBag.InvoiceId = invoiceId;
            return PartialView(Mapper.Map<List<InvoiceItemViewModel>>(invoiceItems));
        }


        /// <summary>
        /// Adds new item.
        /// </summary>
        /// <param name="invoiceItem"></param>
        /// <param name="RacunZId">The invoice identifier.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<PartialViewResult> _InvoiceItemForInvoice(InvoiceItemViewModel invoiceItem, Guid invoiceId)
        {
            invoiceItem.InvoiceId = invoiceId;

            if (ModelState.IsValid)
            {
                await Service.AddAsync(Mapper.Map<InvoiceItemPOCO>(invoiceItem));
            }

            var invoiceItems = Service.Get(invoiceId);
            ViewBag.InvoiceId = invoiceId;
            return PartialView("_InvoiceItemForInvoice", Mapper.Map<List<InvoiceItemViewModel>>(invoiceItems));
        }


        /// <summary>
        /// Gets the partial view for displaying user interface for creating an invoice item with the invoice.
        /// </summary>
        /// <param name="RacunZId">The invoice identifier.</param>
        /// <returns>The partial view for creating an invoice item.</returns>
        public PartialViewResult _Create(Guid invoiceId)
        {
            ViewBag.InvoiceId = invoiceId;
            ViewBag.ProductId = new SelectList(ProductService.Get(), "Id", "Name");
            ViewBag.Year = new SelectList(Enumerable.Range(2011, (DateTime.Today.Year - 2011) + 2));
            return PartialView("_AddInvoiceItem");
        }

        #endregion Methods for Partial Views
    }
}
