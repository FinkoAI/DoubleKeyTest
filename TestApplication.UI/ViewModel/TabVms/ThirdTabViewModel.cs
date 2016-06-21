using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using TestApplication.UI.Model;
using TestApplication.UI.ViewModel.GridRecordsVm;

namespace TestApplication.UI.ViewModel.TabVms
{
    public class ThirdTabViewModel : ViewModelBase
    {
        #region Private fields

        private readonly ThirdTabModel _model;

        private ObservableCollection<UserTypeKeyGridRecordVm> _gridDataSource;
        private ObservableCollection<string> _searchResult;

        private long _identifierFilter;
        private int _sizeFilter;
        #endregion

        #region Constructors

        public ThirdTabViewModel()
        {
            _model = new ThirdTabModel();
            _model.GenerateRecords();
            RefreshDataSource();
        }

        #endregion

        #region Properties

        public ObservableCollection<UserTypeKeyGridRecordVm> GridDataSource
        {
            get { return _gridDataSource ?? (_gridDataSource = new ObservableCollection<UserTypeKeyGridRecordVm>()); }
            set { Set(() => GridDataSource, ref _gridDataSource, value); }
        }

        public ObservableCollection<string> SearchResult
        {
            get { return _searchResult ?? (_searchResult = new ObservableCollection<string>()); }
            set { Set(() => SearchResult, ref _searchResult, value); }
        }

        public long IdentifierFilter
        {
            get { return _identifierFilter; }
            set { Set(()=>IdentifierFilter, ref _identifierFilter, value); }
        }

        public int SizeFilter
        {
            get { return _sizeFilter; }
            set { Set(() => SizeFilter, ref _sizeFilter, value); }
        }

        #endregion

        #region Commands

        public RelayCommand GenerateRecordsCommand => new RelayCommand(GenerateRecordsHandler);

        public RelayCommand FilterRecordsCommand => new RelayCommand(FilterRecordsCommandHandler);

        #endregion

        #region Private methods

        private void RefreshDataSource()
        {
            GridDataSource.Clear();
            _model.Items.ForEach(GridDataSource.Add);
        }

        private void GenerateRecordsHandler()
        {
            _model.GenerateRecords();
            RefreshDataSource();
            SearchResult.Clear();
        }

        private void FilterRecordsCommandHandler()
        {
            SearchResult.Clear();
            var filtered = _model.FindById(IdentifierFilter, SizeFilter);
            filtered.ForEach(SearchResult.Add);
        }

        #endregion
    }
}
