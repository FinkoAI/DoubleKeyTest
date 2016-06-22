using System.Collections.Generic;
using System.Linq;
using DoubleKeyCollection.Implementations;
using DoubleKeyCollection.Interfaces;
using TestApplication.UI.ViewModel.GridRecordsVm;

namespace TestApplication.UI.Model.TabModels
{
    /// <summary>
    /// Модель второй вкладки
    /// </summary>
    public class SecondTabModel
    {
        #region Private fields
        
        private readonly IDoubleKeyDictionary<int, string, string> _doubleKeyDictionary;

        #endregion

        #region Constructors

        public SecondTabModel()
        {
            _doubleKeyDictionary = new DoubleKeyDictionary<int, string, string>();
        }

        #endregion

        #region Public properties

        public List<SimpleTabGridRecordVm> Items
        {
            get
            {
                return
                    _doubleKeyDictionary.Select(x => new SimpleTabGridRecordVm(x.Key.Id, x.Key.Name, x.Value)).ToList();
            }
        }

        #endregion

        #region Public members

        public void AddRecord(int id, string name, string value)
        {
            _doubleKeyDictionary.Add(id, name, value);
        }

        public void RemoveRecord(int id, string name)
        {
            _doubleKeyDictionary.Remove(id, name);
        }

        public bool IsUniqueKey(int id, string name)
        {
            return !_doubleKeyDictionary.ContainsKey(id, name);
        }

        #endregion
    }
}
