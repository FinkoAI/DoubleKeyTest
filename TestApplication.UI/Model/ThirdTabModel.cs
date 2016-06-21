using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoubleKeyCollection.Implementations;
using DoubleKeyCollection.Interfaces;
using TestApplication.UI.Helpers;
using TestApplication.UI.ViewModel.GridRecordsVm;

namespace TestApplication.UI.Model
{
    public class ThirdTabModel
    {
        #region Private fields

        private readonly IDoubleKeyDictionary<UserIdType, string, string> _doubleKeyDictionary;

        #endregion

        #region Constructors

        public ThirdTabModel()
        {
            _doubleKeyDictionary = new DoubleKeyDictionary<UserIdType, string, string>();
        }

        #endregion

        #region Public properties

        public List<UserTypeKeyGridRecordVm> Items
        {
            get
            {
                return _doubleKeyDictionary.Select(
                    x => new UserTypeKeyGridRecordVm(x.Key.Id.Identifier, x.Key.Id.Size, x.Key.Name, x.Value)).ToList();
            }
        }

        #endregion

        #region Public methods

        public void GenerateRecords()
        {
            _doubleKeyDictionary.Clear();

            for (var i = 0; i < 1000; i++)
            {
                var identifier = (long)RandomHelper.RandomInt();
                var size = RandomHelper.RandomInt();
                var name = RandomHelper.RandomString(3);
                var value = RandomHelper.RandomString(10);

                var newId = new UserIdType(identifier, size);
                if (!_doubleKeyDictionary.ContainsKey(newId, name))
                    _doubleKeyDictionary.Add(newId, name, value);
            }
        }

        public List<string> FindById(long identifeir, int size)
        {
            return _doubleKeyDictionary.GetById(new UserIdType(identifeir, size)).ToList();
        }

        #endregion
    }
}
