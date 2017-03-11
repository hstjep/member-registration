using ClosedXML.Excel;
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
        /// Asynchronously gets the membership fees.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns>The membership fees.</returns>
        Task<ICollectionModel<IMembershipFee>> GetAsync(IFilter filter);

        /// <summary>
        /// Asynchronously gets the membership fee by id.
        /// </summary>
        /// <param name="id">The membership fee identifier.</param>
        /// <returns>The membership fee.</returns>
        Task<IMembershipFee> GetAsync(Guid id);

        /// <summary>
        /// Asynchronously gets the current user's membership fees.
        /// </summary>
        /// <returns>The membership fee.</returns>
        List<IMembershipFee> GetCurrentAsync();
    }
}
