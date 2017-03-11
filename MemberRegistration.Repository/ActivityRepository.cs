﻿using MemberRegistration.Model.Common;
using MemberRegistration.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MemberRegistration.DAL;
using MemberRegistration.Model;
using System.Data.Entity;
using MemberRegistration.Common.Filters;

namespace MemberRegistration.Repository
{
    /// <summary>
    /// The activity repository.
    /// </summary>
    /// <seealso cref="MemberRegistration.Repository.Common.IActivityRepository" />
    public class ActivityRepository : IActivityRepository
    {
        #region Properties

        /// <summary>
        /// Gets or sets the repository.
        /// </summary>
        /// <value>
        /// The repository.
        /// </value>
        protected IRepository Repository { get; set; }

        #endregion Properties


        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ActivityRepository"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public ActivityRepository(IRepository repository)
        {
            this.Repository = repository;
        }

        #endregion Constructors


        #region Methods

        /// <summary>
        /// Gets the activities asynchronously.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns>
        /// The activities.
        /// </returns>
        public virtual async Task<ICollectionModel<IActivity>> GetAsync(Filter filter)
        {
            var model = new CollectionModelPOCO<IActivity>();
            IQueryable<Activity> query = Repository.GetWhere<Activity>();

            if (!string.IsNullOrWhiteSpace(filter.SearchString))
            {
                query = query.Where(a => a.Customer.FirstName.ToUpper()
                    .Contains(filter.SearchString.ToUpper())
                    || a.Customer.LastName.ToUpper()
                    .Contains(filter.SearchString.ToUpper())
                    || a.Name.ToUpper()
                    .Contains(filter.SearchString.ToUpper()));
            }

            model.TotalResults = await query.CountAsync();
            model.PageNumber = filter.PageNumber;
            model.PageSize = filter.PageSize;

            model.Items = Mapper.Map<IEnumerable<IActivity>>(
                await query.OrderByDescending(a => a.Customer.LastName)
                .Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize)
                .ToListAsync());

            return model;
        }

        /// <summary>
        /// Gets the activity asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// The activity.
        /// </returns>
        public virtual async Task<IActivity> GetAsync(Guid id)
        {
            return Mapper.Map<ActivityPOCO>(await Repository.GetByIDAsync<Activity>(id));
        }

        /// <summary>
        /// Adds the activity asynchronously.
        /// </summary>
        /// <param name="activity">The activity.</param>
        /// <returns></returns>
        public virtual Task<int> AddAsync(IActivity activity)
        {
            return Repository.AddAsync<Activity>(Mapper.Map<Activity>(activity));
        }

        /// <summary>
        /// Updates the activity asynchronously.
        /// </summary>
        /// <param name="activity">The activity.</param>
        /// <returns></returns>
        public virtual Task<int> UpdateAsync(IActivity activity)
        {
            return Repository.UpdateAsync<Activity>(Mapper.Map<Activity>(activity));
        }

        /// <summary>
        /// Deletes the activity asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public virtual Task<int> DeleteAsync(Guid id)
        {
            return Repository.DeleteAsync<Activity>(id);
        }

        #endregion Methods
    }
}
