using Application.Domain.Product.CategoryAggregate;
using Application.Domain.Product.ProductAggregate;
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

            categoryDTO.CategoryID = category.ID;
            categoryDTO.CategoryName = category.CategoryName;
            categoryDTO.CategoryCode = category.CategoryCode;
            categoryDTO.Order = category.Order;
            categoryDTO.CategoryLevel = category.CategoryLevel;
            categoryDTO.CategoryImage = category.CategoryImage;

            return categoryDTO;
        }

        public static ProductDTO ProductToProductDTO(Product product)
        {
            var productDTO = new ProductDTO()
            {
                ID = product.ID,
                OurCost = product.OurCost,
                SalePrice = product.SalePrice,
                ProductImage = product.ProductImage,
                SKU = product.SKU
            };
            if (product.CategoryProductLinks != null && product.CategoryProductLinks.Any())
            {
                foreach (var categoryProductLink in product.CategoryProductLinks)
                {
                    productDTO.CategoryProductLinks.Add(new CategoryProductLinkDTO() {
                        ID = categoryProductLink.ID,
                        Product = productDTO,
                        Category = CategoryToCategoryDTO(categoryProductLink.Category)
                    });
                }
            }
            return productDTO;

        }
    }
}
