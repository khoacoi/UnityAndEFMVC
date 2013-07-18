using Application.Web.Module.Product.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Application.Web.Module.Product.Controllers.Product
{
    public class ProductController : Controller
    {
        //
        // GET: /Product/

        public ActionResult Manage()
        {
            return View();
        }

        public ActionResult Update(int? id)
        {
            var viewModel = new ProductModel()
            {
                Id = id
            };
            return View(viewModel);
        }
    }
}
