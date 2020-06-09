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


        /*public IActionResult Index()
        {
            return View();
        }*/
    }
}
