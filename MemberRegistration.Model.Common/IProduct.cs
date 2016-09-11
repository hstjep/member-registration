using MemberRegistration.Common;
using System;
using System.Collections.Generic;

namespace MemberRegistration.Model.Common
{
    public interface IProduct
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
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        string Name { get; set; }

        /// <summary>
        /// Gets or sets the measuring unit.
        /// </summary>
        /// <value>
        /// The measuring unit.
        /// </value>
        MeasuringUnit MeasuringUnit { get; set; }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        /// <value>
        /// The price.
        /// </value>
        decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the invoice items.
        /// </summary>
        /// <value>
        /// The invoice items.
        /// </value>
        ICollection<IInvoiceItem> InvoiceItems { get; set; }

        #endregion Properties
    }
}
