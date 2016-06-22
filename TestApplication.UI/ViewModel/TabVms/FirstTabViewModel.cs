using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using TestApplication.UI.Model;
using TestApplication.UI.Model.TabModels;
using TestApplication.UI.ViewModel.GridRecordsVm;
using System.Collections.Generic;

namespace TestApplication.UI.ViewModel.TabVms
{
    /// <summary>
    /// ViewModel 
    /// </summary>
    public class FirstTabViewModel : ViewModelBase
    {
        #region Private fields
        private readonly FirstTabModel _model;

        private ObservableCollection<SimpleTabGridRecordVm> _gridDataSource;
        private ObservableCollection<string> _searchResult; 

        private int _idSearch;
        private string _nameSearch;
        private string _searchResultHeader;

        private FirstTabFilterTypes _filterType;
        #endregion

        #region Constructors

        public FirstTabViewModel()
        {
            _filterType = FirstTabFilterTypes.FilterByBoth;

            _model = new FirstTabModel();
            _model.InitilaizeData(1000000); //при установке больше миллиона записей вызывается OutOfMemory, чтобы обойти можно не держать объект в памяти
            GridDataSource = new ObservableCollection<SimpleTabGridRecordVm>(_model.Items);
            NameSearch = string.Empty;
            SearchResultHeader = "Результаты поиска...";
        }

        #endregion

        #region Commands

        public RelayCommand SearchCommand => new RelayCommand(SearchCommandHandler, SearchCommandCanExecute);

        public RelayCommand ClearCommand => new RelayCommand(ClearCommandHandler);

        #endregion

        #region Public members

        public ObservableCollection<SimpleTabGridRecordVm> GridDataSource
        {
            get { return _gridDataSource ?? (_gridDataSource = new ObservableCollection<SimpleTabGridRecordVm>()); }
            set { Set(() => GridDataSource, ref _gridDataSource, value); }
        }

        public ObservableCollection<string> SearchResult
        {
            get { return _searchResult ?? (_searchResult = new ObservableCollection<string>()); }
            set { Set(() => SearchResult, ref _searchResult, value); }
        }

        public int IdSearch
        {
            get { return _idSearch; }
            set { Set(() => IdSearch, ref _idSearch, value); }
        }

        public string NameSearch
        {
            get { return _nameSearch; }
            set
            {
                Set(() => NameSearch, ref _nameSearch, value);
            }
        }

        public string SearchResultHeader
        {
            get { return _searchResultHeader; }
            set { Set(() => SearchResultHeader, ref _searchResultHeader, value); }
        }

        public FirstTabFilterTypes FilterType
        {
            get { return _filterType; }
            set { Set(() => FilterType, ref _filterType, value); }
        }

        #endregion

        #region Private methods

        private void SearchCommandHandler()
        {
            SearchResult.Clear();
            var timer = new Stopwatch();
            timer.Reset();

            List<string> records;

            switch (FilterType)
            {
                case FirstTabFilterTypes.FilterById:
                    timer.Start();
                    records = _model.GetDataFilteredById(IdSearch);                    
                    timer.Stop();
                    records.ForEach(SearchResult.Add);
                    SearchResultHeader = $"Найдено {records.Count} записей";
                    Debug.Print("Заняло: {0} мс", timer.ElapsedMilliseconds);
                    break;
                case FirstTabFilterTypes.FilterByName:
                    timer.Start();
                    records = _model.GetDataFilteredByName(NameSearch);                    
                    timer.Stop();
                    records.ForEach(SearchResult.Add);
                    SearchResultHeader = $"Найдено {records.Count} записей";
                    Debug.Print("Заняло: {0} мс", timer.ElapsedMilliseconds);
                    break;
                case FirstTabFilterTypes.FilterByBoth:
                    timer.Start();
                    records = _model.GetDataFilteredByBoth(IdSearch, NameSearch);
                    timer.Stop();
                    records.ForEach(SearchResult.Add);
                    SearchResultHeader = $"Найдено {records.Count} записей";
                    Debug.Print("Заняло: {0} мс", timer.ElapsedMilliseconds);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private bool SearchCommandCanExecute()
        {
            return true;
        }

        private void ClearCommandHandler()
        {
            SearchResult.Clear();
            SearchResultHeader = "Результаты поиска...";
        }

        #endregion
    }
}
