using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DLP.Services.PC;
using DLP.ViewModels.PC;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace DLP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PCController : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;

        IPCService Service;

        private readonly ILogger<PCController> _logger;

        public PCController(IPCService service, ILogger<PCController> logger, IWebHostEnvironment hostingEnvironment)
        {
            Service = service;
            _logger = logger;
            _hostingEnvironment = hostingEnvironment;

        }

        [HttpGet("PCList")]
        public IEnumerable<PcModel> GetPCList()
        {
            return Service.GetPcListFromDb();
        }

        [HttpGet("PC")]
        public PcModel GetCatalog([FromBody] int id)
        {
            return Service.GetPcFromDb(id);
        }

        [HttpPost("setPC")]
        public IActionResult SetPC([FromBody] PcModel pc)
        {
            Service.SetPcToDb(pc);
            return Ok();
        }

        [HttpGet("comparecorpusmotherboard")]
        public CompareMessage CompareCorpusMotherboard([FromBody]int corpusId,[FromBody] int motherboardId) {
            return Service.CompareCorpusMotherboard(corpusId, motherboardId);
        }

        [HttpGet("comparemotherboardprocessor")]
        public CompareMessage CompareMotherboardProcessor([FromBody] int motherboardId, [FromBody] int processorId) {
            return Service.CompareMotherboardProcessor(motherboardId, processorId);
        }

        [HttpGet("comparemotherboardram")]
        public CompareMessage CompareMotherboardRam([FromBody] int motherboardId, [FromBody] List<int> ramId) {
            return Service.CompareMotherboardRam(motherboardId, ramId);
        }

        [HttpGet("compareprocesorcooler")]
        public CompareMessage CompareProcessorCooler([FromBody] int processorId, [FromBody] int coolerId) {
            return Service.CompareProcessorCooler(processorId, coolerId);
        }

        [HttpGet("comparegpumotherboard")]
        public CompareMessage CompareGpuMotherboard([FromBody] int gpuId, [FromBody] int motherboardId) {
            return Service.CompareGpuMotherboard(gpuId, motherboardId);
        }

        [HttpGet("comparegpupower")]
        public CompareMessage CompareGpuPower([FromBody] int gpuId, [FromBody] int powerId) {
            return Service.CompareGpuPower(gpuId, powerId);
        }


        /*public IActionResult Index()
        {
            return View();
        }*/
    }
}
