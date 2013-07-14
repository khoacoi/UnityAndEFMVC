using Application.Common.Localization;
using Application.Common.Logging;
using Application.Domain.Product.CategoryAggregate;
using Application.DTO.ProductModule;
using Application.Manager.Contract.ProductModule;
using Application.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Manager.Implementation.ProductModule
{
    public class CategoryManager : ICategoryManager
    {
        #region Global Declaration
        ICategoryRepository _categoryRepository;
        #endregion 

        #region Constructors
        public CategoryManager(ICategoryRepository categoryRespository)
        {
            _categoryRepository = categoryRespository;
        }
        #endregion

        #region ICategoryManager Implementations
        public List<DTO.ProductModule.CategoryDTO> FindCategories(int pageIndex, int pageCount)
        {
            if (pageIndex < 0 || pageCount <= 0)
                throw new AggregateException(LocalizerFactory.CreateLocalizer().GetString("warning_InvalidArgumentForFindProfiles", typeof(Application.Resources.ApplicationErrors)));
            var categories = _categoryRepository.GetPaged<int>(pageIndex, pageCount, c => c.Order, false);

            if (categories != null && categories.Any())
            {
                var categoryDTOes = new List<CategoryDTO>();
                foreach(var category in categories)
                {
                    categoryDTOes.Add(Conversion.ProductModule.Mapping.CategoryToCategoryDTO(category));
                }
                return categoryDTOes;
            }
            return new List<CategoryDTO>();
        }

        public DTO.ProductModule.CategoryDTO FindCategoryByID(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteCategory(int id)
        {
            var category = _categoryRepository.Get(id);
            if (category == null)
            {
                LoggerFactory.CreateLog().LogWarning(LocalizerFactory.CreateLocalizer().GetString("warning_CannotRemoveNonExistingCategory", typeof(ApplicationErrors)));
            }

            _categoryRepository.Remove(category);
            _categoryRepository.UnitOfWork.Commit();
        }
        #endregion
    }
}
