using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DLP.Services.Catalog;
using DLP.ViewModels.Hardwawre;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace DLP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : Controller
    {

        private readonly IWebHostEnvironment _hostingEnvironment;

        ICatalogService Service;

        private readonly ILogger<CatalogController> _logger;

        public CatalogController(ICatalogService service, ILogger<CatalogController> logger, IWebHostEnvironment hostingEnvironment)
        {
            Service = service;
            _logger = logger;
            _hostingEnvironment = hostingEnvironment;

        }

        [HttpGet("catalog")]
        public IEnumerable<HardwareViewModel> GetCatalog()
        {
            return Service.GetCatalog();
        }

        [HttpGet("getProduct")]
        public HardwareViewModel GetProduct([FromBody]int id, string hardwareType)
        {
            return Service.GetProductFromDb(id, hardwareType);
        }


        [HttpPost("setProduct")]
        public IActionResult SetProduct([FromBody] HardwareViewModel product)
        {
            Service.SetProductToDb(product);
            return Ok();
        }

       /* public IActionResult Index()
        {
            return View();
        }*/
    }
}
