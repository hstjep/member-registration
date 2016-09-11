using MemberRegistration.Common;
using System;

namespace MemberRegistration.Model.Common
{
    public interface IActivity
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the customer identifier.
        /// </summary>
        /// <value>
        /// The customer identifier.
        /// </value>
        Guid CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the name of the activity.
        /// </summary>
        /// <value>
        /// The name of the activity.
        /// </value>
        string Name { get; set; }

        /// <summary>
        /// Gets or sets the description of the activity.
        /// </summary>
        /// <value>
        /// The description of the activity.
        /// </value>
        string Description { get; set; }

        /// <summary>
        /// Gets or sets the type of the activity.
        /// </summary>
        /// <value>
        /// The type of the activity.
        /// </value>
        ActivityType ActivityType { get; set; }

        /// <summary>
        /// Gets or sets the number of hours.
        /// </summary>
        /// <value>
        /// The number of hours.
        /// </value>
        int NumberOfHours { get; set; }

        /// <summary>
        /// Gets or sets the date from.
        /// </summary>
        /// <value>
        /// The date from.
        /// </value>
        DateTime DateFrom { get; set; }

        /// <summary>
        /// Gets or sets the date to.
        /// </summary>
        /// <value>
        /// The date to.
        /// </value>
        DateTime? DateTo { get; set; }

        /// <summary>
        /// Gets or sets the customer.
        /// </summary>
        /// <value>
        /// The customer.
        /// </value>
        ICustomer Customer { get; set; }
    }
}
