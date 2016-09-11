using MemberRegistration.Model.Common;
using MemberRegistration.Repository.Common;
using MemberRegistration.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberRegistration.Service
{
    public class ProductService : IProductService
    {

        #region Properties

        protected IProductRepository Repository { get; private set; }

        #endregion Properties


        #region Constructors

        public ProductService(IProductRepository repository)
        {
            this.Repository = repository;
        }

        #endregion Constructors


        #region Methods

        /// <summary>
        /// Gets all products asynchronously.
        /// </summary>
        /// <returns>
        /// The products.
        /// </returns>
        public Task<List<IProduct>> GetAsync()
        {
            return Repository.GetAsync();
        }

        /// <summary>
        /// Gets the product asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// The product.
        /// </returns>
        public Task<IProduct> GetAsync(Guid id)
        {
            return Repository.GetAsync(id);
        }

        /// <summary>
        /// Adds the product asynchronously.
        /// </summary>
        /// <param name="product">The product.</param>
        /// <returns></returns>
        public Task<int> AddAsync(IProduct product)
        {
            return Repository.AddAsync(product);
        }

        /// <summary>
        /// Updates the product asynchronously.
        /// </summary>
        /// <param name="product">The product.</param>
        /// <returns></returns>
        public Task<int> UpdateAsync(IProduct product)
        {
            return Repository.UpdateAsync(product);
        }

        /// <summary>
        /// Removes the product by id asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public Task<int> DeleteAsync(Guid id)
        {
            return Repository.DeleteAsync(id);
        }

        /// <summary>
        /// Gets the product asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// The product.
        /// </returns>
        public Task<IProduct> GetWhereAsync(Guid id)
        {
            return Repository.GetWhereAsync(id);
        }

        /// <summary>
        /// Gets the product.
        /// </summary>
        /// <returns>The product.</returns>
        public List<IProduct> Get()
        {
            return Repository.Get();
        }

        #endregion Methods
    }
}
