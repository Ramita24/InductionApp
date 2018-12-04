using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InductionBusinessModel
{
    public class PageModel
    {
        public int PageId { get; set; }
        public string PageName { get; set; }
        public string PageDescription { get; set; }

        public PageImagesModel PageImage { get; set; }
        public PageSectionModel PageSection { get; set; }
        public PageTextModel PageText { get; set; }
    }
}
