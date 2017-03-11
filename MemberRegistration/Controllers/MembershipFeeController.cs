using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using MemberRegistration.Model.Common;
using MemberRegistration.Service.Common;
using MemberRegistration.ViewModels;
using AutoMapper;
using PagedList;
using Quartz;
using System.Net.Mail;
using Quartz.Impl;

namespace MemberRegistration.Controllers
{
    public class MembershipFeeController : Controller
    {
        #region Properties

        protected IMembershipFeeService Service { get; private set; }
        protected UserManager<MemberRegistration.Models.ApplicationUser, Guid> UserManager { get; private set; }

        #endregion Properties


        #region Constructors

        public MembershipFeeController(IMembershipFeeService service)
        {
            this.Service = service;
            UserManager = new UserManager<MemberRegistration.Models.ApplicationUser, Guid>(new MemberRegistration.Models.CustomUserStore(new MemberRegistration.Models.ApplicationDbContext()));
        }

        #endregion Constructors


        #region Methods

        /// <summary>
        /// If user is in role Admin, gets all membership fees from the database, 
        /// if not, gets the membership fees of the current user.
        /// </summary>
        /// <returns>The affiliation fees.</returns>
        public async Task<ActionResult> Index(string searchTerm, int pageNumber = 0, int pageSize = 2)
        {
            var filter = new Common.Filters.Filter(searchTerm, pageNumber, pageSize);
            var currentUserId = User.IsInRole("Admin") ? Guid.Parse(User.Identity.GetUserId()) : Guid.Empty;
            filter.CurrentUserId = currentUserId;

            var membershipFees = Mapper.Map<CollectionViewModel<MembershipFeeViewModel>>(
                   await Service.GetAsync(filter));

            return View(membershipFees);
        }


        /// <summary>
        /// Gets the membership fee by id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The membership fee.</returns>
        public async Task<ActionResult> Details(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IMembershipFee membershipFee = await Service.GetAsync(id);
            if (membershipFee == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<MembershipFeeViewModel>(membershipFee));
        }

        #endregion Methods
    }
}