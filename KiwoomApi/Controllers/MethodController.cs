using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using Newtonsoft.Json.Linq;

namespace KiwoomApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MethodController : ControllerBase
    {
        [HttpPost]
        public object? Post([FromBody] MethodRequestBody body)
        {
            string arrayString = body.Parameters.ToString();
            object?[]? parameters = JArray.Parse(arrayString == string.Empty ? "[]" : arrayString)
                .Select(token => token.ToObject<object>())
                .Select(obj => {
                    if (obj is Int64)
                        return Convert.ToInt32(obj);
                    else
                        return obj;
                })
                .ToArray();
            return Program.KiwoomCore?.Call(body.Name, parameters);
        }
    }

    public class MethodRequestBody
    {
        public string Name { get; set; } = string.Empty;
        public JsonElement Parameters { get; set; }
    }

    public class MethodParameters
    {
        public object?[]? Parameters { get; set; }
    }
}