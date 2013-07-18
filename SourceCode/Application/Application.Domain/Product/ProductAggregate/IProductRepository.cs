using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Domain.Product.ProductAggregate
{
    public interface IProductRepository : IRepository<Product>
    {
    }
}
