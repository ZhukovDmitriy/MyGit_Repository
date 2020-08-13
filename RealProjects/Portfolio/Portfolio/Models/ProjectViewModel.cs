using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Portfolio.Domain.Entities;

namespace Portfolio.Models
{
    public class ProjectViewModel
    {
        public IEnumerable<Project> Projects { get; set; }
        public IEnumerable<Image> Images { get; set; }
    }
}