using MemberRegistration.DAL;
using MemberRegistration.Model;
using MemberRegistration.Model.Common;
using MemberRegistration.Repository.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNet.Identity;
using MemberRegistration.Common.Filters;
using AutoMapper;

namespace MemberRegistration.Repository
{
    public class MembershipFeeRepository : IMembershipFeeRepository
    {
        #region Properties

        protected IRepository Repository { get; set; }

        #endregion Properties

        
        #region Constructors

        public MembershipFeeRepository(IRepository repository)
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
        public async Task<IEnumerable<IMembershipFee>> GetAsync(IFilter filter = null)
        {
            if (filter != null)
            {
                var MembershipFees = Mapper.Map<List<IMembershipFee>>(await Repository.GetWhere<MembershipFee>().OrderByDescending(r => r.Member.LastName).ToListAsync());

                if (!string.IsNullOrWhiteSpace(filter.SearchString))
                {
                    MembershipFees = MembershipFees.Where(r => r.Member.FirstName.ToUpper()
                        .Contains(filter.SearchString.ToUpper())
                        || r.Member.LastName.ToUpper()
                        .Contains(filter.SearchString.ToUpper()))
                        .ToList();
                }
                return MembershipFees;
            }
            else
            {
                return Mapper.Map<IEnumerable<IMembershipFee>>(await Repository.GetWhere<MembershipFee>().ToListAsync());
            }
        }

        /// <summary>
        /// Gets the membership fee by id asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// The membership fee.
        /// </returns>
        public virtual async Task<IMembershipFee> GetAsync(Guid id)
        {
            return AutoMapper.Mapper.Map<MembershipFeePOCO>(await Repository.GetByIDAsync<MembershipFee>(id));
        }

        /// <summary>
        /// Gets the current user's membership fees asynchronously.
        /// </summary>
        /// <returns>
        /// The membership fee.
        /// </returns>
        public virtual List<IMembershipFee> GetCurrentAsync()
        {
            var currentUser = Guid.Parse(ClaimsPrincipal.Current.Identity.GetUserId());

            return AutoMapper.Mapper.Map<List<IMembershipFee>>(
                    Repository.GetWhere<MembershipFee>().ToList().Where(c => c.Member.Id == currentUser));         
        }

        /// <summary>
        /// Adds the membership fee asynchronously.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        /// <param name="membershipFee">The membership fee.</param>
        /// <returns></returns>
        public virtual Task<int> AddAsync(IUnitOfWork unitOfWork, IMembershipFee membershipFee)
        {
            return unitOfWork.AddAsync<MembershipFee>(Mapper.Map<MembershipFee>(membershipFee));
        }

        #endregion Methods

        }
}


