using Application.DTO.ProductModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Application.Web.Module.Product.Models.Category
{
    public class CategoryModel
    {
        public int? Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }
        public string CategoryImage { get; set; }
    }

    public static class CategoryModelUtis
    {
        public static CategoryModel ConvertCategoryDTOtoCategoryModel(CategoryDTO categoryDTO)
        {
            var categoryModel = new CategoryModel();
            categoryModel.Id = categoryDTO.CategoryID;
            categoryModel.Code = categoryDTO.CategoryCode;
            categoryModel.Name = categoryDTO.CategoryName;
            categoryModel.CategoryImage = categoryDTO.CategoryImage;
            categoryModel.Order = categoryDTO.Order;

            return categoryModel;
        }

        public static CategoryDTO ConvertCategoryModelToCategoryDTO(CategoryModel categoryModel)
        {
            var categoryDTO = new CategoryDTO()
            {
                CategoryID = categoryModel.Id.HasValue ? categoryModel.Id.Value : int.MaxValue,
                CategoryCode = categoryModel.Code,
                CategoryImage = categoryModel.CategoryImage,
                CategoryName = categoryModel.Name,
                //CategoryLevel = categoryModel.
                Order = categoryModel.Order
            };
            return categoryDTO;

        }
    }
}