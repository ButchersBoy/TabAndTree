using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MaterialDesignThemes.Wpf;

namespace MaterialTest.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}
        }
        private RelayCommand _openDialogCommand;

        /// <summary>
        /// Gets the OpenDialogCommand.
        /// </summary>
        public RelayCommand OpenDialogCommand
        {
            get
            {
                return _openDialogCommand
                    ?? (_openDialogCommand = new RelayCommand(async () =>
                    {
                        DialogOpenedEventHandler openedhandler = (sender, eventArgs) =>
                        {
                            System.Diagnostics.Debug.WriteLine(sender.ToString());
                            System.Diagnostics.Debug.WriteLine(sender.ToString());
                            System.Diagnostics.Debug.WriteLine(sender.ToString());
                            System.Diagnostics.Debug.WriteLine(sender.ToString());

                            _activeDialogSession = eventArgs.Session;
                        };

                        DialogClosingEventHandler closinghandler = (sender, e) =>
                        {
                            _activeDialogSession = null;
                        };

                        var theResultFromSessionClose = await DialogHost.Show(new Dialog(), openedhandler, closinghandler);
                        System.Diagnostics.Debug.WriteLine(theResultFromSessionClose);
                    }));
            }
        }

        private RelayCommand _closeDialogCommand;
        private DialogSession _activeDialogSession;

        /// <summary>
        public RelayCommand CloseDialogCommand
        /// Gets the CloseDialogCommand.
        /// </summary>
        {
            get
            {
                return _closeDialogCommand
                    ?? (_closeDialogCommand = new RelayCommand(
                    () =>
                    {
                        //i want to add the branch at here.

                        //if (false) return;

                        //CloseDialogCommand is a RoutedCommand.  Which means it has to be executed in XAML, for the DialogHost event to correctly detect it.
                        //So you have to provide a target in the second parameter...
                        // DialogHost.CloseDialogCommand.Execute(new object(), null);
                        //...however, you are in a view model, not XAML, so you can use the session:
                        var myResult = true;
                        _activeDialogSession?.Close(myResult);

                    }));
            }
        }
    }
}