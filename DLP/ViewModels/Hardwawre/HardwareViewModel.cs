using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DLP.ViewModels.Hardwawre
{
    public class HardwareViewModel
    {
        public int DBId { get; set; }
        public string HardwareType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string MediaLink { get; set; }
        public List<AttributeViewModel> Attributes { get; set; }

        public HardwareViewModel()
        {
            Attributes = new List<AttributeViewModel>();
        }
    }
}
