using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberRegistration.Model.Common
{
    public interface ICollectionModel<T> where T : class
    {
        #region Properties

        bool HasNextPageSet
        {
            get;
        }

        /// <summary>
        /// Gets a value indicating whether this instance has previous page set.
        /// </summary>
        /// <value><c>true</c> if this instance has previous page set; otherwise, <c>false</c></value>
        bool HasPreviousPageSet
        {
            get;
        }

        /// <summary>
        /// Gets or sets the result items.
        /// </summary>
        IEnumerable<T> Items { get; set; }

        /// <summary>
        /// Gets or sets the current page number.
        /// </summary>
        int PageNumber { get; set; }

        /// <summary>
        /// Gets or sets the page size.
        /// </summary>
        int PageSize { get; set; }

        /// <summary>
        /// Gets the total number of pages.
        /// </summary>
        int TotalPages
        {
            get;
        }

        /// <summary>
        /// Gets or sets the total number of result items.
        /// </summary>
        int TotalResults { get; set; }

        #endregion Properties
    }
}
