using MemberRegistration.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberRegistration.ViewModels
{
    public class InvoiceItemViewModel
    {
        public Guid Id { get; set; }

        [DisplayName("Račun")]
        public Guid InvoiceId { get; set; }

        [DisplayName("Proizvod")]
        public Guid ProductId { get; set; }

        [DisplayName("Godina")]
        public int Year { get; set; }
        
        [DisplayName("Član")]
        public Guid MemberId { get; set; }

        [DisplayName("Valutna jedinica")]
        [DefaultValue(1)]
        public CurrencyUnit CurrencyUnit { get; set; }

        [DisplayName("Količina")]
        public int Quantity { get; set; }

        [DisplayName("Vrijednost")]
        public decimal Value { get; set; }

        // Navigation properties
        public virtual MemberViewModel Member { get; set; }
        public virtual ProductViewModel Product { get; set; }
        public virtual InvoiceViewModel Invoice { get; set; }
    }
}
