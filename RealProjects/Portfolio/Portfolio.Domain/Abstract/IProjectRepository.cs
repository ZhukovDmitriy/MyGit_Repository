using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Portfolio.Domain.Entities;
using Portfolio.Domain.Models;

namespace Portfolio.Domain.Abstract
{
   public interface IProjectRepository
    {
        IQueryable<Project> Projects { get; }
        IQueryable<Image> Images { get; }

        void SaveProject(ProjectEditModel editModel);
        Project DeleteProject(int projectID);
        Image DeleteImage(int imageId);
    }
}
