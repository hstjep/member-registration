using MemberRegistration.Model.Common;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MemberRegistration.Model
{
    /// <summary>
    /// The invoice POCO.
    /// </summary>
    /// <seealso cref="MemberRegistration.Model.Common.IInvoice" />
    [KnownType(typeof(InvoicePOCO))]
    public class InvoicePOCO : IInvoice
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
        /// Gets or sets the number.
        /// </summary>
        /// <value>
        /// The number.
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
        public virtual ICollection<IMembershipFee> MembershipFees { get; set; }

        /// <summary>
        /// Gets or sets the invoice issuer.
        /// </summary>
        /// <value>
        /// The invoice issuer.
        /// </value>
        public virtual IInvoiceIssuer InvoiceIssuer { get; set; }

        /// <summary>
        /// Gets or sets the customer.
        /// </summary>
        /// <value>
        /// The customer.
        /// </value>
        public virtual ICustomer Customer { get; set; }

        /// <summary>
        /// Gets or sets the responsible person.
        /// </summary>
        /// <value>
        /// The responsible person.
        /// </value>
        public virtual IResponsiblePerson ResponsiblePerson { get; set; }

        /// <summary>
        /// Gets or sets the invoice items.
        /// </summary>
        /// <value>
        /// The invoice items.
        /// </value>
        public virtual ICollection<IInvoiceItem> InvoiceItems { get; set; }

        /// <summary>
        /// Gets or sets the society.
        /// </summary>
        /// <value>
        /// The society.
        /// </value>
        public virtual ISociety Society { get; set; }

        #endregion Properties
    }
}