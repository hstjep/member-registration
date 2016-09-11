using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using MemberRegistration.Service.Common;
using MemberRegistration.Model.Common;
using MemberRegistration.Model;
using MemberRegistration.ViewModels;
using AutoMapper;
using PagedList;

namespace MemberRegistration.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CustomerController : Controller
    {
        #region Properites

        protected ICustomerService Service { get; private set; }

        #endregion Properties
        
        
        #region Constructors

        public CustomerController(ICustomerService service)
        {
            this.Service = service;
        }

        #endregion Constructors

       
        #region Methods

        /// <summary>
        /// Gets the customers.
        /// </summary>
        /// <returns>The customers.</returns>
        public async Task<ActionResult> Index(string searchTerm, int pageNumber = 1, int pageSize = 15)
        {
            var customers = Mapper.Map<IEnumerable<CustomerViewModel>>(
                await Service.GetAsync(new Common.Filters.Filter(searchTerm, pageNumber, pageSize)))
                .ToPagedList(pageNumber, pageSize);
           
            var customerPagedList = new StaticPagedList<CustomerViewModel>(customers, customers.GetMetaData());         
            return View(customerPagedList);
        }


        /// <summary>
        /// Gets the customer by id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The customer.</returns>
        public async Task<ActionResult> Details(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ICustomer customer = await Service.GetByIDAsync(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<CustomerViewModel>(customer));
        }

        /// <summary>
        /// Gets user interface for creating a new customer.
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Creates new customer.
        /// </summary>
        /// <param name="customer">The customer.</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,FirstName,LastName,OIB,Address,Place,PostalCode,Country,PdvId,IsMember")] CustomerViewModel customer)
        {
            customer.Id = Guid.NewGuid();
            customer.IsMember = false;

            if (ModelState.IsValid)
            {
                await Service.AddAsync(AutoMapper.Mapper.Map<CustomerPOCO>(customer));
                return RedirectToAction("Index");
            }

            return View();
        }

        /// <summary>
        /// Gets the customer by id for editing.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>User interface for editing the customer.</returns>
        public async Task<ActionResult> Edit(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var customer = await Service.GetByIDAsync(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<CustomerViewModel>(customer));
        }

        /// <summary>
        /// Updates the customer.
        /// </summary>
        /// <param name="customer">The customer.</param>
        /// <returns>The customers.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,FirstName,LastName,OIB,Address,Place,PostalCode,Country,PdvId,IsMember")] CustomerViewModel customer)
        {
            if (ModelState.IsValid)
            {
                await Service.UpdateAsync(AutoMapper.Mapper.Map<CustomerPOCO>(customer));
                return RedirectToAction("Index");
            }
            return View();
        }

        /// <summary>
        /// Gets the customer by id for deleting.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The customer.</returns>
        public async Task<ActionResult> Delete(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ICustomer customer = await Service.GetByIDAsync(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<CustomerViewModel>(customer));
        }

        /// <summary>
        /// Deletes the customer.
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
        /// Gets customers to populate the select2 dropdown.
        /// </summary>
        /// <param name="searchTerm"></param>
        /// <param name="currentFilter"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<JsonResult> SearchCustomer(string searchTerm, string currentFilter, int pageNumber = 0, int pageSize = 0)
        {
            var customers = await Service.GetAsync(new Common.Filters.Filter(searchTerm, pageNumber, pageSize));
            return Json(customers.Select(k => new { id = k.Id, text = k.FullName  }), JsonRequestBehavior.AllowGet);
        }

        #endregion Methods
    }
}
