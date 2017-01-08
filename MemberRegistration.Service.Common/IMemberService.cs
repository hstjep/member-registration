using ClosedXML.Excel;
using MemberRegistration.Common.Filters;
using MemberRegistration.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberRegistration.Service.Common
{
    public interface IMemberService
    {
        #region Methods

        /// <summary>
        /// Asynchronously gets the members.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns>The members.</returns>
        Task<IEnumerable<IMember>> GetAsync(IFilter filter = null);

        /// <summary>
        /// Asynchronously gets the member by id.
        /// </summary>
        /// <param name="id">The member identifier.</param>
        /// <returns>The member.</returns>
        Task<IMember> GetAsync(Guid id);

        /// <summary>
        /// Asynchronously gets the current member.
        /// </summary>
        /// <returns>The current member.</returns>
        Task<IMember> GetCurrentMemberAsync();

        /// <summary>
        /// Asynchronously updates the member.
        /// </summary>
        /// <param name="member">The member</param>
        /// <returns></returns>
        Task<int> UpdateAsync(IMember member);

        /// <summary>
        /// Gets the last membership number and increases it by one.
        /// </summary>
        /// <returns>The invoice number.</returns>
        Task<int> GetMembershipNumberAsync();

        /// <summary>
        /// Asynchronously gets the workbook containing the members data.
        /// </summary>
        /// <returns></returns>
        Task<XLWorkbook> GetWorkbookAsync();

        #endregion Methods
    }
}
