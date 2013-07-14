using Application.Domain.Product.CategoryAggregate;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DAL.EntityConfiguration.ProductModule
{
    public class CategoryConfiguration : EntityTypeConfiguration<Category>
    {
        public CategoryConfiguration()
        {
            this.HasKey(a => a.CategoryID);
            this.Property(a => a.CategoryCode).HasMaxLength(100).IsRequired();
            this.Property(a => a.CategoryName).HasMaxLength(200).IsRequired();
            this.Property(c => c.Order).IsRequired();
            this.Property(a => a.CategoryLevel).IsRequired();
            this.HasOptional(c => c.ParentCategory);
            //configure table map
            this.ToTable("Category");
        }
    }
}
