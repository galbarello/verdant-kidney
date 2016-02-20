using Inventory.BusinessEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.ProviderBase;
using System.Data.Entity;

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
        public void Create(ProductEntity product)
        {
            using (EFContext context = new EFContext())
            {
                context.Products.Add(product);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Update stock and state from a product
        /// </summary>
        /// <param name="product"></param>
        public void Update(ProductEntity product)
        {
            using (EFContext context = new EFContext())
            {
                context.Products.Attach(product);
                context.Entry(product).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Archive a product
        /// </summary>
        /// <param name="id"></param>
        public void Archive(Int32 id)
        {
            using (EFContext context = new EFContext())
            {
                ProductEntity product = context.Products.FirstOrDefault(p => p.Id == id);
                product.IsActive = false;
                context.SaveChanges();
            }
        }

        #endregion


    }
}
