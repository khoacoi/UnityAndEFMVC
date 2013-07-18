using Application.Common.Localization;
using Application.Domain.Product.ProductAggregate;
using Application.DTO.ProductModule;
using Application.Manager.Contract.ProductModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Manager.Implementation.ProductModule
{
    public class ProductManager : IProductManager
    {
        #region Global Declaration
        IProductRepository _productRepository;
        #endregion

        #region Constructors
        public ProductManager(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        #endregion
        public List<DTO.ProductModule.ProductDTO> FindProducts(int pageIndex, int pageCount)
        {
            if (pageIndex < 0 || pageCount <= 0)
                throw new AggregateException(LocalizerFactory.CreateLocalizer().GetString("warning_InvalidArgumentForFindProduct", typeof(Application.Resources.ApplicationErrors)));
            var products = _productRepository.GetPaged<string>(pageIndex, pageCount, p=> p.SKU, false);
            if (products != null && products.Any())
            {
                var productDTOs = new List<ProductDTO>();
                foreach (var product in products)
                {
                    productDTOs.Add(Conversion.ProductModule.Mapping.ProductToProductDTO(product));
                }
                return productDTOs;
            }

            return null;
        }

        public DTO.ProductModule.CategoryDTO FindProductByID(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        public void SaveProductInformation(DTO.ProductModule.CategoryDTO categoryDTO)
        {
            throw new NotImplementedException();
        }

        public void UpdateProductInformation(int id, DTO.ProductModule.CategoryDTO categoryDTO)
        {
            throw new NotImplementedException();
        }
    }
}
