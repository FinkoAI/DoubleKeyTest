using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.IO.Ports;
using System.Linq;
using DoubleKeyCollection.Implementations;
using TestApplication.UI.Helpers;
using TestApplication.UI.ViewModel.GridRecordsVm;

namespace TestApplication.UI.Model
{
    public class FirstTabModel
    {
        private DoubleKeyDictionary<int, string, string> _testDictionary;

        public void InitilaizeData(int count)
        {
            _testDictionary = new DoubleKeyDictionary<int, string, string>();

            for (int i = 0; i < count; i++)
            {
                var id = RandomHelper.RandomInt();
                var name = RandomHelper.RandomString(10);
                var value = RandomHelper.RandomString(100);

                if (!_testDictionary.ContainsKey(id, name))
                    _testDictionary.Add(id, name, value);
            }
        }


        public IEnumerable<FirstTabGridRecordVm> GetFullData()
        {
            return _testDictionary.Select(x => new FirstTabGridRecordVm(x.Key.Id, x.Key.Name, x.Value));
        }

        public List<string> GetDataFilteredById(int id)
        {
            return _testDictionary.GetById(id).ToList();
        }

        public List<string> GetDataFilteredByName(string name)
        {
            return _testDictionary.GetByName(name).ToList();
        }

        public List<string> GetDataFilteredByBoth(int id, string name)
        {
            string value;
            return _testDictionary.TryGetValue(id, name, out value) ? new List<string> {value} : new List<string>();
        }
    }
}
