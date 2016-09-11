using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberRegistration.ViewModels
{
    public class CustomerViewModel
    {
        public Guid Id { get; set; }

        [DisplayName("Ime")]
        [StringLength(60, ErrorMessage = "Maksimalno dozvoljena dužina je 60 znakova.")]
        public string FirstName { get; set; }

        [DisplayName("Prezime")]
        [StringLength(60, ErrorMessage = "Maksimalno dozvoljena dužina je 60 znakova.")]
        public string LastName { get; set; }

        [DisplayName("Prezime i ime")]
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        [StringLength(11, ErrorMessage = "Maksimalno dozvoljena dužina je 11 znakova.")]
        public string OIB { get; set; }

        [DisplayName("Adresa")]
        [StringLength(40, ErrorMessage = "Maksimalno dozvoljena dužina je 40 znakova.")]
        public string Address { get; set; }

        [DisplayName("Mjesto")]
        [StringLength(60, ErrorMessage = "Maksimalno dozvoljena dužina je 60 znakova.")]
        public string Place { get; set; }
        
        [DisplayName("Poštanski broj")]
        [StringLength(20, ErrorMessage = "Maksimalno dozvoljena dužina je 20 znakova.")]
        public string PostalCode { get; set; }

        [DisplayName("Država")]
        [StringLength(20, ErrorMessage = "Maksimalno dozvoljena dužina je 20 znakova.")]
        public string Country { get; set; }

        [DisplayName("PDV ID")]
        [StringLength(30, ErrorMessage = "Maksimalno dozvoljena dužina je 30 znakova.")]
        public string PdvId { get; set; }

        public bool IsMember { get; set; }

        // Navigation properties.
        public virtual ICollection<InvoiceViewModel> Invoices { get; set; }
        public virtual ICollection<ActivityViewModel> Activities { get; set; }
    }
}
