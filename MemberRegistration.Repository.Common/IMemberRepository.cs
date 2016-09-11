using MemberRegistration.Common.Filters;
using MemberRegistration.Model.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MemberRegistration.Repository.Common
{
    public interface IMemberRepository
    {
        /// <summary>
        /// Gets the members asynchronously.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns>The members.</returns>
        Task<IEnumerable<IMember>> GetAsync(IFilter filter = null);

        /// <summary>
        /// Gets the member by id asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The member.</returns>
        Task<IMember> GetAsync(Guid id);

        /// <summary>
        /// Gets the current member asynchronously.
        /// </summary>
        /// <returns>The current member.</returns>
        Task<IMember> GetCurrentAsync();

        /// <summary>
        /// Updates the member asynchronously.
        /// </summary>
        /// <param name="member">The member</param>
        /// <returns></returns>
        Task<int> UpdateAsync(IMember member);

        /// <summary>
        /// Gets the last membership number and increases it by one.
        /// </summary>
        /// <returns>The increased invoice number.</returns>
        Task<int> GetMembershipNumberAsync();
    }
}
