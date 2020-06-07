using System;
using System.Collections.Generic;
using System.Linq;
using DLP.ViewModels.Hardwawre;
using DLP.Entities.Catalog;
using System.Threading.Tasks;

namespace DLP.Services.Catalog
{
    public class CatalogService:ICatalogService
    {
        CatalogContext db;
        public CatalogService(CatalogContext catalogContext)
        {
            db = catalogContext;
        }
        //WIP
        public IEnumerable<HardwareViewModel> GetCatalog()
        {
            return new List<HardwareViewModel>();
        }
        //WIP
        public HardwareViewModel GetCorpusFromDb(int id)
        {
            return new HardwareViewModel();
        }
        //WIP
        public HardwareViewModel GetPowerFromDb(int id)
        {
            return new HardwareViewModel();
        }
        //WIP
        public HardwareViewModel GetMotherboardFromDb(int id)
        {
            return new HardwareViewModel();
        }
        //WIP
        public HardwareViewModel GetProcessorFromDb(int id)
        {
            return new HardwareViewModel();
        }
        //WIP
        public HardwareViewModel GetRamFromDb(int id)
        {
            return new HardwareViewModel();
        }
        //WIP
        public HardwareViewModel GetCoolerFromDb(int id)
        {
            return new HardwareViewModel();
        }
        //WIP
        public HardwareViewModel GetVideoFromDb(int id)
        {
            return new HardwareViewModel();
        }
        //WIP
        public void SetCorpusToDb(HardwareViewModel inputCorpus)
        {

        }
        //WIP
        public void SetPowerToDb(HardwareViewModel inputPower)
        {

        }
        //WIP
        public void SetmotherboardToDb(HardwareViewModel inputmotherboard)
        {

        }
        //WIP
        public void SetProcessorToDb(HardwareViewModel inputProcessor)
        {

        }
        //WIP
        public void SetRamToDb(HardwareViewModel inputRam)
        {

        }
        //WIP
        public void SetCoolerToDb(HardwareViewModel inputCooling)
        {

        }
        //WIP
        public void SetVideoToDb(HardwareViewModel inputVideo)
        {

        }
        //WIP
        //main method that insert unrecognized object. He request other object for inputing recognized object.
        public void SetProductToDb(HardwareViewModel product)
        {

        }
    }
}
