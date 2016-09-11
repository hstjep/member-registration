using MemberRegistration.Common;
using System;

namespace MemberRegistration.Model.Common
{
    public interface IMembershipFee
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
        /// Gets or sets the member identifier.
        /// </summary>
        /// <value>
        /// The member identifier.
        /// </value>
        Guid MemberId { get; set; }

        /// <summary>
        /// Gets or sets the invoice identifier.
        /// </summary>
        /// <value>
        /// The invoice identifier.
        /// </value>
        Guid InvoiceId { get; set; }

        /// <summary>
        /// Gets or sets the invoice item identifier.
        /// </summary>
        /// <value>
        /// The invoice item identifier.
        /// </value>
        Guid InvoiceItemId { get; set; }

        /// <summary>
        /// Gets or sets the year.
        /// </summary>
        /// <value>
        /// The year.
        /// </value>
        int Year { get; set; }

        /// <summary>
        /// Gets or sets the payment date.
        /// </summary>
        /// <value>
        /// The payment date.
        /// </value>
        DateTime PaymentDate { get; set; }

        /// <summary>
        /// Gets or sets the expiration date.
        /// </summary>
        /// <value>
        /// The expiration date.
        /// </value>
        DateTime ExpirationDate { get; set; }

        /// <summary>
        /// Gets or sets the payment status.
        /// </summary>
        /// <value>
        /// The payment status.
        /// </value>
        Nullable<PaymentStatus> PaymentStatus { get; set; }

        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>
        /// The amount.
        /// </value>
        decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        /// <value>
        /// The user.
        /// </value>
        IApplicationUser User { get; set; }

        /// <summary>
        /// Gets or sets the member.
        /// </summary>
        /// <value>
        /// The member.
        /// </value>
        IMember Member { get; set; }

        /// <summary>
        /// Gets or sets the invoice.
        /// </summary>
        /// <value>
        /// The invoice.
        /// </value>
        IInvoice Invoice { get; set; }

        /// <summary>
        /// Gets or sets the invoice item.
        /// </summary>
        /// <value>
        /// The invoice item.
        /// </value>
        IInvoiceItem InvoiceItem { get; set; }

        #endregion Properties
    }
}
