using Inventory.BusinessEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Logic.Abstractions
{
    public interface IProductLogic
    {
        void Create(ProductEntity product);
        void AddStock(CommandStockInput cmdStock);
        void RemoveStock(CommandStockInput cmdStock);
        void Archive(Int32 id);
    }
}
