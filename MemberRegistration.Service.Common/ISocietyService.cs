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
        /// Asynchronously gets all societies.
        /// </summary>
        /// <returns>The societies.</returns>
        Task<List<ISociety>> GetAsync();

        /// <summary>
        /// Gets the default society.
        /// </summary>
        /// <returns></returns>
        ISociety GetDefault();

        /// <summary>
        /// Asynchronously gets the society by id.
        /// </summary>
        /// <param name="id">The society identifier.</param>
        /// <returns>The society.</returns>
        Task<ISociety> GetAsync(Guid id);

        /// <summary>
        /// Asynchronously gets the society by id.
        /// </summary>
        /// <param name="id">The invoice identifier.</param>
        /// <returns>The society.</returns>
        Task<ISociety> GetWhereAsync(Guid societyId);

        /// <summary>
        /// Asynchronously creates a society.
        /// </summary>
        /// <param name="society">The society.</param>
        /// <returns></returns>
        Task<int> AddAsync(ISociety society);

        /// <summary>
        /// Asynchronously updates the society.
        /// </summary>
        /// <param name="society">The society.</param>
        /// <returns></returns>
        Task<int> UpdateAsync(ISociety society);

        /// <summary>
        /// Asynchronously removes the society by id.
        /// </summary>
        /// <param name="id">The society identifier.</param>
        /// <returns></returns>
        Task<int> DeleteAsync(Guid id);

        #endregion Methods
    }
}
