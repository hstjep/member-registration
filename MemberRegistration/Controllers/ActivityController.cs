using MemberRegistration.Model.Common;
using MemberRegistration.Service.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using AutoMapper;
using MemberRegistration.ViewModels;
using System.Net;
using MemberRegistration.Model;
using PagedList;

namespace MemberRegistration.Controllers
{
    public class ActivityController : Controller
    {
        #region Properties

        protected IActivityService Service { get; set; }

        #endregion Properites


        #region Constructors

        public ActivityController(IActivityService service)
        {
            this.Service = service;
        }

        #endregion Constructors


        #region Methods

        /// <summary>
        /// Gets the activities.
        /// </summary>
        /// <returns>The activities.</returns>
        public async Task<ActionResult> Index(string searchTerm, int pageNumber = 1, int pageSize = 15)
        {
            var activities = Mapper.Map<IEnumerable<ActivityViewModel>>(
               await Service.GetAsync(new Common.Filters.Filter(searchTerm, pageNumber, pageSize)))
               .ToPagedList(pageNumber, pageSize);

            var activityPagedList = new StaticPagedList<ActivityViewModel>(activities, activities.GetMetaData());
            return View(activityPagedList);
        }

        /// <summary>
        /// Gets the activity by id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The activity details.</returns>
        public async Task<ActionResult> Details(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IActivity activity = await Service.GetAsync(id);
            if (activity == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<ActivityViewModel>(activity));
        }

        /// <summary>
        /// Gets user interface for creating a new activity.
        /// </summary>
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Adds new activity.
        /// </summary>
        /// <param name="activity"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,CustomerId,Name,Description,ActivityType,NumberOfHours,DateFrom,DateTo")] ActivityViewModel activity)
        {
            if (ModelState.IsValid)
            {
                await Service.AddAsync(Mapper.Map<ActivityPOCO>(activity));
                return RedirectToAction("Index");
            }

            return View();
        }

        /// <summary>
        /// Gets the activity by id for editing.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The activity.</returns>
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Edit(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IActivity activity = await Service.GetAsync(id);
            if (activity == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<ActivityViewModel>(activity));
        }

        /// <summary>
        /// Updates the activity.
        /// </summary>
        /// <param name="activity"></param>
        /// <returns>The activities.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,CustomerId,Name,Description,ActivityType,NumberOfHours,DateFrom,DateTo")] ActivityViewModel activity)
        {
            if (ModelState.IsValid)
            {
                await Service.UpdateAsync(AutoMapper.Mapper.Map<ActivityPOCO>(activity));
                return RedirectToAction("Index");
            }
            return View();
        }

        /// <summary>
        /// Gets the activity by id for deleting.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The activity.</returns>
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Delete(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IActivity activity = await Service.GetAsync(id);
            if (activity == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<ActivityViewModel>(activity));
        }

        /// <summary>
        /// Deletes the activity.
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