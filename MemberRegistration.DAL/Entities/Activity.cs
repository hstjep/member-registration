using System;
using MemberRegistration.Common;

namespace MemberRegistration.DAL
{
    /// <summary>
    /// The activity entity.
    /// </summary>
    public class Activity
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the customer identifier.
        /// </summary>
        /// <value>
        /// The customer identifier.
        /// </value>
        public Guid CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the name of the activity.
        /// </summary>
        /// <value>
        /// The name of the activity.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description of the activity.
        /// </summary>
        /// <value>
        /// The description of the activity.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the type of the activity.
        /// </summary>
        /// <value>
        /// The type of the activity.
        /// </value>
        public ActivityType ActivityType { get; set; }

        /// <summary>
        /// Gets or sets the number of hours.
        /// </summary>
        /// <value>
        /// The number of hours.
        /// </value>
        public int NumberOfHours { get; set; }

        /// <summary>
        /// Gets or sets the date from.
        /// </summary>
        /// <value>
        /// The date from.
        /// </value>
        public DateTime DateFrom { get; set; }

        /// <summary>
        /// Gets or sets the date to.
        /// </summary>
        /// <value>
        /// The date to.
        /// </value>
        public DateTime? DateTo { get; set; }

        /// <summary>
        /// Gets or sets the customer.
        /// </summary>
        /// <value>
        /// The customer.
        /// </value>
        public virtual Customer Customer { get; set; }
    }
}
