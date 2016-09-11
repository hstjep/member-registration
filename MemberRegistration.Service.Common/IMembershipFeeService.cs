using MemberRegistration.Common.Filters;
using MemberRegistration.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberRegistration.Service.Common
{
    public interface IMembershipFeeService
    {
        /// <summary>
        /// Gets the membership fees asynchronously.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns>The membership fees.</returns>
        Task<IEnumerable<IMembershipFee>> GetAsync(IFilter filter = null);

        /// <summary>
        /// Gets the membership fee by id asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The membership fee.</returns>
        Task<IMembershipFee> GetAsync(Guid id);

        /// <summary>
        /// Gets the current user's membership fees asynchronously.
        /// </summary>
        /// <returns>The membership fee.</returns>
        List<IMembershipFee> GetCurrentAsync();
    }
}
