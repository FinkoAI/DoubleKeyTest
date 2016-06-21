using GalaSoft.MvvmLight;

namespace TestApplication.UI.ViewModel.GridRecordsVm
{
    public class FirstTabGridRecordVm : ViewModelBase
    {
        #region Private fields

        private int _id;
        private string _name;
        private string _value;

        #endregion

        #region Constructors

        public FirstTabGridRecordVm(int id, string name, string value)
        {
            Id = id;
            Name = name;
            Value = value;
        }

        #endregion

        #region Public members


        public int Id {
            get { return _id; }
            set { Set(() => Id, ref _id, value); }
        }

        public string Name
        {
            get { return _name; }
            set { Set(() => Name, ref _name, value); }
        }

        public string Value
        {
            get { return _value; }
            set { Set(() => Value, ref _value, value); }
        }

        #endregion
    }
}
