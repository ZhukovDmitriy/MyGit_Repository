using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Portfolio.Domain.Entities;
using Portfolio.Domain.Models;
using Portfolio.Domain.Abstract;

namespace Portfolio.Domain.Concrete
{
    public class EFProjectRepository : IProjectRepository
    {
        private EFDbContext context = new EFDbContext();

        public IQueryable<Project> Projects { get { return context.Projects; } }
        public IQueryable<Image> Images { get { return context.Images; } }

        public void SaveProject(ProjectEditModel editModel)
        {
            if (editModel.Project.ProjectID == 0)
            {
                context.Projects.Add(editModel.Project);
                context.SaveChanges();

                if (editModel.Image.ImageData != null)
                {
                    Project project = context.Projects.ToList().Last();

                    editModel.Image.IdProject = project.ProjectID;
                    context.Images.Add(editModel.Image);
                    context.SaveChanges();
                }
            }
            else
            {
                Project dbProjectEntry = context.Projects.Find(editModel.Project.ProjectID);
                if (dbProjectEntry != null)
                {
                    dbProjectEntry.Name = editModel.Project.Name;
                    dbProjectEntry.Description = editModel.Project.Description;
                }

                if (editModel.Image.ImageData != null)
                {
                    editModel.Image.IdProject = dbProjectEntry.ProjectID;
                    context.Images.Add(editModel.Image);
                }
            }

            context.SaveChanges();
        }

        public Project DeleteProject(int projectID)
        {
            Project dbEntry = context.Projects.Find(projectID);
            if (dbEntry != null)
            {
                context.Projects.Remove(dbEntry);
                context.SaveChanges();
            }

            return dbEntry;
        }

        public Image DeleteImage(int imageId)
        {
            Image dbEntry = context.Images.Find(imageId);
            if (dbEntry != null)
            {
                context.Images.Remove(dbEntry);
                context.SaveChanges();
            }

            return dbEntry;
        }
    }
}


