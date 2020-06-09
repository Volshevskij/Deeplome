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
                    CoreFrequencyMHz = 3.8, 
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

        public HardwareViewModel GetProductFromDb(int id, string hardwareType)
        {
            HardwareViewModel hardware= new HardwareViewModel();
            switch (hardwareType)
            {
                case "Корпус":
                    List<Corpus> corpuses = db.Corpuses.ToList();
                    foreach (Corpus corpus in corpuses)
                    {
                        hardware = GetCorpusFromDb(corpus.Id);
                    }
                    break;
                case "Блок питания":
                    List<Power> powers = db.Powers.ToList();
                    foreach (Power power in powers)
                    {
                        hardware = GetPowerFromDb(power.Id);
                    }
                    break;
                case "Материнская плата":
                    List<Motherboard> motherboards = db.Motherboards.ToList();
                    foreach (Motherboard motherboard in motherboards)
                    {
                        hardware = GetMotherboardFromDb(motherboard.Id);
                    }
                    break;
                case "Процессор":
                    List<Processor> processors = db.Processors.ToList();
                    foreach (Processor processor in processors)
                    {
                        hardware = GetProcessorFromDb(processor.Id);
                    }
                    break;
                case "Оперативная память":
                    List<Ram> rams = db.RAMs.ToList();
                    foreach (Ram ram in rams)
                    {
                        hardware = GetRamFromDb(ram.Id);
                    }
                    break;
                case "Охлаждение":
                    List<Cooling> coolers = db.Coolers.ToList();
                    foreach (Cooling cooler in coolers)
                    {
                        hardware = GetCoolerFromDb(cooler.Id);
                    }
                    break;
                case "Видеокарта":
                    List<Video> gpus = db.GPUs.ToList();
                    foreach (Video gpu in gpus)
                    {
                        hardware = GetVideoFromDb(gpu.Id);
                    }
                    break;
            }
            return hardware;
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
            attributes.Add(new AttributeViewModel() { Name = "PCI слот", value = motherboard.PCIVersion });
            return new HardwareViewModel() { DBId = motherboard.Id, HardwareType = "Материнская плата", Name = motherboard.Name, Price = motherboard.Price, Description = motherboard.Description, MediaLink = motherboard.MediaLink, Attributes = attributes };
        }
        
        public HardwareViewModel GetProcessorFromDb(int id)
        {
            Processor processor = db.Processors.FirstOrDefault(data => data.Id == id);
            List<AttributeViewModel> attributes = new List<AttributeViewModel>();
            attributes.Add(new AttributeViewModel() { Name = "Сокет", value = processor.Socket });
            attributes.Add(new AttributeViewModel() { Name = "Количество ядер", value = Convert.ToString(processor.CoresQuantity) });
            attributes.Add(new AttributeViewModel() { Name = "Частота ядра (MHz)", value = Convert.ToString(processor.CoreFrequencyMHz) });
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
            return new HardwareViewModel() { DBId = gpu.Id, HardwareType = "Видеокарта", Name = gpu.Name, Description = gpu.Description, Price = gpu.Price, MediaLink = gpu.MediaLink, Attributes = attributes };
        }
        
        public void SetCorpusToDb(HardwareViewModel inputCorpus)
        {
            Corpus corpus = new Corpus() { Name = inputCorpus.Name, Description = inputCorpus.Description, Price = inputCorpus.Price, MediaLink = inputCorpus.MediaLink };
            foreach(AttributeViewModel atribute in inputCorpus.Attributes)
            {
                if(atribute.Name == "Материал")
                {
                    corpus.Material = atribute.value;
                }
                else if(atribute.Name == "Цвет")
                {
                    corpus.Color = atribute.value;
                }
                else if (atribute.Name == "Форм-фактор материнской платы")
                {
                    corpus.motherboardType = atribute.value;
                }
            }
            db.Corpuses.Add(corpus);
            db.SaveChanges();
        }
        
        public void SetPowerToDb(HardwareViewModel inputPower)
        {
            Power power = new Power() { Name = inputPower.Name, Description = inputPower.Description, Price = inputPower.Price, MediaLink = inputPower.MediaLink };
            foreach(AttributeViewModel attribute in inputPower.Attributes)
            {
                if(attribute.Name == "Генерируемая мощность (Vt)")
                {
                    power.GeneratePowerVt = Convert.ToDouble(attribute.value);
                }
            }
            db.Powers.Add(power);
            db.SaveChanges();
        }
        
        public void SetmotherboardToDb(HardwareViewModel inputmotherboard)
        {
            Motherboard motherboard = new Motherboard() { Name = inputmotherboard.Name, Description = inputmotherboard.Description, Price = inputmotherboard.Price, MediaLink = inputmotherboard.MediaLink };
            foreach(AttributeViewModel attribute in inputmotherboard.Attributes)
            {
                if (attribute.Name == "Сокет")
                {
                    motherboard.Socket = attribute.value;
                }
                else if (attribute.Name == "Форм-фактор")
                {
                    motherboard.MotherboardType = attribute.value;
                }
                else if (attribute.Name == "Количество слотов памяти")
                {
                    motherboard.RamMaxQuantity = Convert.ToInt32(attribute.value);
                }
                else if (attribute.Name == "Тип памяти")
                {
                    motherboard.MemoryType = attribute.value;
                }
                else if (attribute.Name == "Чипсет")
                {
                    motherboard.Chipset = attribute.value;
                }
                else if (attribute.Name == "PCI слот")
                {
                    motherboard.PCIVersion = attribute.value;
                }
            }
            db.Motherboards.Add(motherboard);
            db.SaveChanges();
        }
        
        public void SetProcessorToDb(HardwareViewModel inputProcessor)
        {
            Processor processor = new Processor() { Name = inputProcessor.Name, Description = inputProcessor.Description, Price = inputProcessor.Price, MediaLink = inputProcessor.MediaLink };
            foreach( AttributeViewModel attribute in inputProcessor.Attributes)
            {
                if( attribute.Name == "Сокет")
                {
                    processor.Socket = attribute.value;
                }
                else if( attribute.Name == "Количество ядер")
                {
                    processor.CoresQuantity = Convert.ToInt32(attribute.value);
                }
                else if (attribute.Name == "Частота ядра (MHz)")
                {
                    processor.CoreFrequencyMHz = Convert.ToDouble(attribute.value);
                }
                else if (attribute.Name == "Количество потокоов")
                {
                    processor.FlowsQuantity = Convert.ToInt32(attribute.value);
                }
                else if (attribute.Name == "Выделяемое тепло (Vt)")
                {
                    processor.HeatPowerVt = Convert.ToDouble(attribute.value);
                }
            }
            db.Processors.Add(processor);
            db.SaveChanges();
        }
        
        public void SetRamToDb(HardwareViewModel inputRam)
        {
            Ram ram = new Ram() { Name = inputRam.Name, Description = inputRam.Description, Price = inputRam.Price, MediaLink = inputRam.MediaLink };
            foreach(AttributeViewModel attribute in inputRam.Attributes)
            {
                if (attribute.Name == "Обьём (Gb)")
                {
                    ram.ValueGb = Convert.ToInt32(attribute.value);
                }
                else if (attribute.Name == "Количество планок")
                {
                    ram.Quantity = Convert.ToInt32(attribute.value);
                }
                else if (attribute.Name == "Тип памяти")
                {
                    ram.MemoryType = attribute.value;
                }
                else if (attribute.Name == "Частота памяти (MHz)")
                {
                    ram.MemoryFrequencyMHz = Convert.ToDouble(attribute.value);
                }
            }
            db.RAMs.Add(ram);
            db.SaveChanges();
        }
        
        public void SetCoolerToDb(HardwareViewModel inputCooling)
        {

            Cooling cooler = new Cooling() { Name = inputCooling.Name, Description = inputCooling.Description, Price = inputCooling.Price, MediaLink = inputCooling.MediaLink };
            foreach( AttributeViewModel attribute in inputCooling.Attributes)
            {
                if( attribute.Name == "Сокет")
                {
                    cooler.Socket = attribute.value;
                }
                else if(attribute.Name == "Рассеивание тепла (Vt)")
                {
                    cooler.HeatAbsorbingVt = Convert.ToDouble(attribute.value);
                }
            }
            db.Coolers.Add(cooler);
            db.SaveChanges();
        }
        
        public void SetVideoToDb(HardwareViewModel inputGpu)
        {
            Video gpu = new Video() { Name = inputGpu.Name, Description = inputGpu.Description, Price = inputGpu.Price, MediaLink = inputGpu.MediaLink };
            foreach(AttributeViewModel attribute in inputGpu.Attributes)
            {
                if (attribute.Name == "Тип памяти")
                {
                    gpu.MemoryType = attribute.value;
                }
                else if (attribute.Name == "Обьём (Gb)")
                {
                    gpu.ValueGb = Convert.ToInt32(attribute.value);
                }
                else if (attribute.Name == "PCI слот")
                {
                    gpu.PCIVersion = attribute.value;
                }
                else if (attribute.Name == "Частота памяти (MHz)")
                {
                    gpu.MemoryFrequencyMHz = Convert.ToDouble(attribute.value);
                }
                else if (attribute.Name == "Мощность (Vt)")
                {
                    gpu.PowerConsuptionVt = Convert.ToDouble(attribute.value);
                }
            }
            db.GPUs.Add(gpu);
            db.SaveChanges();
        }
        
        //main method that insert unrecognized object. He request other methods for inputing recognized object.
        public void SetProductToDb(HardwareViewModel product)
        {
            switch (product.HardwareType)
            {
                case "Корпус":
                    SetCorpusToDb(product);
                    break;
                case "Блок питания":
                    SetPowerToDb(product);
                    break;
                case "Материнская плата":
                    SetmotherboardToDb(product);
                    break;
                case "Процессор":
                    SetProcessorToDb(product);
                    break;
                case "Оперативная память":
                    SetRamToDb(product);
                    break;
                case "Охлаждение":
                    SetCoolerToDb(product);
                    break;
                case "Видеокарта":
                    SetVideoToDb(product);
                    break;
            }
        }
    }
}
