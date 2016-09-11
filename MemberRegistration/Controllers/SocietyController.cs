using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MemberRegistration.Service.Common;
using MemberRegistration.Model.Common;
using MemberRegistration.Model;
using MemberRegistration.ViewModels;
using AutoMapper;

namespace MemberRegistration.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SocietyController : Controller
    {
        #region Properties

        protected ISocietyService Service { get; private set; }

        #endregion Properties

        
        #region Constructors

        public SocietyController(ISocietyService service)
        {
            this.Service = service;
        }

        #endregion Constructors

        
        #region Methods

        /// <summary>
        /// Gets the societies.
        /// </summary>
        /// <returns>The societies.</returns>
        public async Task<ActionResult> Index()
        {
            List<ISociety> societies = await Service.GetAsync();
            return View(Mapper.Map<IEnumerable<SocietyViewModel>>(societies));
        }

        /// <summary>
        /// Gets the society by id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The society.</returns>
        public async Task<ActionResult> Details(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ISociety society = await Service.GetAsync(id);
            if (society == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<SocietyViewModel>(society));
        }

        /// <summary>
        /// Gets user interface for creating a new society.
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Creates a society to the database.
        /// </summary>
        /// <param name="society">The society.</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Acronym,Address,Place,PostalCode,Country,OIB,WebSite,Email,Logo,MimeTypeImage,IBAN,CashRegisterLocation,Bank")] SocietyViewModel society, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    society.MimeTypeImage = image.ContentType;
                    society.Logo = new byte[image.ContentLength];
                    image.InputStream.Read(society.Logo, 0, image.ContentLength);
                }
                await Service.AddAsync(Mapper.Map<SocietyPOCO>(society));
                return RedirectToAction("Index");
            }
            return View();
        }

        /// <summary>
        /// Gets the society by id for editing.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<ActionResult> Edit(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ISociety society = await Service.GetAsync(id);
            if (society == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<SocietyViewModel>(society));
        }

        /// <summary>
        /// Updates the society.
        /// </summary>
        /// <param name="society">The society.</param>
        /// <returns>.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Acronym,Address,Place,PostalCode,Country,OIB,WebSite,Email,Logo,MimeTypeImage,IBAN,CashRegisterLocation,Bank")] SocietyViewModel society, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                // If there is a logo image, save it.
                if (image != null)
                {
                    society.MimeTypeImage = image.ContentType;
                    society.Logo = new byte[image.ContentLength];
                    image.InputStream.Read(society.Logo, 0, image.ContentLength);
                }
                await Service.UpdateAsync(Mapper.Map<SocietyPOCO>(society));
                return RedirectToAction("Index");
            }
            return View(society);
        }

        /// <summary>
        /// Gets the society by id for deleting.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>View for deleting the society.</returns>
        public async Task<ActionResult> Delete(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ISociety society = await Service.GetAsync(id);
            if (society == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<SocietyViewModel>(society));
        }

        /// <summary>
        /// Deletes the society.
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
        /// Gets the logo image file for the given society identifier.
        /// </summary>
        /// <param name="SocietyId">The society identifier.</param>
        /// <returns></returns>
        [AllowAnonymous]
        public async Task<FileContentResult> GetImage(Guid societyId)
        {
            ISociety requestedPhoto = AutoMapper.Mapper.Map<SocietyPOCO>(await Service.GetWhereAsync(societyId));
            if (requestedPhoto != null)
            {
                return File(requestedPhoto.Logo, requestedPhoto.MimeTypeImage);
            }
            else
            {
                return null;
            }
        }

        #endregion Methods
    }
}


