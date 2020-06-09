using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DLP.ViewModels.Hardwawre;

namespace DLP.Services.Catalog
{
    public interface ICatalogService
    {
        IEnumerable<HardwareViewModel> GetCatalog();
        HardwareViewModel GetProductFromDb(int id, string hardWareType);
        HardwareViewModel GetCorpusFromDb(int id);
        HardwareViewModel GetPowerFromDb(int id);
        HardwareViewModel GetMotherboardFromDb(int id);
        HardwareViewModel GetProcessorFromDb(int id);
        HardwareViewModel GetRamFromDb(int id);
        HardwareViewModel GetCoolerFromDb(int id);
        HardwareViewModel GetVideoFromDb(int id);
        void SetCorpusToDb(HardwareViewModel inputCorpus);
        void SetPowerToDb(HardwareViewModel inputPower);
        void SetmotherboardToDb(HardwareViewModel inputmotherboard);
        void SetProcessorToDb(HardwareViewModel inputProcessor);
        void SetRamToDb(HardwareViewModel inputRam);
        void SetCoolerToDb(HardwareViewModel inputCooling);
        void SetVideoToDb(HardwareViewModel inputVideo);
        //main method that insert unrecognized object. He request other object for inputing recognized object.
        void SetProductToDb(HardwareViewModel product);



    }
}
