using System;
using System.Reflection;
using Microsoft.AspNetCore.Authorization;
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

        public InfoModel Get()
        {
            var information = ConfigurationController.GetInformation(_configuration);

            return new InfoModel(information.Title, information.Description, Assembly.GetEntryAssembly()?.GetName().Version?.ToString() ?? String.Empty);
        }
    }

    public record InfoModel(string Title, string Description, string Version);
}
