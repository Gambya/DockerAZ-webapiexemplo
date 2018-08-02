using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApiCoreExemplo.Model;

namespace WebApiCoreExemplo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly MongoDB.Driver.MongoClient _mongoDbClient;

        public AboutController(MongoDB.Driver.MongoClient mongoDbClient)
        {
            _mongoDbClient = mongoDbClient;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<About> Get()
        {
            return new About{
                CommandLine = Environment.CommandLine,
                CurrentDirectory = Environment.CurrentDirectory,
                OSVersion = Environment.OSVersion.ToString(),
                MachineName = Environment.MachineName,
                UserName = Environment.UserName
            };
        }
    }
}
