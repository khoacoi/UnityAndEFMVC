using Application.Manager.Contract.ProductModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Application.Web.Module.Product.APIControllers.Product
{
    public class ProductManagerController : ApiController
    {
        IProductManager _productManager;
        public ProductManagerController(IProductManager productManager)
        {
            _productManager = productManager;
        }
        // GET api/productmanager
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/productmanager/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/productmanager
        public void Post([FromBody]string value)
        {
        }

        // PUT api/productmanager/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/productmanager/5
        public void Delete(int id)
        {
        }
    }
}
