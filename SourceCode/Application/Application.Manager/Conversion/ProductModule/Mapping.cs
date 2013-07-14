using Application.Domain.Product.CategoryAggregate;
using Application.DTO.ProductModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Manager.Conversion.ProductModule
{
    public static class Mapping
    {
        public static CategoryDTO CategoryToCategoryDTO(Category category)
        {
            var categoryDTO = new CategoryDTO();

            categoryDTO.CategoryID = category.CategoryID;
            categoryDTO.CategoryName = category.CategoryName;
            categoryDTO.CategoryCode = category.CategoryCode;
            categoryDTO.Order = category.Order;
            categoryDTO.CategoryLevel = category.CategoryLevel;

            return categoryDTO;
        }
    }
}
