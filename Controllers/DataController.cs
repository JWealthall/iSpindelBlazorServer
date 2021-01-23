using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iSpindelBlazorServer.Data;
using iSpindelBlazorServer.Models;
using Microsoft.Extensions.Logging;

namespace iSpindelBlazorServer.Controllers
{
    [Route("[controller]")]
    public class DataController : ControllerBase
    {
        //private readonly LogDbContext _context;
        private readonly ILogger<DataController> _logger;
        private readonly LogDbService _logDb;

        public DataController(ILogger<DataController> logger, LogDbContext context)
        {
            _logger = logger;
            _logDb = new LogDbService(context);
            //_context = context;
        }

        [HttpGet]
        [Route("HelloWorld")]
        public async Task<ActionResult<string>> HelloWorld()
        {
            return "Hello World!";
        }

        [HttpPost]
        [Route("Log")]
        public async Task<ActionResult<bool>> Log(SpindelLog data)
        {
            return await _logDb.Log(data);
        }

    }

}
