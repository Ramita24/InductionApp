using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InductionBusinessModel
{
    public class PageImagesModel
    {
        public int ImageId { get; set; }
        public string ImageName { get; set; }
        public string ImageDescription { get; set; }
        public string ImagePath { get; set; }
        public DateTime ImageUploadedDate { get; set; }

    }
}
