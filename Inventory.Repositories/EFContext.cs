using Inventory.BusinessEntity;
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

        public EFContext()
        {
            
        }

        #endregion

        #region Methods

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Conventions.Remove<StoreGeneratedIdentityKeyConvention>();
        }

        #endregion

    }
}
