using MemberRegistration.Common;
using System;
using System.Collections.Generic;

namespace MemberRegistration.DAL
{
    /// <summary>
    /// The invoice item entity.
    /// </summary>
    public class InvoiceItem
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
        /// Gets or sets the invoice identifier.
        /// </summary>
        /// <value>
        /// The invoice identifier.
        /// </value>
        public Guid InvoiceId { get; set; }

        /// <summary>
        /// Gets or sets the product identifier.
        /// </summary>
        /// <value>
        /// The product identifier.
        /// </value>
        public Guid ProductId { get; set; }

        /// <summary>
        /// Gets or sets the year.
        /// </summary>
        /// <value>
        /// The year.
        /// </value>
        public int Year { get; set; }

        /// <summary>
        /// Gets or sets the member identifier.
        /// </summary>
        /// <value>
        /// The member identifier.
        /// </value>
        public Guid MemberId { get; set; }

        /// <summary>
        /// Gets or sets the currency unit.
        /// </summary>
        /// <value>
        /// The currency unit.
        /// </value>
        public CurrencyUnit CurrencyUnit { get; set; }

        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        /// <value>
        /// The quantity.
        /// </value>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public decimal Value { get; set; }

        /// <summary>
        /// Gets or sets the member.
        /// </summary>
        /// <value>
        /// The member.
        /// </value>
        public virtual Member Member { get; set; }

        /// <summary>
        /// Gets or sets the product.
        /// </summary>
        /// <value>
        /// The product.
        /// </value>
        public virtual Product Product { get; set; }

        /// <summary>
        /// Gets or sets the invoice.
        /// </summary>
        /// <value>
        /// The invoice.
        /// </value>
        public virtual Invoice Invoice { get; set; }

        /// <summary>
        /// Gets or sets the membership fees.
        /// </summary>
        /// <value>
        /// The membership fees.
        /// </value>
        public virtual ICollection<MembershipFee> MembershipFees { get; set; }

        #endregion Properties
    }
}
