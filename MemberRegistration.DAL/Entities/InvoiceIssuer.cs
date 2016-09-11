using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace MemberRegistration.DAL
{
    /// <summary>
    /// The invoice issuer entity.
    /// </summary>
    public class InvoiceIssuer
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
        /// Gets or sets the full name.
        /// </summary>
        /// <value>
        /// The full name.
        /// </value>
        public string FullName { get; set; }

        /// <summary>
        /// Gets or sets the operator label.
        /// </summary>
        /// <value>
        /// The operator label.
        /// </value>
        public string OperatorLabel { get; set; }

        /// <summary>
        /// Gets or sets the invoices.
        /// </summary>
        /// <value>
        /// The invoices.
        /// </value>
        public virtual ICollection<Invoice> Invoices { get; set; }

        #endregion Properties
    }
}
