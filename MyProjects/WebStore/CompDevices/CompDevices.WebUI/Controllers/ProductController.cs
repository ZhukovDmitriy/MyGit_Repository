using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CompDevices.Domain.Abstract;
using CompDevices.Domain.Entities;
using CompDevices.WebUI.Models;

namespace CompDevices.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductsRepository repository;

        public ProductController(IProductsRepository productsRepository)
        {
            this.repository = productsRepository;
        }

        public int PageSize = 6;

        public ViewResult List(string category, int sortType = default(int), int page = 1)
        {
            ProductsListViewModel model = new ProductsListViewModel();

            if (sortType == default(int))
            {
                model.Products = repository.Products
                  .Where(p => category == null || p.Category == category)
                  .OrderBy(p => p.ProductID)
                  .Skip((page - 1) * PageSize)
                  .Take(PageSize);
            }
            else if (sortType == 1)
            {
                model.Products = repository.Products
                 .Where(p => category == null || p.Category == category)
                 .OrderBy(p => p.Price)
                 .Skip((page - 1) * PageSize)
                 .Take(PageSize);
            }
            else if (sortType == 2)
            {
                model.Products = repository.Products
                 .Where(p => category == null || p.Category == category)
                 .OrderByDescending(p => p.Price)
                 .Skip((page - 1) * PageSize)
                 .Take(PageSize);
            }

            model = new ProductsListViewModel
            {
                Products = model.Products,

                AttributesViewModels =
              (from p in repository.AttributeValues
               join c in repository.ProductAttributes on p.AttributeID equals c.AttributeID
               select new
               {
                   p.ID,
                   p.ProductID,
                   p.SelectiveAttribute,
                   c.AttributeName,
                   p.Value
               }).ToList()
               .Select(p => new ProductAttributesViewModel
               {
                   ID = p.ID,
                   ProductID = p.ProductID,
                   SelectiveAttribute = p.SelectiveAttribute,
                   AttributeName = p.AttributeName,
                   Value = p.Value
               }).ToList(),

                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null ?
                   repository.Products.Count() :
                   repository.Products.Where(e => e.Category == category).Count()
                },

                CurrentCategory = category
            };

            return View(model);
        }

        public ViewResult DetailProductView(int prodID)
        {
            DetailProductListViewModel model = new DetailProductListViewModel
            {
                Products = repository.Products
                .Where(p => p.ProductID == prodID),

                AttributesViewModels =
                (from p in repository.AttributeValues.Where(p => p.ProductID == prodID).OrderBy(p => p.AttributeID)
                 join c in repository.ProductAttributes on p.AttributeID equals c.AttributeID
                 select new
                 {
                     p.ID,
                     p.ProductID,
                     p.SelectiveAttribute,
                     c.AttributeName,
                     p.Value
                 }).ToList()
                 .Select(p => new ProductAttributesViewModel
                 {
                     ID = p.ID,
                     ProductID = p.ProductID,
                     SelectiveAttribute = p.SelectiveAttribute,
                     AttributeName = p.AttributeName,
                     Value = p.Value
                 }).ToList(),

                ProductID = prodID
            };

            return View(model);
        }

        public FileContentResult GetImage(int productId)
        {
            Product prod = repository.Products.FirstOrDefault(p => p.ProductID == productId);

            if (prod != null)
            {
                return File(prod.ImageData, prod.ImageMimeType);
            }
            else
            {
                return null;
            }
        }
    }
}