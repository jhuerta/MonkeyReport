using System.Collections.Generic;
using System.Linq;
using MonkeyReport.Repositories;
using MonkeyReport.ViewObject;

namespace MonkeyReport.Services
{
    public class MonkeysPerSpecieReportService : IMonkeysPerSpecieReportService
    {
        private readonly IMonkeyRepository monkeyRepository;

        public MonkeysPerSpecieReportService(IMonkeyRepository _monkeyRepository)
        {
            monkeyRepository=_monkeyRepository;
        }

        public IEnumerable<MonkeyReportRow> Build()
        {
            var monkeys = monkeyRepository.GetAll(); ;
            return monkeys.GroupBy(monkey => monkey.species, (species, quantity) => new MonkeyReportRow()
            {
                Quantity=quantity.Count(),
                Species=species
            });
        }
    }
}