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

        /// <summary>
        /// Gets the repository.
        /// </summary>
        /// <value>
        /// The repository.
        /// </value>
        protected IRepository Repository { get; private set; }

        #endregion Properties


        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SocietyRepository"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public SocietyRepository(IRepository repository)
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
        public virtual async Task<List<ISociety>> GetAsync()
        {
            return Mapper.Map<List<ISociety>>(await Repository.GetAsync<Society>());
        }

        /// <summary>
        /// Asynchronously gets the society by id.
        /// </summary>
        /// <param name="id">The society identifier.</param>
        /// <returns>
        /// The society.
        /// </returns>
        public virtual async Task<ISociety> GetAsync(Guid id)
        {
            return Mapper.Map<SocietyPOCO>(await Repository.GetByIDAsync<Society>(id));
        }

        /// <summary>
        /// Asynchronously gets the society by id.
        /// </summary>
        /// <param name="societyId">The society identifier.</param>
        /// <returns>
        /// The society.
        /// </returns>
        public virtual async Task<ISociety> GetWhereAsync(Guid societyId)
        {
            return Mapper.Map<SocietyPOCO>(await Repository.GetWhere<Society>().Where(p => p.Id == societyId).FirstOrDefaultAsync());
        }

        /// <summary>
        /// Gets the default society.
        /// </summary>
        /// <returns></returns>
        public virtual ISociety GetDefault()
        {
            var societies = Repository.GetWhere<Society>();
            return Mapper.Map<ISociety>(societies.FirstOrDefault());
        }

        /// <summary>
        /// Asynchronously gets the society by id.
        /// </summary>
        /// <param name="invoiceId">The invoice identifier.</param>
        /// <returns>
        /// The society.
        /// </returns>
        public virtual async Task<ISociety> GetSocietyForInvoiceAsync(Guid invoiceId)
        {
            var invoice = await Repository.GetWhere<Invoice>().Where(r => r.Id == invoiceId).FirstOrDefaultAsync();
            return Mapper.Map<SocietyPOCO>(await Repository.GetWhere<Society>().Where(p => p.Id == invoice.SocietyId).FirstOrDefaultAsync());
        }

        /// <summary>
        /// Asynchronously creates a society.
        /// </summary>
        /// <param name="society">The society.</param>
        /// <returns></returns>
        public virtual Task<int> AddAsync(ISociety society)
        {
            return Repository.AddAsync<DAL.Society>(Mapper.Map<DAL.Society>(society));          
        }

        /// <summary>
        /// Asynchronously updates the society.
        /// </summary>
        /// <param name="society">The society.</param>
        /// <returns></returns>
        public virtual Task<int> UpdateAsync(ISociety society)
        {
            return Repository.UpdateAsync<MemberRegistration.DAL.Society>(Mapper.Map<MemberRegistration.DAL.Society>(society));
        }

        /// <summary>
        /// Asynchronously removes the society by id.
        /// </summary>
        /// <param name="id">The society identifier.</param>
        /// <returns></returns>
        public virtual Task<int> DeleteAsync(Guid id)
        {
            return Repository.DeleteAsync<DAL.Society>(id);
        }

        #endregion Methods
    }
}

