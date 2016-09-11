using MemberRegistration.Model.Common;
using MemberRegistration.Repository.Common;
using MemberRegistration.Service.Common;
using System.Threading.Tasks;

namespace MemberRegistration.Service
{
    public class UserService : IUserService
    {
        #region Properties

        protected IUserRepository Repository { get; private set; }

        #endregion Properties


        #region Constructors

        public UserService(IUserRepository repository)
        {
            this.Repository = repository;
        }

        #endregion Constructors


        #region Methods

        /// <summary>
        /// Adds the user asynchronously.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        public Task<int> AddAsync(IApplicationUser user)
        {
            return Repository.AddAsync(user);
        }

        /// <summary>
        /// Registers the user asynchronously.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        public Task<bool> RegisterUser(IApplicationUser user, string password)
        {
            return Repository.RegisterUser(user, password);
        }

        /// <summary>
        /// Finds the user asynchronous.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        /// <returns>
        /// The user.
        /// </returns>
        public Task<IApplicationUser> FindAsync(string userName, string password)
        {
            return Repository.FindAsync(userName, password);
        }

        #endregion Methods
    }
}
