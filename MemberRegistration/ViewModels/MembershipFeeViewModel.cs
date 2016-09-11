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
    public class MembershipFeeViewModel
    {

        public Guid Id { get; set; }

        [DisplayName("Član")]
        public Guid MemberId { get; set; }

        [DisplayName("Račun")]
        public Guid InvoiceId { get; set; }

        [DisplayName("Godine")]
        public int Year { get; set; }

        [DisplayName("Datum plaćanja")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy.}", ApplyFormatInEditMode = true)]
        public DateTime PaymentDate { get; set; }

        [DisplayName("Datum isteka")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy.}", ApplyFormatInEditMode = true)]
        public DateTime ExpirationDate { get; set; }

        [DisplayName("Plaćeno (Da/Ne)")]
        public Nullable<PaymentStatus> PaymentStatus { get; set; }

        [DisplayName("Iznos")]
        public decimal Amount { get; set; }

        // Navigation properties
        public virtual ApplicationUserViewModel User { get; set; }
        public virtual MemberViewModel Member { get; set; }
        public virtual InvoiceViewModel Invoice { get; set; }
    }
}
