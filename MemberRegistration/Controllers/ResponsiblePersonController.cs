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
    public class ResponsiblePersonController : Controller
    {
        #region Properties

        protected IResponsiblePersonService Service { get; set; }

        #endregion Properites


        #region Constructors

        public ResponsiblePersonController(IResponsiblePersonService service)
        {
            this.Service = service;
        }

        #endregion Constructors


        #region Methods

        /// <summary>
        /// Gets the responsible people.
        /// </summary>
        /// <returns>The responsible people.</returns>
        public async Task<ViewResult> Index()
        {
            List<IResponsiblePerson> customers = await Service.GetAsync();

            return View(Mapper.Map<IEnumerable<ResponsiblePersonViewModel>>(customers));
        }

        /// <summary>
        /// Gets the responsible person by id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The responsible person.</returns>
        public async Task<ActionResult> Details(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IResponsiblePerson responsiblePerson = await Service.GetAsync(id);
            if (responsiblePerson == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<ResponsiblePersonViewModel>(responsiblePerson));
        }

        /// <summary>
        /// Gets user interface for creating a new responsible person.
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Creates a responsible person.
        /// </summary>
        /// <param name="ResponsiblePerson">The responsible person.</param>
        /// <returns>The responsible people.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,FullName,Title")] ResponsiblePersonViewModel responsiblePerson)
        {
            if (ModelState.IsValid)
            {
                await Service.AddAsync(AutoMapper.Mapper.Map<ResponsiblePersonPOCO>(responsiblePerson));
                return RedirectToAction("Index");
            }

            return View();
        }

        /// <summary>
        /// Gets the responsible person by id for editing.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<ActionResult> Edit(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IResponsiblePerson responsiblePerson = await Service.GetAsync(id);
            if (responsiblePerson == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<ResponsiblePersonViewModel>(responsiblePerson));
        }

        /// <summary>
        /// Updates the responsible person.
        /// </summary>
        /// <param name="ResponsiblePerson"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,FullName,Title")] ResponsiblePersonViewModel responsiblePerson)
        {
            if (ModelState.IsValid)
            {
                await Service.UpdateAsync(Mapper.Map<ResponsiblePersonPOCO>(responsiblePerson));
                return RedirectToAction("Index");
            }
            return View(responsiblePerson);
        }

        /// <summary>
        /// Gets the responsible person by id for deleting.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>View for deleting the responsible person.</returns>
        public async Task<ActionResult> Delete(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IResponsiblePerson responsiblePerson = await Service.GetAsync(id);
            if (responsiblePerson == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<ResponsiblePersonViewModel>(responsiblePerson));
        }

        /// <summary>
        /// Deletes the responsible person.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            IResponsiblePerson responsiblePerson = await Service.GetAsync(id);
            await Service.DeleteAsync(id);
            return RedirectToAction("Index");
        }

        #endregion Methods
    }
}