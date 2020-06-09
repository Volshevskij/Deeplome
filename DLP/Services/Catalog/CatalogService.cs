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
            if (!db.Corpuses.Any())
            {
                db.Corpuses.Add(new Corpus() { 
                    Name = "Cooler Master MasterBox Lite 5 RGB MCW-L5S3-KGNN-02",
                    Description = "Midi Tower, блок питания отсутствует, для плат ATX/micro-ATX/mini-ITX, 4 вентилятора, 2xUSB 3.0, цвет черный",
                    Price = 0, 
                    MediaLink = "https://diplomawp.000webhostapp.com/wp-content/uploads/2020/05/6e11583a619c6751cdaa5d520a8ee9bc.jpeg",
                    Material = "Стекло, Сталь",
                    Color = "Чёрный",
                    motherboardType = "ATX" });
                db.SaveChanges();
            }
            if (!db.Powers.Any())
            {
                db.Powers.Add(new Power() { 
                    Name = "Chieftec Power Smart GPS-750C",
                    Description = "Активная PFC, КПД 90%, золотой сертификат, вентилятор 1x140 мм, модульные кабели, 12V 62 А",
                    Price = 0,
                    MediaLink = "https://diplomawp.000webhostapp.com/wp-content/uploads/2020/05/8a4860dbe9b72aca8c619782f0a7f538.jpeg",
                    GeneratePowerVt = 750 });
                db.SaveChanges();
            }
            if (!db.Motherboards.Any())
            {
                db.Motherboards.Add(new Motherboard() { 
                    Name = "MSI B450 Tomahawk Max", 
                    Description = "ATX, сокет AMD AM4, чипсет AMD B450, память 4xDDR4, слоты: 2xPCIe x16, 3xPCIe x1, 1xM.2", 
                    Price = 0, 
                    MediaLink = "https://diplomawp.000webhostapp.com/wp-content/uploads/2020/05/6cf4b0c281ebe951ece68dd07c23689f.jpeg",
                    Chipset = "B450", 
                    MemoryType = "DDR4", 
                    MotherboardType = "ATX", 
                    PCIVersion = "Express x16 3.0", 
                    RamMaxQuantity = 4, 
                    Socket = "AM4" });
                db.SaveChanges();
            }
            if (!db.Processors.Any())
            {
                db.Processors.Add(new Processor() { 
                    Name = "AMD Ryzen 3 3300X", 
                    Description = "Matisse, AM4, 4 ядра, частота 4.3/3.8 ГГц, кэш 2 МБ + 16 МБ, техпроцесс 7 нм, TDP 65W", 
                    Price = 0, 
                    MediaLink = "https://diplomawp.000webhostapp.com/wp-content/uploads/2020/05/12122.jpeg", 
                    CoreFrequencyHz = 3.8, 
                    CoresQuantity = 4, 
                    FlowsQuantity = 8, 
                    HeatPowerVt = 65, 
                    Socket = "AM4" });
                db.SaveChanges();
            }
            if (!db.Coolers.Any())
            {
                db.Coolers.Add(new Cooling() { 
                    Name = "Xilence M403.PRO XC029",
                    Description = "Кулер для процессора, алюминий, рассеивание до 150 Вт, шум 25.6 дБ, вентилятор 120 мм, 1800 об/мин, PWM",
                    Price = 0,
                    MediaLink = "https://diplomawp.000webhostapp.com/wp-content/uploads/2020/05/22.jpeg", 
                    Socket = "AM4", 
                    HeatAbsorbingVt = 150 });
                db.SaveChanges();
            }
            if (!db.RAMs.Any())
            {
                db.RAMs.Add(new Ram() { 
                    Name = "HyperX Fury 2x8GB DDR4 PC4-21300 HX426C16FB3K2/16",
                    Description = "2 модуля, частота 2666 МГц, CL 16T, тайминги 16-18-18, напряжение 1.2 В",
                    Price = 0, 
                    MediaLink = "https://diplomawp.000webhostapp.com/wp-content/uploads/2020/05/e0c45380b888343513fc2554073272be.jpeg", 
                    MemoryFrequencyMHz = 26666, 
                    MemoryType = "DDR4", 
                    Quantity = 2,
                    ValueGb = 16 });
                db.SaveChanges();
            }
            if (!db.GPUs.Any())
            {
                db.GPUs.Add(new Video() { 
                    Name = "Gigabyte GeForce GTX 1660 Super Gaming OC 6GB GDDR6", 
                    Description = "NVIDIA GeForce GTX 1660 Super, базовая частота 1530 МГц, Turbo-частота 1860 МГц, 1408sp, частота памяти 3500 МГц, 192 бит, доп. питание: 8 pin, 2 слота, HDMI, DisplayPort", 
                    Price = 0, 
                    MediaLink = "https://diplomawp.000webhostapp.com/wp-content/uploads/2020/05/bc3ee68f0802292dec70521b5bb1543e.jpeg", 
                    MemoryFrequencyMHz = 3500, 
                    MemoryType = "GDDR6", 
                    PCIVersion = "Express x16 3.0", 
                    PowerConsuptionVt = 450,
                    ValueGb = 6 });
                db.SaveChanges();
            }
        }
        
        public IEnumerable<HardwareViewModel> GetCatalog()
        {
            List<HardwareViewModel> hardwares = new List<HardwareViewModel>();
            List<Corpus> corpuses = db.Corpuses.ToList();
            foreach( Corpus corpus in corpuses)
            {
                hardwares.Add(GetCorpusFromDb(corpus.Id));
            }
            List<Power> powers = db.Powers.ToList();
            foreach( Power power in powers)
            {
                hardwares.Add(GetPowerFromDb(power.Id));
            }
            List<Motherboard> motherboards = db.Motherboards.ToList();
            foreach( Motherboard motherboard in motherboards)
            {
                hardwares.Add(GetMotherboardFromDb(motherboard.Id));
            }
            List<Processor> processors = db.Processors.ToList();
            foreach(Processor processor in processors)
            {
                hardwares.Add(GetProcessorFromDb(processor.Id));
            }
            List<Cooling> coolers = db.Coolers.ToList();
            foreach(Cooling cooler in coolers)
            {
                hardwares.Add(GetCoolerFromDb(cooler.Id));
            }
            List<Ram> rams = db.RAMs.ToList();
            foreach(Ram ram in rams)
            {
                hardwares.Add(GetRamFromDb(ram.Id));
            }
            List<Video> gpus = db.GPUs.ToList();
            foreach(Video gpu in gpus)
            {
                hardwares.Add(GetVideoFromDb(gpu.Id));
            }
            return hardwares;
        }

        public HardwareViewModel GetCorpusFromDb(int id)
        {
            Corpus corpus = db.Corpuses.FirstOrDefault(data => data.Id == id);
            List<AttributeViewModel> attributes = new List<AttributeViewModel>();
            attributes.Add(new AttributeViewModel() { Name = "Материал", value = corpus.Material });
            attributes.Add(new AttributeViewModel() { Name = "Цвет", value = corpus.Color });
            attributes.Add(new AttributeViewModel() { Name = "Форм-фактор материнской платы", value = corpus.motherboardType });
            return new HardwareViewModel() { DBId = corpus.Id, HardwareType="Корпус", Name = corpus.Name, Price = corpus.Price, Description = corpus.Description, MediaLink = corpus.MediaLink, Attributes = attributes };
        }

        public HardwareViewModel GetPowerFromDb(int id)
        {
            Power power = db.Powers.FirstOrDefault(data => data.Id == id);
            List<AttributeViewModel> attributes = new List<AttributeViewModel>();
            attributes.Add(new AttributeViewModel() { Name = "Генерируемая мощность (Vt)", value = Convert.ToString(power.GeneratePowerVt) });
            return new HardwareViewModel() { DBId = power.Id, HardwareType = "Блок питания", Name = power.Name, Description= power.Description, Price = power.Price, MediaLink = power.MediaLink, Attributes = attributes };
        }
        
        public HardwareViewModel GetMotherboardFromDb(int id)
        {
            Motherboard motherboard = db.Motherboards.FirstOrDefault(data => data.Id == id);
            List<AttributeViewModel> attributes = new List<AttributeViewModel>();
            attributes.Add(new AttributeViewModel() { Name = "Сокет", value = motherboard.Socket});
            attributes.Add(new AttributeViewModel() { Name = "Форм-фактор", value = motherboard.MotherboardType });
            attributes.Add(new AttributeViewModel() { Name = "Количество слотов памяти", value = Convert.ToString(motherboard.RamMaxQuantity) });
            attributes.Add(new AttributeViewModel() { Name = "Тип памяти", value = motherboard.MemoryType });
            attributes.Add(new AttributeViewModel() { Name = "Чипсет", value = motherboard.Chipset });
            return new HardwareViewModel() { DBId = motherboard.Id, HardwareType = "Материнская плата", Name = motherboard.Name, Price = motherboard.Price, Description = motherboard.Description, MediaLink = motherboard.MediaLink, Attributes = attributes };
        }
        
        public HardwareViewModel GetProcessorFromDb(int id)
        {
            Processor processor = db.Processors.FirstOrDefault(data => data.Id == id);
            List<AttributeViewModel> attributes = new List<AttributeViewModel>();
            attributes.Add(new AttributeViewModel() { Name = "Сокет", value = processor.Socket });
            attributes.Add(new AttributeViewModel() { Name = "Количество ядер", value = Convert.ToString(processor.CoresQuantity) });
            attributes.Add(new AttributeViewModel() { Name = "Частота ядра", value = Convert.ToString(processor.CoreFrequencyHz) });
            attributes.Add(new AttributeViewModel() { Name = "Количество потокоов", value = Convert.ToString(processor.FlowsQuantity) });
            attributes.Add(new AttributeViewModel() { Name = "Выделяемое тепло (Vt)", value = Convert.ToString(processor.HeatPowerVt) });
            return new HardwareViewModel() { DBId = processor.Id, HardwareType = "Процессор", Name = processor.Name, Description = processor.Description, Price = processor.Price, MediaLink = processor.MediaLink, Attributes = attributes };
        }
        
        public HardwareViewModel GetRamFromDb(int id)
        {
            Ram ram = db.RAMs.FirstOrDefault(data => data.Id == id);
            List<AttributeViewModel> attributes = new List<AttributeViewModel>();
            attributes.Add(new AttributeViewModel() { Name = "Обьём (Gb)", value = Convert.ToString(ram.ValueGb) });
            attributes.Add(new AttributeViewModel() { Name = "Количество планок", value = Convert.ToString(ram.Quantity) });
            attributes.Add(new AttributeViewModel() { Name = "Тип памяти", value = ram.MemoryType });
            attributes.Add(new AttributeViewModel() { Name = "Частота памяти (MHz)", value = Convert.ToString(ram.MemoryFrequencyMHz) });
            return new HardwareViewModel() { DBId = ram.Id, HardwareType = "Оперативная память", Name = ram.Name, Description = ram.Description, Price = ram.Price, MediaLink = ram.MediaLink, Attributes = attributes };
        }
        
        public HardwareViewModel GetCoolerFromDb(int id)
        {
            Cooling cooler = db.Coolers.FirstOrDefault(data => data.Id == id);
            List<AttributeViewModel> attributes = new List<AttributeViewModel>();
            attributes.Add(new AttributeViewModel() { Name = "Сокет", value = cooler.Socket });
            attributes.Add(new AttributeViewModel() { Name = "Рассеивание тепла (Vt)", value = Convert.ToString(cooler.HeatAbsorbingVt) });
            return new HardwareViewModel() { DBId = cooler.Id, HardwareType = "Охлаждение", Name = cooler.Name, Description = cooler.Description, Price = cooler.Price, MediaLink = cooler.MediaLink, Attributes = attributes };
        }
        
        public HardwareViewModel GetVideoFromDb(int id)
        {
            Video gpu = db.GPUs.FirstOrDefault(data => data.Id == id);
            List<AttributeViewModel> attributes = new List<AttributeViewModel>();
            attributes.Add(new AttributeViewModel() { Name = "Тип памяти", value = gpu.MemoryType });
            attributes.Add(new AttributeViewModel() { Name = "Обьём (Gb)", value = Convert.ToString(gpu.ValueGb) });
            attributes.Add(new AttributeViewModel() { Name = "PCI слот", value = gpu.PCIVersion });
            attributes.Add(new AttributeViewModel() { Name = "Частота памяти (MHz)", value = Convert.ToString(gpu.MemoryFrequencyMHz) });
            attributes.Add(new AttributeViewModel() { Name = "Мощность (Vt)", value = Convert.ToString(gpu.PowerConsuptionVt) });
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
