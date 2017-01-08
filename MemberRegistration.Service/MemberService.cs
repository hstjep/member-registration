using ClosedXML.Excel;
using MemberRegistration.Common.Filters;
using MemberRegistration.Model.Common;
using MemberRegistration.Repository.Common;
using MemberRegistration.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MemberRegistration.Model;

namespace MemberRegistration.Service
{
    public class MemberService : IMemberService
    {
        #region Properties

        /// <summary>
        /// Gets the member repository.
        /// </summary>
        /// <value>
        /// The member repository.
        /// </value>
        protected IMemberRepository Repository { get; private set; }

        #endregion Properties


        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MemberService"/> class.
        /// </summary>
        /// <param name="repository">The member repository.</param>
        public MemberService(IMemberRepository repository)
        {
            this.Repository = repository;
        }

        #endregion Constructors


        #region Methods

        /// <summary>
        /// Asynchronously gets the members.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns>
        /// The members.
        /// </returns>
        public Task<IEnumerable<IMember>> GetAsync(IFilter filter = null)
        {
            return Repository.GetAsync(filter);
        }

        /// <summary>
        /// Asynchronously gets the member by id.
        /// </summary>
        /// <param name="id">The member identifier.</param>
        /// <returns>
        /// The member.
        /// </returns>
        public Task<IMember> GetAsync(Guid id)
        {
            return Repository.GetAsync(id);
        }

        /// <summary>
        /// Asynchronously gets the current member.
        /// </summary>
        /// <returns>
        /// The current member.
        /// </returns>
        public Task<IMember> GetCurrentMemberAsync()
        {
            return Repository.GetCurrentMemberAsync();
        }

        /// <summary>
        /// Asynchronously updates the member.
        /// </summary>
        /// <param name="member">The member</param>
        /// <returns></returns>
        public async Task<int> UpdateAsync(IMember member) 
        {
            return await Repository.UpdateAsync(member); 
        }

        /// <summary>
        /// Gets the last membership number and increases it by one.
        /// </summary>
        /// <returns>
        /// The invoice number.
        /// </returns>
        public async Task<int> GetMembershipNumberAsync()
        {
            return await Repository.GetMembershipNumberAsync();
        }

        /// <summary>
        /// Asynchronously gets the workbook containing the members data.
        /// </summary>
        /// <returns></returns>
        public async Task<XLWorkbook> GetWorkbookAsync()
        {
            var wb = new XLWorkbook();
            var ws = wb.Worksheets.Add("Clanovi");
            var data = Mapper.Map<IEnumerable<MemberExportPOCO>>(await Repository.GetCurrentMembersAsync());
            ws.FirstCell().InsertTable(data);
            ws.Columns().AdjustToContents();
            int totalColumns = typeof(MemberExportPOCO).GetProperties().Length;
            var dateOfBirthPosition = ws.Cells().Where(c => c.Value.ToString() == "Datum rođenja").FirstOrDefault().Address.ColumnNumber;
            var dates = ws.Range(ws.Cell(1, dateOfBirthPosition), ws.Cell(data.Count() + 1, dateOfBirthPosition));

            var membershipDatePosition = ws.Cells().Where(c => c.Value.ToString() == "Datum učlanjenja").FirstOrDefault().Address.ColumnNumber;
            var membershipDates = ws.Range(ws.Cell(1, membershipDatePosition), ws.Cell(data.Count() + 1, membershipDatePosition));

            var hrow = ws.Range(ws.FirstCell(), ws.Cell(1, totalColumns));
            ws.Style.Alignment.WrapText = true;
            dates.Style.DateFormat.Format = "DD.MM.YYYY.";
            membershipDates.Style.DateFormat.Format = "DD.MM.YYYY.";
            ws.Tables.FirstOrDefault().ShowAutoFilter = false;

            return wb;
        }

        #endregion Methods
    }
}
