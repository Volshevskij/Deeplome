using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DLP.Entities.Catalog
{
    public class Processor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string MediaLink { get; set; }
        public string Socket { get; set; }
        public int CoresQuantity { get; set; }
        public int FlowsQuantity { get; set; }
        public int CoreFrequencyHz { get; set; }
        public int HeatPowerVt { get; set; }
        public string Chipset { get; set; }
    }
}
