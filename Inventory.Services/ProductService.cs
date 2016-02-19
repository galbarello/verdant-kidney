using Inventory.BusinessEntity;
using Inventory.Logic.Abstractions;
using Inventory.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Services
{
    public class ProductService : IProductService
    {
        #region Members

        private IProductLogic _productLogic;

        #endregion

        #region Constructor

        public ProductService(IProductLogic productLogic)
        {
            this._productLogic = productLogic;
        }

        #endregion

        #region Methods

        public void Create(ProductEntity product)
        {
            this._productLogic.Create(product);
        }

        public void AddStock(CommandStockInput cmdStock)
        {
            this._productLogic.AddStock(cmdStock);
        }

        public void RemoveStock(CommandStockInput cmdStock)
        {
            this._productLogic.RemoveStock(cmdStock);
        }

        public void Archive(Int32 id)
        {
            this._productLogic.Archive(id);
        }

        #endregion
    }
}
