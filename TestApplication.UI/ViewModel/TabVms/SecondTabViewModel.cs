using System.Collections.ObjectModel;
using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using TestApplication.UI.Model;
using TestApplication.UI.View.Dialogs;
using TestApplication.UI.ViewModel.DialogVms;
using TestApplication.UI.ViewModel.GridRecordsVm;

namespace TestApplication.UI.ViewModel.TabVms
{
    public class SecondTabViewModel : ViewModelBase
    {
        #region Private fields

        private readonly SecondTabModel _model;

        private ObservableCollection<SimpleTabGridRecordVm> _gridDataSource;
        private SimpleTabGridRecordVm _gridSelectedItem;
        #endregion

        #region Properties

        /// <summary>
        /// Источник данных для грида
        /// </summary>
        public ObservableCollection<SimpleTabGridRecordVm> GridDataSource
        {
            get { return _gridDataSource ?? (_gridDataSource = new ObservableCollection<SimpleTabGridRecordVm>()); }
            set { Set(() => GridDataSource, ref _gridDataSource, value); }
        }

        /// <summary>
        /// Выбранный элемент грида
        /// </summary>
        public SimpleTabGridRecordVm SelectedRecordVm
        {
            get { return _gridSelectedItem; }
            set { Set(() => SelectedRecordVm, ref _gridSelectedItem, value); }
        }

        #endregion
        
        #region Constructors

        public SecondTabViewModel()
        {
            _model = new SecondTabModel();
            RefreshDataSource();
        }

        #endregion

        #region Commands

        public RelayCommand AddCommand => new RelayCommand(AddCommandHandler);

        public RelayCommand RemoveCommand => new RelayCommand(RemoveCommandHandler, RemoveCommandCanExecute);

        #endregion

        #region Private members

        private void AddCommandHandler()
        {
            var dialog = new AddRecordDialog();

            var dialogResult = dialog.ShowDialog();

            if (dialogResult.HasValue && dialogResult.Value)
            {
                var vm = dialog.DataContext as AddRecordDialogVm;

                if (_model.IsUniqueKey(vm.Id, vm.Name))
                {
                    _model.AddRecord(vm.Id, vm.Name, vm.Value);
                    RefreshDataSource();
                }
                else
                    MessageBox.Show("Данный ключ уже существует!", "Повторяющийся ключ", MessageBoxButton.OK, MessageBoxImage.Warning);

            }
        }

        private void RefreshDataSource()
        {
            GridDataSource.Clear();
            _gridSelectedItem = null;

            _model.Items.ForEach(GridDataSource.Add);
        }
        
        private void RemoveCommandHandler()
        {
            _model.RemoveRecord(SelectedRecordVm.Id, SelectedRecordVm.Name);
            RefreshDataSource();
        }

        private bool RemoveCommandCanExecute()
        {
            return SelectedRecordVm != null;
        }

        #endregion

    }
}
