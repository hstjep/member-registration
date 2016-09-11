using MemberRegistration.Model.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace MemberRegistration.Model
{
    /// <summary>
    /// The responsible person POCO.
    /// </summary>
    /// <seealso cref="MemberRegistration.Model.Common.IResponsiblePerson" />
    public class ResponsiblePersonPOCO : IResponsiblePerson
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
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public string Title { get; set; }

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
