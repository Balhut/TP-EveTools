using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TP_EveTools.Infrastructure.Commands;
using TP_EveTools.Infrastructure.Commands.LocalScan;
using TP_EveTools.Infrastructure.Fetchers;
using TP_EveTools.Infrastructure.Services;

namespace TP_EveTools.Infrastructure.Handlers.LocalScan
{
    public class AddLocalScanHandler : ICommandHandler<AddLocalScan>
    {
        private readonly ILocalScanService _localScanService;

        public AddLocalScanHandler(ILocalScanService localScanService)
        {
            _localScanService = localScanService;
        }
        public async Task HandleAsync(AddLocalScan command)
        {
            string[] chars = Regex.Replace(command.content, @"<[^>]+>|", "").Trim().Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
            var charlist = new HashSet<string>();

            foreach (var s in chars)
            {
                charlist.Add(s);
            }

            var localscan = EsiFetcher.ReturnFormattedLocalScan(EsiFetcher.ReturnBasicCharacters(charlist), command.id);

            await _localScanService.AddAsync(localscan);
        }
    }
}