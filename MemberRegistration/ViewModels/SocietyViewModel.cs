using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberRegistration.ViewModels
{
    public class SocietyViewModel
    {
        public Guid Id { get; set; }

        [DisplayName("Naziv")]
        [StringLength(60, ErrorMessage = "Maksimalno dozvoljena dužina je 60 znakova.")]
        public string Name { get; set; }

        [DisplayName("Kratica")]
        [StringLength(10, ErrorMessage = "Maksimalno dozvoljena dužina je 10 znakova.")]
        public string Acronym { get; set; }

        [DisplayName("Adresa")]
        [StringLength(40, ErrorMessage = "Maksimalno dozvoljena dužina je 40 znakova.")]
        public string Address { get; set; }

        [DisplayName("Mjesto")]
        [StringLength(20, ErrorMessage = "Maksimalno dozvoljena dužina je 20 znakova.")]
        public string Place { get; set; }

        [DisplayName("Poštanski broj")]
        [StringLength(20, ErrorMessage = "Maksimalno dozvoljena dužina je 20 znakova.")]
        public string PostalCode { get; set; }

        [DisplayName("Država")]
        [StringLength(20, ErrorMessage = "Maksimalno dozvoljena dužina je 20 znakova.")]
        public string Country { get; set; }

        [StringLength(11, ErrorMessage = "Maksimalno dozvoljena dužina je 11 znakova.")]
        public string OIB { get; set; }

        [DisplayName("Web stranica")]
        [StringLength(50, ErrorMessage = "Maksimalno dozvoljena dužina je 50 znakova.")]
        public string WebSite { get; set; }

        [DisplayName("E-mail")]
        public string Email { get; set; }

        public byte[] Logo { get; set; }

        public string MimeTypeImage { get; set; }

        [StringLength(70, ErrorMessage = "Maksimalno dozvoljena dužina je 70 znakova.")]
        public string IBAN { get; set; }

        [DisplayName("Lokacija blagajne")]
        [StringLength(30, ErrorMessage = "Maksimalno dozvoljena dužina je 30 znakova.")]
        public string CashRegisterLocation { get; set; }

        [DisplayName("Banka")]
        [StringLength(50, ErrorMessage = "Maksimalno dozvoljena dužina je 50 znakova.")]
        public string Bank { get; set; }

        // Navigation properties
        public virtual ICollection<InvoiceViewModel> Invoices { get; set; }
        public virtual ICollection<MemberViewModel> Members { get; set; }
    }
}
