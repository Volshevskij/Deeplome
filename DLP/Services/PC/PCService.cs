using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DLP.Entities.PC;
using DLP.ViewModels.PC;

namespace DLP.Services.PC
{
    public class PCService:IPCService
    {
        private PCContext db;
        public PCService(PCContext pcContext)
        {

        }

        //WIP
        public IEnumerable<PcModel> GetPcListFromDb()
        {
            return new List<PcModel>();
        }
        //WIP
        public PcModel GetPcFromDb(int id)
        {
            return new PcModel();
        }
        //WIP
        public void SetPcToDb(PcModel PC)
        {
            
        }
    }
}
