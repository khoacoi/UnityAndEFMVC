using Application.Common;
using Application.Domain.Product.ProductAggregate;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Domain.Product.CategoryAggregate
{
    public class Category : Entity, IValidatableObject
    {
        #region Properties
        [Key]
        public int ID { get; set; }
        public string CategoryCode { get; set; }
        public string CategoryName { get; set; }
        public int Order { get; set; }
        public string CategoryImage { get; set; }
        public int CategoryLevel { get; set; }
        public virtual Category ParentCategory { get; set; }
        public virtual ICollection<CategoryProductLink> CategoryProductLinks { get; set; }
        #endregion Properties

        #region Public Functions
        #endregion Public Functions

        #region IValidatableObject Implementation
        /// <summary>
        /// This will validate entity for all  the conditions
        /// </summary>
        /// <param name="validationContext"></param>
        /// <returns></returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validationResults = new List<ValidationResult>();
            return validationResults;
        }
        #endregion IValidatableObject Implementation
    }
}
