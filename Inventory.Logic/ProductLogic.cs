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
            this._productRepository.AddStock(cmdStock);
        }

        /// <summary>
        /// Remove stock from a product
        /// </summary>
        /// <param name="cmdStock"></param>
        public void RemoveStock(CommandStockInput cmdStock)
        {
            this._productRepository.RemoveStock(cmdStock);
        }

        /// <summary>
        /// Archive a Product
        /// </summary>
        /// <param name="id"></param>
        public void Archive(Int32 id)
        {
            this._productRepository.Archive(id);
        }

        #endregion
       
    }
}
