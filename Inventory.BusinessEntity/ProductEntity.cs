using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.BusinessEntity
{
    public class ProductEntity
    {
        #region Properties

        public Int32 Id { get; set; }

        public String Description { get; set; }

        public Decimal Price { get; set; }

        #endregion
    }
}
