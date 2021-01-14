using System;
using System.Collections.Generic;
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

        public void SaveProduct(Product product)
        {
            if (product.ProductID == 0)
            {
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
                    dbEntry.Category = product.Category;
                    dbEntry.ImageData = product.ImageData;
                    dbEntry.ImageMimeType = product.ImageMimeType;
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
                context.SaveChanges();
            }

            return dbEntry;
        }

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
