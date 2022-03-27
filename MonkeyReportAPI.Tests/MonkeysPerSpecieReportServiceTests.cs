using System.Collections.Generic;
using System.Linq;
using MonkeyReport.DataObject;
using MonkeyReport.Repositories;
using MonkeyReport.Services;
using Moq;
using NUnit.Framework;

namespace MonkeyReportTests
{
    public class MonkeysPerSpecieReportServiceTests
    {
        [Test]
        public void MonkeyJSONRepository_Counts_Properly_By_Specie()
        {
            var fakeMonkeyRepository = new Mock<IMonkeyRepository>();
            var fakeMonkeyList = new List<Monkey>()
            {
                new Monkey {species = "One"},
                new Monkey {species = "Two"},
                new Monkey {species = "Two"},
                new Monkey {species = "Three"},
                new Monkey {species = "Three"},
                new Monkey {species = "Three"},
            };

            fakeMonkeyRepository.Setup(x => x.GetAll()).Returns(fakeMonkeyList);

            var monkeysPerSpecieReport = new MonkeysPerSpecieReportService(fakeMonkeyRepository.Object);

            var report = monkeysPerSpecieReport.Build();

            Assert.AreEqual(report.Where(r => r.Species == "One").Select(r => r.Quantity).First(),1);
            Assert.AreEqual(report.Where(r => r.Species == "Two").Select(r => r.Quantity).First(), 2);
            Assert.AreEqual(report.Where(r => r.Species == "Three").Select(r => r.Quantity).First(), 3);
        }
    }
}