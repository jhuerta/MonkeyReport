using Microsoft.AspNetCore.Mvc;
using MonkeyReport.Services;
using MonkeyReport.ViewObject;
using System.Collections.Generic;
using System.Linq;

namespace MonkeyReport.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MonkeyReportController : ControllerBase
    {
        private readonly IMonkeysPerSpecieReportService  monkeysPerSpecieReportService;

        public MonkeyReportController(IMonkeysPerSpecieReportService _monkeysPerSpecieReportService)
        {
            monkeysPerSpecieReportService=_monkeysPerSpecieReportService;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<MonkeyReportRow> Get()
        {
            var monkeys = monkeysPerSpecieReportService.Build();
            return monkeys.ToArray();
        }
    }
}
