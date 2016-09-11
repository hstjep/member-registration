using MemberRegistration.Common;

namespace MemberRegistration.Model.Common
{
    public interface IInvoiceItemProduct
    {
        /// <summary>
        /// Gets or sets the name of the product.
        /// </summary>
        /// <value>
        /// The name of the product.
        /// </value>
        string ProductName { get; set; }

        /// <summary>
        /// Gets or sets the year.
        /// </summary>
        /// <value>
        /// The year.
        /// </value>
        int Year { get; set; }

        /// <summary>
        /// Gets or sets the first name of the member.
        /// </summary>
        /// <value>
        /// The first name of the member.
        /// </value>
        string MemberFirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name of the member.
        /// </summary>
        /// <value>
        /// The last name of the member.
        /// </value>
        string MemberLastName { get; set; }

        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        /// <value>
        /// The quantity.
        /// </value>
        int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        /// <value>
        /// The price.
        /// </value>
        decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>
        /// The amount.
        /// </value>
        decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets the measuring unit.
        /// </summary>
        /// <value>
        /// The measuring unit.
        /// </value>
        MeasuringUnit MeasuringUnit { get; set; }

        /// <summary>
        /// Gets or sets the currency unit.
        /// </summary>
        /// <value>
        /// The currency unit.
        /// </value>
        CurrencyUnit CurrencyUnit { get; set; }
    }
}
