using Inventory.BusinessEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory
{
    public interface IProductRepository
    {
        #region Methods

        ProductEntity Get(Int32 id);

        void Save(ProductEntity product);

        #endregion
    }
}
