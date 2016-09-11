using MemberRegistration.Common.Filters;
using MemberRegistration.Model;
using MemberRegistration.Model.Common;
using MemberRegistration.Service.Common;
using MemberRegistration.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using PagedList;
using AutoMapper;

namespace MemberRegistration.Controllers
{
    public class MemberController : Controller
    {
        #region Properties
        
        protected IMemberService Service { get; private set; }
        protected ISocietyService SocietyService { get; private set; }

        #endregion Properties


        #region Constructors

        public MemberController(IMemberService service, ISocietyService societyService)
        {
            this.Service = service;
            this.SocietyService = societyService;
        }

        #endregion Constructors


        #region Methods

        /// <summary>
        /// Gets the members.
        /// </summary>
        /// <param name="searchString">The search string.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>The members.</returns>
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Index(string searchString, int pageNumber = 1, int pageSize = 15)
        {
            var members = Mapper.Map<IEnumerable<MemberViewModel>>(
                await Service.GetAsync(new Common.Filters.Filter(searchString, pageNumber, pageSize)))
                .ToPagedList(pageNumber, pageSize);

            var MembersPagedList = new StaticPagedList<MemberViewModel>(members, members.GetMetaData());
            return View(MembersPagedList);
        }
   
        /// <summary>
        /// Gets the member by id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The member.</returns>
        public async Task<ActionResult> Details(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IMember member = await Service.GetAsync(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<MemberViewModel>(member));
        }

        /// <summary>
        /// Gets the member from the database by id for editing.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<ActionResult> Edit(Guid id)
        {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                IMember member = await Service.GetAsync(id);
                if (member == null)
                {
                    return HttpNotFound();
                }
                return View(Mapper.Map<MemberViewModel>(member));     
        }

        /// <summary>
        /// Updates the member.
        /// </summary>
        /// <param name="member">The member.</param>
        /// <returns>The member.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,MembershipNumber,LastName,FirstName,OIB,BirthPlace,BirthDate,Address,Place,PostalCode,PhoneNumber,CurrentEmployment,Email,WebSite,AreaOfInterest,MembershipDate,Status,IsRemoved")] MemberViewModel member)
        {
            if (ModelState.IsValid)
            {               
                 await Service.UpdateAsync(Mapper.Map<MemberPOCO>(member));
                 return RedirectToAction("Index");
            }
            return View();
        }

        /// <summary>
        /// Creates member report.
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> MemberReport()
        {
            var members = Mapper.Map<IEnumerable<MemberViewModel>>(await Service.GetAsync());
            var society = Mapper.Map<IEnumerable<SocietyViewModel>>(await SocietyService.GetAsync()).FirstOrDefault();
            return View(new Tuple<IEnumerable<MemberViewModel>, SocietyViewModel>(members, society));
        }


        /// <summary>
        /// Gets members to populate the select2 dropdown.
        /// </summary>
        /// <param name="searchTerm"></param>
        /// <param name="currentFilter"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<JsonResult> SearchMember(string searchTerm, string currentFilter, int pageNumber = 0, int pageSize = 0)
        {
            var Members = await Service.GetAsync(new Common.Filters.Filter(searchTerm, pageNumber, pageSize));
            return Json(Members.Select(k => new { id = k.Id, text = k.FullName }), JsonRequestBehavior.AllowGet);
        }

        #endregion Methods
    }
}
