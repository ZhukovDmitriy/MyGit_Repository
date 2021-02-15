using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace StoreEngine.Domain.Entities
{
    public class Image
    {
        public int ImageID { get; set; }
        public int ProductID { get; set; }
        public string Name { get; set; }
        public byte[] ImageData { get; set; }
        public int SortPosition { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string ImageMimeType { get; set; }
    }
}
