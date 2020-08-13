using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Portfolio.Domain.Concrete;
using Portfolio.Domain.Entities;
using Portfolio.Models;
using Portfolio.Domain.Models;

namespace Portfolio.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        EFProjectRepository repository;

        public ViewResult Index()
        {
            repository = new EFProjectRepository();

            ProjectViewModel projectModel = new ProjectViewModel
            {
                Projects = repository.Projects,
                Images = repository.Images
            };

            return View(projectModel);
        }

        public ViewResult Edit(int projectID)
        {
            repository = new EFProjectRepository();

            ProjectEditModel editModel = new ProjectEditModel
            {
                Project = repository.Projects.FirstOrDefault(p => p.ProjectID == projectID),
                Image = new Image(),
                Images = repository.Images.Where(c => c.IdProject == projectID).OrderBy(c => c.Name)
            };

            return View(editModel);
        }

        public ViewResult Create()
        {
            ProjectEditModel editModel = new ProjectEditModel()
            {
                Project = new Project(),
                Image = new Image()
            };

            return View("Edit", editModel);
        }

        public ActionResult Delete(int projectID)
        {
            repository = new EFProjectRepository();

            Project deleteProject = repository.DeleteProject(projectID);
            if (deleteProject != null)
            {
                TempData["message"] = string.Format("{0} успешно удалён", deleteProject.Name);
            }

            return RedirectToAction("Index");
        }

        public ActionResult DeleteImg(int imageId)
        {
            repository = new EFProjectRepository();

            Image deleteImg = repository.DeleteImage(imageId);
            if (deleteImg != null)
            {
                TempData["message"] = string.Format("Изображение {0} успешно удаленно", deleteImg.Name);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(ProjectEditModel editModel, HttpPostedFileBase img)
        {
            repository = new EFProjectRepository();

            if (ModelState.IsValid)
            {
                if (img != null)
                {
                    editModel.Image.ImageMimeType = img.ContentType;
                    editModel.Image.Name = img.FileName;
                    editModel.Image.ImageData = new byte[img.ContentLength];
                    img.InputStream.Read(editModel.Image.ImageData, 0, img.ContentLength);
                }

                repository.SaveProject(editModel);
                TempData["message"] = string.Format("{0} успешно сохраненно ", editModel.Project.Name);

                return RedirectToAction("Index");
            }
            else
            {
                return View(editModel);
            }
        }
    }
}