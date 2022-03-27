using System.Collections.Generic;
using MonkeyReport.ViewObject;

namespace MonkeyReport.Services
{
    public interface IMonkeysPerSpecieReportService
    {
        IEnumerable<MonkeyReportRow> Build();
    }
}