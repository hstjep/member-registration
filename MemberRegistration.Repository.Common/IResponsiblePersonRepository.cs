using MemberRegistration.DAL;
using MemberRegistration.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberRegistration.Repository.Common
{
    public interface IResponsiblePersonRepository
    {
        #region Methods

        /// <summary>
        /// Gets all responisble people asynchronously.
        /// </summary>
        /// <returns>The responsible people.</returns>
        Task<List<IResponsiblePerson>> GetAsync();

        /// <summary>
        /// Gets the responsible person by id asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The responsible person.</returns>
        Task<IResponsiblePerson> GetAsync(Guid id);

        /// <summary>
        /// Creates a responsible person asynchronously.
        /// </summary>
        /// <param name="ResponsiblePerson">The responsible person.</param>
        /// <returns></returns>
        Task<int> AddAsync(IResponsiblePerson responsiblePerson);

        /// <summary>
        /// Updates the responsible person asynchronously.
        /// </summary>
        /// <param name="ResponsiblePerson">The responsible person.</param>
        /// <returns></returns>
        Task<int> UpdateAsync(IResponsiblePerson responsiblePerson);

        /// <summary>
        /// Removes the responsible person by id asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<int> DeleteAsync(Guid id);

        #endregion Methods
    }
}
