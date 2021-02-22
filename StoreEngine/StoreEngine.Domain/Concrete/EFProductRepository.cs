using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreEngine.Domain.Abstract;
using StoreEngine.Domain.Entities;

namespace StoreEngine.Domain.Concrete
{
    public class EFProductRepository : IProductRepository
    {
        private EFDbContext context = new EFDbContext();

        public IQueryable<Product> Products { get { return context.Products; } }
        public IQueryable<Category> Categories { get { return context.Categories; } }
        public IQueryable<Entities.Attribute> Attributes { get { return context.Attributes; } }
        public IQueryable<AttributeValue> AttributeValues { get { return context.AttributeValues; } }
        public IQueryable<Image> Images { get { return context.Images; } }

        // Создает, редактирует данные объекта Product 
        public void SaveProduct(Product product, Category category)
        {
            if (product.ProductID == 0)
            {
                product.CategoryID = category.CategoryID;

                context.Products.Add(product);
            }
            else
            {
                Product dbEntry = context.Products.Find(product.ProductID);

                if (dbEntry != null)
                {
                    dbEntry.Name = product.Name;
                    dbEntry.Description = product.Description;
                    dbEntry.Price = product.Price;
                }
            }

            context.SaveChanges();
        }

        // Создает изображения в БД
        public void SaveImages(Product product, List<Image> images, bool existImgInDB)
        {
            Product savedProduct = context.Products.FirstOrDefault(p => p.ProductID == product.ProductID);

            if (images != null)
            {
                int i = 0;

                if (existImgInDB)
                {
                    List<Image> existingImages = context.Images.Where(p => p.ProductID == product.ProductID).ToList();
                    Image lastImage = existingImages.OrderByDescending(p => p.SortPosition).FirstOrDefault();

                    i = lastImage.SortPosition;
                }

                foreach (var img in images)
                {
                    i++;

                    Image newImage = new Image()
                    {
                        ProductID = savedProduct.ProductID,
                        Name = img.Name,
                        ImageData = img.ImageData,
                        ImageMimeType = img.ImageMimeType,
                        SortPosition = i
                    };

                    context.Images.Add(newImage);
                }

                context.SaveChanges();
            }
        }

        public void SaveImagePosition(int productID, List<int> imgID)
        {
            List<Image> images = context.Images.Where(p => p.ProductID == productID).OrderBy(p => p.ImageID).ToList();

            for (int i = 0; i < imgID.Count(); i++)
            {
                for (int j = 0; j < images.Count(); j++)
                {
                    if (imgID[i] == images[j].ImageID)
                    {
                        images[j].SortPosition = i + 1;

                        break;
                    }
                }
            }

            context.SaveChanges();
        }

        public void DeleteImage(List<int> imageID, int productID)
        {
            List<Image> images = context.Images.Where(p => p.ProductID == productID).ToList();

            if (imageID != null)
            {
                for (int i = 0; i < imageID.Count(); i++)
                {
                    for (int j = 0; j < images.Count(); j++)
                    {
                        if (imageID[i] == images[j].ImageID)
                        {
                            images.Remove(images[j]);

                            break;
                        }
                    }
                }
            }

            foreach (var img in images)
            {
                context.Images.Remove(img);
            }

            context.SaveChanges();
        }

        // Создает атрибуты и записывает все необходимые значения в таблице AttributeValues 
        public void CreateAttributesValues(List<string> attributeValue)
        {
            Product lastSavedProduct = context.Products.OrderByDescending(p => p.ProductID).FirstOrDefault();
            List<Entities.Attribute> attributes = context.Attributes.Where(p => p.CategoryID == lastSavedProduct.CategoryID)
                .OrderBy(p => p.SortPosition).ToList();

            for (int i = 0; i < attributes.Count(); i++)
            {
                AttributeValue attrVal = new AttributeValue();

                attrVal.ProductID = lastSavedProduct.ProductID;
                attrVal.CategoryID = lastSavedProduct.CategoryID;
                attrVal.AttributeID = attributes[i].AttributeID;
                attrVal.Value = attributeValue[i];

                context.AttributeValues.Add(attrVal);
            }

            context.SaveChanges();
        }

