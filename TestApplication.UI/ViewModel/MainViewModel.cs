using GalaSoft.MvvmLight;
using TestApplication.UI.ViewModel.TabVms;

namespace TestApplication.UI.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        #region Privates

        private FirstTabViewModel _firstTabVm;

        #endregion

        #region Public properties
        public FirstTabViewModel FirstTabVm
        {
            get { return _firstTabVm; }
            set { Set(() => FirstTabVm, ref _firstTabVm, value); }
        }
        #endregion

        #region Constructor

        public MainViewModel()
        {
            FirstTabVm = new FirstTabViewModel();
        }

        #endregion
    }
}
