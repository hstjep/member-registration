using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Net;
using Microsoft.AspNet.Identity;
using MemberRegistration.Models;
using MemberRegistration.ViewModels;
using MemberRegistration.Model;
using MemberRegistration.Service.Common;
using AutoMapper;
using PagedList;
using System.Net.Mail;
using System.Transactions;

namespace MemberRegistration.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        #region Properties 

        protected IUserService Service { get; private set; }
        protected ISocietyService SocietyService { get; private set; }
        public RoleManager<CustomRole, Guid> RoleManager { get; private set; }
        protected UserManager<ApplicationUser, Guid> UserManager { get; private set; }
        protected IMemberService MemberService { get; private set; }

        #endregion Properites

        #region Constructors

        public UserController(RoleManager<IdentityRole> roleManager, IUserService service, ISocietyService societyService, IMemberService memberService)
        {
            Service = service;
            SocietyService = societyService;
            MemberService = memberService;
            RoleManager = new RoleManager<CustomRole, Guid>(new CustomRoleStore(new ApplicationDbContext()));
            UserManager = new UserManager<ApplicationUser, Guid>(new CustomUserStore(new ApplicationDbContext()));
        }

        #endregion Constructors


        #region Methods

        /// <summary>
        /// Gets the users.
        /// </summary>
        /// <returns>The users.</returns>
        public async Task<ActionResult> Index(string searchTerm, int? page)
        {
            var users = await UserManager.Users.ToListAsync();
            
            if (!string.IsNullOrEmpty(searchTerm))
            {
                users = users.Where(s => s.UserName.ToUpper().Contains(searchTerm.ToUpper())).ToList();
            }

            int pageSize = 15;
            int pageNumber = (page ?? 1);
            return View(users.ToPagedList(pageNumber, pageSize));
        }

        /// <summary>
        /// Gets the user by id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The user.</returns>
        public async Task<ActionResult> Create()
        {
            ViewBag.SocietyId = new SelectList(await SocietyService.GetAsync(), "Id", "Name");
            ViewBag.RoleId = new SelectList(await RoleManager.Roles.ToListAsync(), "Id", "Name");
            return View();
        }

        /// <summary>
        /// Creates a user.
        /// </summary>
        /// <param name="model"></param>
        /// <param name="RoleId"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Create(RegisterViewModel model, ApplicationUserViewModel user, string RoleId)
        {
            if (ModelState.IsValid)
            {
                // Create new member
                user.Member = new MemberViewModel {
                    Id = Guid.NewGuid(),
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    MembershipDate = DateTime.Today,
                    IsMember = true,
                    MembershipNumber = await MemberService.GetMembershipNumberAsync()
                };

                bool adminresult = await Service.RegisterUser(Mapper.Map<ApplicationUserPOCO>(user), model.Password);

                if (adminresult)
                {
                    if (!String.IsNullOrEmpty(RoleId))
                    {
                        var role = await RoleManager.FindByIdAsync(Guid.Parse(RoleId));
                        var result = await UserManager.AddToRoleAsync(Guid.Parse(user.Id), role.Name);
                        if (!result.Succeeded)
                        {
                            ModelState.AddModelError("", result.Errors.First().ToString());
                            ViewBag.RoleId = new SelectList(await RoleManager.Roles.ToListAsync(), "Id", "Name");
                        }
                    }
                }
                else
                {
                    ViewBag.RoleId = new SelectList(RoleManager.Roles, "Id", "Name");
                    return View();
                }

                // Send email
                //sendEmails(model.Email, model.FirstName, model.Password, model.UserName);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.RoleId = new SelectList(RoleManager.Roles, "Id", "Name");
                return View();
            }
        }

        /// <summary>
        /// Gets the user by id for editing.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>View for editing the user.</returns>
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var user = await UserManager.FindByIdAsync(Guid.Parse(id));
            if (user == null)
            {
                return HttpNotFound();
            }

            ViewBag.RoleId = new SelectList(RoleManager.Roles, "Id", "Name");
            return View(user);
        }

        /// <summary>
        /// Updates the user to the database.
        /// </summary>
        /// <param name="formuser"></param>
        /// <param name="id"></param>
        /// <param name="RoleId"></param>
        /// <returns>The users.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Username,Email,Id")] ApplicationUser formuser, string id, string RoleId)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.RoleId = new SelectList(RoleManager.Roles, "Id", "Name");
            var user = await UserManager.FindByIdAsync(Guid.Parse(id));
            user.UserName = formuser.UserName;
            if (ModelState.IsValid)
            {
                await UserManager.UpdateAsync(user);

                var rolesForUser = await UserManager.GetRolesAsync(Guid.Parse(id));
                if (rolesForUser.Count() > 0)
                {
                    foreach (var item in rolesForUser)
                    {
                        var result = await UserManager.RemoveFromRoleAsync(Guid.Parse(id), item);
                    }
                }

                if (!String.IsNullOrEmpty(RoleId))
                {
                    var role = await RoleManager.FindByIdAsync(Guid.Parse(RoleId));

                    var result = await UserManager.AddToRoleAsync(Guid.Parse(id), role.Name);
                    if (!result.Succeeded)
                    {
                        ModelState.AddModelError("", result.Errors.First().ToString());
                        ViewBag.RoleId = new SelectList(RoleManager.Roles, "Id", "Name");
                        return View();
                    }
                }
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.RoleId = new SelectList(RoleManager.Roles, "Id", "Name");
                return View();
            }
        }


        /// <summary>
        /// Gets user by id for deleting.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>View for deleting the user.</returns>
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var user = await UserManager.FindByIdAsync(Guid.Parse(id));
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            var user = await UserManager.FindByIdAsync(Guid.Parse(id));
            await UserManager.DeleteAsync(user);
            return RedirectToAction("Index");
        }  

        public async Task<ActionResult> ResetPassword(ManageMessageId? message)
        {
            ViewBag.StatusMessage =
               message == ManageMessageId.ChangePasswordSuccess ? "Lozinka je uspješno promijenjena."
               : "";
            ResetUserPasswordViewModel model = new ResetUserPasswordViewModel();
            ViewBag.UserIdList = new SelectList(await UserManager.Users.ToListAsync(), "Id", "UserName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ResetPassword(ResetUserPasswordViewModel model)
        {
            ViewBag.UserIdList = new SelectList(await UserManager.Users.ToListAsync(), "Id", "UserName");

            if (ModelState.IsValid)
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    UserManager.RemovePassword(model.UserId);
                    UserManager.AddPassword(model.UserId, model.NewPassword);
                    scope.Complete();
                    return RedirectToAction("ResetPassword", new { Message = ManageMessageId.ChangePasswordSuccess });
                }
            }
            return View();
        }

        public enum ManageMessageId
        {
            ChangePasswordSuccess,
            SetPasswordSuccess,
            RemoveLoginSuccess,
            Error
        }


        /// <summary>
        /// Send email to user with username and password information.
        /// </summary>
        /// <param name="emailTo"></param>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <param name="userName"></param>
        private void sendEmails(string emailTo, string name, string password, string userName)
        {
            EmailFrom = "";
            EmailTo = emailTo;
            Password = "";
            EmailServer = "smtp.gmail.com";

            // check all properties have been set
            if (string.IsNullOrWhiteSpace(EmailFrom))
                throw new ArgumentException("EmailFrom nije postavljen");
            if (string.IsNullOrWhiteSpace(EmailTo))
                throw new ArgumentException("EmailTo nije postavljen");
            if (string.IsNullOrWhiteSpace(EmailServer))
                throw new ArgumentException("EmailServer nije postavljen");


            var fromAddress = new MailAddress(EmailFrom, "Helena");
            var toAddress = new MailAddress(EmailTo, name);

            var client = new SmtpClient
            {
                Host = EmailServer,
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(EmailFrom, Password),
                Timeout = 20000
            };

                var msg = new MailMessage(fromAddress, toAddress);
                msg.IsBodyHtml = true;
                msg.Subject = "Aplikacija Racuni - poruka";
                msg.Body = "Poštovani," + "<br />" + "Vaše korisničko ime: " + userName + "<p>" + "Lozinka: " + password + "<p>";
                client.Send(msg);
        }

        #region Properties for emails

        public string EmailServer { get; set; }
        public string EmailFrom { get; set; }
        public string EmailTo { get; set; }
        public string Password { get; set; }

        #endregion 

        #endregion Methods
    }
}