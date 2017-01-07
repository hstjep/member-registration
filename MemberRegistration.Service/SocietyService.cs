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

        /// <summary>
        /// Gets the society repository.
        /// </summary>
        /// <value>
        /// The society repository.
        /// </value>
        protected ISocietyRepository Repository { get; private set; }

        #endregion Properties


        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SocietyService"/> class.
        /// </summary>
        /// <param name="repository">The society repository.</param>
        public SocietyService(ISocietyRepository repository)
        {
            this.Repository = repository;
        }

        #endregion Constructors


        #region Methods

        /// <summary>
        /// Asynchronously gets all societies.
        /// </summary>
        /// <returns>
        /// The societies.
        /// </returns>
        public Task<List<ISociety>> GetAsync()
        {
            return Repository.GetAsync();
        }

        /// <summary>
        /// Gets the default society.
        /// </summary>
        /// <returns></returns>
        public virtual ISociety GetDefault()
        {
            return Repository.GetDefault();
        }

        /// <summary>
        /// Asynchronously gets the society by id.
        /// </summary>
        /// <param name="id">The society identifier.</param>
        /// <returns>
        /// The society.
        /// </returns>
        public Task<ISociety> GetAsync(Guid id) 
        {
            return Repository.GetAsync(id);
        }

        /// <summary>
        /// Asynchronously gets the society by id.
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
        /// Asynchronously creates a society.
        /// </summary>
        /// <param name="society">The society.</param>
        /// <returns></returns>
        public Task<int> AddAsync(ISociety society)
        {
            return Repository.AddAsync(society);
        }

        /// <summary>
        /// Asynchronously updates the society.
        /// </summary>
        /// <param name="society">The society.</param>
        /// <returns></returns>
        public Task<int> UpdateAsync(ISociety society)
        {
            return Repository.UpdateAsync(society);
        }

        /// <summary>
        /// Asynchronously removes the society by id.
        /// </summary>
        /// <param name="id">The society identifier.</param>
        /// <returns></returns>
        public Task<int> DeleteAsync(Guid id)
        {
            return Repository.DeleteAsync(id);
        }

        #endregion Methods
    }
}
