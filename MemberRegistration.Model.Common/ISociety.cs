using System;
using System.Collections.Generic;

namespace MemberRegistration.Model.Common
{
    public interface ISociety
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
        /// Gets or sets the acronym.
        /// </summary>
        /// <value>
        /// The acronym.
        /// </value>
        string Acronym { get; set; }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>
        /// The address.
        /// </value>
        string Address { get; set; }

        /// <summary>
        /// Gets or sets the place.
        /// </summary>
        /// <value>
        /// The place.
        /// </value>
        string Place { get; set; }

        /// <summary>
        /// Gets or sets the postal code.
        /// </summary>
        /// <value>
        /// The postal code.
        /// </value>
        string PostalCode { get; set; }

        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        /// <value>
        /// The country.
        /// </value>
        string Country { get; set; }

        /// <summary>
        /// Gets or sets the oib.
        /// </summary>
        /// <value>
        /// The oib.
        /// </value>
        string OIB { get; set; }

        /// <summary>
        /// Gets or sets the web site.
        /// </summary>
        /// <value>
        /// The web site.
        /// </value>
        string WebSite { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        string Email { get; set; }

        /// <summary>
        /// Gets or sets the logo.
        /// </summary>
        /// <value>
        /// The logo.
        /// </value>
        byte[] Logo { get; set; }

        /// <summary>
        /// Gets or sets the MIME type image.
        /// </summary>
        /// <value>
        /// The MIME type image.
        /// </value>
        string MimeTypeImage { get; set; }

        /// <summary>
        /// Gets or sets the iban.
        /// </summary>
        /// <value>
        /// The iban.
        /// </value>
        string IBAN { get; set; }

        /// <summary>
        /// Gets or sets the cash register location.
        /// </summary>
        /// <value>
        /// The cash register location.
        /// </value>
        string CashRegisterLocation { get; set; }

        /// <summary>
        /// Gets or sets the bank.
        /// </summary>
        /// <value>
        /// The bank.
        /// </value>
        string Bank { get; set; }

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


