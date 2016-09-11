using MemberRegistration.Model;
using MemberRegistration.Model.Common;
using MemberRegistration.Service.Common;
using MemberRegistration.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AutoMapper;

namespace MemberRegistration.Controllers
{
    public class ProfileController : Controller
    {
        #region Properties

        protected IMemberService Service { get; private set; }
        protected ISocietyService SocietyService { get; private set; }

        #endregion Properties


        #region Constructors

        public ProfileController(IMemberService service, ISocietyService societyService)
        {
            this.Service = service;
            this.SocietyService = societyService;
        }

        #endregion Constructors


        #region Methods

        /// <summary>
        /// Gets the current user.
        /// </summary>
        /// <returns>User profile view.</returns>
        public async Task<ActionResult> Index()
        {
            if (Request.IsAuthenticated)
            {
                var profile = await Service.GetCurrentAsync();
                ViewBag.UMemberId = profile.Id;
                return View(Mapper.Map<MemberViewModel>(profile));
            }
            else
            {
                return View();
            }
        }

        /// <summary>
        /// Gets the member by id for editing.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<ActionResult> Edit(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IMember Member = await Service.GetAsync(id);
            if (Member == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<MemberViewModel>(Member));
        }

        /// <summary>
        /// Updates the member.
        /// </summary>
        /// <param name="member">The member.</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,MembershipNumber,LastName,FirstName,OIB,BirthPlace,BirthDate,Address,Place,PostalCode,PhoneNumber,CurrentEmployment,Email,WebSite,AreaOfInterest,MembershipDate,Status")] MemberViewModel member)
        {
            if (ModelState.IsValid)
            {
                await Service.UpdateAsync(AutoMapper.Mapper.Map<MemberPOCO>(member));
                return RedirectToAction("Index");
            }
            return View();
        }

        #endregion Methods
    }
}