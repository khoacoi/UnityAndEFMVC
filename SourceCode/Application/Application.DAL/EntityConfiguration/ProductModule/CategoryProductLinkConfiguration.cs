using Application.Domain.Product.ProductAggregate;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DAL.EntityConfiguration.ProductModule
{
    public class CategoryProductLinkConfiguration : EntityTypeConfiguration<CategoryProductLink>
    {
        public CategoryProductLinkConfiguration()
        {
            this.HasRequired(cpl => cpl.Category)
                .WithMany(c => c.CategoryProductLinks)
                //.Map( m=> m.MapKey("CategoryID"))
                //.HasForeignKey(cpl => cpl.CategoryID)
                .WillCascadeOnDelete(false);

            this.HasRequired(cpl => cpl.Product)
                .WithMany(c => c.CategoryProductLinks)
                //.HasForeignKey(cpl => cpl.ProductID)
                .WillCascadeOnDelete(false);
        }
    }
}
