using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CompDevices.Domain.Abstract;
using CompDevices.Domain.Entities;
using CompDevices.WebUI.Models;
using System.IO;

namespace CompDevices.WebUI.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private IProductsRepository repository;

        public AdminController(IProductsRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index()
        {
            ProductsAdminListModel prodList = new ProductsAdminListModel
            {
                Products = repository.Products,

                Categories = repository.Products.Select(x => x.Category).Distinct().OrderBy(x => x)
            };

            return View(prodList);
        }

        public ViewResult Edit(int productId, string category)
        {
            ProductEditModel editModel = new ProductEditModel
            {
                Products = repository.Products
                .FirstOrDefault(p => p.ProductID == productId),

                ProductAttributes = repository.ProductAttributes
                .Where(p => p.Category == category).OrderBy(p => p.AttributeID).ToList(),

                AttributeValues = repository.AttributeValues
                .Where(p => p.ProductID == productId).OrderBy(p => p.AttributeID).ToList()
            };

            return View(editModel);
        }

        [HttpPost]
        public ActionResult Edit(ProductEditModel editModel, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    editModel.Products.ImageMimeType = image.ContentType;
                    editModel.Products.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(editModel.Products.ImageData, 0, image.ContentLength);
                    //BinaryReader reader = new BinaryReader(image.InputStream);                    // Заменить строку 61 на две нижние (альтернативный метод)
                    //editModel.Products.ImageData = reader.ReadBytes(image.ContentLength);
                }
                else
                {
                    if (editModel.Products.ProductID != 0 & editModel.Products.ImageData == null)
                    {
                        Product prod = repository.Products.FirstOrDefault(p => p.ProductID == editModel.Products.ProductID);

                        if (prod != null & prod.ImageData != null)
                        {
                            editModel.Products.ImageMimeType = prod.ImageMimeType;
                            editModel.Products.ImageData = prod.ImageData;
                        }
                    }
                }

                repository.SaveProduct(editModel);
                TempData["message"] = string.Format("Изменения в товаре {0} {1} успешно сохранены!", editModel.Products.Brand, editModel.Products.Model);

                return RedirectToAction("Index");
            }
            else
            {
                return View(editModel);
            }
        }

        public ViewResult Create(ProductsAdminListModel prodList)
        {
            ProductEditModel newModel = new ProductEditModel();
            newModel.Products = new Product();
            newModel.Products.Category = prodList.SelectedCategory;

            newModel.ProductAttributes = repository.ProductAttributes
                .Where(p => p.Category == prodList.SelectedCategory).OrderBy(p => p.AttributeID).ToList();

            newModel.AttributeValues =
                    (from p in repository.ProductAttributes.Where(p => p.Category == prodList.SelectedCategory).OrderBy(p => p.AttributeID)
                     select new
                     {
                         p.SelectiveAttribute,
                         p.FilterAttribute,
                         p.Category,
                         p.AttributeID
                     }).ToList()
                 .Select(p => new AttributeValue
                 {
                     ID = 0,
                     ProductID = 0,
                     SelectiveAttribute = p.SelectiveAttribute,
                     FilterAttribute = p.FilterAttribute,
                     Category = p.Category,
                     AttributeID = p.AttributeID,
                     Value = null
                 }).ToList();

            return View("Edit", newModel);
        }

        [HttpPost]
        public ActionResult Delete(int productId)
        {
            Product deleteProduct = repository.DeleteProduct(productId);

            if (deleteProduct != null)
            {
                TempData["message"] = string.Format("Товар {0} {1} удалён!", deleteProduct.Brand, deleteProduct.Model);
            }

            return RedirectToAction("Index");
        }
    }
}