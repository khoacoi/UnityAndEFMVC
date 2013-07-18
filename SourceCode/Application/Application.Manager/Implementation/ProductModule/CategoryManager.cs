using Application.Common;
using Application.Common.Localization;
using Application.Common.Logging;
using Application.Common.Validator;
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
                throw new AggregateException(LocalizerFactory.CreateLocalizer().GetString("warning_InvalidArgumentForFindCategory", typeof(Application.Resources.ApplicationErrors)));
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
            var category = _categoryRepository.Get(id);
            if (category == null)
            {
                LoggerFactory.CreateLog().LogWarning(LocalizerFactory.CreateLocalizer().GetString("warning_CannotRemoveNonExistingCategory", typeof(ApplicationErrors)));
                return null;
            }
            return Conversion.ProductModule.Mapping.CategoryToCategoryDTO(category);
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

        public void SaveCategoryInformation(CategoryDTO categoryDTO)
        {
            if (categoryDTO == null)
            {
                throw new ArgumentException(LocalizerFactory.CreateLocalizer().GetString("warning_CannotAddCategoryWithNullInformation", typeof(ApplicationErrors)));
            }
            var category = new Category()
            {
                CategoryCode = categoryDTO.CategoryCode,
                CategoryImage = categoryDTO.CategoryImage,
                CategoryLevel = categoryDTO.CategoryLevel,
                CategoryName = categoryDTO.CategoryName,
                Order = categoryDTO.Order
            };
            SaveCategory(category);
        }

        public void UpdateCategoryInformation(int id, CategoryDTO categoryDTO)
        {
            if (categoryDTO == null)
                throw new ArgumentException(LocalizerFactory.CreateLocalizer().GetString("warning_CannotAddCategoryWithNullInformation", typeof(ApplicationErrors)));
            var originalCategory = _categoryRepository.Get(id);
            if(originalCategory == null)
                throw new ArgumentException(LocalizerFactory.CreateLocalizer().GetString("warning_CategoryDoesNotExists", typeof(ApplicationErrors)));

            var updatedCategory = new Category()
            {
                // Can input modified date and modified by here
                ID = id,
                CategoryCode = categoryDTO.CategoryCode,
                CategoryImage = categoryDTO.CategoryImage,
                CategoryLevel = categoryDTO.CategoryLevel,
                CategoryName = categoryDTO.CategoryName,
                Order = categoryDTO.Order
            };
            UpdateCategory(originalCategory, updatedCategory);
        }

        #endregion

        #region Private Support Functions
        Category SaveCategory(Category category)
        {
            var entityValidator = EntityValidatorFactory.CreateValidator();
            if (entityValidator.IsValid(category))
            {
                _categoryRepository.Add(category);
                _categoryRepository.UnitOfWork.Commit();
                return category;
            }
            else
            {
                throw new ApplicationValidationErrorsException(entityValidator.GetInvalidMessages(category));
            }
        }
        Category UpdateCategory(Category originalCategory, Category updatedCategory)
        {
            var entityValidator = EntityValidatorFactory.CreateValidator();
            if (entityValidator.IsValid(updatedCategory))
            {
                _categoryRepository.Merge(originalCategory, updatedCategory);
                _categoryRepository.UnitOfWork.Commit();
                return updatedCategory;
            }
            else
            {
                throw new ApplicationValidationErrorsException(entityValidator.GetInvalidMessages(updatedCategory));
            }

        }
        #endregion
    }
}
