using System.Collections.Generic;
using System.Linq;
using DoubleKeyCollection.Implementations;
using DoubleKeyCollection.Interfaces;
using TestApplication.UI.Helpers;
using TestApplication.UI.ViewModel.GridRecordsVm;

namespace TestApplication.UI.Model.TabModels
{
    /// <summary>
    /// Модель первой вкладки
    /// </summary>
    public class FirstTabModel
    {
        #region Private fields
        
        private IDoubleKeyDictionary<int, string, string> _testDictionary;

        #endregion

        #region Public methods

        public void InitilaizeData(int count)
        {
            _testDictionary = new DoubleKeyDictionary<int, string, string>();

            for (int i = 0; i < count; i++)
            {
                var id = RandomHelper.RandomInt();
                var name = RandomHelper.RandomString(5);
                var value = RandomHelper.RandomString(100);

                if (!_testDictionary.ContainsKey(id, name))
                    _testDictionary.Add(id, name, value);
            }
        }

        /// <summary>
        /// Получает все элементы коллекции в виде листа
        /// </summary>
        public List<SimpleTabGridRecordVm> Items
        {
            get
            {
                return _testDictionary.Select(x => new SimpleTabGridRecordVm(x.Key.Id, x.Key.Name, x.Value)).ToList();
            }
        }            

        /// <summary>
        /// Получает элементы отфильтрованные по ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<string> GetDataFilteredById(int id)
        {
            return _testDictionary.GetById(id).ToList();
        }

        /// <summary>
        /// Получает элементы отфильтрованные по Name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public List<string> GetDataFilteredByName(string name)
        {
            return _testDictionary.GetByName(name).ToList();
        }

        /// <summary>
        /// Получает элементы отфильтрованные по дввм ключам
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public List<string> GetDataFilteredByBoth(int id, string name)
        {
            string value;
            return _testDictionary.TryGetValue(id, name, out value) ? new List<string> {value} : new List<string>();
        }
        #endregion
    }
}
