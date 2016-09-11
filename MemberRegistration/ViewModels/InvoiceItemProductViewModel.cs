using MemberRegistration.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MemberRegistration.ViewModels
{
    public class InvoiceItemProductViewModel
    {       
        public Guid InvoiceItemId { get; set; }

        [DisplayName("Proizvod")]
        public string ProductName { get; set; }

        public int Year { get; set; }

        [DisplayName("Član")]
        [Required(AllowEmptyStrings = true)]
        public string MemberFirstName { get; set; }
        public string MemberLastName { get; set; }

        [DisplayName("Količina")]
        public int Quantity { get; set; }

        [DisplayName("Cijena")]
        public decimal Price { get; set; }

        [DisplayName("Vrijednost")]
        public decimal Amount { get; set; }

        public MeasuringUnit MeasuringUnit { get; set; }

        //public CurrencyUnit CurrencyUnit { get; set; }
    }
}