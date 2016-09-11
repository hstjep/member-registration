using MemberRegistration.Common;
using System;
using System.Collections.Generic;

namespace MemberRegistration.Model.Common
{
    public interface IInvoiceItem
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
        /// Gets or sets the invoice identifier.
        /// </summary>
        /// <value>
        /// The invoice identifier.
        /// </value>
        Guid InvoiceId { get; set; }

        /// <summary>
        /// Gets or sets the product identifier.
        /// </summary>
        /// <value>
        /// The product identifier.
        /// </value>
        Guid ProductId { get; set; }

        /// <summary>
        /// Gets or sets the year.
        /// </summary>
        /// <value>
        /// The year.
        /// </value>
        int Year { get; set; }

        /// <summary>
        /// Gets or sets the member identifier.
        /// </summary>
        /// <value>
        /// The member identifier.
        /// </value>
        Guid MemberId { get; set; }

        /// <summary>
        /// Gets or sets the currency unit.
        /// </summary>
        /// <value>
        /// The currency unit.
        /// </value>
        CurrencyUnit CurrencyUnit { get; set; }

        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        /// <value>
        /// The quantity.
        /// </value>
        int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        decimal Value { get; set; }

        /// <summary>
        /// Gets or sets the member.
        /// </summary>
        /// <value>
        /// The member.
        /// </value>
        IMember Member { get; set; }

        /// <summary>
        /// Gets or sets the product.
        /// </summary>
        /// <value>
        /// The product.
        /// </value>
        IProduct Product { get; set; }

        /// <summary>
        /// Gets or sets the invoice.
        /// </summary>
        /// <value>
        /// The invoice.
        /// </value>
        IInvoice Invoice { get; set; }

        /// <summary>
        /// Gets or sets the membership fees.
        /// </summary>
        /// <value>
        /// The membership fees.
        /// </value>
        ICollection<IMembershipFee> MembershipFees { get; set; }

        #endregion Properties
    }
}
