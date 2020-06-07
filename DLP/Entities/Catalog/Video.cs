using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DLP.Entities.Catalog
{
    public class Video
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string MediaLink { get; set; }
        public int ValueGb { get; set; }
        public string MemoryType { get; set; }
        public string PCIVersion { get; set; }
        public int MemoryFrequencyHz { get; set; }
        public int PowerConsuptionVt { get; set; }
    }
}
