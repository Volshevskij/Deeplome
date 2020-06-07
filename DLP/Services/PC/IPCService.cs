using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DLP.ViewModels.PC;

namespace DLP.Services.PC
{
    public interface IPCService
    {
        IEnumerable<PcModel> GetPcListFromDb();
        PcModel GetPcFromDb(int id);
        void SetPcToDb(PcModel PC);
    }
}
