using MemberRegistration.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberRegistration.Service.Common
{
    public interface IProductService
    {
        #region Methods

        /// <summary>
        /// Gets all products asynchronously.
        /// </summary>
        /// <returns>The products.</returns>
        Task<List<IProduct>> GetAsync();

        /// <summary>
        /// Gets the product asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The product.</returns>
        Task<IProduct> GetAsync(Guid id);

        /// <summary>
        /// Adds the product asynchronously.
        /// </summary>
        /// <param name="product">The product.</param>
        /// <returns></returns>
        Task<int> AddAsync(IProduct product);

        /// <summary>
        /// Updates the product asynchronously.
        /// </summary>
        /// <param name="product">The product.</param>
        /// <returns></returns>
        Task<int> UpdateAsync(IProduct product);

        /// <summary>
        /// Removes the product by id asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<int> DeleteAsync(Guid id);

        /// <summary>
        /// Gets the product asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The product.</returns>
        Task<IProduct> GetWhereAsync(Guid id);

        /// <summary>
        /// Gets the product.
        /// </summary>
        /// <returns>The product.</returns>
        List<IProduct> Get();

        #endregion Methods
    }
}
