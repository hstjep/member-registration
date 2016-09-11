using MemberRegistration.DAL;
using MemberRegistration.Model.Common;
using MemberRegistration.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MemberRegistration.Model;
using System.Data.Entity;

namespace MemberRegistration.Repository
{
    public class ProductRepository : IProductRepository
    {
        #region Properties

        protected IRepository Repository { get; private set; }

        #endregion Properties


        #region Constructors

        public ProductRepository(IRepository repository)
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
        public virtual async Task<List<IProduct>> GetAsync()
        {
            return Mapper.Map<List<IProduct>>(await Repository.GetAsync<Product>());
        }

        /// <summary>
        /// Gets the product asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// The product.
        /// </returns>
        public virtual async Task<IProduct> GetAsync(Guid id)
        {
            return Mapper.Map<ProductPOCO>(await Repository.GetByIDAsync<Product>(id));
        }

        /// <summary>
        /// Gets the product asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// The product.
        /// </returns>
        public virtual async Task<IProduct> GetWhereAsync(Guid id)
        {
            return Mapper.Map<ProductPOCO>(await Repository.GetWhere<Product>().Where(p => p.Id == id).FirstOrDefaultAsync());
        }

        /// <summary>
        /// Gets the product.
        /// </summary>
        /// <returns>
        /// The product.
        /// </returns>
        public virtual List<IProduct> Get()
        {
            return Mapper.Map<List<IProduct>>(Repository.GetWhere<Product>());           
        }

        /// <summary>
        /// Adds the product asynchronously.
        /// </summary>
        /// <param name="product">The product.</param>
        /// <returns></returns>
        public virtual Task<int> AddAsync(IProduct product)
        {
            return Repository.AddAsync<DAL.Product>(Mapper.Map<DAL.Product>(product));
        }

        /// <summary>
        /// Updates the product asynchronously.
        /// </summary>
        /// <param name="product">The product.</param>
        /// <returns></returns>
        public virtual Task<int> UpdateAsync(IProduct product)
        {
            return Repository.UpdateAsync<DAL.Product>(Mapper.Map<DAL.Product>(product));
        }

        /// <summary>
        /// Removes the product by id asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public virtual Task<int> DeleteAsync(Guid id)
        {
            return Repository.DeleteAsync<DAL.Product>(id);
        }

        #endregion Methods
    }
}
