using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DLP.Models
{
    public class PC
    {
        public int Id { get; set; }
        public int Corpus { get; set; }
        public int PowerBlock { get; set; }
        public int Motherboard { get; set; }
        public int CPU { get; set; }
        public int GPU1 { get; set; }
        public int GPU2 { get; set; }
        public int GPU3 { get; set; }
        public int GPU4 { get; set; }
        public int HDD1 { get; set; }
        public int HDD2 { get; set; }
        public int HDD3 { get; set; }
        public int HDD4 { get; set; }
        public int OZU1 { get; set; }
        public int OZU2 { get; set; }
        public int OZU3 { get; set; }
        public int OZU4 { get; set; }

        public int DVD1 { get; set; }
        public int DVD2 { get; set; }
        public int DVD3 { get; set; }
        public int DVD4 { get; set; }

        public int Cooling { get; set; }
        public int CPUCooling { get; set; }
    }
}
