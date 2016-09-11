using MemberRegistration.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberRegistration.Service.Common
{
    public interface IUserService
    {
        #region Methods

        /// <summary>
        /// Adds the user asynchronously.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        Task<int> AddAsync(IApplicationUser user);

        /// <summary>
        /// Registers the user asynchronously.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        Task<bool> RegisterUser(IApplicationUser user, string password);

        /// <summary>
        /// Finds the user asynchronous.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        /// <returns>The user.</returns>
        Task<IApplicationUser> FindAsync(string userName, string password);

        #endregion Methods
    }
}

