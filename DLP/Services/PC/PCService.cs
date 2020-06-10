using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DLP.Entities.PC;
using DLP.ViewModels.Hardwawre;
using DLP.Services.Catalog;
using DLP.ViewModels.PC;

namespace DLP.Services.PC
{
    public class PCService:IPCService
    {
        private PCContext db;
        private ICatalogService catalogService;
        public PCService(PCContext pcContext, ICatalogService service)
        {
            catalogService = service;
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
        
        public CompareMessage CompareCorpusMotherboard(int corpusId, int motherboardId)
        {
            HardwareViewModel corpus = catalogService.GetCorpusFromDb(corpusId);
            HardwareViewModel motherboard = catalogService.GetMotherboardFromDb(motherboardId);
            foreach(AttributeViewModel corpusAttribute in corpus.Attributes)
            {
                if(corpusAttribute.Name == "Форм-фактор материнской платы")
                {
                    foreach (AttributeViewModel motherboardAttribute in motherboard.Attributes)
                    {
                        if(motherboardAttribute.Name == "Форм-фактор" && corpusAttribute.value == motherboardAttribute.value)
                        {
                            return new CompareMessage() { Comparable = true, Message = "Материнская плата и корпус совместимы" };
                        }
                    }
                }
            }
            return new CompareMessage() { Comparable = false, Message = "Материнская плата и корпус несовместимы. Не совпадает форм фактор" };
        }
        
        public CompareMessage CompareMotherboardProcessor(int motherboardId, int processorId)
        {
            HardwareViewModel motherboard = catalogService.GetMotherboardFromDb(motherboardId);
            HardwareViewModel processor = catalogService.GetProcessorFromDb(processorId);
            foreach(AttributeViewModel motherboardAttribute in motherboard.Attributes)
            {
                if(motherboardAttribute.Name == "Сокет")
                {
                    foreach(AttributeViewModel processorAttribute in processor.Attributes)
                    {
                        if(processorAttribute.Name == "Сокет" && motherboardAttribute.value == processorAttribute.value)
                        {
                            return new CompareMessage() { Comparable = true, Message = "Материнская плата и процессор совместимы" };
                        }
                    }
                }
            }
            return new CompareMessage() { Comparable = false, Message = "Материнская плата и процессор несовместимы. Не совпадает сокет" };
        }
        
        public CompareMessage CompareMotherboardRam(int motherboardId, List<int> ramId)
        {
            HardwareViewModel motherboard = catalogService.GetMotherboardFromDb(motherboardId);
            List<HardwareViewModel> rams = new List<HardwareViewModel>();
            foreach (int i in ramId)
            {
                rams.Add(catalogService.GetRamFromDb(i));
            }
            foreach (AttributeViewModel motherboardAttribute in motherboard.Attributes)
            {
                if(motherboardAttribute.Name == "Тип памяти")
                {
                    foreach( HardwareViewModel ram in rams)
                    {
                        foreach( AttributeViewModel ramAttribute in ram.Attributes)
                        {
                            if(ramAttribute.Name == "Тип памяти" && ramAttribute.value != motherboardAttribute.value)
                            {
                                return new CompareMessage() { Comparable = false, Message = "Материнская плата и оперативная память несовместимы. Не совпадает используемый тип памяти" };
                            }
                        }
                    }
                }
                else if(motherboardAttribute.Name == "Количество слотов памяти")
                {
                    int count = 0;
                    foreach(HardwareViewModel ram in rams)
                    {
                        foreach(AttributeViewModel ramAttribute in ram.Attributes)
                        {
                            if( ramAttribute.Name == "Количество планок")
                            {
                                count += Convert.ToInt32(ramAttribute.value);
                                if (count > Convert.ToInt32(motherboardAttribute.value))
                                {
                                    return new CompareMessage() { Comparable = false, Message = "Материнская плата и оперативная память несовместимы. Недостаточно слотов памяти" };
                                }
                            }
                        }
                    }
                }
            }
            return new CompareMessage() { Comparable = true, Message = "Материнская плата и оперативная память совместимы" };
        }
        
        public CompareMessage CompareProcessorCooler(int processorId, int coolerId)
        {
            HardwareViewModel processor = catalogService.GetProcessorFromDb(processorId);
            HardwareViewModel cooler = catalogService.GetCoolerFromDb(coolerId);
            foreach(AttributeViewModel processorAttribute in processor.Attributes)
            {
                if(processorAttribute.Name == "Сокет")
                {
                    foreach(AttributeViewModel coolerAttribute in cooler.Attributes)
                    {
                        if(coolerAttribute.Name == "Сокет" && coolerAttribute.value != processorAttribute.value)
                        {
                            return new CompareMessage() { Comparable = false, Message = "Оохлаждение и процессор несовместимы. Не подходит сокет" };
                        }
                    }
                }
                else if(processorAttribute.Name == "Выделяемое тепло (Vt)")
                {
                    foreach (AttributeViewModel coolerAttribute in cooler.Attributes)
                    {
                        if (coolerAttribute.Name == "Рассеивание тепла (Vt)" && Convert.ToDouble(coolerAttribute.value) < Convert.ToDouble(processorAttribute.value))
                        {
                            return new CompareMessage() { Comparable = false, Message = "Риск перегрева вычислительного кристала" };
                        }
                    }
                }
            }
            return new CompareMessage() { Comparable = true, Message = "Оохлаждение и процессор совместимы" };
        }
        
        public CompareMessage CompareGpuMotherboard(int gpuId, int motherboardId)
        {
            HardwareViewModel motherboard = catalogService.GetMotherboardFromDb(motherboardId);
            HardwareViewModel gpu = catalogService.GetVideoFromDb(gpuId);
            foreach(AttributeViewModel motherboardAttribute in motherboard.Attributes)
            {
                if(motherboardAttribute.Name == "PCI слот")
                {
                    foreach(AttributeViewModel gpuAttribute in gpu.Attributes)
                    {
                        if(gpuAttribute.Name == "PCI слот" && gpuAttribute.value == motherboardAttribute.value)
                        {
                            return new CompareMessage() { Comparable = true, Message = "Видеокарта и материнская плата совместимы" };
                        }
                    }
                }
            }
            return new CompareMessage() { Comparable = false, Message = "Видеокарта и материнская плата несовместимы. Разные интерфейсы подключения" };
        }
        
        public CompareMessage CompareGpuPower(int gpuId, int powerId)
        {
            HardwareViewModel gpu = catalogService.GetVideoFromDb(gpuId);
            HardwareViewModel power = catalogService.GetPowerFromDb(powerId);
            foreach(AttributeViewModel gpuAttribute in gpu.Attributes)
            {
                if (gpuAttribute.Name == "")
                {
                    foreach(AttributeViewModel powerAttribute in power.Attributes)
                    {
                        if(powerAttribute.Name == "" && Convert.ToDouble(gpuAttribute.value) > Convert.ToDouble(gpuAttribute.value))
                        {
                            return new CompareMessage() { Comparable = false, Message = "Недостаточно мощности для видеокарты" };
                        }
                    }
                }
            }
            return new CompareMessage() { Comparable = false, Message = "Видеокарта достаточно обеспечена питанием" };
        }
    }
}
