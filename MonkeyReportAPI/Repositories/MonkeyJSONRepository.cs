using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions.Configuration;
using MonkeyReport.DataObject;
using Newtonsoft.Json;

namespace MonkeyReport.Repositories
{
    public class MonkeyJSONRepository : IMonkeyRepository
    {
        private readonly IConfiguration config;

        public MonkeyJSONRepository(IConfiguration _config)
        {
            config=_config;
        }

        public List<Monkey> GetAll()
        {
            var monkeysJSONFile = config.GetValue<string>("MonkeyJSONLocation");

            using (var steamReader = new StreamReader(monkeysJSONFile))
            {
                var monkeysJSONString = steamReader.ReadToEnd();
                return JsonConvert.DeserializeObject<List<Monkey>>(monkeysJSONString);
            }
        }
    }
}