using System;
using System.Collections.Generic;

namespace MemberRegistration.Model.Common
{
    public interface IInvoiceIssuer
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
        /// Gets or sets the full name.
        /// </summary>
        /// <value>
        /// The full name.
        /// </value>
        string FullName { get; set; }

        /// <summary>
        /// Gets or sets the operator label.
        /// </summary>
        /// <value>
        /// The operator label.
        /// </value>
        string OperatorLabel { get; set; }

        /// <summary>
        /// Gets or sets the invoices.
        /// </summary>
        /// <value>
        /// The invoices.
        /// </value>
        ICollection<IInvoice> Invoices { get; set; }

        #endregion Properties
    }
}
