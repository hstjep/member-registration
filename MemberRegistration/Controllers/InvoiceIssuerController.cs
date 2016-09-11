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
using MemberRegistration.Model.Common;
using MemberRegistration.Model;
using MemberRegistration.ViewModels;
using AutoMapper;

namespace MemberRegistration.Controllers
{
    [Authorize(Roles = "Admin")]
    public class InvoiceIssuerController : Controller
    {
        #region Properties

        protected IInvoiceIssuerService Service { get; private set; }

        #endregion Properties


        #region Constructors

        public InvoiceIssuerController(IInvoiceIssuerService service)
        {
            this.Service = service;
        }

        #endregion Constructors

        
        #region Methods

        /// <summary>
        /// Gets all invoice issuers.
        /// </summary>
        /// <returns>The invoice issuers.</returns>
        public async Task<ActionResult> Index()
        {
            List<IInvoiceIssuer> invoiceIssuers = await Service.GetAsync();
            return View(Mapper.Map<IEnumerable<InvoiceIssuerViewModel>>(invoiceIssuers));
        }


        /// <summary>
        /// Gets the invoice issuer by id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The invoice issuer.</returns>
        public async Task<ActionResult> Details(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IInvoiceIssuer invoiceIssuer = await Service.GetAsync(id);
            if (invoiceIssuer == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<InvoiceIssuerViewModel>(invoiceIssuer));
        }

        /// <summary>
        /// Gets user interface for creating a new invoice issuer.
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Crates an invoice issuer.
        /// </summary>
        /// <param name="invoiceIssuer">The invoice issuer.</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,FullName,OperatorLabel")] InvoiceIssuerViewModel invoiceIssuer)
        {
            if (ModelState.IsValid)
            {                
                await Service.AddAsync(AutoMapper.Mapper.Map<InvoiceIssuerPOCO>(invoiceIssuer));
                return RedirectToAction("Index");
            }

            return View();
        }

        /// <summary>
        /// Gets the selected invoice issuer by id for editing.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<ActionResult> Edit(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var invoiceIssuer = await Service.GetAsync(id);
            if (invoiceIssuer == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<InvoiceIssuerViewModel>(invoiceIssuer));
        }

        /// <summary>
        /// Updates the invoice issuer.
        /// </summary>
        /// <param name="invoiceIssuer">The invoice issuer.</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,FullName,OperatorLabel")] InvoiceIssuerViewModel invoiceIssuer)
        {
            if (ModelState.IsValid)
            {
                await Service.UpdateAsync(AutoMapper.Mapper.Map<InvoiceIssuerPOCO>(invoiceIssuer));
                return RedirectToAction("Index");
            }
            return View();
        }


        /// <summary>
        /// Gets the invoice issuer by id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<ActionResult> Delete(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var invoiceIssuer = await Service.GetAsync(id);
            if (invoiceIssuer == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<InvoiceIssuerViewModel>(invoiceIssuer));
        }

        /// <summary>
        /// Deletes the invoice issuer.
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

        #endregion Methods
    }
}

