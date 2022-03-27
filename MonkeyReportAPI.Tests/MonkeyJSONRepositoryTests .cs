using Microsoft.Extensions.Configuration;
using MonkeyReport.DataObject;
using MonkeyReport.Repositories;
using NUnit.Framework;
using System.Collections.Generic;

namespace MonkeyReportTests
{
    public class MonkeyJSONRepositoryTests
    {
        private List<Monkey> monkeys;

        [SetUp]
        public void Setup()
        {

            var inMemorySettings = new Dictionary<string, string> {
                {"MonkeyJSONLocation", "./FakeMonkeyCollection.json"},
                {"AllowedHosts", "*" },
                {"Logging:LogLevel:Default", "Warning" }

            };

            IConfiguration configuration = new ConfigurationBuilder().AddInMemoryCollection(inMemorySettings).Build();

            var monkeyJSONRepository = new MonkeyJSONRepository(configuration);
            monkeys = monkeyJSONRepository.GetAll();
        }

        [Test]
        public void MonkeyJSONRepository_Reads_Full_File_Of_Data_Properly_From_Configuration_Interface()
        {
            Assert.AreEqual(monkeys.Count, 2);

            var monkeyMiguel=monkeys[0];
            Assert.AreEqual(monkeyMiguel._id, "1");
            Assert.AreEqual(monkeyMiguel.name, "Miguel");
            Assert.AreEqual(monkeyMiguel.eyeColor, "black");
            Assert.AreEqual(monkeyMiguel.species, "Boy");
        }

        [Test]
        public void MonkeyJSONRepository_Maps_Properly_Data_JSON_Database()
        {
            var monkeyMiguel = monkeys[0];
            Assert.AreEqual(monkeyMiguel._id, "1");
            Assert.AreEqual(monkeyMiguel.name, "Miguel");
            Assert.AreEqual(monkeyMiguel.eyeColor, "black");
            Assert.AreEqual(monkeyMiguel.species, "Boy");
        }

    }
}