        // Редактирует значения в таблице AttributeValues
        public void SaveAttributesValues(int productID, List<string> attributeValue)
        {
            List<AttributeValue> attributes = context.AttributeValues.Include(p => p.Attribute)
                .Where(p => p.ProductID == productID).OrderBy(p => p.Attribute.SortPosition).ToList();

            for (int i = 0; i < attributes.Count(); i++)
            {
                attributes[i].Value = attributeValue[i];
            }

            context.SaveChanges();
        }

        // Удаляет продукт из БД по ID
        public Product DeleteProduct(int productID)
        {
            Product dbEntry = context.Products.Find(productID);

            if (dbEntry != null)
            {
                context.Products.Remove(dbEntry);
                context.SaveChanges();
            }

            DeleteAttributeValues(productID);

            return dbEntry;
        }

        // Удаляет данные из таблицы AttributeValues по ID продукта
        public void DeleteAttributeValues(int productID)
        {
            IEnumerable<AttributeValue> productDatas = context.AttributeValues.Where(p => p.ProductID == productID);

            if (productDatas != null)
            {
                context.AttributeValues.RemoveRange(productDatas);
                context.SaveChanges();
            }
        }

        // Сохраняет категорию, редактирует название категории
        public void SaveCategory(Category category)
        {
            if (category.CategoryID == 0)
            {
                context.Categories.Add(category);
            }
            else
            {
                Category currentData = context.Categories.Find(category.CategoryID);

                currentData.Name = category.Name;
            }

            context.SaveChanges();
        }

        // Сохраняет атрибуты в БД в порядке следования атрибутов полученных из List
        // Задает свойству SortPosition номер по порядку, присваивается из инкремента переменной int i; 
        // Метод применяется при первом создании атрибутов в БД
        public void SaveAttributes(List<string> attribute)
        {
            //Category currentCategory = context.Categories.ToList().LastOrDefault();
            Category currentCategory = context.Categories.OrderByDescending(p => p.CategoryID).FirstOrDefault();

            int i = 0;

            foreach (var elm in attribute)
            {
                i++;

                Entities.Attribute newAttribute = new Entities.Attribute();

                newAttribute.Name = elm;
                newAttribute.CategoryID = currentCategory.CategoryID;
                newAttribute.SortPosition = i;

                context.Attributes.Add(newAttribute);
            }

            context.SaveChanges();
        }

        // Перегруженный метод выполняющий сохранение (пересохранение) атрибутов уже существующих в БД
        // Выполняет удаление из БД атрибутов помеченных на удаление (имеющих значение null)
        // а также выравнивает (упорядочивает) значение SortPosition оставшихся атрибутов
        public void SaveAttributes(IEnumerable<Entities.Attribute> attributes, Category category)
        {
            IEnumerable<Entities.Attribute> currentData = context.Attributes.Where(p => p.CategoryID == category.CategoryID);

            foreach (var item in currentData)
            {
                foreach (var elm in attributes)
                {
                    if (item.AttributeID == elm.AttributeID)
                    {
                        if (elm.Name == null)
                        {
                            DeleteAttribute(item.AttributeID);

                            break;
                        }

                        item.Name = elm.Name;

                        break;
                    }
                }
            }

            context.SaveChanges();

            IEnumerable<Entities.Attribute> remainingData = context.Attributes.Where(p => p.CategoryID == category.CategoryID).OrderBy(p => p.SortPosition);

            int i = 0;

            foreach (var item in remainingData)
            {
                i++;

                item.SortPosition = i;
            }

            context.SaveChanges();
        }

