using Application.Common;
using Application.Domain.Product.CategoryAggregate;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Domain.Product.ProductAggregate
{
    public class CategoryProductLink : Entity, IValidatableObject
    {
        #region Properties
        [Key]
        public int ID { get; set; }
        //public int ProductID { get; set; }
        //public int CategoryID { get; set; }
        public virtual Product Product { get; set; }
        public virtual Category Category { get; set; }
        #endregion

        #region IValidatableObject implementation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
