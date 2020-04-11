using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace KiwoomApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventController : ControllerBase
    {
        [HttpPost]
        public int? Post([FromBody] EventRequestBody body)
        {
            return Program.KiwoomCore?.AddUri(body.Name, body.Uri);
        }
    }

    public class EventRequestBody
    {
        public string Name { get; set; } = string.Empty;
        public string Uri { get; set; } = string.Empty;
    }
}