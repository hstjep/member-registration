using System.Collections.Generic;

namespace MemberRegistration.Model.Common
{
    public interface IApplicationUser
    {
        #region Properties

        /// <summary>
        /// Gets or sets the member.
        /// </summary>
        /// <value>
        /// The member.
        /// </value>
        IMember Member { get; set; }

        /// <summary>
        /// Gets or sets the membership fees.
        /// </summary>
        /// <value>
        /// The membership fees.
        /// </value>
        ICollection<IMembershipFee> MembershipFees { get; set; }

        #endregion Properties
    }
}
