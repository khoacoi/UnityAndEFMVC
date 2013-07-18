using Application.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Domain.Product.ProductAggregate
{
    public class Product : Entity, IValidatableObject
    {
        #region Properties
        [Key]
        public int ID { get; set; }
        public string SKU { get; set; }
        public decimal OurCost { get; set; }
        public decimal SalePrice { get; set; }
        public string ProductImage { get; set; }
        public virtual ICollection<CategoryProductLink> CategoryProductLinks { get; set; }
        #endregion


        #region IValidatableObject implementation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
