using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Portfolio.Domain.Entities
{
    public class Image
    {
        [HiddenInput(DisplayValue = false)]
        public int IdProject { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int ImageID { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string Name { get; set; }

        public byte[] ImageData { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string ImageMimeType { get; set; }
    }
}
