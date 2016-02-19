using Inventory.BusinessEntity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Repositories.Mapping
{
    public class ProductMapper : EntityTypeConfiguration<ProductEntity>
    {
        public ProductMapper()
        {
            HasKey(p => p.Id);

            this.Property(p => p.Id).HasColumnName("Id");
            this.Property(p => p.Code).HasColumnName("Code");
            this.Property(p => p.Description).HasColumnName("Description");
            this.Property(p => p.Price).HasColumnName("Price");
            this.Property(p => p.Quantity).HasColumnName("Quantity");
            this.Property(p => p.IsActive).HasColumnName("IsActive");
            this.ToTable("Product");
        }
    }
}
