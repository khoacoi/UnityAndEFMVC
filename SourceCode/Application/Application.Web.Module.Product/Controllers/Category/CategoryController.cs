using Application.Manager.Contract.ProductModule;
using Application.Web.Module.Product.Models.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Application.Web.Module.Product.Controllers.Category
{
    public class CategoryController : Controller
    {
        ICategoryManager _categoryManager;
        public CategoryController(ICategoryManager categoryManager)
        {
            _categoryManager = categoryManager;
        }
        //
        // GET: /Category/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Manage()
        {
            return View();
        }

        public ActionResult Update(int? id)
        {
            var categoryViewModel = new CategoryModel();

            if (id.HasValue)
            {
                var categoryDTO = _categoryManager.FindCategoryByID(id.Value);
                if (categoryDTO == null)
                    return HttpNotFound();

                categoryViewModel = CategoryModelUtis.ConvertCategoryDTOtoCategoryModel(categoryDTO);
            }
            return View(categoryViewModel);
        }

    }
}
