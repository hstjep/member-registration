using MemberRegistration.Common;
using System;
using System.Collections.Generic;

namespace MemberRegistration.Model.Common
{
    public interface IMember : ICustomer
    {
        #region Properites

        /// <summary>
        /// Gets or sets the membership number.
        /// </summary>
        /// <value>
        /// The membership number.
        /// </value>
        int MembershipNumber { get; set; }

        /// <summary>
        /// Gets or sets the birth place.
        /// </summary>
        /// <value>
        /// The birth place.
        /// </value>
        string BirthPlace { get; set; }

        /// <summary>
        /// Gets or sets the birth date.
        /// </summary>
        /// <value>
        /// The birth date.
        /// </value>
        Nullable<DateTime> BirthDate { get; set; }

        /// <summary>
        /// Gets or sets the phone number.
        /// </summary>
        /// <value>
        /// The phone number.
        /// </value>
        string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the current employment.
        /// </summary>
        /// <value>
        /// The current employment.
        /// </value>
        string CurrentEmployment { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        string Email { get; set; }

        /// <summary>
        /// Gets or sets the web site.
        /// </summary>
        /// <value>
        /// The web site.
        /// </value>
        string WebSite { get; set; }

        /// <summary>
        /// Gets or sets the area of interest.
        /// </summary>
        /// <value>
        /// The area of interest.
        /// </value>
        string AreaOfInterest { get; set; }

        /// <summary>
        /// Gets or sets the membership date.
        /// </summary>
        /// <value>
        /// The membership date.
        /// </value>
        DateTime MembershipDate { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        Status Status { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is removed.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is removed; otherwise, <c>false</c>.
        /// </value>
        bool IsRemoved { get; set; }

        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        /// <value>
        /// The user.
        /// </value>
        IApplicationUser User { get; set; }

        /// <summary>
        /// Gets or sets the membership fees.
        /// </summary>
        /// <value>
        /// The membership fees.
        /// </value>
        ICollection<IMembershipFee> MembershipFees { get; set; }

        /// <summary>
        /// Gets or sets the invoice items.
        /// </summary>
        /// <value>
        /// The invoice items.
        /// </value>
        ICollection<IInvoiceItem> InvoiceItems { get; set; }

        #endregion Properites
    }
}
