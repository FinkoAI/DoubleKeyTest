using GalaSoft.MvvmLight;

namespace TestApplication.UI.ViewModel.GridRecordsVm
{
    /// <summary>
    /// ViewModel записи грида с пользовательским ключом Id
    /// </summary>
    public class UserTypeKeyGridRecordVm : ViewModelBase
    {
        #region Private fields

        private long _identifier;
        private int _size;
        private string _name;
        private string _value;

        #endregion

        #region Properties
        /// <summary>
        /// Идентификатор
        /// </summary>
        public long Identifier
        {
            get { return _identifier; }
            set { Set(() => Identifier, ref _identifier, value); }
        }

        /// <summary>
        /// Размер
        /// </summary>
        public int Size
        {
            get { return _size; }
            set { Set(() => Size, ref _size, value); }
        }

        /// <summary>
        /// Имя
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { Set(() => Name, ref _name, value); }
        }

        /// <summary>
        /// Значение
        /// </summary>
        public string Value
        {
            get { return _value; }
            set { Set(() => Value, ref _value, value); }
        }
        #endregion

        #region Constructors

        public UserTypeKeyGridRecordVm(long identifier, int size, string name, string value)
        {
            Identifier = identifier;
            Size = size;
            Name = name;
            Value = value;
        }

        #endregion
    }
}
