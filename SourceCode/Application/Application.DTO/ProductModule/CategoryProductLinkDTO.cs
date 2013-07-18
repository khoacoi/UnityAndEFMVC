using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.ProductModule
{
    public class CategoryProductLinkDTO
    {
        public int ID { get; set; }
        public CategoryDTO Category { get; set; }
        public ProductDTO Product { get; set; }
    }
}
