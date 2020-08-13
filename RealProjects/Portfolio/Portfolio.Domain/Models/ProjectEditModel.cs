using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Portfolio.Domain.Entities;

namespace Portfolio.Domain.Models
{
    public class ProjectEditModel
    {
        public Project Project { get; set; }
        public Image Image { get; set; }
        public IEnumerable<Image> Images { get; set; }
    }
}
