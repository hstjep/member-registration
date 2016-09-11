using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MemberRegistration.Infrastructure.Attributes
{
    public class CustomRequired : RequiredAttribute
    {
        public CustomRequired()
        {
            this.ErrorMessage = "Polje {0} je obvezno.";
        }
    }
}
