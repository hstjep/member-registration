using MemberRegistration.DAL;
using MemberRegistration.Model;
using MemberRegistration.Model.Common;
using MemberRegistration.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MemberRegistration.Common.Filters;
using System.Security.Claims;
using Microsoft.AspNet.Identity;
using System.Data.Entity;

namespace MemberRegistration.Repository
{
    public class MemberRepository : IMemberRepository
    {
        #region Properties

        protected IRepository Repository { get; private set; }

        #endregion Properties


        #region Constructors

        public MemberRepository(IRepository repository)
        {
            this.Repository = repository;
        }

        #endregion Constructors


        #region Methods

        /// <summary>
        /// Gets the members asynchronously.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns>
        /// The members.
        /// </returns>
        public virtual Task<ICollectionModel<IMember>> GetAsync(IFilter filter)
        {
            IEnumerable<IMember> members;
            var model = new CollectionModelPOCO<IMember>();

            if (!string.IsNullOrWhiteSpace(filter.SearchString))
            {
                members = Mapper.Map<IEnumerable<MemberPOCO>>(
                    Repository.GetWhere<Member>()
                    .Where(s => s.LastName.ToUpper()
                        .Contains(filter.SearchString.ToUpper())
                                        || s.FirstName.ToUpper()
                                        .Contains(filter.SearchString.ToUpper())));
            } else
            {
                members = Mapper.Map<IEnumerable<MemberPOCO>>(
                    Repository.GetWhere<Member>());
            }

            model.TotalResults = members.Count();
            model.PageNumber = filter.PageNumber;
            model.PageSize = filter.PageSize;

            members = members
                .Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize)
                .OrderBy(c => c.LastName)
                .ToList();

            foreach (var member in members)
            {
                model.Items.Add(member);
            }

            return Task.FromResult<ICollectionModel<IMember>>(model);
        }

        /// <summary>
        /// Asynchronously gets the current members.
        /// </summary>
        /// <returns></returns>
        public virtual Task<IEnumerable<IMember>> GetCurrentMembersAsync()
        {
            return Task.FromResult(Mapper.Map<IEnumerable<IMember>>(
                Repository.GetWhere<Member>()
                .Where(m => m.IsRemoved == false)
                .OrderBy(m => m.MembershipNumber)));
        }

        /// <summary>
        /// Gets the current member asynchronously.
        /// </summary>
        /// <returns>
        /// The current member.
        /// </returns>
        public virtual async Task<IMember> GetCurrentMemberAsync()
        {
            var currentUser = Guid.Parse(ClaimsPrincipal.Current.Identity.GetUserId());
            return Mapper.Map<MemberPOCO>(await Repository.GetWhere<Member>().Where(c => c.User.Id == currentUser).FirstOrDefaultAsync());
        }

        /// <summary>
        /// Gets the member by id asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// The member.
        /// </returns>
        public virtual async Task<IMember> GetAsync(Guid id)
        {
            return Mapper.Map<MemberPOCO>(await Repository.GetWhere<Member>().Where(c => c.Id == id).FirstOrDefaultAsync());
        }

        /// <summary>
        /// Updates the member asynchronously.
        /// </summary>
        /// <param name="member">The member</param>
        /// <returns></returns>
        public virtual Task<int> UpdateAsync(IMember member)
        {
            return Repository.UpdateAsync<MemberRegistration.DAL.Member>(Mapper.Map<MemberRegistration.DAL.Member>(member));
        }

        /// <summary>
        /// Gets the last membership number and increases it by one.
        /// </summary>
        /// <returns>
        /// The increased invoice number.
        /// </returns>
        public virtual Task<int> GetMembershipNumberAsync()
        {
            return Task.FromResult(Repository.GetWhere<Member>()
                .OrderByDescending(i => i.MembershipNumber)
                .Select(i => i.MembershipNumber)
                .FirstOrDefault() + 1);
        }

        #endregion Methods
    }
}




