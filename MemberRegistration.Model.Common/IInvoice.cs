using System;
using System.Collections.Generic;

namespace MemberRegistration.Model.Common
{
    public interface IInvoice
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
        /// Gets or sets the society identifier.
        /// </summary>
        /// <value>
        /// The society identifier.
        /// </value>
        Guid SocietyId { get; set; }

        /// <summary>
        /// Gets or sets the customer identifier.
        /// </summary>
        /// <value>
        /// The customer identifier.
        /// </value>
        Guid CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the number.
        /// </summary>
        /// <value>
        /// The number.
        /// </value>
        int Number { get; set; }

        /// <summary>
        /// Gets or sets the payment date.
        /// </summary>
        /// <value>
        /// The payment date.
        /// </value>
        DateTime PaymentDate { get; set; }

        /// <summary>
        /// Gets or sets the maturity date.
        /// </summary>
        /// <value>
        /// The maturity date.
        /// </value>
        DateTime MaturityDate { get; set; }

        /// <summary>
        /// Gets or sets the payment method.
        /// </summary>
        /// <value>
        /// The payment method.
        /// </value>
        string PaymentMethod { get; set; }

        /// <summary>
        /// Gets or sets the invoice issuer identifier.
        /// </summary>
        /// <value>
        /// The invoice issuer identifier.
        /// </value>
        Guid InvoiceIssuerId { get; set; }

        /// <summary>
        /// Gets or sets the responsible person identifier.
        /// </summary>
        /// <value>
        /// The responsible person identifier.
        /// </value>
        Guid ResponsiblePersonId { get; set; }

        /// <summary>
        /// Gets or sets the membership fees.
        /// </summary>
        /// <value>
        /// The membership fees.
        /// </value>
        ICollection<IMembershipFee> MembershipFees { get; set; }

        /// <summary>
        /// Gets or sets the invoice issuer.
        /// </summary>
        /// <value>
        /// The invoice issuer.
        /// </value>
        IInvoiceIssuer InvoiceIssuer { get; set; }

        /// <summary>
        /// Gets or sets the customer.
        /// </summary>
        /// <value>
        /// The customer.
        /// </value>
        ICustomer Customer { get; set; }

        /// <summary>
        /// Gets or sets the responsible person.
        /// </summary>
        /// <value>
        /// The responsible person.
        /// </value>
        IResponsiblePerson ResponsiblePerson { get; set; }

        /// <summary>
        /// Gets or sets the invoice items.
        /// </summary>
        /// <value>
        /// The invoice items.
        /// </value>
        ICollection<IInvoiceItem> InvoiceItems { get; set; }

        /// <summary>
        /// Gets or sets the society.
        /// </summary>
        /// <value>
        /// The society.
        /// </value>
        ISociety Society { get; set; }

        #endregion Properties
    }
}
