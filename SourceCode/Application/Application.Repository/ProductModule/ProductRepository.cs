using Application.DAL;
using Application.DAL.Contract;
using Application.Domain.Product.ProductAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository.ProductModule
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(IQueryableUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}
