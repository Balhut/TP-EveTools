using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TP_EveTools.Infrastructure.Commands;
using TP_EveTools.Infrastructure.Commands.DScan;
using TP_EveTools.Infrastructure.Services;
using System.Threading.Tasks;

namespace TP_EveTools.Infrastructure.Handlers.DScan
{
    public class AddDScanHandler : ICommandHandler<AddDScan>
    {
        private readonly IDScanService _dScanService;

        public AddDScanHandler(IDScanService dScanService)
        {
            _dScanService = dScanService;
        }
        public async Task HandleAsync(AddDScan command)
        {
            string[] chars = Regex.Replace(command.content, @"<[^>]+>|", "").Trim().Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
            var charlist = new HashSet<string>();

            foreach (var s in chars)
            {
                charlist.Add(s);
            }
            var dscan = new TP_EveTools.Core.Domain.DScan();

            await _dScanService.AddAsync(dscan);
        }
    }
}