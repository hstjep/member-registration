using MemberRegistration.Common;
using MemberRegistration.Model.Common;
using System;
using System.Runtime.Serialization;


namespace MemberRegistration.Model
{
    /// <summary>
    /// The membership fee POCO.
    /// </summary>
    /// <seealso cref="MemberRegistration.Model.Common.IMembershipFee" />
    [KnownType(typeof(MembershipFeePOCO))]
    public class MembershipFeePOCO : IMembershipFee
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
        /// Gets or sets the member identifier.
        /// </summary>
        /// <value>
        /// The member identifier.
        /// </value>
        public Guid MemberId { get; set; }

        /// <summary>
        /// Gets or sets the invoice identifier.
        /// </summary>
        /// <value>
        /// The invoice identifier.
        /// </value>
        public Guid InvoiceId { get; set; }

        /// <summary>
        /// Gets or sets the invoice item identifier.
        /// </summary>
        /// <value>
        /// The invoice item identifier.
        /// </value>
        public Guid InvoiceItemId { get; set; }

        /// <summary>
        /// Gets or sets the year.
        /// </summary>
        /// <value>
        /// The year.
        /// </value>
        public int Year { get; set; }

        /// <summary>
        /// Gets or sets the payment date.
        /// </summary>
        /// <value>
        /// The payment date.
        /// </value>
        public DateTime PaymentDate { get; set; }

        /// <summary>
        /// Gets or sets the expiration date.
        /// </summary>
        /// <value>
        /// The expiration date.
        /// </value>
        public DateTime ExpirationDate { get; set; }

        /// <summary>
        /// Gets or sets the payment status.
        /// </summary>
        /// <value>
        /// The payment status.
        /// </value>
        public Nullable<PaymentStatus> PaymentStatus { get; set; }

        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>
        /// The amount.
        /// </value>
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        /// <value>
        /// The user.
        /// </value>
        public virtual IApplicationUser User { get; set; }

        /// <summary>
        /// Gets or sets the member.
        /// </summary>
        /// <value>
        /// The member.
        /// </value>
        public virtual IMember Member { get; set; }

        /// <summary>
        /// Gets or sets the invoice.
        /// </summary>
        /// <value>
        /// The invoice.
        /// </value>
        public virtual IInvoice Invoice { get; set; }

        /// <summary>
        /// Gets or sets the invoice item.
        /// </summary>
        /// <value>
        /// The invoice item.
        /// </value>
        public virtual IInvoiceItem InvoiceItem { get; set; }

        #endregion Properties
    }
}
