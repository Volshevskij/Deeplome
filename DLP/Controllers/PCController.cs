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
        public CompareMessage CompareCorpusMotherboard([FromBody] CompareIdViewModel Ids) {
            return Service.CompareCorpusMotherboard(Ids.firstRequestId, Ids.secondRequestId);
        }

        [HttpGet("comparemotherboardprocessor")]
        public CompareMessage CompareMotherboardProcessor([FromBody] CompareIdViewModel Ids) {
            return Service.CompareMotherboardProcessor(Ids.firstRequestId, Ids.secondRequestId);
        }

        [HttpGet("comparemotherboardram")]
        public CompareMessage CompareMotherboardRam([FromBody] CompareIdViewModel Ids) {
            return Service.CompareMotherboardRam(Ids.firstRequestId, Ids.ListRequestIds);
        }

        [HttpGet("compareprocesorcooler")]
        public CompareMessage CompareProcessorCooler([FromBody] CompareIdViewModel Ids) {
            return Service.CompareProcessorCooler(Ids.firstRequestId, Ids.secondRequestId);
        }

        [HttpGet("comparegpumotherboard")]
        public CompareMessage CompareGpuMotherboard([FromBody] CompareIdViewModel Ids) {
            return Service.CompareGpuMotherboard(Ids.firstRequestId, Ids.secondRequestId);
        }

        [HttpGet("comparegpupower")]
        public CompareMessage CompareGpuPower([FromBody] CompareIdViewModel Ids) {
            return Service.CompareGpuPower(Ids.firstRequestId, Ids.secondRequestId);
        }


        /*public IActionResult Index()
        {
            return View();
        }*/
    }
}
