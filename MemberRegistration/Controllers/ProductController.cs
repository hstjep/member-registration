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
    public class ProductController : Controller
    {
        #region Properties

        protected IProductService Service { get; private set; }

        #endregion Properties


        #region Constructors

        public ProductController(IProductService service)
        {
            this.Service = service;
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Gets the products.
        /// </summary>
        /// <returns>The products.</returns>
        public async Task<ActionResult> Index()
        {
            List<IProduct> products = await Service.GetAsync();
            return View(Mapper.Map<IEnumerable<ProductViewModel>>(products));
        }

        /// <summary>
        /// Gets the product by id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The product.</returns>
        public async Task<ActionResult> Details(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IProduct product = await Service.GetAsync(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<ProductViewModel>(product));
        }

        /// <summary>
        /// Gets user interface for creating a new product.
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Updates the product.
        /// </summary>
        /// <param name="Product"></param>
        /// <returns>The products.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,MeasuringUnit,Price")] ProductViewModel product)
        {
            if (ModelState.IsValid)
            {
                await Service.AddAsync(Mapper.Map<ProductPOCO>(product));
                return RedirectToAction("Index");
            }

            return View();
        }

        /// <summary>
        /// Gets the product by id for editing.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<ActionResult> Edit(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IProduct product = await Service.GetAsync(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<ProductViewModel>(product));
        }

        /// <summary>
        /// Updates the product.
        /// </summary>
        /// <param name="product">The product.</param>
        /// <returns>The products.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,MeasuringUnit,Price")] ProductViewModel product)
        {
            if (ModelState.IsValid)
            {
                await Service.UpdateAsync(AutoMapper.Mapper.Map<ProductPOCO>(product));
                return RedirectToAction("Index");
            }
            return View();
        }

        /// <summary>
        /// Gets the product by id for deleting.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>View for deleting the product.</returns>
        public async Task<ActionResult> Delete(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IProduct product = await Service.GetAsync(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<ProductViewModel>(product));
        }

        /// <summary>
        /// Deletes the product.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The products.</returns>
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
