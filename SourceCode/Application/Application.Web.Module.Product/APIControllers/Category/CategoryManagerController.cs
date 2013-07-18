using Application.DTO.ProductModule;
using Application.Manager.Contract.ProductModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Application.Web.Module.Product.APIControllers.Category
{
    public class CategoryManagerController : ApiController
    {
        #region Properties
        ICategoryManager _categoryManager;
        #endregion

        #region Constructors
        public CategoryManagerController(ICategoryManager categoryManager)
        {
            _categoryManager = categoryManager;
        }
        #endregion

        // GET api/categorymanagerment
        public IEnumerable<CategoryDTO> GetCategories()
        {
            //return new string[] { "value1", "value2" };
            var categories = _categoryManager.FindCategories(0, 10);
            return categories;
        }

        // GET api/categorymanagerment/5
        public CategoryDTO GetCategory(int id)
        {
            return _categoryManager.FindCategoryByID(id);
        }

        //// POST api/categorymanagerment
        public HttpResponseMessage Post(CategoryDTO categoryDTO)
        {
            try
            {
                _categoryManager.SaveCategoryInformation(categoryDTO);
                return Request.CreateResponse(HttpStatusCode.OK, categoryDTO);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotAcceptable, ex.Message);
            }
        }

        // PUT api/categorymanagerment/5
        public HttpResponseMessage Put(int id, CategoryDTO categoryDTO)
        {
            try
            {
                //var categoryDTO = Application.Web.Module.Product.Models.Category.CategoryModelUtis.ConvertCategoryModelToCategoryDTO(category);
                _categoryManager.UpdateCategoryInformation(id, categoryDTO);
                return Request.CreateResponse(HttpStatusCode.OK, categoryDTO);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotAcceptable, ex.Message);
            }
        }

        // DELETE api/categorymanagerment/5
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                _categoryManager.DeleteCategory(id);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotAcceptable, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
