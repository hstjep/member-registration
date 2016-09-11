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
    public class ResponsiblePersonService : IResponsiblePersonService
    {
        #region Properties

        protected IResponsiblePersonRepository Repository { get; private set; }
    
        #endregion Properties


        #region Constructors

        public ResponsiblePersonService(IResponsiblePersonRepository repository)
        {
            this.Repository = repository;
        }

        #endregion Constructors


        #region Methods

        /// <summary>
        /// Gets all responisble people async.
        /// </summary>
        /// <returns>The responsible people.</returns>
        public Task<List<IResponsiblePerson>> GetAsync()
        {
            return Repository.GetAsync();
        }

        /// <summary>
        /// Gets the responsible person by id asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// The responsible person.
        /// </returns>
        public Task<IResponsiblePerson> GetAsync(Guid id)
        {
            return Repository.GetAsync(id);
        }

        /// <summary>
        /// Creates a responsible person asynchronously.
        /// </summary>
        /// <param name="responsiblePerson"></param>
        /// <returns></returns>
        public Task<int> AddAsync(IResponsiblePerson responsiblePerson)
        {
            return Repository.AddAsync(responsiblePerson);
        }

        /// <summary>
        /// Updates the responsible person asynchronously.
        /// </summary>
        /// <param name="responsiblePerson"></param>
        /// <returns></returns>
        public Task<int> UpdateAsync(IResponsiblePerson responsiblePerson)
        {
            return Repository.UpdateAsync(responsiblePerson);
        }

        /// <summary>
        /// Removes the responsible person by id asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public Task<int> DeleteAsync(Guid id)
        {
            return Repository.DeleteAsync(id);
        }

        #endregion Methods
    }
}
