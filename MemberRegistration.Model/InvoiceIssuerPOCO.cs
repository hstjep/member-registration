using MemberRegistration.Model.Common;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MemberRegistration.Model
{
    /// <summary>
    /// The invoice issuer POCO.
    /// </summary>
    /// <seealso cref="MemberRegistration.Model.Common.IInvoiceIssuer" />
    [KnownType(typeof(InvoiceIssuerPOCO))]
    public class InvoiceIssuerPOCO : IInvoiceIssuer
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
        public virtual ICollection<IInvoice> Invoices { get; set; }

        #endregion Properties
    }
}
