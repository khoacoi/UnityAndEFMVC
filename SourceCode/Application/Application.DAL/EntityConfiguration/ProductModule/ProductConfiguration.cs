using Application.Domain.Product.ProductAggregate;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DAL.EntityConfiguration.ProductModule
{
    public class ProductConfiguration : EntityTypeConfiguration<Product>
    {
        public ProductConfiguration()
        {
            this.HasKey(x => x.ID);
            this.Property(x => x.OurCost).IsRequired();
            this.Property(x => x.ProductImage);
            this.Property(x => x.SalePrice).IsRequired();
            this.Property(x => x.SKU).IsRequired();
        }
    }
}
