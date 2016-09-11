using System;
using System.Collections.Generic;

namespace MemberRegistration.DAL
{
    /// <summary>
    /// The invoice entity.
    /// </summary>
    public class Invoice
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
        /// Gets or sets the society identifier.
        /// </summary>
        /// <value>
        /// The society identifier.
        /// </value>
        public Guid SocietyId { get; set; }

        /// <summary>
        /// Gets or sets the customer identifier.
        /// </summary>
        /// <value>
        /// The customer identifier.
        /// </value>
        public Guid CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the invoice number.
        /// </summary>
        /// <value>
        /// The invoice number.
        /// </value>
        public int Number { get; set; }

        /// <summary>
        /// Gets or sets the payment date.
        /// </summary>
        /// <value>
        /// The payment date.
        /// </value>
        public DateTime PaymentDate { get; set; }

        /// <summary>
        /// Gets or sets the maturity date.
        /// </summary>
        /// <value>
        /// The maturity date.
        /// </value>
        public DateTime MaturityDate { get; set; }

        /// <summary>
        /// Gets or sets the payment method.
        /// </summary>
        /// <value>
        /// The payment method.
        /// </value>
        public string PaymentMethod { get; set; }

        /// <summary>
        /// Gets or sets the invoice issuer identifier.
        /// </summary>
        /// <value>
        /// The invoice issuer identifier.
        /// </value>
        public Guid InvoiceIssuerId { get; set; }

        /// <summary>
        /// Gets or sets the responsible person identifier.
        /// </summary>
        /// <value>
        /// The responsible person identifier.
        /// </value>
        public Guid ResponsiblePersonId { get; set; }

        /// <summary>
        /// Gets or sets the membership fees.
        /// </summary>
        /// <value>
        /// The membership fees.
        /// </value>
        public virtual ICollection<MembershipFee> MembershipFees { get; set; }

        /// <summary>
        /// Gets or sets the invoice issuer.
        /// </summary>
        /// <value>
        /// The invoice issuer.
        /// </value>
        public virtual InvoiceIssuer InvoiceIssuer { get; set; }

        /// <summary>
        /// Gets or sets the customer.
        /// </summary>
        /// <value>
        /// The customer.
        /// </value>
        public virtual Customer Customer { get; set; }

        /// <summary>
        /// Gets or sets the responsible person.
        /// </summary>
        /// <value>
        /// The responsible person.
        /// </value>
        public virtual ResponsiblePerson ResponsiblePerson { get; set; }

        /// <summary>
        /// Gets or sets the invoice items.
        /// </summary>
        /// <value>
        /// The invoice items.
        /// </value>
        public virtual ICollection<InvoiceItem> InvoiceItems { get; set; }

        /// <summary>
        /// Gets or sets the society.
        /// </summary>
        /// <value>
        /// The society.
        /// </value>
        public virtual Society Society { get; set; }

        #endregion Properties
    }
}
