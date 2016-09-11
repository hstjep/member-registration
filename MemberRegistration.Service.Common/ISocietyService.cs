using MemberRegistration.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberRegistration.Service.Common
{
    public interface ISocietyService
    {
        #region Methods

        /// <summary>
        /// Gets all societies asynchronously.
        /// </summary>
        /// <returns>The societies.</returns>
        Task<List<ISociety>> GetAsync();

        /// <summary>
        /// Gets the society by id asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The society.</returns>
        Task<ISociety> GetAsync(Guid id);

        /// <summary>
        /// Gets the society by id asynchronously.
        /// </summary>
        /// <param name="id">The invoice identifier.</param>
        /// <returns>The society.</returns>
        Task<ISociety> GetWhereAsync(Guid societyId);

        /// <summary>
        /// Creates a society asynchronously.
        /// </summary>
        /// <param name="society">The society.</param>
        /// <returns></returns>
        Task<int> AddAsync(ISociety society);

        /// <summary>
        /// Updates the society asynchronously.
        /// </summary>
        /// <param name="society">The society.</param>
        /// <returns></returns>
        Task<int> UpdateAsync(ISociety society);

        /// <summary>
        /// Removes the society by id async.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<int> DeleteAsync(Guid id);

        #endregion Methods
    }
}
