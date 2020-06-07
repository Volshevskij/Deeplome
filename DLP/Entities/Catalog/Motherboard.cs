using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DLP.Entities.Catalog
{
    public class Motherboard
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string MediaLink { get; set; }
        public string Socket { get; set; }
        public string MotherboardType { get; set; }
        public int RamMaxQuantity { get; set; }
        public string MemoryType { get; set; }
        public string Chipset { get; set; }
        public string PCIVersion { get; set; }
    }
}
