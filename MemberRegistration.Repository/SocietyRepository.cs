using MemberRegistration.DAL;
using MemberRegistration.Model.Common;
using MemberRegistration.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MemberRegistration.Model;
using System.Data.Entity;

namespace MemberRegistration.Repository
{
    public class SocietyRepository : ISocietyRepository
    {
        #region Properties

        protected IRepository Repository { get; private set; }

        #endregion Properties


        #region Constructors

        public SocietyRepository(IRepository repository)
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
        public virtual async Task<List<ISociety>> GetAsync()
        {
            return Mapper.Map<List<ISociety>>(await Repository.GetAsync<Society>());
        }

        /// <summary>
        /// Gets the society by id asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// The society.
        /// </returns>
        public virtual async Task<ISociety> GetAsync(Guid id)
        {
            return Mapper.Map<SocietyPOCO>(await Repository.GetByIDAsync<Society>(id));
        }

        /// <summary>
        /// Gets the society by id asynchronously.
        /// </summary>
        /// <param name="societyId"></param>
        /// <returns>
        /// The society.
        /// </returns>
        public virtual async Task<ISociety> GetWhereAsync(Guid societyId)
        {
            return Mapper.Map<SocietyPOCO>(await Repository.GetWhere<Society>().Where(p => p.Id == societyId).FirstOrDefaultAsync());
        }

        /// <summary>
        /// Gets the society by id asynchronously.
        /// </summary>
        /// <param name="invoiceId"></param>
        /// <returns>
        /// The society.
        /// </returns>
        public virtual async Task<ISociety> GetSocietyForRacunAsync(Guid invoiceId)
        {
            var invoice = await Repository.GetWhere<Invoice>().Where(r => r.Id == invoiceId).FirstOrDefaultAsync();
            return Mapper.Map<SocietyPOCO>(await Repository.GetWhere<Society>().Where(p => p.Id == invoice.SocietyId).FirstOrDefaultAsync());
        }

        /// <summary>
        /// Creates a society asynchronously.
        /// </summary>
        /// <param name="society">The society.</param>
        /// <returns></returns>
        public virtual Task<int> AddAsync(ISociety society)
        {
            return Repository.AddAsync<DAL.Society>(Mapper.Map<DAL.Society>(society));          
        }

        /// <summary>
        /// Updates the society asynchronously.
        /// </summary>
        /// <param name="society">The society.</param>
        /// <returns></returns>
        public virtual Task<int> UpdateAsync(ISociety society)
        {
            return Repository.UpdateAsync<MemberRegistration.DAL.Society>(Mapper.Map<MemberRegistration.DAL.Society>(society));
        }

        /// <summary>
        /// Removes the product by id asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public virtual Task<int> DeleteAsync(Guid id)
        {
            return Repository.DeleteAsync<DAL.Society>(id);
        }

        #endregion Methods
    }
}

