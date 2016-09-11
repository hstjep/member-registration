using MemberRegistration.Model.Common;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MemberRegistration.Model
{
    /// <summary>
    /// The customer POCO.
    /// </summary>
    /// <seealso cref="MemberRegistration.Model.Common.ICustomer" />
    [KnownType(typeof(CustomerPOCO))]
    public class CustomerPOCO : ICustomer
    {
        #region Properties

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        public string LastName { get; set; }

        /// <summary>
        /// Gets the full name.
        /// </summary>
        /// <value>
        /// The full name.
        /// </value>
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        /// <summary>
        /// Gets or sets the oib.
        /// </summary>
        /// <value>
        /// The oib.
        /// </value>
        public string OIB { get; set; }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>
        /// The address.
        /// </value>
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the place.
        /// </summary>
        /// <value>
        /// The place.
        /// </value>
        public string Place { get; set; }

        /// <summary>
        /// Gets or sets the postal code.
        /// </summary>
        /// <value>
        /// The postal code.
        /// </value>
        public string PostalCode { get; set; }

        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        /// <value>
        /// The country.
        /// </value>
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets the PDV identifier.
        /// </summary>
        /// <value>
        /// The PDV identifier.
        /// </value>
        public string PdvId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is member.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is member; otherwise, <c>false</c>.
        /// </value>
        public bool IsMember { get; set; }

        /// <summary>
        /// Gets or sets the invoices.
        /// </summary>
        /// <value>
        /// The invoices.
        /// </value>
        public virtual ICollection<IInvoice> Invoices { get; set; }

        /// <summary>
        /// Gets or sets the activities.
        /// </summary>
        /// <value>
        /// The activities.
        /// </value>
        public virtual ICollection<IActivity> Activities { get; set; }

        #endregion Properties
    }
}
