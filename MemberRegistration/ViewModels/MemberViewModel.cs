using MemberRegistration.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MemberRegistration.ViewModels
{
    public class MemberViewModel : CustomerViewModel
    {
        [DisplayName("Članski broj")]
        public int MembershipNumber { get; set; }

        [DisplayName("Mjesto rođenja")]
        [StringLength(20, ErrorMessage = "Maksimalno dozvoljena dužina je 20 znakova.")]
        public string BirthPlace { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayName("Datum rođenja")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy.}", ApplyFormatInEditMode = true)]
        public Nullable<DateTime> BirthDate { get; set; }

        [DisplayName("Telefon")]
        [StringLength(30, ErrorMessage = "Maksimalno dozvoljena dužina je 30 znakova.")]
        public string PhoneNumber { get; set; }

        [DisplayName("Sadašnje zaposlenje")]
        [StringLength(200, ErrorMessage = "Maksimalno dozvoljena dužina je 200 znakova.")]
        public string CurrentEmployment { get; set; }

        [Required]
        [DisplayName("E-mail")]        
        [EmailAddress(ErrorMessage = "E-mail nije validan.")]
        [StringLength(100, ErrorMessage = "Maksimalno dozvoljena dužina je 100 znakova.")]
        public string Email { get; set; }

        [DisplayName("Web stranica")]
        [StringLength(50, ErrorMessage = "Maksimalno dozvoljena dužina je 50 znakova.")]
        public string WebSite { get; set; }

        [DisplayName("Područje interesa")]
        [StringLength(140, ErrorMessage = "Maksimalno dozvoljena dužina je 140 znakova.")]
        public string AreaOfInterest { get; set; }
 
        [DataType(DataType.DateTime)]
        [DisplayName("Datum učlanjenja")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy.}", ApplyFormatInEditMode=true)]
        public DateTime MembershipDate { get; set; }

        public Status Status { get; set; }

        public bool IsRemoved { get; set; }

        // Navigation properties
        public virtual ApplicationUserViewModel User { get; set; }
        public virtual SocietyViewModel Society { get; set; }
        public virtual ICollection<MembershipFeeViewModel> MembershipFees { get; set; }
        public virtual ICollection<InvoiceItemViewModel> InvoiceItems { get; set; }
    }
}