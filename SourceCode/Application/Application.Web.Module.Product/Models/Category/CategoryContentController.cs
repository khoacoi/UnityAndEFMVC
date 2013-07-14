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
    public class CategoryContentController : ApiController
    {
        #region Properties
        ICategoryManager _categoryManager;
        #endregion

        #region Constructors
        public CategoryContentController() { }
        public CategoryContentController(ICategoryManager categoryManager)
        {
            _categoryManager = categoryManager;
        }
        #endregion

        // GET api/categorycontent
        public IEnumerable<CategoryDTO> GetCategories()
        {
            //return new string[] { "value1", "value2" };
            var categories = _categoryManager.FindCategories(0, 10);
            return categories;
        }

        //// GET api/categorycontent
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/categorycontent/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/categorycontent
        public void Post([FromBody]string value)
        {
        }

        // PUT api/categorycontent/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/categorycontent/5
        public void Delete(int id)
        {
        }
    }
}
