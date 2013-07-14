using Application.DTO.ProductModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Manager.Contract.ProductModule
{
    public interface ICategoryManager
    {
        /// <summary>
        /// Get all Category by Page
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageCount"></param>
        /// <returns></returns>
        List<CategoryDTO> FindCategories(int pageIndex, int pageCount);

        /// <summary>
        /// Get Category By ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        CategoryDTO FindCategoryByID(int id);

        /// <summary>
        /// Delete the category by ID
        /// </summary>
        /// <param name="id"></param>
        void DeleteCategory(int id);
    }
}
