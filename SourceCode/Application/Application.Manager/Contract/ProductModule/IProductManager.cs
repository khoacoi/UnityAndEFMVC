using Application.DTO.ProductModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Manager.Contract.ProductModule
{
    public interface IProductManager
    {
        /// <summary>
        /// Get all Category by Page
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageCount"></param>
        /// <returns></returns>
        List<ProductDTO> FindProducts(int pageIndex, int pageCount);

        /// <summary>
        /// Get Category By ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        CategoryDTO FindProductByID(int id);

        /// <summary>
        /// Delete the category by ID
        /// </summary>
        /// <param name="id"></param>
        void DeleteProduct(int id);

        /// <summary>
        /// Add New Category 
        /// </summary>
        /// <param name="categoryDTO"></param>
        void SaveProductInformation(CategoryDTO categoryDTO);

        /// <summary>
        /// Update existing Category
        /// </summary>
        /// <param name="id"></param>
        /// <param name="categoryDTO"></param>
        void UpdateProductInformation(int id, CategoryDTO categoryDTO);
    }
}
