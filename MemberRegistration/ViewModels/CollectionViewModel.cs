using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MemberRegistration.ViewModels
{
    public class CollectionViewModel<T> where T : class
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of <see cref="CollectionViewModel" /> class.
        /// </summary>
        public CollectionViewModel()
        {
            Items = new List<T>();
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets a value indicating whether this instance has next page set.
        /// </summary>
        /// <value><c>true</c> if this instance has next page set; otherwise, <c>false</c></value>
        public bool HasNextPageSet
        {
            get
            {
                return PageNumber < TotalPages;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance has previous page set.
        /// </summary>
        /// <value><c>true</c> if this instance has previous page set; otherwise, <c>false</c></value>
        public bool HasPreviousPageSet
        {
            get
            {
                return PageNumber > 1;
            }
        }

        /// <summary>
        /// Gets or sets the result items.
        /// </summary>
        public List<T> Items { get; set; }

        /// <summary>
        /// Gets or sets the current page number.
        /// </summary>
        public int PageNumber { get; set; }

        /// <summary>
        /// Gets or sets the page size.
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// Gets the total number of pages.
        /// </summary>
        public int TotalPages
        {
            get
            {
                return TotalResults > PageSize && PageSize > 0 ? Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(TotalResults) / Convert.ToDecimal(PageSize))) : 1;
            }
        }

        /// <summary>
        /// Gets or sets the total number of result items.
        /// </summary>
        public int TotalResults { get; set; }

        #endregion Properties
    }
}