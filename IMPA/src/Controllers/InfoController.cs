using System;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace IMPA
{
    [ApiController]
    [Route("[Controller]")]
    public class InfoController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public InfoController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public InfoResult GetInfo()
        {
            var information = ConfigurationController.GetInformation(_configuration);

            return new InfoResult(information.Title, information.Description, Assembly.GetEntryAssembly()?.GetName().Version?.ToString() ?? "Unkown");
        }
    }
}
