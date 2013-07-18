using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.ProductModule
{
    public class ProductDTO
    {
        public int ID { get; set; }
        public string SKU { get; set; }
        public decimal OurCost { get; set; }
        public decimal SalePrice { get; set; }
        public string ProductImage { get; set; }
        public List<CategoryProductLinkDTO> CategoryProductLinks { get; set; }

        public ProductDTO()
        {
            CategoryProductLinks = new List<CategoryProductLinkDTO>();
        }
    }
}
