using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberRegistration.ViewModels
{
    public class ApplicationUserViewModel : IdentityUser
    {
        public virtual MemberViewModel Member { get; set; }

        public virtual ICollection<MembershipFeeViewModel> MembershipFees { get; set; }
    }
}
