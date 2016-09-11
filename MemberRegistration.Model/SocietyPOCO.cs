using MemberRegistration.Model.Common;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MemberRegistration.Model
{
    /// <summary>
    /// The society POCO.
    /// </summary>
    /// <seealso cref="MemberRegistration.Model.Common.ISociety" />
    [KnownType(typeof(SocietyPOCO))]
    public class SocietyPOCO : ISociety
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
        /// Gets or sets the acronym.
        /// </summary>
        /// <value>
        /// The acronym.
        /// </value>
        public string Acronym { get; set; }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>
        /// The address.
        /// </value>
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the place.
        /// </summary>
        /// <value>
        /// The place.
        /// </value>
        public string Place { get; set; }

        /// <summary>
        /// Gets or sets the postal code.
        /// </summary>
        /// <value>
        /// The postal code.
        /// </value>
        public string PostalCode { get; set; }

        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        /// <value>
        /// The country.
        /// </value>
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets the oib.
        /// </summary>
        /// <value>
        /// The oib.
        /// </value>
        public string OIB { get; set; }

        /// <summary>
        /// Gets or sets the web site.
        /// </summary>
        /// <value>
        /// The web site.
        /// </value>
        public string WebSite { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the logo.
        /// </summary>
        /// <value>
        /// The logo.
        /// </value>
        public byte[] Logo { get; set; }

        /// <summary>
        /// Gets or sets the MIME type image.
        /// </summary>
        /// <value>
        /// The MIME type image.
        /// </value>
        public string MimeTypeImage { get; set; }

        /// <summary>
        /// Gets or sets the iban.
        /// </summary>
        /// <value>
        /// The iban.
        /// </value>
        public string IBAN { get; set; }

        /// <summary>
        /// Gets or sets the cash register location.
        /// </summary>
        /// <value>
        /// The cash register location.
        /// </value>
        public string CashRegisterLocation { get; set; }

        /// <summary>
        /// Gets or sets the bank.
        /// </summary>
        /// <value>
        /// The bank.
        /// </value>
        public string Bank { get; set; }

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

