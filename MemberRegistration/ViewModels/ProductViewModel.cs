using MemberRegistration.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberRegistration.ViewModels
{
    public class ProductViewModel
    {
        public Guid Id { get; set; }

        [DisplayName("Naziv")]
        [StringLength(30, ErrorMessage = "Maksimalno dozvoljena dužina je 30 znakova.")]
        public string Name { get; set; }

        [DisplayName("Mjerna jedinica")]
        public MeasuringUnit MeasuringUnit { get; set; }

        [DisplayName("Cijena (kn)")]
        public decimal Price { get; set; }

        // Navigation properties
        public virtual ICollection<InvoiceItemViewModel> InvoiceItems { get; set; }
    }
}
