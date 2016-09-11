using MemberRegistration.Common.Filters;
using MemberRegistration.Model.Common;
using MemberRegistration.Repository.Common;
using MemberRegistration.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberRegistration.Service
{
    public class MemberService : IMemberService
    {
        #region Properties

        protected IMemberRepository Repository { get; private set; }

        #endregion Properties

        
        #region Constructors

        public MemberService(IMemberRepository repository)
        {
            this.Repository = repository;
        }

        #endregion Constructors


        #region Methods

        /// <summary>
        /// Gets the members asynchronously.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns>
        /// The members.
        /// </returns>
        public Task<IEnumerable<IMember>> GetAsync(IFilter filter = null)
        {
            return Repository.GetAsync(filter);
        }

        /// <summary>
        /// Gets the member by id asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// The member.
        /// </returns>
        public Task<IMember> GetAsync(Guid id)
        {
            return Repository.GetAsync(id);
        }

        /// <summary>
        /// Gets the current member asynchronously.
        /// </summary>
        /// <returns>
        /// The current member.
        /// </returns>
        public Task<IMember> GetCurrentAsync()
        {
            return Repository.GetCurrentAsync();
        }

        /// <summary>
        /// Updates the member asynchronously.
        /// </summary>
        /// <param name="member">The member</param>
        /// <returns></returns>
        public async Task<int> UpdateAsync(IMember member) 
        {
            return await Repository.UpdateAsync(member); 
        }

        /// <summary>
        /// Gets the last membership number and increases it by one.
        /// </summary>
        /// <returns>
        /// The increased invoice number.
        /// </returns>
        public async Task<int> GetMembershipNumberAsync()
        {
            return await Repository.GetMembershipNumberAsync();
        }

        #endregion Methods
    }
}
