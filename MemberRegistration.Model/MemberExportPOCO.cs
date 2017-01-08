using MemberRegistration.Common;
using System;
using System.ComponentModel.DataAnnotations;

namespace MemberRegistration.Model
{
    /// <summary>
    /// Member export POCO class.
    /// </summary>
    public class MemberExportPOCO
    {
        /// <summary>
        /// Gets or sets the membership number.
        /// </summary>
        /// <value>
        /// The membership number.
        /// </value>
        [Display(Name = "Članski broj")]
        public int MembershipNumber { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        [Display(Name = "Ime")]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        [Display(Name = "Prezime")]
        [StringLength(60, ErrorMessage = "Maksimalno dozvoljena dužina je 60 znakova.")]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the OIB.
        /// </summary>
        /// <value>
        /// The OIB.
        /// </value>
        public string OIB { get; set; }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>
        /// The address.
        /// </value>
        [Display(Name = "Adresa")]
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the place.
        /// </summary>
        /// <value>
        /// The place.
        /// </value>
        [Display(Name = "Mjesto")]
        public string Place { get; set; }

        /// <summary>
        /// Gets or sets the postal code.
        /// </summary>
        /// <value>
        /// The postal code.
        /// </value>
        [Display(Name = "Poštanski broj")]
        public string PostalCode { get; set; }

        /// <summary>
        /// Gets or sets the birth place.
        /// </summary>
        /// <value>
        /// The birth place.
        /// </value>
        [Display(Name = "Mjesto rođenja")]
        public string BirthPlace { get; set; }

        /// <summary>
        /// Gets or sets the birth date.
        /// </summary>
        /// <value>
        /// The birth date.
        /// </value>
        [DataType(DataType.DateTime)]
        [Display(Name = "Datum rođenja")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy.}", ApplyFormatInEditMode = true)]
        public Nullable<DateTime> BirthDate { get; set; }

        /// <summary>
        /// Gets or sets the phone number.
        /// </summary>
        /// <value>
        /// The phone number.
        /// </value>
        [Display(Name = "Telefon")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the current employment.
        /// </summary>
        /// <value>
        /// The current employment.
        /// </value>
        [Display(Name = "Sadašnje zaposlenje")]
        public string CurrentEmployment { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the membership date.
        /// </summary>
        /// <value>
        /// The membership date.
        /// </value>
        [DataType(DataType.DateTime)]
        [Display(Name = "Datum učlanjenja")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy.}", ApplyFormatInEditMode = true)]
        public DateTime MembershipDate { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        public Status Status { get; set; }
    }
}
