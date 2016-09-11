using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberRegistration.ViewModels
{
    public class InvoiceViewModel
    {
        public Guid Id { get; set; }
 
        [DisplayName("Udruga")]
        public Guid SocietyId { get; set; }

        [DisplayName("Kupac")]
        public Guid CustomerId { get; set; }

        [DisplayName("Broj računa")]
        public int Number { get; set; }

        [DisplayName("Datum plaćanja")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy. HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime PaymentDate { get; set; }

        /// <summary>
        /// Gets or sets the invoice issue date (Date).
        /// </summary>
        /// <value>The invoice issue date.</value>
        [DisplayName("Datum dospijeća")]
        [DataType(DataType.DateTime)]
        public DateTime MaturityDate { get; set; }

        /// <summary>
        /// Gets or sets the payment method.
        /// </summary>
        /// <value>The payment method.</value>
        [DisplayName("Način plaćanja")]
        [StringLength(30, ErrorMessage = "Maksimalno dozvoljena dužina je 30 znakova.")]
        public string PaymentMethod { get; set; }

        [DisplayName("Izdavatelj računa")]
        public Guid InvoiceIssuerId { get; set; }

        [DisplayName("Odgovorna osoba")]
        public Guid ResponsiblePersonId { get; set; }

        // Navigation properties
        public virtual ICollection<MembershipFeeViewModel> MembershipFees { get; set; }
        public virtual InvoiceIssuerViewModel InvoiceIssuer { get; set; }
        public virtual CustomerViewModel Customer { get; set; }
        public virtual ResponsiblePersonViewModel ResponsiblePerson { get; set; }
        public virtual ICollection<InvoiceItemViewModel> InvoiceItems { get; set; }
        public virtual SocietyViewModel Society { get; set; }
    }
}
