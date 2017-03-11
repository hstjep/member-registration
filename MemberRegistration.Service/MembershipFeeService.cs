using MemberRegistration.Common.Filters;
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
    public class MembershipFeeService : IMembershipFeeService
    {
        #region Properties

        public IMembershipFeeRepository Repository { get; private set; }

        #endregion Properties

       
        #region Constructors

        public MembershipFeeService(IMembershipFeeRepository repository)
        {
            this.Repository = repository;            
        }

        #endregion Constructors


        #region Methods

        /// <summary>
        /// Gets the membership fees asynchronously.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns>
        /// The membership fees.
        /// </returns>
        public Task<ICollectionModel<IMembershipFee>> GetAsync(IFilter filter)
        {
            return Repository.GetAsync(filter);
        }

        /// <summary>
        /// Gets the membership fee by id asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// The membership fee.
        /// </returns>
        public Task<IMembershipFee> GetAsync(Guid id)
        {
            return Repository.GetAsync(id);
        }

        /// <summary>
        /// Gets the current user's membership fees asynchronously.
        /// </summary>
        /// <returns>
        /// The membership fee.
        /// </returns>
        public List<IMembershipFee> GetCurrentAsync()
        {
            return Repository.GetCurrentAsync();
        }

        #endregion Methods
    }
}
