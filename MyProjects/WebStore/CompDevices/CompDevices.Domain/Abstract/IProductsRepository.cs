using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompDevices.Domain.Entities;

namespace CompDevices.Domain.Abstract
{
    public interface IProductsRepository
    {
        IQueryable<Product> Products { get; }
        IQueryable<ProductAttribute> ProductAttributes { get; }
        IQueryable<AttributeValue> AttributeValues { get; }

        void SaveProduct(ProductEditModel editModel);
        Product DeleteProduct(int productID);
    }
}
