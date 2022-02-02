using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreEngine.Domain.Entities;

namespace StoreEngine.Domain.Abstract
{
    public interface IProductRepository
    {
        IQueryable<Product> Products { get; }
        IQueryable<Category> Categories { get; }
        IQueryable<Entities.Attribute> Attributes { get; }
        IQueryable<AttributeValue> AttributeValues { get; }
        IQueryable<Image> Images { get; }

        void SaveProduct(Product product, Category category);
        void CreateAttributesValues(List<string> attributeValue);
        void SaveAttributesValues(int productID, List<string> attrbuteValue);
        Product DeleteProduct(int productID);
        Category DeleteCategory(int categoryID);
        void SaveCategory(Category category);
        void SaveAttributes(List<string> attribute);
        void SaveAttributes(IEnumerable<Entities.Attribute> attributes, Category category);
        void SaveAttributes(List<string> attribute, Category category);
        void SaveAttributesPosition(IEnumerable<Entities.Attribute> attributes, Category category);
        void SaveImages(Product product, List<Image> images, bool existImgInDB);
        void SaveImagePosition(int productID, List<int> imageID);
        void DeleteImage(List<int> imageID, int productID);
    }
}
