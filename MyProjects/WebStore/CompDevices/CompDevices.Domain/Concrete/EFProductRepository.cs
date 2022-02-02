using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompDevices.Domain.Abstract;
using CompDevices.Domain.Entities;

namespace CompDevices.Domain.Concrete
{
    public class EFProductRepository : IProductsRepository
    {
        private EFDbContext context = new EFDbContext();

        public IQueryable<Product> Products { get { return context.Products; } }
        public IQueryable<ProductAttribute> ProductAttributes { get { return context.ProductAttributes; } }
        public IQueryable<AttributeValue> AttributeValues { get { return context.AttributeValues; } }

        public void SaveProduct(ProductEditModel editModel)
        {
            if (editModel.Products.ProductID == 0)
            {
                context.Products.Add(editModel.Products);

                context.SaveChanges();

                Product product = context.Products.ToList().Last();

                foreach (var p in editModel.AttributeValues)
                {
                    p.ProductID = product.ProductID;
                }

                foreach (var p in editModel.AttributeValues)
                {
                    if (p.ID == 0)
                    {
                        context.AttributeValues.Add(p);
                    }
                }
            }
            else
            {
                Product dbEntry = context.Products.Find(editModel.Products.ProductID);

                if (dbEntry != null)
                {
                    dbEntry.Brand = editModel.Products.Brand;
                    dbEntry.Model = editModel.Products.Model;
                    dbEntry.Description = editModel.Products.Description;
                    dbEntry.TotalDescription = editModel.Products.TotalDescription;
                    dbEntry.Price = editModel.Products.Price;
                    dbEntry.Category = editModel.Products.Category;
                    dbEntry.ImageData = editModel.Products.ImageData;
                    dbEntry.ImageMimeType = editModel.Products.ImageMimeType;
                }

                IEnumerable<AttributeValue> dbValuesEntry =
                    context.AttributeValues.Where(p => p.ProductID == editModel.Products.ProductID).OrderBy(p => p.AttributeID);

                if (dbValuesEntry != null)
                {
                    foreach (var itemDB in dbValuesEntry)
                    {
                        foreach (var itemModel in editModel.AttributeValues)
                        {
                            if (itemDB.ID == itemModel.ID)
                            {
                                itemDB.Value = itemModel.Value;
                            }
                        }
                    }
                }
            }

            context.SaveChanges();
        }

        public Product DeleteProduct(int productID)
        {
            Product dbEntry = context.Products.Find(productID);

            if (dbEntry != null)
            {
                context.Products.Remove(dbEntry);

                IEnumerable<AttributeValue> attributesDelete =
                    context.AttributeValues.Where(p => p.ProductID == productID);

                foreach (var p in attributesDelete)
                {
                    context.AttributeValues.Remove(p);
                }

                context.SaveChanges();
            }

            return dbEntry;
        }
    }
}
