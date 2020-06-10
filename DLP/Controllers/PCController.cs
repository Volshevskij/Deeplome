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

        [HttpGet("PC/{id}")]
        public PcModel GetCatalog(int id)
        {
            return Service.GetPcFromDb(id);
        }

        [HttpPost("setPC")]
        public IActionResult SetPC([FromBody] PcModel pc)
        {
            Service.SetPcToDb(pc);
            return Ok();
        }

        [HttpGet("comparecorpusmotherboard/{firstRequestId}/{secondRequestId}")]
        public CompareMessage CompareCorpusMotherboard(int firstRequestId, int secondRequestId) {
            return Service.CompareCorpusMotherboard(firstRequestId, secondRequestId);
        }

        [HttpGet("comparemotherboardprocessor/{firstRequestId}/{secondRequestId}")]
        public CompareMessage CompareMotherboardProcessor(int firstRequestId, int secondRequestId) {
            return Service.CompareMotherboardProcessor(firstRequestId, secondRequestId);
        }

        [HttpPost("comparemotherboardram")]
        public CompareMessage CompareMotherboardRam([FromBody] CompareIdViewModel Ids) {
            return Service.CompareMotherboardRam(Ids.firstRequestId, Ids.ListRequestIds);
        }

        [HttpGet("compareprocesorcooler/{firstRequestId}/{secondRequestId}")]
        public CompareMessage CompareProcessorCooler(int firstRequestId, int secondRequestId) {
            return Service.CompareProcessorCooler(firstRequestId, secondRequestId);
        }

        [HttpGet("comparegpumotherboard/{firstRequestId}/{secondRequestId}")]
        public CompareMessage CompareGpuMotherboard(int firstRequestId, int secondRequestId) {
            return Service.CompareGpuMotherboard(firstRequestId, secondRequestId);
        }

        [HttpGet("comparegpupower/{firstRequestId}/{secondRequestId}")]
        public CompareMessage CompareGpuPower(int firstRequestId, int secondRequestId) {
            return Service.CompareGpuPower(firstRequestId, secondRequestId);
        }

        [HttpPost("compareall")]
        public IEnumerable<CompareMessage> CompareAll([FromBody] PcModel PC)
        {
            return Service.ComparePC(PC);
        }

        /*public IActionResult Index()
        {
            return View();
        }*/
    }
}
