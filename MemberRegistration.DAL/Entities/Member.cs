using MemberRegistration.Common;
using System;
using System.Collections.Generic;

namespace MemberRegistration.DAL
{
    /// <summary>
    /// The member entity.
    /// </summary>
    /// <seealso cref="MemberRegistration.DAL.Customer" />
    public class Member : Customer
    {
        #region Properites

        /// <summary>
        /// Gets or sets the membership number.
        /// </summary>
        /// <value>
        /// The membership number.
        /// </value>
        public int MembershipNumber { get; set; }

        /// <summary>
        /// Gets or sets the birth place.
        /// </summary>
        /// <value>
        /// The birth place.
        /// </value>
        public string BirthPlace { get; set; }

        /// <summary>
        /// Gets or sets the birth date.
        /// </summary>
        /// <value>
        /// The birth date.
        /// </value>
        public Nullable<DateTime> BirthDate { get; set; }

        /// <summary>
        /// Gets or sets the phone number.
        /// </summary>
        /// <value>
        /// The phone number.
        /// </value>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the current employment.
        /// </summary>
        /// <value>
        /// The current employment.
        /// </value>
        public string CurrentEmployment { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the web site.
        /// </summary>
        /// <value>
        /// The web site.
        /// </value>
        public string WebSite { get; set; }

        /// <summary>
        /// Gets or sets the area of interest.
        /// </summary>
        /// <value>
        /// The area of interest.
        /// </value>
        public string AreaOfInterest { get; set; }

        /// <summary>
        /// Gets or sets the membership date.
        /// </summary>
        /// <value>
        /// The membership date.
        /// </value>
        public DateTime MembershipDate { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        public Status Status { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is removed.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is removed; otherwise, <c>false</c>.
        /// </value>
        public bool IsRemoved { get; set; }

        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        /// <value>
        /// The user.
        /// </value>
        public virtual ApplicationUser User { get; set; }

        /// <summary>
        /// Gets or sets the membership fees.
        /// </summary>
        /// <value>
        /// The membership fees.
        /// </value>
        public virtual ICollection<MembershipFee> MembershipFees { get; set; }

        /// <summary>
        /// Gets or sets the invoice items.
        /// </summary>
        /// <value>
        /// The invoice items.
        /// </value>
        public virtual ICollection<InvoiceItem> InvoiceItems { get; set; }

        #endregion Properites
    }
}
