using System;
using System.Collections.Generic;

namespace MemberRegistration.Model.Common
{
    public interface ICustomer
    {
        #region Properties

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        string LastName { get; set; }

        /// <summary>
        /// Gets the full name.
        /// </summary>
        /// <value>
        /// The full name.
        /// </value>
        string FullName { get; }

        /// <summary>
        /// Gets or sets the oib.
        /// </summary>
        /// <value>
        /// The oib.
        /// </value>
        string OIB { get; set; }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>
        /// The address.
        /// </value>
        string Address { get; set; }

        /// <summary>
        /// Gets or sets the place.
        /// </summary>
        /// <value>
        /// The place.
        /// </value>
        string Place { get; set; }

        /// <summary>
        /// Gets or sets the postal code.
        /// </summary>
        /// <value>
        /// The postal code.
        /// </value>
        string PostalCode { get; set; }

        /// <summary>
        /// Gets or sets the PDV identifier.
        /// </summary>
        /// <value>
        /// The PDV identifier.
        /// </value>
        string PdvId { get; set; }

        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        /// <value>
        /// The country.
        /// </value>
        string Country { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is member.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is member; otherwise, <c>false</c>.
        /// </value>
        bool IsMember { get; set; }

        /// <summary>
        /// Gets or sets the invoices.
        /// </summary>
        /// <value>
        /// The invoices.
        /// </value>
        ICollection<IInvoice> Invoices { get; set; }

        /// <summary>
        /// Gets or sets the activities.
        /// </summary>
        /// <value>
        /// The activities.
        /// </value>
        ICollection<IActivity> Activities { get; set; }

        #endregion Properties
    }
}
