using Application.DTO.ProductModule;
using Application.Manager.Contract.ProductModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Application.Web.Module.Product.Models.Category
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

        //// GET api/categorymanagerment
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/categorymanagerment/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/categorymanagerment
        public void Post([FromBody]string value)
        {
        }

        // PUT api/categorymanagerment/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/categorymanagerment/5
        public void Delete(int id)
        {
        }
    }
}
