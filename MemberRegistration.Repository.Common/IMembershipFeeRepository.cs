using MemberRegistration.Common.Filters;
using MemberRegistration.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MemberRegistration.Repository.Common
{
    public interface IMembershipFeeRepository
    {
        /// <summary>
        /// Gets the membership fees asynchronously.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns>The membership fees.</returns>
        Task<ICollectionModel<IMembershipFee>> GetAsync(IFilter filter);

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

        /// <summary>
        /// Adds the membership fee asynchronously.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        /// <param name="membershipFee">The membership fee.</param>
        /// <returns></returns>
        Task<int> AddAsync(IUnitOfWork unitOfWork, IMembershipFee membershipFee);

    }
}
