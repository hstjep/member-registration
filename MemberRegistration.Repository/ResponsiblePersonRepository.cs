using MemberRegistration.DAL;
using MemberRegistration.Model.Common;
using MemberRegistration.Repository.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MemberRegistration.Model;

namespace MemberRegistration.Repository
{
    public class ResponsiblePersonRepository : IResponsiblePersonRepository
    {
        #region Properties

        protected IRepository Repository { get; private set; }
    
        #endregion Properties


        #region Constructors

        public ResponsiblePersonRepository(IRepository repository)
        {
            this.Repository = repository;
        }

        #endregion Constructors


        #region Methods

        /// <summary>
        /// Gets all responisble people asynchronously.
        /// </summary>
        /// <returns>
        /// The responsible people.
        /// </returns>
        public virtual async Task<List<IResponsiblePerson>> GetAsync()
        {
            return Mapper.Map<List<IResponsiblePerson>>(await Repository.GetAsync<ResponsiblePerson>());
        }

        /// <summary>
        /// Gets the responsible person by id asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// The responsible person.
        /// </returns>
        public virtual async Task<IResponsiblePerson> GetAsync(Guid id)
        {
            return Mapper.Map<ResponsiblePersonPOCO>(await Repository.GetByIDAsync<ResponsiblePerson>(id));           
        }

        /// <summary>
        /// Creates a responsible person asynchronously.
        /// </summary>
        /// <param name="responsiblePerson">The responsible person.</param>
        /// <returns></returns>
        public virtual Task<int> AddAsync(IResponsiblePerson responsiblePerson)
        {
            return Repository.AddAsync<DAL.ResponsiblePerson>(Mapper.Map<DAL.ResponsiblePerson>(responsiblePerson));
        }

        /// <summary>
        /// Updates the responsible person asynchronously.
        /// </summary>
        /// <param name="responsiblePerson">The responsible person.</param>
        /// <returns></returns>
        public virtual Task<int> UpdateAsync(IResponsiblePerson responsiblePerson)
        {
            return Repository.UpdateAsync<MemberRegistration.DAL.ResponsiblePerson>(Mapper.Map<MemberRegistration.DAL.ResponsiblePerson>(responsiblePerson));
        }

        /// <summary>
        /// Removes the responsible person by id asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public virtual Task<int> DeleteAsync(Guid id)
        {
            return Repository.DeleteAsync<DAL.ResponsiblePerson>(id);
        }


        #endregion Methods
    }
}
