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
        Task<ICollectionModel<IMember>> GetAsync(IFilter filter);

        /// <summary>
        /// Asynchronously gets the current members.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<IMember>> GetCurrentMembersAsync();

        /// <summary>
        /// Asynchronously gets the current member.
        /// </summary>
        /// <returns>The current member.</returns>
        Task<IMember> GetCurrentMemberAsync();
         
        /// <summary>
        /// Asynchronously gets the member by id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The member.</returns>
        Task<IMember> GetAsync(Guid id);

        /// <summary>
        /// Asynchronously updates the member.
        /// </summary>
        /// <param name="member">The member</param>
        /// <returns></returns>
        Task<int> UpdateAsync(IMember member);

        /// <summary>
        /// Gets the last membership number and increases it by one.
        /// </summary>
        /// <returns>The invoice number.</returns>
        Task<int> GetMembershipNumberAsync();
    }
}
