using System;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MemberRegistration.Models;

namespace MemberRegistration.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RoleController : Controller
    {
        #region Properties

        public RoleManager<CustomRole, Guid> RoleManager { get; private set; }

        #endregion Properties


        #region Constructors

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            RoleManager = new RoleManager<CustomRole, Guid>(new CustomRoleStore(new ApplicationDbContext()));
            //RoleManager = roleManager;
        }

        #endregion Constructors


        #region Methods

        /// <summary>
        /// Gets the roles.
        /// </summary>
        /// <returns>The roles.</returns>
        public ActionResult Index()
        {
            return View(RoleManager.Roles);
        }

        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Adds the role.
        /// </summary>
        /// <param name="roleViewModel"></param>
        /// <returns>The roles.</returns>
        [HttpPost]
        public async Task<ActionResult> Create(RoleViewModel roleViewModel)
        {
            if (ModelState.IsValid)
            {
                var role = new CustomRole(roleViewModel.Name);
                var roleresult = await RoleManager.CreateAsync(role);
                if (!roleresult.Succeeded)
                {
                    ModelState.AddModelError("", roleresult.Errors.First().ToString());
                    return View();
                }
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        /// <summary>
        /// Gets the role by id for editing.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The view for editing the role.</returns>
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var role = await RoleManager.FindByIdAsync(Guid.Parse(id));
            if (role == null)
            {
                return HttpNotFound();
            }
            return View(role);
        }

        /// <summary>
        /// Updates the role.
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Name,Id")] CustomRole role)
        {
            if (ModelState.IsValid)
            {
                var result = await RoleManager.UpdateAsync(role);
                if (!result.Succeeded)
                {
                    ModelState.AddModelError("", result.Errors.First().ToString());
                    return View();
                }
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        /// <summary>
        /// Gets the role by id for deleting.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>View for deleting the role.</returns>
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var role = await RoleManager.FindByIdAsync(Guid.Parse(id));
            if (role == null)
            {
                return HttpNotFound();
            }
            return View(role);
        }

        /// <summary>
        /// Deletes the role.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            if (ModelState.IsValid)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                var role = await RoleManager.FindByIdAsync(Guid.Parse(id));
                var result = await RoleManager.DeleteAsync(role);
                if (!result.Succeeded)
                {
                    ModelState.AddModelError("", result.Errors.First().ToString());
                    return View();
                }
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        #endregion Methods
    }
}
