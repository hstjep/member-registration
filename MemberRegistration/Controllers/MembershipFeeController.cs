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
        public async Task<ActionResult> Index(string searchTerm, int pageNumber = 1, int pageSize = 15)
        {
            if (User.IsInRole("Admin"))
            {
                var membershipFees = Mapper.Map<IEnumerable<MembershipFeeViewModel>>(
                    await Service.GetAsync(new Common.Filters.Filter(searchTerm, pageNumber, pageSize)))
                    .ToPagedList(pageNumber, pageSize);

                var membershipFeesPagedList = new StaticPagedList<MembershipFeeViewModel>(membershipFees, membershipFees.GetMetaData());
                return View(membershipFeesPagedList);
            }
            else
            {
                var membershipFees = Mapper.Map<IEnumerable<MembershipFeeViewModel>>(
                    Service.GetCurrentAsync())
                    .ToPagedList(pageNumber, pageSize);

                var membershipFeePagedList = new StaticPagedList<MembershipFeeViewModel>(membershipFees, membershipFees.GetMetaData());
                return View(membershipFeePagedList);
            }
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