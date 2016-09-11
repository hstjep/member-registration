using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberRegistration.ViewModels
{
    public class ResponsiblePersonViewModel
    {
        public Guid Id { get; set; }
        
        [DisplayName("Ime i prezime")]
        [StringLength(35, ErrorMessage = "Maksimalno dozvoljena dužina je 35 znakova.")]
        public string FullName { get; set; }

        [DisplayName("Pozicija")]
        [StringLength(30, ErrorMessage = "Maksimalno dozvoljena dužina je 30 znakova.")]
        public string Title { get; set; }

        // Navigation properties
        public virtual ICollection<InvoiceViewModel> Invoices { get; set; }
    }
}
