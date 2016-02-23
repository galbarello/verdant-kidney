using Inventory.BusinessEntity;
using Inventory.Logic.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Inventory.Logic
{
    public class ProductLogic : IProductLogic
    {
        #region Members

        private IProductRepository _productRepository;

        #endregion

        #region Constructor

        public ProductLogic(IProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Persist the product 
        /// </summary>
        /// <param name="product"></param>
        public void Create(ProductEntity product)
        {
            this._productRepository.Create(product);
        }

        /// <summary>
        /// Add stock from a product
        /// </summary>
        /// <param name="cmdStock"></param>
        public void AddStock(CommandStockInput cmdStock)
        {
            ProductEntity product = this._productRepository.Get(cmdStock.Id);
            product.Quantity += cmdStock.Quantity;
            this._productRepository.Update(product);
        }

        /// <summary>
        /// Remove stock from a product
        /// </summary>
        /// <param name="cmdStock"></param>
        public void RemoveStock(CommandStockInput cmdStock)
        {
            ProductEntity product = this._productRepository.Get(cmdStock.Id);
            product.Quantity -= cmdStock.Quantity;
            this._productRepository.Update(product);
        }

        /// <summary>
        /// Archive a Product
        /// </summary>
        /// <param name="id"></param>
        public void Archive(Int32 id)
        {
            ProductEntity product = this._productRepository.Get(id);
            product.IsActive = false;
            this._productRepository.Update(product);
        }

        #endregion
    }
}
