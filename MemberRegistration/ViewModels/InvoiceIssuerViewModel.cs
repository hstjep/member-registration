using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberRegistration.ViewModels
{
    public class InvoiceIssuerViewModel
    {
        public Guid Id { get; set; }
        
        [DisplayName("Ime i prezime")]
        [StringLength(35, ErrorMessage = "Maksimalno dozvoljena dužina je 35 znakova.")]
        public string FullName { get; set; }

        [DisplayName("Oznaka operatera")]
        [StringLength(20, ErrorMessage = "Maksimalno dozvoljena dužina je 20 znakova.")]
        public string OperatorLabel { get; set; }

        // Navigation properties
        public virtual ICollection<InvoiceViewModel> Invoices { get; set; }
    }
}
