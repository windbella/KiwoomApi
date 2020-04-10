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
    public class CommConnectController : ControllerBase
    {
        [HttpGet]
        public int Get()
        {
            return Program.KiwoomCore.CommConnect();
        }
    }
}
