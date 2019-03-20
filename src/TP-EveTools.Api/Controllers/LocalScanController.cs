using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using shortid;
using TP_EveTools.Infrastructure.Commands;
using TP_EveTools.Infrastructure.Commands.LocalScan;
using TP_EveTools.Infrastructure.Services;

namespace TP_EveTools.Api.Controllers
{
    [Route("api/[controller]")]
    public class LocalScanController : Controller
    {
        private readonly ILocalScanService _localScanService;
        private readonly ICommandDispatcher _commandDispatcher;
        public LocalScanController(ICommandDispatcher commandDispatcher, ILocalScanService localScanService)
        {
            _localScanService = localScanService;
            _commandDispatcher = commandDispatcher;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id){
            var localScan = await _localScanService.GetAsync(id);
            
            return Json(localScan);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]AddLocalScan command)
        {
            command.id = ShortId.Generate(true);
            await _commandDispatcher.DispatchAsync(command);

            return Redirect($"/LocalScan/{command.id}");
        }
    }
}