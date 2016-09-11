using MemberRegistration.Common;
using System;
using System.Collections.Generic;

namespace MemberRegistration.DAL
{
    /// <summary>
    /// The product entity.
    /// </summary>
    public class Product
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
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the measuring unit.
        /// </summary>
        /// <value>
        /// The measuring unit.
        /// </value>
        public MeasuringUnit MeasuringUnit { get; set; }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        /// <value>
        /// The price.
        /// </value>
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the invoice items.
        /// </summary>
        /// <value>
        /// The invoice items.
        /// </value>
        public virtual ICollection<InvoiceItem> InvoiceItems { get; set; }

        #endregion Properties
    }
}
