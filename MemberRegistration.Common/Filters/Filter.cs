using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberRegistration.Common.Filters
{
    public class Filter : IFilter
    {
        #region Properties 

        /// <summary>
        /// Gets or sets the search string.
        /// </summary>
        /// <value>The search string.</value>
        public string SearchString { get; set; }

        /// <summary>
        /// Gets or sets the sort order.
        /// </summary>
        /// <value>The sort order.</value>
        public string SortOrder { get; set; }

        /// <summary>
        /// Gets or sets the page number.
        /// </summary>
        /// <value>The page number.</value>
        public int PageNumber { get; set; }

        /// <summary>
        /// Gets or sets the page size.
        /// </summary>
        /// <value>The page size.</value>
        public int PageSize { get; set; }

        /// <summary>
        /// Gets or sets the current user identifier.
        /// </summary>
        /// <value>
        /// The current user identifier.
        /// </value>
        public Guid CurrentUserId { get; set; }

        #endregion Properties


        #region Variables

        public int DefaultPageSize = 15;

        #endregion Variables


        #region Constructors

        /// <summary>
        /// Initializes a new instance of <see cref="Filter" /> class.
        /// </summary>
        /// <param name="searchTerm">The search term.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        public Filter(string searchTerm, int pageNumber, int pageSize)
        {
            SearchString = searchTerm;
            SetPageNumberAndSize(pageNumber, pageSize);
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Sets the default values for current page number and page size.
        /// </summary>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        private void SetPageNumberAndSize(int pageNumber = 1, int pageSize = 0)
        {
            PageNumber = (pageNumber > 0) ? pageNumber : 1;
            PageSize = (pageSize > 0 && pageSize <= DefaultPageSize) ? pageSize : DefaultPageSize;
        }

        #endregion Methods
    }
}
