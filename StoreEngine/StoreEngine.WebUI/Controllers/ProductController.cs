using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StoreEngine.Domain.Abstract;
using StoreEngine.Domain.Entities;
using StoreEngine.WebUI.Models;

namespace StoreEngine.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository repository;
        public int PageSize = 4;

        public ProductController(IProductRepository productRepository)
        {
            repository = productRepository;
        }

        //public ViewResult List(string category, int page = 1)
        //{
        //    ProductsListViewModel model = new ProductsListViewModel
        //    {
        //        Products = repository.Products
        //        .Where(p => category == null || p.Category == category)
        //        .OrderBy(p => p.ProductID)
        //        .Skip((page - 1) * PageSize)
        //        .Take(PageSize),

        //        PagingInfo = new PagingInfo
        //        {
        //            CurrentPage = page,
        //            ItemsPerPage = PageSize,
        //            TotalItems = category == null ?
        //            repository.Products.Count() :
        //            repository.Products.Where(e => e.Category == category).Count()
        //        },

        //        CurrentCategory = category
        //    };

        //    return View(model);
        //}

        public ViewResult List(string category, int page = 1)
        {
            ProductsListViewModel model = new ProductsListViewModel
            {
                Products = repository.Products
                .Where(p => category == null)
                .OrderBy(p => p.ProductID)
                .Skip((page - 1) * PageSize)
                .Take(PageSize),

                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = repository.Products.Count()
                },

                CurrentCategory = category
            };

            return View(model);
        }

        public FileContentResult GetImage(int imageID)
        {
            Image image = repository.Images.FirstOrDefault(p => p.ImageID == imageID);

            if (image != null)
            {
                return File(image.ImageData, image.ImageMimeType);
            }
            else
            {
                return null;
            }
        }
    }
}