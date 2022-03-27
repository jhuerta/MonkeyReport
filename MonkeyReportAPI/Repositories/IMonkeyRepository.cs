using System.Collections.Generic;
using MonkeyReport.DataObject;

namespace MonkeyReport.Repositories
{
    public interface IMonkeyRepository
    {
        List<Monkey> GetAll();
    }
}
