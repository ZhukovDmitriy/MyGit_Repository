using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DependencyInjection.Models;

namespace DependencyInjection.Controllers
{
    public class HomeController : Controller
    {
        // Вариант 1
        //public ViewResult Index()
        //{
        //    SmallRepository smallRepository = new SmallRepository();
        //    IEnumerable<Product> fewProducts = smallRepository.products;

        //    MediumRepository mediumRepository = new MediumRepository();
        //    IEnumerable<Product> averageProdust = mediumRepository.products;

        //    return View(fewProducts);
        //}

        // Вариант 2
        //private SmallRepository smallRepository;
        //private MediumRepository mediumRepository;

        //public HomeController()
        //{
        //    smallRepository = new SmallRepository();
        //    mediumRepository = new MediumRepository();
        //}

        //public ViewResult Index()
        //{
        //    IEnumerable<Product> fewProducts = smallRepository.products;
        //    IEnumerable<Product> averageProducts = mediumRepository.products;

        //    return View(fewProducts);
        //}

        // Вариант 3
        //private SmallRepository smallRepository;
        //private MediumRepository mediumRepository;

        //public HomeController(SmallRepository smallRepo, MediumRepository mediumRepo)
        //{
        //    smallRepository = smallRepo;
        //    mediumRepository = mediumRepo;
        //}

        //public ViewResult Index()
        //{
        //    IEnumerable<Product> fewProducts = smallRepository.products;
        //    IEnumerable<Product> averageProducts = mediumRepository.products;

        //    return View(fewProducts);
        //}

        // Вариант 4
        //public ViewResult Index()
        //{
        //    IEntranceRepository smallRepository = new SmallRepository();
        //    IEnumerable<Product> fewProducts = smallRepository.Products;

        //    IEntranceRepository mediumRepository = new MediumRepository();
        //    IEnumerable<Product> averageProducts = mediumRepository.Products;

        //    return View(fewProducts);
        //}

        // Вариант 5
        //private IEntranceRepository smallRepository;
        //private IEntranceRepository mediumRepository;

        //public HomeController()
        //{
        //    smallRepository = new SmallRepository();
        //    mediumRepository = new MediumRepository();
        //}

        //public ViewResult Index()
        //{
        //    IEnumerable<Product> fewProducts = smallRepository.Products;
        //    IEnumerable<Product> averageProducts = mediumRepository.Products;

        //    return View(fewProducts);
        //}

        // Вариант 6
        private IEntranceRepository repository;

        public HomeController(IEntranceRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index()
        {
            IEnumerable<Product> products = repository.Products;

            return View(products);
        }

        public void CreateController()
        {
            SmallRepository repository = new SmallRepository();
            HomeController controller = new HomeController(repository);
        }

        // Вариант 7 
        //private ISmallRepository smallRepository;
        //private IMediumRepository mediumRepository;

        //public HomeController(ISmallRepository smallRepo, IMediumRepository mediumRepo)
        //{
        //    smallRepository = smallRepo;
        //    mediumRepository = mediumRepo;
        //}

        //public ViewResult Index()
        //{
        //    IEnumerable<Product> fewProducts = smallRepository.Products;
        //    IEnumerable<Product> averageProducts = mediumRepository.Products;

        //    return View(fewProducts);
        //}
    }
}


