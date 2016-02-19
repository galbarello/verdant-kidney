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
        public void Create(ProductEntity product)
        {
            using (EFContext context = new EFContext())
            {
                context.Products.Add(product);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Update stock from a product
        /// </summary>
        /// <param name="cmdStock"></param>
        public void AddStock(CommandStockInput cmdStock)
        {
            using (EFContext context = new EFContext())
            {
                ProductEntity product = context.Products.FirstOrDefault(p => p.Id == cmdStock.Id);
                product.Quantity += cmdStock.Quantity;
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Update stock from a product
        /// </summary>
        /// <param name="cmdStock"></param>
        public void RemoveStock(CommandStockInput cmdStock)
        {
            using (EFContext context = new EFContext())
            {
                ProductEntity product = context.Products.FirstOrDefault(p => p.Id == cmdStock.Id);
                product.Quantity -= cmdStock.Quantity;
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
