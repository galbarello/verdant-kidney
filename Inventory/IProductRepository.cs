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
        ProductEntity Get(Int32 id);
        void Create(ProductEntity product);
        void Update(ProductEntity product);
        void Archive(Int32 id);
    }
}
