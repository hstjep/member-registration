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
    public class ActivityService : IActivityService
    {
        #region Properties

        protected IActivityRepository Repository { get; set; }

        #endregion Properties


        #region Constructors

        public ActivityService(IActivityRepository repository)
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
        public Task<ICollectionModel<IActivity>> GetAsync(Filter filter)
        {
            return Repository.GetAsync(filter);
        }

        /// <summary>
        /// Gets the activity asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// The activity.
        /// </returns>
        public Task<IActivity> GetAsync(Guid id)
        {
            return Repository.GetAsync(id);
        }

        /// <summary>
        /// Adds the activity asynchronously.
        /// </summary>
        /// <param name="activity">The activity.</param>
        /// <returns></returns>
        public Task<int> AddAsync(IActivity activity)
        {
            return Repository.AddAsync(activity);
        }

        /// <summary>
        /// Updates the activity asynchronously.
        /// </summary>
        /// <param name="activity">The activity.</param>
        /// <returns></returns>
        public Task<int> UpdateAsync(IActivity activity)
        {
            return Repository.UpdateAsync(activity);
        }

        /// <summary>
        /// Deletes the activity asynchronously.
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
