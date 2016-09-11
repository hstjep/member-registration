using MemberRegistration.Model.Common;
using MemberRegistration.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MemberRegistration.DAL;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MemberRegistration.Model;
using System.Security.Claims;
using System.Data.Entity;

namespace MemberRegistration.Repository
{
    public class UserRepository : IUserRepository
    {
        #region Properties

        protected IRepository Repository { get; private set; }
        protected IUnitOfWork UnitOfWork { get; private set; }
        protected UserManager<ApplicationUser, Guid> UserManager { get; private set; }

        #endregion Properties


        #region Constructors

        public UserRepository(IRepository repository, IUnitOfWork unitOfWork, UserManager<ApplicationUser, Guid> userManager)
        {
            this.Repository = repository;
            this.UnitOfWork = unitOfWork;
            this.UserManager = userManager;
        }

        #endregion Constructors


        #region Methods

        /// <summary>
        /// Finds the user asynchronously.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        /// <returns>
        /// The user.
        /// </returns>
        public async Task<IApplicationUser> FindAsync(string userName, string password)
        {
            return Mapper.Map<ApplicationUserPOCO>(await UserManager.FindAsync(userName, password));
        }

        /// <summary>
        /// Adds the user asynchronously.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        public virtual Task<int> AddAsync(IApplicationUser user)
        {
            return Repository.AddAsync<ApplicationUser>(Mapper.Map<ApplicationUser>(user));
        }

        /// <summary>
        /// Registers the user asynchronously.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        public virtual async Task<bool> RegisterUser(IApplicationUser user, string password)
        {
            IdentityResult result = await UserManager.CreateAsync(Mapper.Map<ApplicationUser>(user), password);
            return result.Succeeded;
        }

        #endregion Methods
    }
}            


