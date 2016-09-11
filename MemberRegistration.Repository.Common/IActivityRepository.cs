using MemberRegistration.Common.Filters;
using MemberRegistration.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberRegistration.Repository.Common
{
    public interface IActivityRepository
    {
        #region Methods

        /// <summary>
        /// Gets the activities asynchronously.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns>The activities.</returns>
        Task<IEnumerable<IActivity>> GetAsync(Filter filter = null);

        /// <summary>
        /// Gets the activity asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The activity.</returns>
        Task<IActivity> GetAsync(Guid id);

        /// <summary>
        /// Adds the activity asynchronously.
        /// </summary>
        /// <param name="activity">The activity.</param>
        /// <returns></returns>
        Task<int> AddAsync(IActivity activity);

        /// <summary>
        /// Updates the activity asynchronously.
        /// </summary>
        /// <param name="activity">The activity.</param>
        /// <returns></returns>
        Task<int> UpdateAsync(IActivity activity);

        /// <summary>
        /// Deletes the activity asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<int> DeleteAsync(Guid id);

        #endregion Methods
    }
}
