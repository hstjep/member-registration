using MemberRegistration.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MemberRegistration.ViewModels
{
    public class ActivityViewModel
    {
        public Guid Id { get; set; }

        [DisplayName("Ime i prezime")]
        public Guid CustomerId { get; set; }

        [DisplayName("Naziv")]
        [StringLength(60, ErrorMessage = "Maksimalno dozvoljena dužina je 60 znakova.")]
        public string Name { get; set; }

        [DisplayName("Opis")]
        [StringLength(200, ErrorMessage = "Maksimalno dozvoljena dužina je 200 znakova.")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [DisplayName("Tip aktivnosti")]
        public ActivityType ActivityType { get; set; }

        [DisplayName("Broj sati")]
        public int NumberOfHours { get; set; }

        [DisplayName("Od")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateFrom { get; set; }

        [DisplayName("Do")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DateTo { get; set; }

        public virtual CustomerViewModel Customer { get; set; }
    }
}