        // Перегруженный метод, применяется в случаях когда при редактировании категории, к уже существующим атрибутам в БД,
        // добавляются новые, еще не существующие атрибуты!
        // Создает новые атрибуты в БД продолжая присваивать им значения SortPosition на основании
        // последнего существующего значения SortPosition атрибута в БД  
        public void SaveAttributes(List<string> attribute, Category category)
        {
            Category currentCategory = context.Categories.Find(category.CategoryID);
            IEnumerable<Entities.Attribute> attributes = context.Attributes.Where(p => p.CategoryID == category.CategoryID);
            Entities.Attribute lastAttribute = attributes.OrderByDescending(p => p.SortPosition).FirstOrDefault();

            int i = lastAttribute.SortPosition;

            List<Entities.Attribute> newAddedAttributes = new List<Entities.Attribute>();

            foreach (var elm in attribute)
            {
                i++;

                Entities.Attribute newAttribute = new Entities.Attribute();

                newAttribute.Name = elm;
                newAttribute.CategoryID = currentCategory.CategoryID;
                newAttribute.SortPosition = i;

                context.Attributes.Add(newAttribute);
                newAddedAttributes.Add(newAttribute);
            }

            context.SaveChanges();

            AddNewAttributeToAttrbiuteValues(category.CategoryID, newAddedAttributes);
        }

        // Метод добавляет в таблицу AttributeValues атрибуты и заполняет их необходимыми значениями
        // в значения Value записывает " - "
        // !!! Вызывается только в том случае, !!! если при добавлении нового атрибута в таблицу Attributes 
        // в таблице AttributesValues уже существуют один или более созданных продуктов с атрибутами данной категории 
        public void AddNewAttributeToAttrbiuteValues(int categoryID, List<Entities.Attribute> addedAttributes)
        {
            AttributeValue checkForExist = context.AttributeValues.FirstOrDefault(p => p.CategoryID == categoryID);

            if (checkForExist != null)
            {
                IEnumerable<int> products = context.AttributeValues.Where(p => p.CategoryID == categoryID)
                    .Select(p => p.ProductID).Distinct().OrderBy(p => p);

                foreach (var item in products)
                {
                    foreach (var elm in addedAttributes)
                    {
                        AttributeValue newAddedAttribute = new AttributeValue()
                        {
                            ProductID = item,
                            CategoryID = categoryID,
                            AttributeID = elm.AttributeID,
                            Value = " - "
                        };

                        context.AttributeValues.Add(newAddedAttribute);
                    }
                }

                context.SaveChanges();
            }
        }

        // Метод принимает коллекцию с новым порядком атрибутов и задает значение SortPosition для этого порядка
        // Далее заменяет существующий порядок SortPosition атрибутов из БД, на новые значения SortPosition 
        public void SaveAttributesPosition(IEnumerable<Entities.Attribute> attributes, Category category)
        {
            IEnumerable<Entities.Attribute> currentAttributes = context.Attributes.Where(p => p.CategoryID == category.CategoryID).OrderBy(p => p.SortPosition);

            int i = 0;

            foreach (var elm in attributes)
            {
                i++;

                elm.SortPosition = i;
            }

            foreach (var item in currentAttributes)
            {
                foreach (var elm in attributes)
                {
                    if (item.AttributeID == elm.AttributeID)
                    {
                        item.SortPosition = elm.SortPosition;
                    }
                }
            }

            context.SaveChanges();
        }

        // Метод удаляет атрибут по его ID из БД
        public void DeleteAttribute(int attributeId)
        {
            Entities.Attribute currentData = context.Attributes.Find(attributeId);

            if (currentData != null)
            {
                context.Attributes.Remove(currentData);
            }
        }

        // Метод удаляет категорию по её ID из БД
        public Category DeleteCategory(int categoryID)
        {
            Category currentData = context.Categories.Find(categoryID);

            if (currentData != null)
            {
                context.Categories.Remove(currentData);
                context.SaveChanges();
            }

            return currentData;
        }
    }
}
