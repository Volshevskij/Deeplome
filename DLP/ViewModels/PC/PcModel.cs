using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DLP.ViewModels.PC
{
    public class PcModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CorpusId { get; set; }
        public int PowerId { get; set; }
        public int MotherboardId { get; set; }
        public int ProcessorId { get; set; }
        public int Ram1Id { get; set; }
        public int Ram2Id { get; set; }
        public int Ram3Id { get; set; }
        public int ram4Id { get; set; }
        public int CoolerId { get; set; }
        public int GPUId { get; set; }
    }
}
