using Inventory.BusinessEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Repositories
{
    public class ProductRepository : IProductRepository
    {
        #region Methods

        /// <summary>
        /// Return a product by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ProductEntity Get(Int32 id)
        {
            using (EFContext context = new EFContext())
            {
                ProductEntity query = context.Products.FirstOrDefault(p => p.Id == id);
                return query;
            }
        }

        /// <summary>
        /// Persist a product
        /// </summary>
        /// <param name="product"></param>
        public void Save(ProductEntity product)
        {
            using (EFContext context = new EFContext())
            {
                context.Products.Add(product);
                context.SaveChanges();
            }
        }

        #endregion
    }
}
