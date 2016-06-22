using GalaSoft.MvvmLight;

namespace TestApplication.UI.ViewModel.DialogVms
{
    /// <summary>
    /// ViewModel диалога добавления записи
    /// </summary>
    public class AddRecordDialogVm : ViewModelBase
    {
        #region Private fields

        private int _id;
        private string _name;
        private string _value;

        #endregion

        #region Properties

        /// <summary>
        /// ID записи
        /// </summary>
        public int Id
        {
            get { return _id; }
            set { Set(() => Id, ref _id, value); }
        }

        /// <summary>
        /// Имя записи
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { Set(() => Name, ref _name, value); }
        }

        /// <summary>
        /// Значение записи
        /// </summary>
        public string Value
        {
            get { return _value; }
            set { Set(() => Value, ref _value, value); }
        }

        #endregion

    }
}
