using Inventory.BusinessEntity;
using Inventory.Repositories.Mapping;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Repositories
{
    public class EFContext : DbContext
    {

        #region Properties

        public DbSet<ProductEntity> Products { get; set; }

        #endregion

        #region Constructor

        static EFContext()
        {
            Database.SetInitializer<EFContext>(null);
        }


        public EFContext()
            : base("InventoryDb")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        #endregion

        #region Methods

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ProductMapper());
        }

        #endregion

    }
}
