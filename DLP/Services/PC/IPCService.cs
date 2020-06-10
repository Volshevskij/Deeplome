using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DLP.ViewModels.PC;
using DLP.ViewModels.Hardwawre;

namespace DLP.Services.PC
{
    public interface IPCService
    {
        IEnumerable<PcModel> GetPcListFromDb();
        PcModel GetPcFromDb(int id);
        void SetPcToDb(PcModel PC);
        CompareMessage CompareCorpusMotherboard(int corpusId, int motherboardId);
        CompareMessage CompareMotherboardProcessor(int motherboardId, int processorId);
        CompareMessage CompareMotherboardRam(int motherboardId, List<int> ramId);
        CompareMessage CompareProcessorCooler(int processorId, int coolerId);
        CompareMessage CompareGpuMotherboard(int gpuId, int motherboardId);
        CompareMessage CompareGpuPower(int gpuId, int powerId);
    }
}
