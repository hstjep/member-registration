using MemberRegistration.Common;
using MemberRegistration.Model.Common;
using System.Runtime.Serialization;

namespace MemberRegistration.Model
{
    /// <summary>
    /// The invoice item product POCO.
    /// </summary>
    /// <seealso cref="MemberRegistration.Model.Common.IInvoiceItemProduct" />
    [KnownType(typeof(InvoiceItemProductPOCO))]
    public class InvoiceItemProductPOCO : IInvoiceItemProduct
    {
        /// <summary>
        /// Gets or sets the name of the product.
        /// </summary>
        /// <value>
        /// The name of the product.
        /// </value>
        public string ProductName { get; set; }

        /// <summary>
        /// Gets or sets the year.
        /// </summary>
        /// <value>
        /// The year.
        /// </value>
        public int Year { get; set; }

        /// <summary>
        /// Gets or sets the first name of the member.
        /// </summary>
        /// <value>
        /// The first name of the member.
        /// </value>
        public string MemberFirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name of the member.
        /// </summary>
        /// <value>
        /// The last name of the member.
        /// </value>
        public string MemberLastName { get; set; }

        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        /// <value>
        /// The quantity.
        /// </value>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        /// <value>
        /// The price.
        /// </value>
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>
        /// The amount.
        /// </value>
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets the measuring unit.
        /// </summary>
        /// <value>
        /// The measuring unit.
        /// </value>
        public MeasuringUnit MeasuringUnit { get; set; }

        /// <summary>
        /// Gets or sets the currency unit.
        /// </summary>
        /// <value>
        /// The currency unit.
        /// </value>
        public CurrencyUnit CurrencyUnit { get; set; }
    }
}
