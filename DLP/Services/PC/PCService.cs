using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DLP.Entities.PC;
using DLP.Models;
using DLP.ViewModels.PC;

namespace DLP.Services.PC
{
    public class PCService:IPCService
    {
        private PCContext db;
        public PCService(PCContext pcContext)
        {
            db = pcContext;
        }

        
        public IEnumerable<PcModel> GetPcListFromDb()
        {
            List<Entities.PC.PC> pcs = db.PCs.ToList();
            List<PcModel> pcModels = new List<PcModel>();
            foreach(Entities.PC.PC pc in pcs)
            {
                pcModels.Add(new PcModel() { Id = pc.Id, Name = pc.Name, CorpusId = pc.CorpusId, PowerId = pc.PowerId, MotherboardId = pc.MotherboardId, ProcessorId = pc.ProcessorId, CoolerId = pc.CoolerId, Ram1Id = pc.Ram1Id, Ram2Id = pc.Ram2Id, Ram3Id = pc.Ram3Id, ram4Id = pc.ram4Id, GPUId = pc.GPUId });
            }
            return pcModels;
        }
        
        public PcModel GetPcFromDb(int id)
        {
            Entities.PC.PC pc = db.PCs.FirstOrDefault(data => data.Id == id);
            return new PcModel() { Id = pc.Id, Name = pc.Name, CorpusId = pc.CorpusId, PowerId = pc.PowerId, MotherboardId = pc.MotherboardId, ProcessorId = pc.ProcessorId, CoolerId = pc.CoolerId, Ram1Id = pc.Ram1Id, Ram2Id = pc.Ram2Id, Ram3Id = pc.Ram3Id, ram4Id = pc.ram4Id, GPUId = pc.GPUId };
        }
        
        public void SetPcToDb(PcModel pc)
        {
            Entities.PC.PC PC = new Entities.PC.PC() { Id = pc.Id, Name = pc.Name, CorpusId = pc.CorpusId, PowerId = pc.PowerId, MotherboardId = pc.MotherboardId, ProcessorId = pc.ProcessorId, CoolerId = pc.CoolerId, Ram1Id = pc.Ram1Id, Ram2Id = pc.Ram2Id, Ram3Id = pc.Ram3Id, ram4Id = pc.ram4Id, GPUId = pc.GPUId };
            db.PCs.Add(PC);
            db.SaveChanges();
        }
    }
}
