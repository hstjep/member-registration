using MemberRegistration.Common;
using MemberRegistration.Model.Common;
using System;
using System.Runtime.Serialization;

namespace MemberRegistration.Model
{
    /// <summary>
    /// The activity POCO.
    /// </summary>
    /// <seealso cref="MemberRegistration.Model.Common.IActivity" />
    [KnownType(typeof(ActivityPOCO))]
    public class ActivityPOCO : IActivity
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
        /// Gets or sets the start date of the activity.
        /// </summary>
        /// <value>
        /// The date.
        /// </value>
        public DateTime DateFrom { get; set; }

        /// <summary>
        /// Gets or sets the end date of the acitivity.
        /// </summary>
        /// <value>
        /// The date.
        /// </value>
        public DateTime? DateTo { get; set; }

        /// <summary>
        /// Gets or sets the customer.
        /// </summary>
        /// <value>
        /// The customer.
        /// </value>
        public virtual ICustomer Customer { get; set; }
    }
}
