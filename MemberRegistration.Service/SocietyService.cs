using MemberRegistration.Model.Common;
using MemberRegistration.Repository.Common;
using MemberRegistration.Service.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MemberRegistration.Service
{
    public class SocietyService : ISocietyService
    {
        
        #region Properties

        protected ISocietyRepository Repository { get; private set; }

        #endregion Properties


        #region Constructors

        public SocietyService(ISocietyRepository repository)
        {
            this.Repository = repository;
        }

        #endregion Constructors


        #region Methods

        /// <summary>
        /// Gets all societies asynchronously.
        /// </summary>
        /// <returns>
        /// The societies.
        /// </returns>
        public Task<List<ISociety>> GetAsync()
        {
            return Repository.GetAsync();
        }

        /// <summary>
        /// Gets the society by id asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// The society.
        /// </returns>
        public Task<ISociety> GetAsync(Guid id) 
        {
            return Repository.GetAsync(id);
        }

        /// <summary>
        /// Gets the society by id asynchronously.
        /// </summary>
        /// <param name="societyId"></param>
        /// <returns>
        /// The society.
        /// </returns>
        public Task<ISociety> GetWhereAsync(Guid societyId)
        {
            return Repository.GetWhereAsync(societyId);
        }

        /// <summary>
        /// Creates a society asynchronously.
        /// </summary>
        /// <param name="society">The society.</param>
        /// <returns></returns>
        public Task<int> AddAsync(ISociety society)
        {
            return Repository.AddAsync(society);
        }

        /// <summary>
        /// Updates the society asynchronously.
        /// </summary>
        /// <param name="society">The society.</param>
        /// <returns></returns>
        public Task<int> UpdateAsync(ISociety society)
        {
            return Repository.UpdateAsync(society);
        }

        /// <summary>
        /// Removes the society by id async.
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
