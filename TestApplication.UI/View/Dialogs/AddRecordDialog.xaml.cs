using System.Windows;
using TestApplication.UI.ViewModel.DialogVms;

namespace TestApplication.UI.View.Dialogs
{
    /// <summary>
    /// Interaction logic for AddRecordDialog.xaml
    /// </summary>
    public partial class AddRecordDialog : Window
    {
        public AddRecordDialog()
        {
            InitializeComponent();
            DataContext = new AddRecordDialogVm();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
