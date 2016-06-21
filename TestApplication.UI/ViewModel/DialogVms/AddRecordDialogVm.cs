using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace TestApplication.UI.ViewModel.DialogVms
{
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
