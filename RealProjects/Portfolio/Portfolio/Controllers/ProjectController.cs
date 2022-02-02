using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Portfolio.Domain.Entities;
using Portfolio.Domain.Concrete;
using Portfolio.Models;
using Portfolio.Domain.Abstract;

namespace Portfolio.Controllers
{
    public class ProjectController : Controller
    {
        //EFProjectRepository repository;
        private IProjectRepository repository;

        public ProjectController(IProjectRepository projectRepository)
        {
            repository = projectRepository;
        }

        public ViewResult ProjectsList()
        {
            //repository = new EFProjectRepository();

            ProjectViewModel projectModel = new ProjectViewModel()
            {
                Projects = repository.Projects,
                Images = repository.Images.OrderBy(c => c.Name)
            };

            return View(projectModel);
        }

        public FileContentResult GetImage(int imageId)
        {
            //repository = new EFProjectRepository();

            Image image = repository.Images.FirstOrDefault(c => c.ImageID == imageId);
            if (image != null)
            {
                return File(image.ImageData, image.ImageMimeType, image.Name);
            }
            else
            {
                return null;
            }
        }

        public ViewResult GetModalImage()
        {
            return View();
        }
    }
}