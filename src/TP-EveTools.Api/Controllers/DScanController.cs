using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using shortid;
using TP_EveTools.Infrastructure.Commands;
using TP_EveTools.Infrastructure.Commands.DScan;
using TP_EveTools.Infrastructure.Services;

namespace TP_EveTools.Api.Controllers
{
    [Route("api/[controller]")]
    public class DScanController : Controller
    {
        private readonly IDScanService _dScanService;
        private readonly ICommandDispatcher _commandDispatcher;
        public DScanController(ICommandDispatcher commandDispatcher, IDScanService dScanService)
        {
            _dScanService = dScanService;
            _commandDispatcher = commandDispatcher;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var dScan = await _dScanService.GetAsync(id);

            return Json(dScan);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]AddDScan command)
        {
            command.id = ShortId.Generate(true);
            await _commandDispatcher.DispatchAsync(command);
            var obj = new { id = command.id };

            return Json(obj);
        }
    }
}