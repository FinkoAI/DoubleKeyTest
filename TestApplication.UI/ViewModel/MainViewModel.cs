using GalaSoft.MvvmLight;
using TestApplication.UI.ViewModel.TabVms;

namespace TestApplication.UI.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        #region Privates

        private FirstTabViewModel _firstTabVm;
        private SecondTabViewModel _secondTabVm;
        private ThirdTabViewModel _thirdTabVm;

        #endregion

        #region Public properties

        /// <summary>
        /// ViewMOdel для первой вкладки
        /// </summary>
        public FirstTabViewModel FirstTabVm
        {
            get { return _firstTabVm; }
            set { Set(() => FirstTabVm, ref _firstTabVm, value); }
        }

        /// <summary>
        /// ViewModel для второй вкладки
        /// </summary>
        public SecondTabViewModel SecondTabVm
        {
            get { return _secondTabVm; }
            set { Set(() => SecondTabVm, ref _secondTabVm, value); }
        }

        /// <summary>
        /// View model для третьей вкладки
        /// </summary>
        public ThirdTabViewModel ThirdTabVm
        {
            get { return _thirdTabVm; }
            set { Set(() => ThirdTabVm, ref _thirdTabVm, value); }
        }

        #endregion

        #region Constructor

        public MainViewModel()
        {
            FirstTabVm = new FirstTabViewModel();
            SecondTabVm = new SecondTabViewModel();
            ThirdTabVm = new ThirdTabViewModel();
        }

        #endregion
    }
}
